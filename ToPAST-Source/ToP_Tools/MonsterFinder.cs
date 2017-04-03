namespace ToP_Tools
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using System.Threading;

    public class MonsterFinder : Form
    {
        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
        private IContainer components;
        private string ItemDemi = "";
        public int ItemID;
        private string ItemType = "";
        private Label label1;
        private Label label2;
        private Label label40;
        private ListBox listBox1;
        private ListBox listBox2;
        public ArrayList NPCz = new ArrayList();
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox textBox1;
        private TextBox textBox10;

        public MonsterFinder(string ResourceLoc)
        {
            this.InitializeComponent();
            //string[] strArray = (string[])TMAIN.Monsterz[i];
            if (File.Exists(ResourceLoc + "characterinfo.txt"))
            {
                string[] strArray = File.ReadAllLines(ResourceLoc + "Characterinfo.txt");
                char ch = '\t';
                for (int i = 1; i < strArray.Length; i++)
                {
                    Thread.Sleep(10);
                    string[] parts = strArray[i].Split(new char[] { ch });

                    listBox1.Items.Add(parts[0] + "-" + parts[1]);
                }
            }
            //this.listBox1.Items.Add(((string[])TMAIN.Monsterz[i])[0] + "-" + ((string[])TMAIN.Monsterz[i])[1]);
            this.button1.Enabled = true;
            this.listBox2.Visible = true;
            this.listBox1.Visible = false;
        }
        ArrayList Characters = new ArrayList();
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
            base.Close();
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
            for (int i = 0; i < TMAIN.ret.Count; i++)
            {
                string[] strArray = (string[]) TMAIN.ret[i];
                if ((strArray[0] == ins) && File.Exists(Environment.CurrentDirectory + "/Icons/" + strArray[2] + ".jpg"))
                {
                    str = Environment.CurrentDirectory + "/Icons/" + strArray[2] + ".jpg";
                }
            }
            return str;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(MonsterFinder));
            this.label40 = new Label();
            this.listBox1 = new ListBox();
            this.textBox10 = new TextBox();
            this.button1 = new Button();
            this.textBox1 = new TextBox();
            this.label1 = new Label();
            this.button2 = new Button();
            this.listBox2 = new ListBox();
            this.checkBox1 = new CheckBox();
            this.label2 = new Label();
            this.radioButton1 = new RadioButton();
            this.radioButton2 = new RadioButton();
            base.SuspendLayout();
            this.label40.AutoSize = true;
            this.label40.ForeColor = Color.Black;
            this.label40.Location = new Point(8, 8);
            this.label40.Name = "label40";
            this.label40.Size = new Size(0x52, 13);
            this.label40.TabIndex = 0x11;
            this.label40.Text = "Monster Search";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new Point(12, 50);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new Size(0x149, 0x18a);
            this.listBox1.TabIndex = 0x10;
            this.listBox1.SelectedIndexChanged += new EventHandler(this.listBox1_SelectedIndexChanged);
            this.textBox10.Location = new Point(0x16, 0x18);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Size(0x15b, 20);
            this.textBox10.TabIndex = 0x12;
            this.textBox10.TextChanged += new EventHandler(this.textBox10_TextChanged);
            this.button1.Location = new Point(0x177, 0x15);
            this.button1.Name = "button1";
            this.button1.Size = new Size(60, 0x17);
            this.button1.TabIndex = 0x13;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.textBox1.BackColor = Color.WhiteSmoke;
            this.textBox1.Location = new Point(0x166, 0x177);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new Size(0x4d, 20);
            this.textBox1.TabIndex = 0x15;
            this.textBox1.Text = "0";
            this.label1.AutoSize = true;
            this.label1.ForeColor = Color.Black;
            this.label1.Location = new Point(0x158, 0x167);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3f, 13);
            this.label1.TabIndex = 0x11;
            this.label1.Text = "Selected ID";
            //this.button2.DialogResult = DialogResult.OK;
            this.button2.Location = new Point(0x18f, 0x1a5);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x24, 0x17);
            this.button2.TabIndex = 0x13;
            this.button2.Text = "Go";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.listBox2.BackColor = Color.White;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new Point(12, 50);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new Size(0x149, 0x18a);
            this.listBox2.TabIndex = 0x10;
            this.listBox2.SelectedIndexChanged += new EventHandler(this.listBox2_SelectedIndexChanged);
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new Point(0x15b, 50);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(0x61, 0x11);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "ViewAll Search";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x158, 0x57);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x5b, 13);
            this.label2.TabIndex = 0x16;
            this.label2.Text = "Search Properties";
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new Point(0x166, 0x67);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(0x35, 0x11);
            this.radioButton1.TabIndex = 0x17;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Name";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new Point(0x166, 0x7e);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(0x24, 0x11);
            this.radioButton2.TabIndex = 0x17;
            this.radioButton2.Text = "ID";
            this.radioButton2.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            //base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1bf, 0x1c8);
            base.Controls.Add(this.radioButton2);
            base.Controls.Add(this.radioButton1);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.checkBox1);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.label40);
            base.Controls.Add(this.listBox2);
            base.Controls.Add(this.listBox1);
            base.Controls.Add(this.textBox10);
            //base.FormBorderStyle = FormBorderStyle.FixedDialog;
            //base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "MonsterFinder";
            this.Text = "Monster Search";
            base.ResumeLayout(false);
            base.PerformLayout();
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
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = ((string) this.listBox2.Items[this.listBox2.SelectedIndex]).Split(new char[] { '-' })[0];
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
            this.ItemType = JU;
            this.ItemDemi = "-";
            return base.ShowDialog();
        }

        public DialogResult SDlg(string JU, string IDe)
        {
            this.ItemType = JU;
            this.ItemDemi = IDe;
            return base.ShowDialog();
        }

        private void Search()
        {
            for (int i = 0; i < TMAIN.Monsterz.Count; i++)
            {
                string[] strArray = (string[])TMAIN.Monsterz[i];
                if (this.radioButton1.Checked && strArray[1].ToLower().Contains(this.textBox10.Text.ToLower()))
                {
                    this.listBox2.Items.Add(((string[])TMAIN.Monsterz[i])[0] + "-" + ((string[])TMAIN.Monsterz[i])[1]);
                }
                if (this.radioButton2.Checked && (strArray[0] == this.textBox10.Text.ToLower()))
                {
                    this.listBox2.Items.Add(((string[])TMAIN.Monsterz[i])[0] + "-" + ((string[])TMAIN.Monsterz[i])[1]);
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
    }
}

