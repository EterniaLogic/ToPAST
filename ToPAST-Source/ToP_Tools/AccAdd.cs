namespace ToP_Tools
{
    using System;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Forms;

    public class AccAdd : Form
    {
        private string accdb = "";
        private Button button1;
        private CheckBox checkBox1;
        private IContainer components;
        private string gamedb = "";
        private Label label1;
        private Label label2;
        private System.Data.SqlClient.SqlCommand op;
        private TextBox textBox1;
        private TextBox textBox2;

        public AccAdd(System.Data.SqlClient.SqlCommand op1, string accdb1, string gamedb1)
        {
            this.InitializeComponent();
            this.op = op1;
            this.accdb = accdb1;
            this.gamedb = gamedb1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TMAIN.SQL_Com("INSERT INTO [" + this.accdb + "].[dbo].[account_login] ( [name], [password], [originalPassword], [ban]) VALUES ('" + this.SqlInJectProt(this.textBox1.Text) + "','" + this.EncodePassword(this.SqlInJectProt(this.textBox2.Text)) + "','" + this.SqlInJectProt(this.textBox2.Text) + "',0)");
            
            TMAIN.BaseReader reader= TMAIN.SQL_Read("SELECT * FROM [" + this.gamedb + "].[dbo].[account] ORDER BY [act_id] ASC");
            int num = 0;
            while (reader.Read())
            {
                num = reader.GetInt32(0) + 1;
            }
            reader.Close();
           //MessageBox.Show(num.ToString());
            string str = "0";
            if (this.checkBox1.Checked)
            {
                str = "99";
            }
            TMAIN.SQL_Com(string.Concat(new object[] { "INSERT INTO [", this.gamedb, "].[dbo].[account] ([act_id],[act_name], [gm],[password]) VALUES (", num, ",'", this.SqlInJectProt(this.textBox1.Text), "','", str, "','", this.EncodePassword(this.EncodePassword(this.SqlInJectProt(this.textBox2.Text))), "')" }));
            
            this.DialogResult = DialogResult.OK;
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public string EncodePassword(string originalPassword)
        {
            MD5 md = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(originalPassword);
            return BitConverter.ToString(md.ComputeHash(bytes)).Replace("-", "");
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(AccAdd));
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.checkBox1 = new CheckBox();
            this.label2 = new Label();
            this.textBox2 = new TextBox();
            this.button1 = new Button();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x4e, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Name";
            this.textBox1.Location = new Point(0x21, 0x19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0xb3, 20);
            this.textBox1.TabIndex = 1;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new Point(15, 0x58);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(0x2b, 0x11);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "GM";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 0x2e);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Account Password";
            this.textBox2.Location = new Point(0x21, 0x3e);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new Size(0xb3, 20);
            this.textBox2.TabIndex = 2;
            this.button1.Location = new Point(180, 0x58);
            this.button1.Name = "button1";
            this.button1.Size = new Size(40, 0x17);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            //base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0xe8, 0x73);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.checkBox1);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label1);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "AccAdd";
            this.Text = "Account Add";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private string SqlInJectProt(string ins)
        {
            string str = ins;
            str.Replace("=", "");
            str.Replace("'", "");
            str.Replace("--", "");
            return str;
        }
    }
}

