using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ToP_Tools
{
    public partial class confirmlanguage : Form
    {
        public confirmlanguage()
        {
            InitializeComponent();
            //gets the names of the languages... then confirms that the language files are there...
            try
            {
                string[] lines = File.ReadAllLines(Environment.CurrentDirectory + "/translate/names.langs");
                foreach (string line in lines)
                {
                    try
                    {
                        string[] l = line.Split(':');
                        if (File.Exists(Environment.CurrentDirectory + "/translate/" + l[0] + ".lang"))
                        {
                            listBox1.Items.Add(l[1]);
                            L2.Add(L2[0]);
                        }
                    }
                    catch { }
                }
            }
            catch { }

        }
        List<string> L2 = new List<string>();
    }
}
