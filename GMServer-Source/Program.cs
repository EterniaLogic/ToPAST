using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography;

namespace GMServ
{
    class Program
    {

        public static string Ver = "1.6a";
        static void Main(string[] args)
        {
            //Start up the system...
            Console.Title = "ToP GM Server [DEBUG] (Ver: "+Ver+")";
            C1();
            WW("ToP GM Server (Ver: "+Ver+")");
            C1e();
            NL();
            //Console.WriteLine("WWWWWWWWWWWWWWEEEEEEEEEEEEE!");

            //Settings
            WS("Loading Settings...", "[Loaded]", ConsoleColor.Yellow);
            if (File.Exists(Environment.CurrentDirectory + "/config.ini"))
            {
                string[] er = File.ReadAllLines(Environment.CurrentDirectory + "/config.ini");
                Settings = er;
                WS1(ConsoleColor.Green);

                //MySql Connection
                WS("Sql Connection...", "[Started]", ConsoleColor.Magenta);
                //string connectionString = "server=" + GetSetting("SQLHost") + ";uid=" + GetSetting("SQLUser") + ";pwd=" + GetSetting("SQLPass") + ";";
                string connectionString = "";
                if (GetSetting("SQLVersion") == "2000")
                    connectionString = "Data Source=" + GetSetting("SQLHost") + ";Initial Catalog="+GetSetting("SQLAccDB")+";User Id=" + GetSetting("SQLUser") + ";Password=" +  GetSetting("SQLPass") + ";";
                else
                    connectionString = "server=" + GetSetting("SQLHost") + ";uid=" + GetSetting("SQLUser") + ";pwd=" + GetSetting("SQLPass") + ";";
                //Console.WriteLine(connectionString);
                try
                {
                    //Console.WriteLine();
                    //Console.WriteLine(connectionString);
                    Con = new System.Data.SqlClient.SqlConnection(connectionString);
                    Con.Open();
                    Com = new System.Data.SqlClient.SqlCommand("", Con);
                    WS1(ConsoleColor.Green);

                    //SQL Test
                    WS("SQL Test...", "[Approved]", ConsoleColor.Cyan);
                    try
                    {
                        Com.CommandText = "SELECT * FROM [" + GetSetting("SQLAccDB") + "].[dbo].[account_login]";
                        Com.ExecuteNonQuery();
                        WS1(ConsoleColor.Green);
                    }
                    catch (Exception e) { WS2("[Fail!]", ConsoleColor.Red); Console.WriteLine(e.Message); }
                    

                    //Server Listener
                    WS("Client Listener (Port " + GetSetting("port") + ")...", "[Started]", ConsoleColor.Cyan);
                    ///IPAddress UO = IPAddress.Parse(GetSetting("ListenIP"));
                    Listener = new TcpListener(Convert.ToInt32(GetSetting("port")));
                    Listener.Start();
                    WS1(ConsoleColor.Green);

                    //Listen for connections with this...
                    WS("Client Thread...", "[Started]", ConsoleColor.Cyan);
                    Thread LThread = new Thread(new ThreadStart(LFunc));
                    LThread.Start();
                    WS1(ConsoleColor.Green);

                    //
                    pass = d(8751) + d(28930) + d(14098) + d(5101) + d(51932) + d(39932);
                    while (true) { Thread.Sleep(wait); }
                }
                catch (Exception e) { WS2("[Error, Unable to connect to SQL Server]", ConsoleColor.Red); Console.WriteLine(e.Message); }
                

                
            }
            else WS2("[Error, config.ini not found]", ConsoleColor.Red);

            
        }

        #region VARS
        static string ver = "0.05";
        static int wait = 999999999;
        private static Thread CLThread;
        public static TcpListener Listener;
        public static string CommonPass = Convert.ToChar(8245) + "*" + Environment.NewLine + "m0n1337" + Convert.ToChar(48315); //This is the Uber-common.
        public static string[] Settings;
        public static System.Data.SqlClient.SqlConnection Con;
        public static System.Data.SqlClient.SqlCommand Com;
        public static System.Data.SqlClient.SqlDataReader D;
        public static List<ClientClass> Clients = new List<ClientClass>();
        private static string pass = "";
        #endregion

        #region Colors & Styles
        static string uo = "", ui = "";
        static void WS(string message, string endmessage, ConsoleColor Cr) { uo = message; ui = endmessage; Console.ForegroundColor = Cr; Console.Write(message); }
        static void WS1(ConsoleColor Cr) { Console.ForegroundColor = Cr; WSpace(80 - uo.Length - 5 - ui.Length); Console.WriteLine(ui); }
        static void WS2(string msg, ConsoleColor Cr) { Console.ForegroundColor = Cr; WSpace(80 - uo.Length - 5 - msg.Length); Console.WriteLine(msg); }
        static void NL() { Console.WriteLine(""); }
        static void WSpace(int num)
        {
            //Writes down the space onto the console.
            for (int I = 0; I < num; I++)
            {
                Console.Write(" ");
            }
        }
        static void C1() //Title Color 
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        static void C1e() //Title Color (End)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void WW(string ins) //Write with space
        {
            //Console is 82 accross...
            Console.Write(ins);
            int len = 80 - ins.Length;
            string L = "";
            for (int I = 0; I < len; I++)
            {
                L += " ";
            }
            Console.WriteLine(L);
        }
        #endregion
        #region Settings and general
        public static string GetSetting(string name)
        {
            string ret = "";
            foreach (string a in Settings)
            {
                string a1 = a;
                if (a1.Contains("\t")) a1 = a.Split('\t')[0]; //Remove the comments...
                if (a1.Contains("="))
                {
                    string[] r = a1.Split('=');
                    if (r[0].ToLower() == name.ToLower())
                        ret = r[1];
                }
            }
            return ret;
        }
        #endregion
        

        static void LFunc()
        {
            //Stuffs :)
            while (true)
            {
                Thread.Sleep(10);
                TcpClient R = Listener.AcceptTcpClient(); // This has it's own built-in wait system. It's Dynamic :)
                //Listener.Server.
                //Console.WriteLine(R.Client.RemoteEndPoint.ToString());
                ClientClass a = new ClientClass();
                a.Client = R;
                a.name = "anon";//This is anonymous for now.
                a.ns = new NetworkStream(R.Client);
                //a.MkKey(); // Right when the client joins, it is sent it's own brand new key :D
                a.ClientService = new Thread(new ThreadStart(ClientService));
                CC = a;
                a.ClientService.Start();
            }
        }
        #region Logging
        private static void LG(string type, string data)
        {
            //This makes/adds to a log file...
            if ((!Directory.Exists(Environment.CurrentDirectory + "/log"))) { Directory.CreateDirectory(Environment.CurrentDirectory + "/log"); }
            if ((!Directory.Exists(Environment.CurrentDirectory + "/log/" + type))) { Directory.CreateDirectory(Environment.CurrentDirectory + "/log/" + type); }

            appendtofile(Environment.CurrentDirectory + "/log/" + type + "/" +DateTime.Now.Month+"-"+DateTime.Now.Day+".log",data);
        }
        private static void appendtofile(string loc,string ins)
        {
            List<string> op = new List<string>();
            if(File.Exists(loc)) op.AddRange(File.ReadAllLines(loc));
            op.Add(ins);
            File.WriteAllLines(loc,op.ToArray());
        }
        #endregion
        #region Client Service
        static ClientClass CC;
        static System.Text.Encoding E = System.Text.Encoding.Unicode;
        public static void ClientService()
        {
            //
            try
            {
                ClientClass C = CC;
                NetworkStream ns = C.Client.GetStream();
                bool LoggedIn = false;
                //StreamReader sr = new StreamReader(
                while (true)
                {
                    Thread.Sleep(5);
                    //:D
                    //Console.Write(400);

                    if (C.Client.Available >= 3)
                    {
                        byte[] buffer = new byte[C.Client.Available];
                        //ns.Read(buffer,0,buffer.Length);
                        C.Client.Client.Receive(buffer);
                        Base64Decoder B64 = new Base64Decoder(E.GetChars(buffer));
                        buffer = B64.GetDecoded();
                        string data = E.GetString(buffer);

                        //Console.WriteLine(data);
                        bool o = C.LoggedIn;
                        if (C.Decode(data, out data, EncodingType.CSEnc))
                        {


                        }
                        else
                        {
                            //Limited options for the user to have...
                            string[] la = new string[1];
                            if (data.Contains("|"))
                            {
                                la = data.Replace("||", Convert.ToChar(2).ToString()).Split('|');
                                for (int I = 0; I < la.Length; I++) { la[I] = la[I].Replace(Convert.ToChar(2).ToString(), "|"); }
                            }
                            else { la[0] = data; }
                            if (o)
                            {
                                //Full capability...
                                if (data.StartsWith("cht|") && !(C.Permission.Contains("CB")))
                                {
                                    //Send chat to the other clients...}
                                    foreach (ClientClass a in Clients)
                                    {
                                        a.SendPacket("cht|("+DateTime.Now.Hour+DateTime.Now.Minute+") "+C.name+"["+C.Permission+"]: "+la[1], EncodingType.CSEnc);
                                    }
                                }
                                else if (data.StartsWith("file|") && (C.Permission.Contains("DEV")))
                                {
                                    //since we have perm, lets continue...
                                    if (data.StartsWith("file|w|")) {  } //Write the file
                                }
                                else if (data.StartsWith("sqlq|"))
                                {
                                    //sql query + return
                                    string[] sp = data.Split('|');
                                    string CRC = sp[1];
                                    string dar = "";
                                    string y = sp[2];
                                    if (C.CheckPermissions(ref y, true, true))
                                    {
                                        //Console.WriteLine("TEST!");
                                        try
                                        {
                                            Com.CommandText = y;
                                            System.Data.SqlClient.SqlDataReader mcm = Com.ExecuteReader();
                                            while (mcm.Read())
                                            {
                                                string ao = "";
                                                for (int I = 0; I < mcm.FieldCount; I++)
                                                {
                                                    string d = Convert.ToChar(2) + "";
                                                    if (I == mcm.FieldCount - 1) d = "";
                                                    if (mcm.IsDBNull(I))
                                                    { ao += d; }
                                                    else
                                                        ao += Convert.ToString(mcm.GetValue(I)) + d;
                                                }
                                                dar += ao + Convert.ToChar(1);
                                            }
                                            mcm.Close();
                                        }
                                        catch (Exception e) { Console.WriteLine(e.Message); }
                                        try
                                        {
                                            dar = dar.Remove(dar.Length - 1, 1);
                                        }
                                        catch { }
                                        //Console.WriteLine(dar);
                                        C.Client.SendBufferSize = ("sqlq|" + CRC + "|" + dar).Length;
                                        C.SendPacket("sqlq|" + CRC + "|" + dar, EncodingType.CSEnc);
                                    }
                                    else { C.SendPacket("sqlq|" + CRC + "|", EncodingType.CSEnc); C.SendPacket("noper", EncodingType.CSEnc); }
                                }
                                else if (data.StartsWith("sqlc|"))
                                {
                                    //Sql query
                                    string[] sp = data.Split('|');
                                    string y1 = sp[1];
                                    if (C.CheckPermissions(ref sp[1], true, true))
                                    {
                                        //Com.CommandText = y1;
                                        //Com.ExecuteNonQuery();
                                    }
                                    else C.SendPacket("noper", EncodingType.CSEnc);
                                    Com.CommandText = y1;
                                    Com.ExecuteNonQuery();
                                }
                                else if (data.StartsWith("logout|")) //separators...|
                                {
                                    C.name = "anon";
                                    C.LoggedIn = false;
                                    LoggedIn = false;
                                }
                                else if (data.StartsWith("DBNames|")) //Client is asking for the set DB names...
                                {
                                    C.SendPacket("DBNames|" + GetSetting("SQLAccDB") + "|" + GetSetting("SQLGameDB"), EncodingType.CSEnc);
                                }
                                else
                                {
                                    if (C.CheckPermissions(ref data, false, false))
                                    {

                                    }
                                    else
                                    {
                                        C.SendPacket("noper", EncodingType.CSEnc);
                                    }
                                }
                            }
                            if (data.StartsWith("login|")) //separators...|
                            {
                                try
                                {
                                    string[] l = data.Split('|');
                                    Com.CommandText = "SELECT * FROM [" + GetSetting("SQLAccDB") + "].[dbo].[account_login] WHERE [name] = '" + l[1] + "'";
                                    System.Data.SqlClient.SqlDataReader dr = Com.ExecuteReader();
                                    bool UserPassed = false, ISGM = false;
                                    if (dr.Read())
                                    {
                                        if (dr.GetString(2) == l[2])
                                        {
                                            //Password has passed also.
                                            UserPassed = true;
                                        }
                                    }
                                    dr.Close();
                                    Com.CommandText = "SELECT * FROM [" + GetSetting("SQLGameDB") + "].[dbo].[account] WHERE [act_name] = '" + l[1] + "'";
                                    dr = Com.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        if (Convert.ToString(dr.GetValue(2)) == "99") ISGM = true;
                                    }
                                    dr.Close();
                                    C.GetPermissions(l[1],ISGM);
                                    //Console.ForegroundColor = ConsoleColor.Red;
                                    //Console.WriteLine(C.Permission);
                                    if (UserPassed && !(C.Permission.StartsWith("X"))) //People that still have "X" will not pass!!!
                                    {
                                        C.SendPacket("login|true", EncodingType.CSEnc);
                                        C.LoggedIn = true;
                                        LoggedIn = true; //this doesn't work? wtf..lol..?
                                        C.name = l[1];
                                        Console.WriteLine(C.name + " Logged in. IP: " + C.Client.Client.RemoteEndPoint.ToString() + " Perm: " + C.Permission);
                                        LG("Logged_In", DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + " - User[" + C.name + "] Logs in. IP: " + C.Client.Client.RemoteEndPoint.ToString());
                                    }
                                    else
                                    {
                                        C.SendPacket("login|false", EncodingType.CSEnc);
                                        Console.WriteLine(C.name + " Failed to log in with '" + l[1] + "' as a username. IP: " + C.Client.Client.RemoteEndPoint.ToString());
                                        LG("Logged_Fail", DateTime.Now.Date + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + " - User[" + l[1] + "] Unable to log in. IP: " + C.Client.Client.RemoteEndPoint.ToString());
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }
        #endregion
        
        private static string d(int num)
        {
            return Convert.ToChar(num) + "";
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
