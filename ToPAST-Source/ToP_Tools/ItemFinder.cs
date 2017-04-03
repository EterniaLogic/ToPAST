namespace ToP_Tools
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;
    using System.Threading;


    public class ItemFinder : Form
    {
        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
        private IContainer components;
        private CustomImage customImage4;
        private string ItemDemi = "";
        public int ItemID=0;
        private string ItemType = "";
        private Label label1;
        private Label label2;
        private Label label40;
        private ListBox listBox1;
        private ListBox listBox2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private TextBox textBox1;
        private TextBox textBox10;

        public ItemFinder()
        {
            this.InitializeComponent();
            for (int i = 0; i < TMAIN.ret.Count; i++)
            {
                Thread.Sleep(10);
                string[] strArray = (string[]) TMAIN.ret[i];
                string str = strArray[0x18];
                string str2 = "-(Lvl: " + str + ")";
                if (str == "0")
                {
                    str2 = "";
                }
                this.listBox1.Items.Add(((string[]) TMAIN.ret[i])[0] + "-" + ((string[]) TMAIN.ret[i])[1] + str2);
            }
            this.button1.Enabled = true;
            this.listBox2.Visible = true;
            this.listBox1.Visible = false;
            //this.customImage4.Paint += new PaintEventHandler(this.Paint1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listBox2.Items.Clear();
            this.Search();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ItemID = this.R(this.textBox1.Text);
            TMAIN.yui = this.ItemID.ToString();
            this.DialogResult = DialogResult.OK;
            //base.Close();
            base.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.button1.Enabled = true;
                this.listBox2.Visible = true;
                this.listBox1.Visible = false;
                this.listBox2.Items.Clear();
            }
            else
            {
                this.button1.Enabled = false;
                this.listBox2.Visible = false;
                this.listBox1.Visible = true;
                this.listBox2.Items.Clear();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private string GetImage(string ins)
        {
            string str = Environment.CurrentDirectory + "/Icons/noexist.png";
            ins = ins.Replace("{CURRENT}", Environment.CurrentDirectory);
            for (int i = 0; i < TMAIN.ret.Count; i++)
            {
                string[] strArray = (string[]) TMAIN.ret[i];
                if ((strArray[0] == ins) && File.Exists(Environment.CurrentDirectory + "/Icons/" + strArray[2] + ".jpg"))
                {
                    str = Environment.CurrentDirectory + "/Icons/" + strArray[2] + ".jpg";
                }
                if ((strArray[0] == ins) && File.Exists(Environment.CurrentDirectory + "/Icons/" + strArray[2] + ".gif"))
                {
                    str = Environment.CurrentDirectory + "/Icons/" + strArray[2] + ".gif";
                }
                if ((strArray[0] == ins) && File.Exists(Environment.CurrentDirectory + "/Icons/" + strArray[2] + ".png"))
                {
                    str = Environment.CurrentDirectory + "/Icons/" + strArray[2] + ".png";
                }
            }
            return str;
        }

        private void InitializeComponent()
        {
            this.label40 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.customImage4 = new ToP_Tools.ItemFinder.CustomImage();
            this.SuspendLayout();
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(8, 8);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(64, 13);
            this.label40.TabIndex = 17;
            this.label40.Text = "Item Search";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 50);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(329, 394);
            this.listBox1.TabIndex = 16;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(22, 24);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(347, 20);
            this.textBox10.TabIndex = 18;
            this.textBox10.TextChanged += new System.EventHandler(this.textBox10_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.Location = new System.Drawing.Point(358, 375);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(77, 20);
            this.textBox1.TabIndex = 21;
            this.textBox1.Text = "0";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(344, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Selected ID";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(399, 421);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Go";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.White;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(12, 50);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(329, 394);
            this.listBox2.TabIndex = 16;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(347, 50);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(97, 17);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "ViewAll Search";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Search Properties";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(358, 103);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 17);
            this.radioButton1.TabIndex = 23;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Name";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(358, 126);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(36, 17);
            this.radioButton2.TabIndex = 23;
            this.radioButton2.Text = "ID";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(358, 149);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(92, 17);
            this.radioButton3.TabIndex = 23;
            this.radioButton3.Text = "Level (Equips)";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(358, 172);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(49, 17);
            this.radioButton4.TabIndex = 23;
            this.radioButton4.Text = "Price";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // customImage4
            // 
            this.customImage4.AccessibleName = "shield";
            this.customImage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //this.customImage4.ImageLocation = "";
            this.customImage4.Location = new System.Drawing.Point(358, 401);
            this.customImage4.Name = "customImage4";
            this.customImage4.Size = new System.Drawing.Size(35, 35);
            this.customImage4.TabIndex = 24;
            // 
            // ItemFinder
            // 
            this.ClientSize = new System.Drawing.Size(447, 456);
            this.Controls.Add(this.customImage4);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.listBox2);
            this.Name = "ItemFinder";
            this.Text = "Item Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool IsNum(string r1)
        {
            try
            {
                int num = Convert.ToInt32(r1) / 9;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = ((string) this.listBox1.Items[this.listBox1.SelectedIndex]).Split(new char[] { '-' })[0];
            ItemID = Convert.ToInt32(textBox1.Text);
            //MessageBox.Show(this.GetImage(((string) this.listBox1.Items[this.listBox1.SelectedIndex]).Split(new char[] { '-' })[0]));
            this.customImage4.Image = Image.FromFile(this.GetImage(((string) this.listBox1.Items[this.listBox1.SelectedIndex]).Split(new char[] { '-' })[0]));
            //this.customImage4.Refresh();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = ((string) this.listBox2.Items[this.listBox2.SelectedIndex]).Split(new char[] { '-' })[0];
            ItemID = Convert.ToInt32(textBox1.Text);
            //MessageBox.Show(this.GetImage(((string) this.listBox2.Items[this.listBox2.SelectedIndex]).Split(new char[] { '-' })[0]));
            this.customImage4.Image = Image.FromFile(this.GetImage(((string) this.listBox2.Items[this.listBox2.SelectedIndex]).Split(new char[] { '-' })[0]));
            //this.customImage4.Refresh();
        }

        public void Paint1(object sender, PaintEventArgs e)
        {
            /*this.ToBack();
            CustomImage image = (CustomImage) sender;
            string imageLocation = image.ImageLocation;
            if (imageLocation != "")
            {
                Bitmap bitmap = (Bitmap) Image.FromFile(imageLocation);
                ImageAttributes imageAttr = new ImageAttributes();
                imageAttr.SetColorKey(Color.FromArgb(230, 230, 230), Color.White);
                Rectangle destRect = new Rectangle(0, 0, 0x20, 0x20);
                e.Graphics.DrawImage(bitmap, destRect, 0, 0, 0x20, 0x20, GraphicsUnit.Pixel, imageAttr);
            }*/
        }

        private int R(string ins)
        {
            int num = 0;
            if (this.IsNum(ins))
            {
                num = Convert.ToInt32(ins);
            }
            return num;
        }

        public DialogResult SDlg(string JU)
        {
            if (this.ItemType == JU && ItemDemi == "-") return base.ShowDialog();
            else
            {
                this.ItemType = JU;
                this.ItemDemi = "-";
                textBox1.Text = "";
                textBox10.Text = "";
                listBox2.Items.Clear();
                customImage4 = new CustomImage();
                return base.ShowDialog();
            } 
        }

        public DialogResult SDlg(string JU, string IDe)
        {
            if (this.ItemType == JU && ItemDemi == IDe) return base.ShowDialog();
            else
            {
                this.ItemType = JU;
                this.ItemDemi = IDe;
                textBox1.Text = "";
                textBox10.Text = "";
                listBox2.Items.Clear();
                customImage4 = new CustomImage();
                return base.ShowDialog();
            }
        }

        private void Search()
        {
            for (int i = 0; i < TMAIN.ret.Count; i++)
            {
                string[] strArray = (string[]) TMAIN.ret[i];
                if (this.radioButton1.Checked && strArray[1].ToLower().Contains(this.textBox10.Text.ToLower()))
                {
                    if (this.ItemType != "0")
                    {
                        if (strArray[0x1c].Contains(","))
                        {
                            string[] st = strArray[0x1c].Split(',');
                            foreach (string l in st)
                            {
                                if (l == this.ItemType)
                                {
                                    string str = strArray[0x18];
                                    string str2 = "-(Lvl: " + str + " Price: " + strArray[0x16] + ")";
                                    if (str == "0")
                                    {
                                        str2 = "";
                                    }
                                    this.listBox2.Items.Add(((string[])TMAIN.ret[i])[0] + "-" + ((string[])TMAIN.ret[i])[1] + str2);
                                }
                            }
                        }
                        else
                        {
                            if (strArray[0x1c] == this.ItemType)
                            {
                                string str = strArray[0x18];
                                string str2 = "-(Lvl: " + str + " Price: " + strArray[0x16] + ")";
                                if (str == "0")
                                {
                                    str2 = "";
                                }
                                this.listBox2.Items.Add(((string[])TMAIN.ret[i])[0] + "-" + ((string[])TMAIN.ret[i])[1] + str2);
                            }
                        }
                    }
                    else if ((this.ItemType == "0") && (this.ItemDemi != "-"))
                    {
                        if ((strArray[10] == this.ItemDemi) && (strArray[0x1c] == "0"))
                        {
                            string str3 = strArray[0x18];
                            string str4 = "-(Lvl: " + str3 + " Price: " + strArray[0x16] + ")";
                            if (str3 == "0")
                            {
                                str4 = "";
                            }
                            this.listBox2.Items.Add(((string[]) TMAIN.ret[i])[0] + "-" + ((string[]) TMAIN.ret[i])[1] + str4);
                        }
                    }
                    else
                    {
                        string str5 = strArray[0x18];
                        string str6 = "-(Lvl: " + str5 + " Price: " + strArray[0x16] + ")";
                        if (str5 == "0")
                        {
                            str6 = "";
                        }
                        this.listBox2.Items.Add(((string[]) TMAIN.ret[i])[0] + "-" + ((string[]) TMAIN.ret[i])[1] + str6);
                    }
                }
                try
                {
                    if (this.radioButton2.Checked && (Convert.ToInt32(strArray[0]) == Convert.ToInt32(this.textBox10.Text)))
                    {
                        if (this.ItemType != "0")
                        {
                            /*if (strArray[0x1c].Contains(this.ItemType))
                            {
                                string str7 = strArray[0x18];
                                string str8 = "-(Lvl: " + str7 + " Price: " + strArray[0x16] + ")";
                                if (str7 == "0")
                                {
                                    str8 = "";
                                }
                                this.listBox2.Items.Add(((string[])TMAIN.ret[i])[0] + "-" + ((string[])TMAIN.ret[i])[1] + str8);
                            }*/

                            if (strArray[0x1c].Contains(","))
                            {
                                string[] st = strArray[0x1c].Split(',');
                                foreach (string l in st)
                                {
                                    if (l == this.ItemType)
                                    {
                                        string str = strArray[0x18];
                                        string str2 = "-(Lvl: " + str + " Price: " + strArray[0x16] + ")";
                                        if (str == "0")
                                        {
                                            str2 = "";
                                        }
                                        this.listBox2.Items.Add(((string[])TMAIN.ret[i])[0] + "-" + ((string[])TMAIN.ret[i])[1] + str2);
                                    }
                                }
                            }
                            else
                            {
                                if (strArray[0x1c] == this.ItemType)
                                {
                                    string str = strArray[0x18];
                                    string str2 = "-(Lvl: " + str + " Price: " + strArray[0x16] + ")";
                                    if (str == "0")
                                    {
                                        str2 = "";
                                    }
                                    this.listBox2.Items.Add(((string[])TMAIN.ret[i])[0] + "-" + ((string[])TMAIN.ret[i])[1] + str2);
                                }
                            }
                        }
                        else if ((this.ItemType == "0") && (this.ItemDemi != "-"))
                        {
                            if ((strArray[10] == this.ItemDemi) && (strArray[0x1c] == "0"))
                            {
                                string str9 = strArray[0x18];
                                string str10 = "-(Lvl: " + str9 + " Price: " + strArray[0x16] + ")";
                                if (str9 == "0")
                                {
                                    str10 = "";
                                }
                                this.listBox2.Items.Add(((string[])TMAIN.ret[i])[0] + "-" + ((string[])TMAIN.ret[i])[1] + str10);
                            }
                        }
                        else
                        {
                            string str11 = strArray[0x18];
                            string str12 = "-(Lvl: " + str11 + " Price: " + strArray[0x16] + ")";
                            if (str11 == "0")
                            {
                                str12 = "";
                            }
                            this.listBox2.Items.Add(((string[])TMAIN.ret[i])[0] + "-" + ((string[])TMAIN.ret[i])[1] + str12);
                        }
                    }
                }
                catch { }
                if (this.radioButton3.Checked && (strArray[0x18] == this.textBox10.Text.ToLower()))
                {
                    if (this.ItemType != "0")
                    {
                        /*if (strArray[0x1c].Contains(this.ItemType))
                        {
                            string str13 = strArray[0x18];
                            string str14 = "-(Lvl: " + str13 + " Price: " + strArray[0x16] + ")";
                            if (str13 == "0")
                            {
                                str14 = "";
                            }
                            this.listBox2.Items.Add(((string[]) TMAIN.ret[i])[0] + "-" + ((string[]) TMAIN.ret[i])[1] + str14);
                        }*/

                        if (strArray[0x1c].Contains(","))
                        {
                            string[] st = strArray[0x1c].Split(',');
                            foreach (string l in st)
                            {
                                if (l == this.ItemType)
                                {
                                    string str = strArray[0x18];
                                    string str2 = "-(Lvl: " + str + " Price: " + strArray[0x16] + ")";
                                    if (str == "0")
                                    {
                                        str2 = "";
                                    }
                                    this.listBox2.Items.Add(((string[])TMAIN.ret[i])[0] + "-" + ((string[])TMAIN.ret[i])[1] + str2);
                                }
                            }
                        }
                        else
                        {
                            if (strArray[0x1c] == this.ItemType)
                            {
                                string str = strArray[0x18];
                                string str2 = "-(Lvl: " + str + " Price: " + strArray[0x16] + ")";
                                if (str == "0")
                                {
                                    str2 = "";
                                }
                                this.listBox2.Items.Add(((string[])TMAIN.ret[i])[0] + "-" + ((string[])TMAIN.ret[i])[1] + str2);
                            }
                        }
                    }
                    else if ((this.ItemType == "0") && (this.ItemDemi != "-"))
                    {
                        if ((strArray[10] == this.ItemDemi) && (strArray[0x1c] == "0"))
                        {
                            string str15 = strArray[0x18];
                            string str16 = "-(Lvl: " + str15 + " Price: " + strArray[0x16] + ")";
                            if (str15 == "0")
                            {
                                str16 = "";
                            }
                            this.listBox2.Items.Add(((string[]) TMAIN.ret[i])[0] + "-" + ((string[]) TMAIN.ret[i])[1] + str16);
                        }
                    }
                    else
                    {
                        string str17 = strArray[0x18];
                        string str18 = "-(Lvl: " + str17 + " Price: " + strArray[0x16] + ")";
                        if (str17 == "0")
                        {
                            str18 = "";
                        }
                        this.listBox2.Items.Add(((string[]) TMAIN.ret[i])[0] + "-" + ((string[]) TMAIN.ret[i])[1] + str18);
                    }
                }
                if (this.radioButton4.Checked && (strArray[0x16] == this.textBox10.Text.ToLower()))
                {
                    if (this.ItemType != "0")
                    {
                        /*if (strArray[0x1c].Contains(this.ItemType))
                        {
                            string str19 = strArray[0x18];
                            string str20 = "-(Lvl: " + str19 + " Price: " + strArray[0x16] + ")";
                            if (str19 == "0")
                            {
                                str20 = "";
                            }
                            this.listBox2.Items.Add(((string[]) TMAIN.ret[i])[0] + "-" + ((string[]) TMAIN.ret[i])[1] + str20);
                        }*/

                        if (strArray[0x1c].Contains(","))
                        {
                            string[] st = strArray[0x1c].Split(',');
                            foreach (string l in st)
                            {
                                if (l == this.ItemType)
                                {
                                    string str = strArray[0x18];
                                    string str2 = "-(Lvl: " + str + " Price: " + strArray[0x16] + ")";
                                    if (str == "0")
                                    {
                                        str2 = "";
                                    }
                                    this.listBox2.Items.Add(((string[])TMAIN.ret[i])[0] + "-" + ((string[])TMAIN.ret[i])[1] + str2);
                                }
                            }
                        }
                        else
                        {
                            if (strArray[0x1c] == this.ItemType)
                            {
                                string str = strArray[0x18];
                                string str2 = "-(Lvl: " + str + " Price: " + strArray[0x16] + ")";
                                if (str == "0")
                                {
                                    str2 = "";
                                }
                                this.listBox2.Items.Add(((string[])TMAIN.ret[i])[0] + "-" + ((string[])TMAIN.ret[i])[1] + str2);
                            }
                        }
                    }
                    else if ((this.ItemType == "0") && (this.ItemDemi != "-"))
                    {
                        if ((strArray[10] == this.ItemDemi) && (strArray[0x1c] == "0"))
                        {
                            string str21 = strArray[0x18];
                            string str22 = "-(Lvl: " + str21 + " Price: " + strArray[0x16] + ")";
                            if (str21 == "0")
                            {
                                str22 = "";
                            }
                            this.listBox2.Items.Add(((string[]) TMAIN.ret[i])[0] + "-" + ((string[]) TMAIN.ret[i])[1] + str22);
                        }
                    }
                    else
                    {
                        string str23 = strArray[0x18];
                        string str24 = "-(Lvl: " + str23 + " Price: " + strArray[0x16] + ")";
                        if (str23 == "0")
                        {
                            str24 = "";
                        }
                        this.listBox2.Items.Add(((string[]) TMAIN.ret[i])[0] + "-" + ((string[]) TMAIN.ret[i])[1] + str24);
                    }
                }
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if ((this.textBox10.Text != "") && this.checkBox1.Checked)
            {
                int num = 0;
                for (int i = 0; i < this.listBox1.Items.Count; i++)
                {
                    string str = ((string) this.listBox1.Items[i]).Split(new char[] { '-' })[1];
                    if (str.ToLower().StartsWith(this.textBox10.Text.ToLower()))
                    {
                        num = i;
                        i = this.listBox1.Items.Count;
                    }
                }
                this.listBox1.SelectedIndex = num;
            }
        }

        private void ToBack()
        {
        }

        private class CustomImage : PictureBox
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

