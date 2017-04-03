namespace ToP_Tools
{
    using System;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Windows.Forms;

    public class Attribute_Editor : Form
    {
        private string attributename;
        private Button button1;
        private string charname;
        private IContainer components;
        private string DBCollumn;
        private string gamedb;
        private Label label1;
        private System.Data.SqlClient.SqlCommand OC;
        private TextBox textBox1;

        public Attribute_Editor(System.Data.SqlClient.SqlCommand OC1, string gamedb1, string charname1, string DBCollumn1, string AttributeName, int OldAttribute)
        {
            this.InitializeComponent();
            this.OC = OC1;
            this.gamedb = gamedb1;
            this.label1.Text = AttributeName;
            this.charname = charname1;
            this.textBox1.Text = OldAttribute.ToString();
            this.DBCollumn = DBCollumn1;
            this.textBox1.SelectAll();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.IsNum(this.textBox1.Text))
            {
                try
                {
                    TMAIN.SQL_Com("UPDATE [" + this.gamedb + "].[dbo].[character] SET [" + this.DBCollumn + "] = '" + this.textBox1.Text + "' WHERE [cha_name] = '" + this.charname + "'");
                    //this.OC.ExecuteNonQuery();
                    TMAIN.Refresher = true;
                    this.DialogResult = DialogResult.OK;
                    base.Close();
                }
                catch
                {
                    MessageBox.Show("Was unable to set your class.");
                }
            }
            else
            {
                MessageBox.Show("Must be a number!");
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

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(Attribute_Editor));
            this.button1 = new Button();
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            base.SuspendLayout();
            this.button1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.button1.Location = new Point(0x9d, 0x36);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x2d, 0x17);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2e, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Attribute";
            this.textBox1.Location = new Point(0x1d, 0x19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0xad, 20);
            this.textBox1.TabIndex = 2;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            //base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0xd6, 0x59);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.button1);
            //base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "Attribute_Editor";
            this.Text = "Attribute Editor";
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
    }
}

