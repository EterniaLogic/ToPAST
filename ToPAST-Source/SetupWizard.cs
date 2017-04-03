using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToP_Tools
{
	public partial class SetupWizard: Form
	{
		public SetupWizard()
		{
			InitializeComponent();
            textBox2.Text = Environment.CurrentDirectory + "\\resource\\";
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
		}
        public SetupWizard(ArrayList settings)
        {
            InitializeComponent();
            Settings = settings;
            exit = true;
            //textBox2.Text = Environment.CurrentDirectory + "\\resource\\";
            if (GetSetting("Proxy") == "0") radioButton1.Checked = true; else radioButton2.Checked = true;
            Proxy.Text = GetSetting("ProxyHost");
            Username.Text = GetSetting("ProxyUser");
            textBox1.Text = GetSetting("SQLHost");
            textBox3.Text = GetSetting("SQLUser");
            textBox4.Text = GetSetting("SQLPass");
            textBox5.Text = GetSetting("SQLAccountDB");
            textBox6.Text = GetSetting("SQLGameDB");
            textBox2.Text = GetSetting("Resources");
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            ST();
        }
        int step = 0;
        ArrayList Settings = new ArrayList();
        private void ST()
        {
            this.label1.Text = TMAIN.tr[285];
            this.label2.Text = TMAIN.tr[286];
            this.label20.Text = TMAIN.tr[287];
            this.label5.Text = TMAIN.tr[288];
            this.label4.Text = TMAIN.tr[289];
            this.label3.Text = TMAIN.tr[290];
            this.button1.Text = TMAIN.tr[291];
            this.button2.Text = TMAIN.tr[292];
            this.button3.Text = TMAIN.tr[293];
            this.label6.Text = TMAIN.tr[317];
            this.label7.Text = TMAIN.tr[105];
            this.label12.Text = TMAIN.tr[30];
            this.Proxy.Text = TMAIN.tr[297];
            this.textBox9.Text = TMAIN.tr[298];
            this.Username.Text = TMAIN.tr[299];
            this.label13.Text = TMAIN.tr[30];
            this.textBox6.Text = TMAIN.tr[301];
            this.textBox5.Text = TMAIN.tr[302];
            this.label11.Text = TMAIN.tr[73];
            this.label8.Text = TMAIN.tr[304];
            this.label9.Text = TMAIN.tr[305];
            this.radioButton2.Text = TMAIN.tr[306];
            this.radioButton1.Text = TMAIN.tr[307];
            this.label14.Text = TMAIN.tr[308];
            this.label15.Text = TMAIN.tr[309];
            this.label24.Text = TMAIN.tr[318];
            this.label19.Text = TMAIN.tr[319];
            this.label23.Text = TMAIN.tr[312];
            this.label17.Text = TMAIN.tr[313];
            this.label21.Text = TMAIN.tr[314];
            this.label22.Text = TMAIN.tr[315];
            this.Text = TMAIN.tr[316];
        }
        private string GetSetting(string setting)
        {
            string set = "null"; //Returns null if there is not setting like that.
            //Sort through settings...
            foreach (string e in Settings)
            {
                try
                {
                    string[] arr = e.Split('=');
                    if (arr[0].ToLower() == setting.ToLower())
                    {
                        set = arr[1];
                    }
                }
                catch { }
            }
            return set;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        bool exit = false;
        private void button3_Click(object sender, EventArgs e)
        {
            switch (step)
            {
                case 0:
                    {
                        Invalidate();
                        //Panel P2 = panel5;
                        //this.Controls.Add(P2);
                        //Main.Name = "pane1";
                        //P2.SendToBack();
                        //P2.BorderStyle = BorderStyle.FixedSingle;
                        //Point loc = P2.Location;
                        //P2.Location = Main.Location;
                        //Main.Location = loc;
                        //this.Controls.Remove(Main);
                        //P2.Name = "Main";
                        Main.Visible = false;
                        panel5.Visible = true;
                        button1.Enabled = true;
                        pictureBox5.Image = pictureBox1.Image;
                        pictureBox6.Image = pictureBox2.Image;
                        break;
                    }
                case 1:
                    {
                        panel5.Visible = false;
                        panel8.Visible = true;
                        button1.Enabled = true;
                        pictureBox6.Image = pictureBox1.Image;
                        pictureBox7.Image = pictureBox2.Image;
                        break;
                    }
                case 2:
                    {
                        panel8.Visible = false;
                        panel9.Visible = true;
                        pictureBox7.Image = pictureBox1.Image;
                        pictureBox8.Image = pictureBox2.Image;
                        button3.Text = "&Finish";
                        break;
                    }
                case 3:
                    {
                        //Save settings...
                        exit = true;
                        string prox = "0";
                        if (radioButton2.Checked) prox = "1";
                        string contents = @"Proxy="+prox+@"
ProxyHost=" + Proxy.Text+@"
ProxyUser=" + Username.Text + @"
ProxyPass //Deprecated, and not used. (Security purposes...)
SQLHost=" +textBox1.Text+@"
SQLUser=" + textBox3.Text + @"
SQLPass=" + textBox4.Text + @"
SQLAccountDB=" + textBox5.Text + @"
SQLGameDB=" + textBox6.Text + @"
Resources=" + textBox2.Text;
                        System.IO.File.WriteAllText(Environment.CurrentDirectory + "/settings.ini", contents);
                        Close();
                        break;
                    }

            }
            step++;
        }

        private void SetupWizard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit == false)
            {
                //try { Program.TMAIN1.Dispose(); Program.TMAIN1 = new TMAIN(); Program.TMAIN1.Show(); }
                //catch { }
                Application.Exit();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Point loc = panel6.Location;
                Point loc2 = panel7.Location;
                panel6.Location = loc2;
                panel7.Location = loc;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Point loc = panel6.Location;
                Point loc2 = panel7.Location;
                panel7.Location = loc;
                panel6.Location = loc2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (step)
            {
                case 1:
                    {
                        panel5.Visible = false;
                        Main.Visible = true;
                        button1.Enabled = false;
                        pictureBox5.Image = pictureBox2.Image;
                        pictureBox6.Image = pictureBox3.Image;
                        break;
                    }
                case 2:
                    {
                        panel8.Visible = false;
                        panel5.Visible = true;
                        pictureBox6.Image = pictureBox2.Image;
                        pictureBox7.Image = pictureBox3.Image;
                        break;
                    }
                case 3:
                    {
                        panel9.Visible = false;
                        panel8.Visible = true;
                        pictureBox7.Image = pictureBox2.Image;
                        pictureBox8.Image = pictureBox3.Image;
                        button3.Text = "&Next";
                        break;
                    }
                
            }
            step--;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = textBox2.Text;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = fbd.SelectedPath+"\\";
            }
        }
	}
}
