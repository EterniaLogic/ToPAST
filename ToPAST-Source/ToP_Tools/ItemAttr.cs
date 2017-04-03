namespace ToP_Tools
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ItemAttr : Form
    {
        private Button button1;
        private IContainer components;
        public string ItemAttrII = "";
        private ListBox listBox2;

        public ItemAttr()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.listBox2.SelectedIndex != -1)
            {
                this.ItemAttrII = (this.listBox2.SelectedIndex + 26).ToString();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemAttr));
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
            "Str",
            "AGI",
            "DEX",
            "CON",
            "SPR",
            "LUCK",
            "Attack Speed",
            "Attack Distance",
            "Min Atk",
            "Max Atk",
            "Def",
            "Max HP",
            "Max SP",
            "Evade",
            "Shooting Hit",
            "Critical Rate",
            "Drop Rate",
            "Health Recovery",
            "Magic Recovery",
            "Movement Speed",
            "Resource Drop Rate",
            "Physical Defence"});
            this.listBox2.Location = new System.Drawing.Point(12, 12);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(197, 173);
            this.listBox2.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 21);
            this.button1.TabIndex = 20;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ItemAttr
            // 
            this.ClientSize = new System.Drawing.Size(221, 228);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemAttr";
            this.Text = "ItemAttr";
            this.ResumeLayout(false);

        }
    }
}

