namespace ToP_Tools
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using System.Threading;

    public class SkillPicker : Form
    {
        private Button button1;
        private IContainer components;
        private ImageList imageList1;
        private Label label1;
        private Label label2;
        private Label label3;
        private ListView listView1;
        private ListView listView10;
        private ListView listView11;
        private ListView listView12;
        private ListView listView13;
        private ListView listView14;
        private ListView listView15;
        private ListView listView2;
        private ListView listView3;
        private ListView listView4;
        private ListView listView5;
        private ListView listView6;
        private ListView listView7;
        private ListView listView8;
        private ListView listView9;
        public string SkillID = "";
        public string SkillLvl = "";
        private TabControl tabControl1;
        private TabControl tabControl2;
        private TabControl tabControl3;
        private TabPage tabPage1;
        private TabPage tabPage10;
        private TabPage tabPage11;
        private TabPage tabPage12;
        private TabPage tabPage13;
        private TabPage tabPage14;
        private TabPage tabPage15;
        private TabPage tabPage16;
        private TabPage tabPage17;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private ArrayList Tags1 = new ArrayList();
        private ArrayList Tags10 = new ArrayList();
        private ArrayList Tags11 = new ArrayList();
        private ArrayList Tags12 = new ArrayList();
        private ArrayList Tags13 = new ArrayList();
        private ArrayList Tags14 = new ArrayList();
        private ArrayList Tags15 = new ArrayList();
        private ArrayList Tags2 = new ArrayList();
        private ArrayList Tags3 = new ArrayList();
        private ArrayList Tags4 = new ArrayList();
        private ArrayList Tags9 = new ArrayList();
        private TextBox textBox2;
        private NumericUpDown numericUpDown1;
        private System.Windows.Forms.Timer timer1;

        public SkillPicker(string ResourceLoc)
        {
            this.InitializeComponent();
            //MessageBox.Show(ResourceLoc + "skillinfo.txt");
            if (File.Exists(ResourceLoc + "skillinfo.txt"))
            {
                string[] strArray = File.ReadAllLines(ResourceLoc + "skillinfo.txt");
                char ch = '\t';
                //MessageBox.Show(strArray.Length.ToString());
                for (int i = 0; i < strArray.Length; i++)
                {
                    Thread.Sleep(10);
                    string[] parts = strArray[i].Split(new char[] { ch });
                    if (!strArray[i].StartsWith("//") && parts[3].Contains(","))
                    {
                        if (parts[3] == "-1,10")
                        {
                            this.Set("rr", parts);
                        }
                        else
                        {
                            string[] strArray3 = parts[3].Split(new char[] { ',' });
                            for (int j = 0; j < strArray3.Length; j++)
                            {
                                if (!strArray3[j].Contains(";"))
                                {
                                    this.Set(strArray3[j], parts);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((this.textBox2.Text != "") && this.IsNum(this.textBox2.Text))
            {
                this.SkillID = Convert.ToInt32(this.textBox2.Text).ToString();
                this.SkillLvl = this.numericUpDown1.Text;
                TMAIN.yui = this.SkillID;
                TMAIN.yui2 = this.SkillLvl;
                this.DialogResult = DialogResult.OK;
                if (((this.SkillID != "") && (this.numericUpDown1.Text != "")) && this.IsNum(this.numericUpDown1.Text))
                {
                    base.Close();
                }
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkillPicker));
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView3 = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.listView4 = new System.Windows.Forms.ListView();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.listView9 = new System.Windows.Forms.ListView();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.listView10 = new System.Windows.Forms.ListView();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.listView11 = new System.Windows.Forms.ListView();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.listView12 = new System.Windows.Forms.ListView();
            this.tabPage16 = new System.Windows.Forms.TabPage();
            this.listView13 = new System.Windows.Forms.ListView();
            this.tabPage17 = new System.Windows.Forms.TabPage();
            this.listView14 = new System.Windows.Forms.ListView();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.listView15 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listView5 = new System.Windows.Forms.ListView();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.listView6 = new System.Windows.Forms.ListView();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.listView7 = new System.Windows.Forms.ListView();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.listView8 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.tabPage15.SuspendLayout();
            this.tabPage16.SuspendLayout();
            this.tabPage17.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(525, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "s0062.jpg");
            this.imageList1.Images.SetKeyName(1, "s0063.jpg");
            this.imageList1.Images.SetKeyName(2, "s0064.jpg");
            this.imageList1.Images.SetKeyName(3, "s0065.jpg");
            this.imageList1.Images.SetKeyName(4, "s0066.jpg");
            this.imageList1.Images.SetKeyName(5, "s0067.jpg");
            this.imageList1.Images.SetKeyName(6, "s0068.jpg");
            this.imageList1.Images.SetKeyName(7, "s0070.jpg");
            this.imageList1.Images.SetKeyName(8, "s0074.jpg");
            this.imageList1.Images.SetKeyName(9, "s0075.jpg");
            this.imageList1.Images.SetKeyName(10, "s0078.jpg");
            this.imageList1.Images.SetKeyName(11, "s0079.jpg");
            this.imageList1.Images.SetKeyName(12, "s0080.jpg");
            this.imageList1.Images.SetKeyName(13, "s0081.jpg");
            this.imageList1.Images.SetKeyName(14, "s0082.jpg");
            this.imageList1.Images.SetKeyName(15, "s0083.jpg");
            this.imageList1.Images.SetKeyName(16, "s0084.jpg");
            this.imageList1.Images.SetKeyName(17, "s0086.jpg");
            this.imageList1.Images.SetKeyName(18, "s0087.jpg");
            this.imageList1.Images.SetKeyName(19, "s0090.jpg");
            this.imageList1.Images.SetKeyName(20, "s0093.jpg");
            this.imageList1.Images.SetKeyName(21, "s0094.jpg");
            this.imageList1.Images.SetKeyName(22, "s0095.jpg");
            this.imageList1.Images.SetKeyName(23, "s0096.jpg");
            this.imageList1.Images.SetKeyName(24, "s0097.jpg");
            this.imageList1.Images.SetKeyName(25, "s0098.jpg");
            this.imageList1.Images.SetKeyName(26, "s0099.jpg");
            this.imageList1.Images.SetKeyName(27, "s0100.jpg");
            this.imageList1.Images.SetKeyName(28, "s0101.jpg");
            this.imageList1.Images.SetKeyName(29, "s0102.jpg");
            this.imageList1.Images.SetKeyName(30, "s0103.jpg");
            this.imageList1.Images.SetKeyName(31, "s0104.jpg");
            this.imageList1.Images.SetKeyName(32, "s0105.jpg");
            this.imageList1.Images.SetKeyName(33, "s0106.jpg");
            this.imageList1.Images.SetKeyName(34, "s0107.jpg");
            this.imageList1.Images.SetKeyName(35, "s0109.jpg");
            this.imageList1.Images.SetKeyName(36, "s0112.jpg");
            this.imageList1.Images.SetKeyName(37, "s0113.jpg");
            this.imageList1.Images.SetKeyName(38, "s0116.jpg");
            this.imageList1.Images.SetKeyName(39, "s0119.jpg");
            this.imageList1.Images.SetKeyName(40, "s0121.jpg");
            this.imageList1.Images.SetKeyName(41, "s0122.jpg");
            this.imageList1.Images.SetKeyName(42, "s0123.jpg");
            this.imageList1.Images.SetKeyName(43, "s0124.jpg");
            this.imageList1.Images.SetKeyName(44, "s0210.jpg");
            this.imageList1.Images.SetKeyName(45, "s0211.jpg");
            this.imageList1.Images.SetKeyName(46, "s0212.jpg");
            this.imageList1.Images.SetKeyName(47, "s0213.jpg");
            this.imageList1.Images.SetKeyName(48, "s0214.jpg");
            this.imageList1.Images.SetKeyName(49, "s0215.jpg");
            this.imageList1.Images.SetKeyName(50, "s0216.jpg");
            this.imageList1.Images.SetKeyName(51, "s0217.jpg");
            this.imageList1.Images.SetKeyName(52, "s0218.jpg");
            this.imageList1.Images.SetKeyName(53, "s0219.jpg");
            this.imageList1.Images.SetKeyName(54, "s0220.jpg");
            this.imageList1.Images.SetKeyName(55, "s0222.jpg");
            this.imageList1.Images.SetKeyName(56, "s0223.jpg");
            this.imageList1.Images.SetKeyName(57, "s0224.jpg");
            this.imageList1.Images.SetKeyName(58, "s0225.jpg");
            this.imageList1.Images.SetKeyName(59, "s0453.jpg");
            this.imageList1.Images.SetKeyName(60, "s0454.jpg");
            this.imageList1.Images.SetKeyName(61, "s0455.jpg");
            this.imageList1.Images.SetKeyName(62, "s0456.jpg");
            this.imageList1.Images.SetKeyName(63, "s0457.jpg");
            this.imageList1.Images.SetKeyName(64, "s0458.jpg");
            this.imageList1.Images.SetKeyName(65, "s0459.jpg");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(574, 280);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(566, 254);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Swordsman";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(560, 248);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.StateImageList = this.imageList1;
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(566, 254);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Explorer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView3
            // 
            this.listView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView3.LargeImageList = this.imageList1;
            this.listView3.Location = new System.Drawing.Point(3, 3);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(560, 248);
            this.listView3.SmallImageList = this.imageList1;
            this.listView3.StateImageList = this.imageList1;
            this.listView3.TabIndex = 8;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.List;
            this.listView3.SelectedIndexChanged += new System.EventHandler(this.listView3_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(566, 254);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Hunter";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.LargeImageList = this.imageList1;
            this.listView2.Location = new System.Drawing.Point(3, 3);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(560, 248);
            this.listView2.SmallImageList = this.imageList1;
            this.listView2.StateImageList = this.imageList1;
            this.listView2.TabIndex = 8;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.List;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.listView4);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(566, 254);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Herbalist";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // listView4
            // 
            this.listView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView4.LargeImageList = this.imageList1;
            this.listView4.Location = new System.Drawing.Point(3, 3);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(560, 248);
            this.listView4.SmallImageList = this.imageList1;
            this.listView4.StateImageList = this.imageList1;
            this.listView4.TabIndex = 6;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.List;
            this.listView4.SelectedIndexChanged += new System.EventHandler(this.listView4_SelectedIndexChanged);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Location = new System.Drawing.Point(12, 12);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(588, 312);
            this.tabControl2.TabIndex = 3;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.tabControl1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(580, 286);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "1st Job";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.tabControl3);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(580, 286);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "2nd Job";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage12);
            this.tabControl3.Controls.Add(this.tabPage13);
            this.tabControl3.Controls.Add(this.tabPage14);
            this.tabControl3.Controls.Add(this.tabPage15);
            this.tabControl3.Controls.Add(this.tabPage16);
            this.tabControl3.Controls.Add(this.tabPage17);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(3, 3);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(574, 280);
            this.tabControl3.TabIndex = 6;
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.listView9);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(566, 254);
            this.tabPage12.TabIndex = 0;
            this.tabPage12.Text = "Champion";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // listView9
            // 
            this.listView9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView9.LargeImageList = this.imageList1;
            this.listView9.Location = new System.Drawing.Point(3, 3);
            this.listView9.MultiSelect = false;
            this.listView9.Name = "listView9";
            this.listView9.Size = new System.Drawing.Size(560, 248);
            this.listView9.SmallImageList = this.imageList1;
            this.listView9.StateImageList = this.imageList1;
            this.listView9.TabIndex = 8;
            this.listView9.UseCompatibleStateImageBehavior = false;
            this.listView9.View = System.Windows.Forms.View.List;
            this.listView9.SelectedIndexChanged += new System.EventHandler(this.listView9_SelectedIndexChanged);
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.listView10);
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(566, 254);
            this.tabPage13.TabIndex = 1;
            this.tabPage13.Text = "Crusader";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // listView10
            // 
            this.listView10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView10.LargeImageList = this.imageList1;
            this.listView10.Location = new System.Drawing.Point(3, 3);
            this.listView10.Name = "listView10";
            this.listView10.Size = new System.Drawing.Size(560, 248);
            this.listView10.SmallImageList = this.imageList1;
            this.listView10.StateImageList = this.imageList1;
            this.listView10.TabIndex = 8;
            this.listView10.UseCompatibleStateImageBehavior = false;
            this.listView10.View = System.Windows.Forms.View.List;
            this.listView10.SelectedIndexChanged += new System.EventHandler(this.listView10_SelectedIndexChanged);
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.listView11);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(566, 254);
            this.tabPage14.TabIndex = 2;
            this.tabPage14.Text = "Cleric";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // listView11
            // 
            this.listView11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView11.LargeImageList = this.imageList1;
            this.listView11.Location = new System.Drawing.Point(3, 3);
            this.listView11.Name = "listView11";
            this.listView11.Size = new System.Drawing.Size(560, 248);
            this.listView11.SmallImageList = this.imageList1;
            this.listView11.StateImageList = this.imageList1;
            this.listView11.TabIndex = 8;
            this.listView11.UseCompatibleStateImageBehavior = false;
            this.listView11.View = System.Windows.Forms.View.List;
            this.listView11.SelectedIndexChanged += new System.EventHandler(this.listView11_SelectedIndexChanged);
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.listView12);
            this.tabPage15.Location = new System.Drawing.Point(4, 22);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(566, 254);
            this.tabPage15.TabIndex = 4;
            this.tabPage15.Text = "Seal Master";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // listView12
            // 
            this.listView12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView12.LargeImageList = this.imageList1;
            this.listView12.Location = new System.Drawing.Point(3, 3);
            this.listView12.Name = "listView12";
            this.listView12.Size = new System.Drawing.Size(560, 248);
            this.listView12.SmallImageList = this.imageList1;
            this.listView12.StateImageList = this.imageList1;
            this.listView12.TabIndex = 6;
            this.listView12.UseCompatibleStateImageBehavior = false;
            this.listView12.View = System.Windows.Forms.View.List;
            this.listView12.SelectedIndexChanged += new System.EventHandler(this.listView12_SelectedIndexChanged);
            // 
            // tabPage16
            // 
            this.tabPage16.Controls.Add(this.listView13);
            this.tabPage16.Location = new System.Drawing.Point(4, 22);
            this.tabPage16.Name = "tabPage16";
            this.tabPage16.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage16.Size = new System.Drawing.Size(566, 254);
            this.tabPage16.TabIndex = 5;
            this.tabPage16.Text = "Voyager";
            this.tabPage16.UseVisualStyleBackColor = true;
            // 
            // listView13
            // 
            this.listView13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView13.LargeImageList = this.imageList1;
            this.listView13.Location = new System.Drawing.Point(3, 3);
            this.listView13.MultiSelect = false;
            this.listView13.Name = "listView13";
            this.listView13.Size = new System.Drawing.Size(560, 248);
            this.listView13.SmallImageList = this.imageList1;
            this.listView13.StateImageList = this.imageList1;
            this.listView13.TabIndex = 10;
            this.listView13.UseCompatibleStateImageBehavior = false;
            this.listView13.View = System.Windows.Forms.View.List;
            this.listView13.SelectedIndexChanged += new System.EventHandler(this.listView13_SelectedIndexChanged);
            // 
            // tabPage17
            // 
            this.tabPage17.Controls.Add(this.listView14);
            this.tabPage17.Location = new System.Drawing.Point(4, 22);
            this.tabPage17.Name = "tabPage17";
            this.tabPage17.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage17.Size = new System.Drawing.Size(566, 254);
            this.tabPage17.TabIndex = 6;
            this.tabPage17.Text = "Sharp Shooter";
            this.tabPage17.UseVisualStyleBackColor = true;
            // 
            // listView14
            // 
            this.listView14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView14.LargeImageList = this.imageList1;
            this.listView14.Location = new System.Drawing.Point(3, 3);
            this.listView14.MultiSelect = false;
            this.listView14.Name = "listView14";
            this.listView14.Size = new System.Drawing.Size(560, 248);
            this.listView14.SmallImageList = this.imageList1;
            this.listView14.StateImageList = this.imageList1;
            this.listView14.TabIndex = 10;
            this.listView14.UseCompatibleStateImageBehavior = false;
            this.listView14.View = System.Windows.Forms.View.List;
            this.listView14.SelectedIndexChanged += new System.EventHandler(this.listView14_SelectedIndexChanged);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.listView15);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(580, 286);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "Extra";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // listView15
            // 
            this.listView15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView15.LargeImageList = this.imageList1;
            this.listView15.Location = new System.Drawing.Point(3, 3);
            this.listView15.MultiSelect = false;
            this.listView15.Name = "listView15";
            this.listView15.Size = new System.Drawing.Size(574, 280);
            this.listView15.SmallImageList = this.imageList1;
            this.listView15.StateImageList = this.imageList1;
            this.listView15.TabIndex = 12;
            this.listView15.UseCompatibleStateImageBehavior = false;
            this.listView15.View = System.Windows.Forms.View.List;
            this.listView15.SelectedIndexChanged += new System.EventHandler(this.listView15_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 46);
            this.label1.TabIndex = 4;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.listView5);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(576, 264);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Swordsman";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // listView5
            // 
            this.listView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView5.LargeImageList = this.imageList1;
            this.listView5.Location = new System.Drawing.Point(3, 3);
            this.listView5.MultiSelect = false;
            this.listView5.Name = "listView5";
            this.listView5.Size = new System.Drawing.Size(570, 258);
            this.listView5.SmallImageList = this.imageList1;
            this.listView5.StateImageList = this.imageList1;
            this.listView5.TabIndex = 8;
            this.listView5.UseCompatibleStateImageBehavior = false;
            this.listView5.View = System.Windows.Forms.View.List;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.listView6);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(576, 264);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "Explorer";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // listView6
            // 
            this.listView6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView6.LargeImageList = this.imageList1;
            this.listView6.Location = new System.Drawing.Point(3, 3);
            this.listView6.Name = "listView6";
            this.listView6.Size = new System.Drawing.Size(570, 258);
            this.listView6.SmallImageList = this.imageList1;
            this.listView6.StateImageList = this.imageList1;
            this.listView6.TabIndex = 8;
            this.listView6.UseCompatibleStateImageBehavior = false;
            this.listView6.View = System.Windows.Forms.View.List;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.listView7);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(576, 264);
            this.tabPage10.TabIndex = 2;
            this.tabPage10.Text = "Hunter";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // listView7
            // 
            this.listView7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView7.LargeImageList = this.imageList1;
            this.listView7.Location = new System.Drawing.Point(3, 3);
            this.listView7.Name = "listView7";
            this.listView7.Size = new System.Drawing.Size(570, 258);
            this.listView7.SmallImageList = this.imageList1;
            this.listView7.StateImageList = this.imageList1;
            this.listView7.TabIndex = 8;
            this.listView7.UseCompatibleStateImageBehavior = false;
            this.listView7.View = System.Windows.Forms.View.List;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.listView8);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(576, 264);
            this.tabPage11.TabIndex = 4;
            this.tabPage11.Text = "Herbalist";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // listView8
            // 
            this.listView8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView8.LargeImageList = this.imageList1;
            this.listView8.Location = new System.Drawing.Point(3, 3);
            this.listView8.Name = "listView8";
            this.listView8.Size = new System.Drawing.Size(570, 258);
            this.listView8.SmallImageList = this.imageList1;
            this.listView8.StateImageList = this.imageList1;
            this.listView8.TabIndex = 6;
            this.listView8.UseCompatibleStateImageBehavior = false;
            this.listView8.View = System.Windows.Forms.View.List;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Level";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(546, 334);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(54, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "0";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(522, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(394, 362);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SkillPicker
            // 
            this.ClientSize = new System.Drawing.Size(612, 391);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SkillPicker";
            this.Text = "Skill Picker";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            this.tabPage15.ResumeLayout(false);
            this.tabPage16.ResumeLayout(false);
            this.tabPage17.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedIndices.Count > 0)
            {
                int num = this.listView1.SelectedIndices[0];
                string[] strArray = ((string) this.Tags1[num]).Split(new char[] { '|' });
                if (strArray[1] != "0")
                {
                    this.label1.Text = strArray[1];
                }
                else
                {
                    this.label1.Text = "";
                }
            }
        }

        private void listView10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView10.SelectedIndices.Count > 0)
            {
                int num = this.listView10.SelectedIndices[0];
                string[] strArray = ((string) this.Tags10[num]).Split(new char[] { '|' });
                if (strArray[1] != "0")
                {
                    this.label1.Text = strArray[1];
                }
                else
                {
                    this.label1.Text = "";
                }
            }
        }

        private void listView11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView11.SelectedIndices.Count > 0)
            {
                int num = this.listView11.SelectedIndices[0];
                string[] strArray = ((string) this.Tags11[num]).Split(new char[] { '|' });
                if (strArray[1] != "0")
                {
                    this.label1.Text = strArray[1];
                }
                else
                {
                    this.label1.Text = "";
                }
            }
        }

        private void listView12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView12.SelectedIndices.Count > 0)
            {
                int num = this.listView12.SelectedIndices[0];
                string[] strArray = ((string) this.Tags12[num]).Split(new char[] { '|' });
                if (strArray[1] != "0")
                {
                    this.label1.Text = strArray[1];
                }
                else
                {
                    this.label1.Text = "";
                }
            }
        }

        private void listView13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView13.SelectedIndices.Count > 0)
            {
                int num = this.listView13.SelectedIndices[0];
                string[] strArray = ((string) this.Tags13[num]).Split(new char[] { '|' });
                if (strArray[1] != "0")
                {
                    this.label1.Text = strArray[1];
                }
                else
                {
                    this.label1.Text = "";
                }
            }
        }

        private void listView14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView14.SelectedIndices.Count > 0)
            {
                int num = this.listView14.SelectedIndices[0];
                string[] strArray = ((string) this.Tags14[num]).Split(new char[] { '|' });
                if (strArray[1] != "0")
                {
                    this.label1.Text = strArray[1];
                }
                else
                {
                    this.label1.Text = "";
                }
            }
        }

        private void listView15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView15.SelectedIndices.Count > 0)
            {
                int num = this.listView15.SelectedIndices[0];
                string[] strArray = ((string) this.Tags15[num]).Split(new char[] { '|' });
                if (strArray[1] != "0")
                {
                    this.label1.Text = strArray[1];
                }
                else
                {
                    this.label1.Text = "";
                }
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView2.SelectedIndices.Count > 0)
            {
                int num = this.listView2.SelectedIndices[0];
                string[] strArray = ((string) this.Tags2[num]).Split(new char[] { '|' });
                if (strArray[1] != "0")
                {
                    this.label1.Text = strArray[1];
                }
                else
                {
                    this.label1.Text = "";
                }
            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView3.SelectedIndices.Count > 0)
            {
                int num = this.listView3.SelectedIndices[0];
                string[] strArray = ((string) this.Tags3[num]).Split(new char[] { '|' });
                if (strArray[1] != "0")
                {
                    this.label1.Text = strArray[1];
                }
                else
                {
                    this.label1.Text = "";
                }
            }
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.tabControl1.SelectedTab == this.tabPage5) && (this.listView4.SelectedIndices.Count > 0))
            {
                int num = this.listView4.SelectedIndices[0];
                string[] strArray = ((string) this.Tags4[num]).Split(new char[] { '|' });
                if (strArray[1] != "0")
                {
                    this.label1.Text = strArray[1];
                }
                else
                {
                    this.label1.Text = "";
                }
            }
        }

        private void listView9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView9.SelectedIndices.Count > 0)
            {
                int num = this.listView9.SelectedIndices[0];
                string[] strArray = ((string) this.Tags9[num]).Split(new char[] { '|' });
                if (strArray[1] != "0")
                {
                    this.label1.Text = strArray[1];
                }
                else
                {
                    this.label1.Text = "";
                }
            }
        }

        private void Set(string ROP, string[] Parts)
        {
            string str = "";
            string str2 = "";
            if (Parts[0x48] == "Passive")
            {
                str = " [P]";
                str2 = " (Passive skill)";
            }
            string str3 = Parts[0] + "|" + Parts[70] + str2;
            if (ROP == "1")
            {
                this.listView1.Items.Add(Parts[1] + str, Parts[0x43].Replace(".tga", ".jpg"));
                this.Tags1.Add(str3);
            }
            else if (ROP == "2")
            {
                this.listView2.Items.Add(Parts[1] + str, Parts[0x43].Replace(".tga", ".jpg"));
                this.Tags2.Add(str3);
            }
            else if (ROP == "4")
            {
                this.listView3.Items.Add(Parts[1] + str, Parts[0x43].Replace(".tga", ".jpg"));
                this.Tags3.Add(str3);
            }
            else if (ROP == "5")
            {
                this.listView4.Items.Add(Parts[1] + str, Parts[0x43].Replace(".tga", ".jpg"));
                this.Tags4.Add(str3);
            }
            else if (ROP == "8")
            {
                this.listView9.Items.Add(Parts[1] + str, Parts[0x43].Replace(".tga", ".jpg"));
                this.Tags9.Add(str3);
            }
            else if (ROP == "9")
            {
                this.listView10.Items.Add(Parts[1] + str, Parts[0x43].Replace(".tga", ".jpg"));
                this.Tags10.Add(str3);
            }
            else if (ROP == "13")
            {
                this.listView11.Items.Add(Parts[1] + str, Parts[0x43].Replace(".tga", ".jpg"));
                this.Tags11.Add(str3);
            }
            else if (ROP == "14")
            {
                this.listView12.Items.Add(Parts[1] + str, Parts[0x43].Replace(".tga", ".jpg"));
                this.Tags12.Add(str3);
            }
            else if (ROP == "16")
            {
                this.listView13.Items.Add(Parts[1] + str, Parts[0x43].Replace(".tga", ".jpg"));
                this.Tags13.Add(str3);
            }
            else if (ROP == "12")
            {
                this.listView14.Items.Add(Parts[1] + str, Parts[0x43].Replace(".tga", ".jpg"));
                this.Tags14.Add(str3);
            }
            else if (ROP == "rr")
            {
                this.listView15.Items.Add(Parts[1] + str, Parts[0x43].Replace(".tga", ".jpg"));
                this.Tags15.Add(str3);
            }
        }

        public void SetVisi(bool visi)
        {
            this.numericUpDown1.Visible = visi; 
            this.label2.Visible = visi;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.IsNum(this.numericUpDown1.Text))
            {
                if (Convert.ToInt32(this.numericUpDown1.Text) > 10)
                {
                    this.numericUpDown1.Text = "10";
                }
            }
            else
            {
                this.numericUpDown1.Text = "0";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.tabControl2.SelectedIndex == 0)
            {
                if ((this.tabControl1.SelectedIndex == 0) && (this.listView1.SelectedItems.Count > 0))
                {
                    this.textBox2.Text = ((string) this.Tags1[this.listView1.SelectedIndices[0]]).Split(new char[] { '|' })[0].ToString();
                }
                if ((this.tabControl1.SelectedIndex == 1) && (this.listView2.SelectedItems.Count > 0))
                {
                    this.textBox2.Text = ((string) this.Tags2[this.listView2.SelectedIndices[0]]).Split(new char[] { '|' })[0].ToString();
                }
                if ((this.tabControl1.SelectedIndex == 2) && (this.listView3.SelectedItems.Count > 0))
                {
                    this.textBox2.Text = ((string) this.Tags3[this.listView3.SelectedIndices[0]]).Split(new char[] { '|' })[0].ToString();
                }
                if ((this.tabControl1.SelectedIndex == 3) && (this.listView4.SelectedItems.Count > 0))
                {
                    this.textBox2.Text = ((string) this.Tags4[this.listView4.SelectedIndices[0]]).Split(new char[] { '|' })[0].ToString();
                }
            }
            if (this.tabControl2.SelectedIndex == 1)
            {
                if ((this.tabControl3.SelectedIndex == 0) && (this.listView9.SelectedItems.Count > 0))
                {
                    this.textBox2.Text = ((string) this.Tags9[this.listView9.SelectedIndices[0]]).Split(new char[] { '|' })[0].ToString();
                }
                if ((this.tabControl3.SelectedIndex == 1) && (this.listView10.SelectedItems.Count > 0))
                {
                    this.textBox2.Text = ((string) this.Tags10[this.listView10.SelectedIndices[0]]).Split(new char[] { '|' })[0].ToString();
                }
                if ((this.tabControl3.SelectedIndex == 2) && (this.listView11.SelectedItems.Count > 0))
                {
                    this.textBox2.Text = ((string) this.Tags11[this.listView11.SelectedIndices[0]]).Split(new char[] { '|' })[0].ToString();
                }
                if ((this.tabControl3.SelectedIndex == 3) && (this.listView12.SelectedItems.Count > 0))
                {
                    this.textBox2.Text = ((string) this.Tags12[this.listView12.SelectedIndices[0]]).Split(new char[] { '|' })[0].ToString();
                }
                if ((this.tabControl3.SelectedIndex == 4) && (this.listView13.SelectedItems.Count > 0))
                {
                    this.textBox2.Text = ((string) this.Tags13[this.listView13.SelectedIndices[0]]).Split(new char[] { '|' })[0].ToString();
                }
                if ((this.tabControl3.SelectedIndex == 5) && (this.listView14.SelectedItems.Count > 0))
                {
                    this.textBox2.Text = ((string) this.Tags14[this.listView14.SelectedIndices[0]]).Split(new char[] { '|' })[0].ToString();
                }
            }
            if ((this.tabControl2.SelectedIndex == 2) && (this.listView15.SelectedItems.Count > 0))
            {
                this.textBox2.Text = ((string) this.Tags15[this.listView15.SelectedIndices[0]]).Split(new char[] { '|' })[0].ToString();
            }
        }
    }
}

