namespace ToP_Tools
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class GemID : Form
    {
        private Button button1;
        private IContainer components;
        private string dos = "1\tFiery Gem\t0878\t1\t1\tItemHint_LieYanS\r\n2\tFurious Gem\t0879\t2,3,7,9\t1\tItemHint_ZhiYanS\r\n3\tExplosive Gem\t0880\t4\t1\tItemHint_HuoYaoS\r\n4\tLustrious Gem\t0881\t1,2,3,4,7,9,23\t1\tItemHint_MaNaoS\r\n5\tGlowing Gem\t0882\t11,22,27\t2\tItemHint_HanYu\r\n6\tShining Gem\t0883\t11,22,27\t2\tItemHint_YueZhiX\r\n7\tShadow Gem\t0884\t1,2,3,4,7,9,24\t2\tItemHint_ShuiLingS\r\n8\tSpirit Gem\t0887\t1,2,3,4,7,9,24\t4\tItemHint_ShengGuangS\r\n9\tGem of the Wind\t0860\t24\t4\tItemHint_FengLingS\r\n10\tGem of Striking\t0861\t23\t4\tItemHint_YingYanS\r\n11\tGem of Colossus\t0862\t11,22,27\t4\tItemHint_YanVitS\r\n12\tGem of Rage\t0863\t1,2,3,4,7,9\t4\tItemHint_YanStrS\r\n13\tEye of Black Dragon\t0864\t1,2,3,4,7,9\t1\tItemHint_LongZhiTong\r\n14\tSoul of Black Dragon\t0865\t11,22,27\t2\tItemHint_LongZhiHun\r\n15\tHeart of Black Dragon\t0866\t23,24\t2\tItemHint_LongZhiXin";
        private ListBox listBox1;

        public GemID(string Resource)
        {
            this.InitializeComponent();
            if (File.Exists(Resource + "/stoneinfo.txt"))
            {
                string[] strArray = File.ReadAllLines(Resource + "/stoneinfo.txt");
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].Contains("\t"))
                    {
                        string[] strArray2 = strArray[i].Split(new char[] { '\t' });
                        this.listBox1.Items.Add(strArray2[0] + " - (" + strArray2[1] + ")");
                    }
                }
            }
            else
            {
                File.WriteAllText(Resource + "/stoneinfo.txt", this.dos);
                string[] strArray3 = this.dos.Split(new char[] { '\n' });
                for (int j = 0; j < strArray3.Length; j++)
                {
                    if (strArray3[j].Contains("\t"))
                    {
                        string[] strArray4 = strArray3[j].Split(new char[] { '\t' });
                        this.listBox1.Items.Add(strArray4[0] + " - (" + strArray4[1] + ")");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.listBox1.Items[this.listBox1.SelectedIndex] != null)
            {
                TMAIN.GemSaveID = Convert.ToInt32(((string) this.listBox1.Items[this.listBox1.SelectedIndex]).Split(new char[] { ' ' })[0]);
                base.DialogResult = DialogResult.OK;
                base.Close();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GemID));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(206, 121);
            this.listBox1.TabIndex = 0;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(154, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GemID
            // 
            this.ClientSize = new System.Drawing.Size(232, 179);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GemID";
            this.Text = "Basic GemIDs";
            this.ResumeLayout(false);

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

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listBox1.Items[this.listBox1.SelectedIndex] != null)
            {
                TMAIN.GemSaveID = Convert.ToInt32(((string) this.listBox1.Items[this.listBox1.SelectedIndex]).Split(new char[] { ' ' })[0]);
                base.DialogResult = DialogResult.OK;
                base.Close();
            }
        }
    }
}

