namespace ToP_Tools
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class IPrompt : Form
    {
        private string attributename;
        private Button button1;
        private string charname;
        private IContainer components;
        private string DBCollumn;
        private string gamedb;
        private Label label1;
        private System.Data.SqlClient.SqlCommand OC;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        public string data = "",data1="";

        public IPrompt(string BoxName,string V1, string V2)
        {
            this.InitializeComponent();
		    this.Text = BoxName;
            //this.label1.Text = "User: "+AttributeName+"\nPassword:";
            this.textBox1.Text = V1.ToString();
            this.textBox2.Text = V2.ToString();
            
            //this.textBox2.SelectAll();
        }
        public bool exit = false;
        private void button1_Click(object sender, EventArgs e)
        {
            //lol
            data = textBox1.Text;
            data1 = textBox2.Text;
			this.DialogResult = DialogResult.OK;
            exit = true;
			Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(240, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(194, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(73, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(194, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(14, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Note... This is based on your in game login account";
            // 
            // IPrompt
            // 
            this.ClientSize = new System.Drawing.Size(297, 111);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IPrompt";
            this.Text = "Login";
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
    }
}

