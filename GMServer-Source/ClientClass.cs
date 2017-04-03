using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;

namespace GMServ
{
    public enum EncodingType { none, CSEnc, CSEncCORE, B64, DEC };
    class ClientClass
    {
        public string name = "";
        public bool LoggedIn = false;
        public string Key = ""; //Security Key
        public string Permission = "X"; //Security Permissions...
        public TcpClient Client;
        public NetworkStream ns;
        public Thread ClientService;
        public ClientClass() { Key = d(8751) + d(28930) + d(14098) + d(5101) + d(51932) + d(39932); }
        System.Text.Encoding E = System.Text.Encoding.Unicode;
        public bool SendPacket(string data, EncodingType ET)
        {
            bool ret = false;
            //
            try
            {
                byte[] buffer = new byte[data.Length];
                //Console.BackgroundColor = ConsoleColor.Gray;
                //Console.WriteLine(data);
                //Console.BackgroundColor = ConsoleColor.Black;
                Client.Client.SendBufferSize = buffer.Length;
                //Encode(data, out data, ET);
                buffer = E.GetBytes(data);
                //ns.Write(buffer, 0, data.Length);
                Base64Encoder B64 = new Base64Encoder(buffer);
                buffer = E.GetBytes(B64.GetEncoded());
                Client.Client.SendBufferSize = buffer.Length;
                Client.Client.Send(buffer);
                ret = true;
            }
            catch { }
            return ret;
        }

        public void Encode(string inz, out string ins, EncodingType et)
        {
            string N = inz;
            //ACRYPT32Lib.addCRYPT AC = new ACRYPT32Lib.addCRYPT();
            //AC.AC.CipherMode = ACRYPT32Lib._EnumModes.ECB;
            //AC.CipherAlgorithm = ACRYPT32Lib._EnumAlgorithms.SKIPJACK;
            string pass = "";
            if (et == EncodingType.CSEncCORE) pass = Program.CommonPass;
            if (et == EncodingType.CSEnc) pass = Key;
            int t = N.Length;
            //bool r = AC.Encrypt(ref N, ref t, pass, pass.Length,"",0);
            //MessageBox.Show(r.ToString());
            ins = N;
        }
        public bool Decode(string inz, out string ins, EncodingType et)
        {
            bool i = false;
            string N = inz;
            //ACRYPT32Lib.addCRYPT AC = new ACRYPT32Lib.addCRYPT();
            string pass = "";
            if (et == EncodingType.CSEncCORE) pass = Program.CommonPass;
            if (et == EncodingType.CSEnc) pass = Key;
            int t = N.Length;
            //i= AC.Decrypt(ref N, ref t, pass, pass.Length,"",0);
            ins = N;
            return i;
        }
        private string d(int num)
        {
            return Convert.ToChar(num) + "";
        }

        public bool CheckPermissions(ref string SQLENTRY,bool Query,bool ISSQL) //on return false, this packet is not sent, and a sub packet is sent.
        //Sub packet: "You do not have enough permissions.
        {
            bool ret = true;
            if (ISSQL)
                if (Query)
                {
                    //check the permissions for this SQL query. If the user is GM, then we want to filter out the other GM's.

                    //check to see what DB is being executed...
                    //[accdb, or gamedb]

                    //This is an elimination game based on permissions...

                    if (Permission.StartsWith("X-") || Permission == "X")
                    {
                        ret = false;
                    }
                    else
                    {
                        string[] ti = SQLENTRY.Split(' ');
                        string h = ti[1];
                        if ((ti[0].ToLower() == "insert" || ti[0].ToLower() == "update" || ti[0].ToLower() == "delete") && Permission.Contains("XR"))
                            ret = false;
                        else
                        {
                            bool isAccDB = false;
                            if (h.StartsWith("[" + Program.GetSetting("SQLAccDB") + "]")) isAccDB = true;
                            if (h.StartsWith("[" + Program.GetSetting("SQLGameDB") + "]")) isAccDB = false;
                            if (isAccDB && (ti[0].ToLower() == "insert" || ti[0].ToLower() == "update" || ti[0].ToLower() == "delete") && Permission.Contains("XA")) ret = false;
                            if (!isAccDB && (ti[0].ToLower() == "insert" || ti[0].ToLower() == "update" || ti[0].ToLower() == "delete") && Permission.Contains("XG")) ret = false;

                            //Edit the SQLENTRY, so the user only sees what we want him/her to see.
                            if(SQLENTRY.StartsWith("SELECT ") && ret) //Filter select commands for the specific character ID
                            {
                                string end = " WHERE ";
                                if(SQLENTRY.Contains("WHERE")) //We need to end with " AND [GM] = 
                                {
                                    end = " AND ";
                                }
                                string qLoc = h.Split('.')[h.Split('.').Length-1];;
                                string dbLoc = h.Split('.')[0];
                                qLoc = qLoc.Replace("[","").Replace("]","");
                                dbLoc =dbLoc.Replace("[","").Replace("]","");
                                //We need to get the IDs for the GM chars...
                                Program.Com.CommandText = "SELECT * FROM ["+Program.GetSetting("SQLGameDB")+"].[dbo].[account] WHERE [GM] = 99";
                                System.Data.SqlClient.SqlDataReader DR = Program.Com.ExecuteReader();
                                List<int> GMs = new List<int>();
                                int selfID = 0;
                                while (DR.Read())
                                {
                                    if (DR.GetString(1) == name) selfID = DR.GetInt32(0);
                                    else GMs.Add(DR.GetInt32(0));
                                }
                                DR.Close();

                                //How this will work...
                                //-Using the gotten GMIDs, we can filter them out, or filter others out based on the DBtype.
                                string totalend = ""; //we can filter it all up with this...
                                if (Permission.StartsWith("GM-") || Permission == "GM")
                                {
                                    if (dbLoc == Program.GetSetting("SQLAccDB"))
                                    {
                                        if (qLoc == "account_login") totalend = end + C(GMs.ToArray(), "[id] NOT {X} AND", " AND");
                                    }
                                    if (dbLoc == Program.GetSetting("SQLGameDB"))
                                    {
                                        if (qLoc == "account") totalend = end + C(GMs.ToArray(), "[act_id] NOT {X} AND", " AND");
                                        if (qLoc == "character") totalend = end + C(GMs.ToArray(), "[act_id] NOT {X} AND", " AND");
                                    }
                                }
                            }
                        }
                    }
                }
                else //Not a query, and is return data...
                {
                    //Get DB name...
                    //Query starts w/ 
                }
            else
            {
                //filter this, as it IS a pure packet.
                string q = SQLENTRY.ToLower();
                if ((q.StartsWith("file") || q.StartsWith("dirs")) && !(Permission.Contains("GA") || Permission.Contains("DEV")) || Permission.Contains("SCRIPTDEV")) //cannot have scriptdev...
                    ret = false; //This user is not allowed to edit, or even view the server files.
                if ((q.StartsWith("file /resource/script/") || q.StartsWith("dirs")) && !(Permission.Contains("GA") || Permission.Contains("DEV")))
                    ret = false; //This user is not allowed to edit, or even view the server files.
                if (q.StartsWith("chat ") && Permission.Contains("CB"))
                    ret = false;

                //View logs, delete log, reverse log
                if ((q.StartsWith("vlogs ") || q.StartsWith("dlog") || q.StartsWith("rlog")) && !(Permission.Contains("GA") || Permission.Contains("GMA")))
                    ret = false;
            }
            //Console.WriteLine(ret.ToString());
            //Console.WriteLine(SQLENTRY);
            return ret;
            //return true;
        }
        private string C(int[] list, string phrasex, string endcut)
        {
            string ret = "";
            foreach (int a in list)
            {
                ret += phrasex.Replace("{X}", Convert.ToString(a));
            }
            ret = ret.Remove(ret.Length-endcut.Length,endcut.Length);
            return ret;
        }
        public void GetPermissions(string uname,bool isGameGM)
        {
                //name
                Permission = "X";
                if (System.IO.File.Exists(Environment.CurrentDirectory + "/Users.conf"))
                {
                    string[] dat = System.IO.File.ReadAllLines(Environment.CurrentDirectory + "/Users.conf");
                    bool gotNOdata = true;
                    foreach (string a in dat)
                    {
                        if (a.StartsWith(uname+":"))
                        {
                            gotNOdata = false;

                            Permission = a.Split(':')[1];
                        }
                    }
                    //Console.WriteLine(gotNOdata.ToString());
                    if (gotNOdata && isGameGM) Permission = "GM";
                }
                else { if (isGameGM) Permission = "GM"; }
            //}
        }
        public class Base64Encoder
        {
            byte[] source;
            int length, length2;
            int blockCount;
            int paddingCount;
            public Base64Encoder(byte[] input)
            {
                source = input;
                length = input.Length;
                if ((length % 3) == 0)
                {
                    paddingCount = 0;
                    blockCount = length / 3;
                }
                else
                {
                    paddingCount = 3 - (length % 3);//need to add padding
                    blockCount = (length + paddingCount) / 3;
                }
                length2 = length + paddingCount;//or blockCount *3
            }

            public char[] GetEncoded()
            {
                byte[] source2;
                source2 = new byte[length2];
                //copy data over insert padding
                for (int x = 0; x < length2; x++)
                {
                    if (x < length)
                    {
                        source2[x] = source[x];
                    }
                    else
                    {
                        source2[x] = 0;
                    }
                }

                byte b1, b2, b3;
                byte temp, temp1, temp2, temp3, temp4;
                byte[] buffer = new byte[blockCount * 4];
                char[] result = new char[blockCount * 4];
                for (int x = 0; x < blockCount; x++)
                {
                    b1 = source2[x * 3];
                    b2 = source2[x * 3 + 1];
                    b3 = source2[x * 3 + 2];

                    temp1 = (byte)((b1 & 252) >> 2);//first

                    temp = (byte)((b1 & 3) << 4);
                    temp2 = (byte)((b2 & 240) >> 4);
                    temp2 += temp; //second

                    temp = (byte)((b2 & 15) << 2);
                    temp3 = (byte)((b3 & 192) >> 6);
                    temp3 += temp; //third

                    temp4 = (byte)(b3 & 63); //fourth

                    buffer[x * 4] = temp1;
                    buffer[x * 4 + 1] = temp2;
                    buffer[x * 4 + 2] = temp3;
                    buffer[x * 4 + 3] = temp4;

                }

                for (int x = 0; x < blockCount * 4; x++)
                {
                    result[x] = sixbit2char(buffer[x]);
                }

                //covert last "A"s to "=", based on paddingCount
                switch (paddingCount)
                {
                    case 0: break;
                    case 1: result[blockCount * 4 - 1] = '='; break;
                    case 2: result[blockCount * 4 - 1] = '=';
                        result[blockCount * 4 - 2] = '=';
                        break;
                    default: break;
                }
                return result;
            }

            private char sixbit2char(byte b)
            {
                char[] lookupTable = new char[64]
					{	'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
						'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
						'0','1','2','3','4','5','6','7','8','9','+','/'};

                if ((b >= 0) && (b <= 63))
                {
                    return lookupTable[(int)b];
                }
                else
                {
                    //should not happen;
                    return ' ';
                }
            }
        }
        public class Base64Decoder
        {
            char[] source;
            int length, length2, length3;
            int blockCount;
            int paddingCount;
            public Base64Decoder(char[] input)
            {
                int temp = 0;
                source = input;
                length = input.Length;

                //find how many padding are there
                for (int x = 0; x < 2; x++)
                {
                    if (input[length - x - 1] == '=')
                        temp++;
                }
                paddingCount = temp;
                //calculate the blockCount;
                //assuming all whitespace and carriage returns/newline were removed.
                blockCount = length / 4;
                length2 = blockCount * 3;
            }

            public byte[] GetDecoded()
            {
                byte[] buffer = new byte[length];//first conversion result
                byte[] buffer2 = new byte[length2];//decoded array with padding

                for (int x = 0; x < length; x++)
                {
                    buffer[x] = char2sixbit(source[x]);
                }

                byte b, b1, b2, b3;
                byte temp1, temp2, temp3, temp4;

                for (int x = 0; x < blockCount; x++)
                {
                    temp1 = buffer[x * 4];
                    temp2 = buffer[x * 4 + 1];
                    temp3 = buffer[x * 4 + 2];
                    temp4 = buffer[x * 4 + 3];

                    b = (byte)(temp1 << 2);
                    b1 = (byte)((temp2 & 48) >> 4);
                    b1 += b;

                    b = (byte)((temp2 & 15) << 4);
                    b2 = (byte)((temp3 & 60) >> 2);
                    b2 += b;

                    b = (byte)((temp3 & 3) << 6);
                    b3 = temp4;
                    b3 += b;

                    buffer2[x * 3] = b1;
                    buffer2[x * 3 + 1] = b2;
                    buffer2[x * 3 + 2] = b3;
                }
                //remove paddings
                length3 = length2 - paddingCount;
                byte[] result = new byte[length3];

                for (int x = 0; x < length3; x++)
                {
                    result[x] = buffer2[x];
                }

                return result;
            }

            private byte char2sixbit(char c)
            {
                char[] lookupTable = new char[64]
					{	'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
						'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
						'0','1','2','3','4','5','6','7','8','9','+','/'};
                if (c == '=')
                    return 0;
                else
                {
                    for (int x = 0; x < 64; x++)
                    {
                        if (lookupTable[x] == c)
                            return (byte)x;
                    }
                    //should not reach here
                    return 0;
                }

            }

        }
    }
}
