using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            /*string L = "",r="textBox";
            for (int I = 0; I <= 64; I++)
            {
                L += r +""+ I.ToString()+",";
            }
            Clipboard.SetText(L);*/
            
            //tes();
            //48@113#
            string c = "btjgkb]gejda\\gafaem``b]f]id`\\b]f]isa\\hig]jdahiaf]jq``b]gjlh\\cegf]iddbbfhaih\\cfefgmh`\\c]hgej\\bj]f]kq\\f^cm]odc`^aqcejcad]mheh\\`^abaeh\\`^abatk\\eiibhld`\\b]f]id`\\b]f]isd\\fgfceqe\\b]f]id`\\b]f]id`kg]jgik\\ig]f]id`\\b]f]id`\\bll]mn`d^jn]id`\\b]f]id`\\b]flpdcafbbjqd`\\b]f]id`\\b]f]ish\\eaoieqa\\b]f]id`\\b]f]id`kk]hiqq\\b^abaeh\\`^abaeh\\`mbf]kpi`^cbaeh\\`^abaeh\\`^aqbjdbhkbbceh\\`^abaeh\\`^abatib\\eaojeqh\\b]f]id`\\b]f]id`kcdbcpn\\ii]f]id`\\b]f]id`\\blgeejgg^ji]id`\\b]f]id`\\b]fljm\\bijbjnd`\\b]f]id`\\b]f]isaf^doiqda\\b]f]id`\\b]f]llgd^aqbpdaadcbbej``babcih``^abaeh\\`^abbekf\\b]f]id`\\b]f]id`\\blgiek`ie]g]id`\\b]f]id`\\b]fljq\\cben]kd`\\b]f]id`\\b]f]isb`^dffidb\\b]f]id`\\b]f]id`kdbbdima\\d]f]id`\\b]f]id`\\blhcek`ed]h]id`\\b]f]id`\\b]flkk\\cbfi]kd`\\b]f]id`\\b]f]isbd^dffnda\\b]f]id`\\b]f]id`kdfbdimd\\c]f]id`\\b]f]id`\\blhgejdic]g]id`\\b]f]id`\\b]flpnfbfffh                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ";
            string new1="";
            Decrypt(ref new1,ref c);
            this.Text = "done";
            label1.Text = new1;
            Clipboard.SetText(new1);
             
        }

        public static string g_key = "19800216"; 
	    public static void Decrypt(ref string buf ,ref string enc) 
	    {
            StringBuilder SB = new StringBuilder();
            for (int I = 0; I <= enc.Length; I++)
            {
                try
                {
                    SB.Append(Convert.ToChar(Convert.ToInt32(enc[I]) - Convert.ToInt32(g_key[I % 8])));
                    //System.Threading.Thread.Sleep(15);
                }
                catch { }
            }
            buf = SB.ToString();
	    } 
	    public static void Encrypt(ref string buf,ref string pwd) 
	    {
            StringBuilder SB = new StringBuilder();
            for (int I = 0; I <= pwd.Length; I++)
            {
                try
                {
                    SB.Append(Convert.ToChar(Convert.ToInt32(g_key[I % 8]) + Convert.ToInt32(pwd[I])));
                    //System.Threading.Thread.Sleep(15);
                }
                catch { }
            }
            buf = SB.ToString();
	    } 

        private void tes1()
        {
            StringBuilder SB = new StringBuilder();
            string[] LO = System.IO.File.ReadAllLines("D:\\Servers\\reflector\\ToP_Tools\\help\\help.Designer.cs");
            label1.Text = "0";
            foreach (string I in LO)
            {
                if (I.Contains(".Text = "))
                {
                    SB.AppendLine(I.Replace("    ",""));
                }
                label1.Text = (Convert.ToInt32(label1.Text)+1).ToString();
            }
            Clipboard.SetText(SB.ToString());
        }
        private void tes()
        {
            string[] LO = System.IO.File.ReadAllLines("D:\\Servers\\reflector\\ToP_Tools\\ToP_Tools\\new 5.cs");
            string[] LI = System.IO.File.ReadAllLines("C:\\ToPAST\\translate\\en.lang");
            StringBuilder SB = new StringBuilder();
            //int P=0;
            foreach (string I in LO)
            {
                bool changed = false;
                int T = 0;
                foreach (string u in LI)
                {
                    if (I.Contains(".Text = \"" + u + "\""))
                    {
                        changed = true;
                        SB.AppendLine(I.Replace(".Text = \"" + u + "\"", ".Text = tr[" + T + "]"));
                        break;
                    }
                    T++;
                }
                if (!changed) SB.AppendLine(I);
            }
            Clipboard.SetText(SB.ToString());
        }
        private void tes2()
        {
            //Wipes the lines that are reused.
            StringBuilder L = new StringBuilder();
            string[] LI = System.IO.File.ReadAllLines("C:\\ToPAST\\translate\\en.lang");
            foreach (string I in LI)
            {
                //
                bool none=true;
                try
                {
                    foreach (string L1 in L.ToString().Split('\n'))
                    {
                        if (L1 == I) { none = false; MessageBox.Show(I); }
                    }
                }
                catch (Exception e) { MessageBox.Show(e.Message); }
                if (I == "" || I == " ") none = true;
                if (none) L.AppendLine(I);
            }
            
            Clipboard.SetText(L.ToString());
        }
    }
}
