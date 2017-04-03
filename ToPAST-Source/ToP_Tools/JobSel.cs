namespace ToP_Tools
{
    using System;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Windows.Forms;

    public class JobSel : Form
    {
        private Button button1;
        private string charname;
        private IContainer components;
        private string gamedb;
        private Label label1;
        private Label label2;
        private System.Data.SqlClient.SqlCommand OC;
        private RadioButton radioButton1;
        private RadioButton radioButton10;
        private RadioButton radioButton11;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private RadioButton radioButton9;

        public JobSel(System.Data.SqlClient.SqlCommand OC1, string gamedb1, string charnaem, string OldJob)
        {
            this.InitializeComponent();
            this.OC = OC1;
            this.gamedb = gamedb1;
            this.charname = charnaem;
            if (OldJob == "Newbie")
            {
                this.radioButton1.Checked = true;
            }
            if (OldJob == "Swordy")
            {
                this.radioButton2.Checked = true;
            }
            if (OldJob == "Hunter")
            {
                this.radioButton3.Checked = true;
            }
            if (OldJob == "Xplorer")
            {
                this.radioButton4.Checked = true;
            }
            if (OldJob == "Herby")
            {
                this.radioButton5.Checked = true;
            }
            if (OldJob == "Champ")
            {
                this.radioButton6.Checked = true;
            }
            if (OldJob == "Crusdr")
            {
                this.radioButton7.Checked = true;
            }
            if (OldJob == "SShoot")
            {
                this.radioButton8.Checked = true;
            }
            if (OldJob == "Cleric")
            {
                this.radioButton9.Checked = true;
            }
            if (OldJob == "SealMaster")
            {
                this.radioButton10.Checked = true;
            }
            if (OldJob == "Voyger")
            {
                this.radioButton11.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "";
            if (this.radioButton1.Checked)
            {
                str = "Newbie";
            }
            if (this.radioButton1.Checked)
            {
                str = "Swordy";
            }
            if (this.radioButton2.Checked)
            {
                str = "Hunter";
            }
            if (this.radioButton3.Checked)
            {
                str = "Xplorer";
            }
            if (this.radioButton5.Checked)
            {
                str = "Herby";
            }
            if (this.radioButton6.Checked)
            {
                str = "Champ";
            }
            if (this.radioButton7.Checked)
            {
                str = "Crusdr";
            }
            if (this.radioButton8.Checked)
            {
                str = "SShoot";
            }
            if (this.radioButton9.Checked)
            {
                str = "Cleric";
            }
            if (this.radioButton10.Checked)
            {
                str = "SMaster";
            }
            if (this.radioButton11.Checked)
            {
                str = "Voyger";
            }
            try
            {
                this.OC.CommandText = "UPDATE [" + this.gamedb + "].[dbo].[character] SET [job] = '" + str + "' WHERE [cha_name] = '" + this.charname + "'";
                this.OC.ExecuteNonQuery();
                TMAIN.Refresher = true;
            }
            catch
            {
                MessageBox.Show("Was unable to set your class.");
            }
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

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(JobSel));
            this.radioButton1 = new RadioButton();
            this.radioButton2 = new RadioButton();
            this.radioButton3 = new RadioButton();
            this.radioButton4 = new RadioButton();
            this.radioButton5 = new RadioButton();
            this.radioButton6 = new RadioButton();
            this.radioButton7 = new RadioButton();
            this.label1 = new Label();
            this.label2 = new Label();
            this.radioButton8 = new RadioButton();
            this.radioButton9 = new RadioButton();
            this.radioButton10 = new RadioButton();
            this.radioButton11 = new RadioButton();
            this.button1 = new Button();
            base.SuspendLayout();
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new Point(0x1b, 0x1d);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(0x3d, 0x11);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Newbie";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new Point(0x1b, 0x34);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(80, 0x11);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Swordsman";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new Point(0x1b, 0x4b);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new Size(0x39, 0x11);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Hunter";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new Point(0x1b, 0x62);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new Size(0x3f, 0x11);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Explorer";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new Point(0x1b, 0x79);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new Size(0x42, 0x11);
            this.radioButton5.TabIndex = 0;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Herbalist";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new Point(0x97, 0x1d);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new Size(0x48, 0x11);
            this.radioButton6.TabIndex = 0;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Champion";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new Point(0x97, 0x34);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new Size(0x43, 0x11);
            this.radioButton7.TabIndex = 0;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Crusader";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "1st Job";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x88, 13);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x2d, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "2nd Job";
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new Point(0x97, 0x4b);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new Size(0x58, 0x11);
            this.radioButton8.TabIndex = 0;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "Sharpshooter";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new Point(0x97, 0x62);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new Size(0x33, 0x11);
            this.radioButton9.TabIndex = 0;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "Cleric";
            this.radioButton9.UseVisualStyleBackColor = true;
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new Point(0x97, 0x79);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new Size(0x51, 0x11);
            this.radioButton10.TabIndex = 0;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "Seal Master";
            this.radioButton10.UseVisualStyleBackColor = true;
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new Point(0x97, 0x90);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new Size(0x40, 0x11);
            this.radioButton11.TabIndex = 0;
            this.radioButton11.TabStop = true;
            this.radioButton11.Text = "Voyager";
            this.radioButton11.UseVisualStyleBackColor = true;
            this.button1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.button1.Location = new Point(0xbf, 0xb1);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x2f, 0x17);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            //base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(250, 0xd4);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.radioButton11);
            base.Controls.Add(this.radioButton10);
            base.Controls.Add(this.radioButton9);
            base.Controls.Add(this.radioButton8);
            base.Controls.Add(this.radioButton7);
            base.Controls.Add(this.radioButton6);
            base.Controls.Add(this.radioButton5);
            base.Controls.Add(this.radioButton4);
            base.Controls.Add(this.radioButton3);
            base.Controls.Add(this.radioButton2);
            base.Controls.Add(this.radioButton1);
            //base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "JobSel";
            this.Text = "Job Selector";
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

