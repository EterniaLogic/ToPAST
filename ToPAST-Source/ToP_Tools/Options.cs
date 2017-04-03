namespace ToP_Tools
{
    using System;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Collections;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class Options : Form
    {
        private BindingSource bindingSource1;
        private Button button1;
        private Button button2;
        private Button button3;
        private IContainer components;
        private FolderBrowserDialog folderBrowserDialog1;
        private string[] IRLines = new string[] { "SQLHost=", "SQLUser=", "SQLPass=", "SQLAccountDB=", "SQLGameDB=", "DBType=", "Resource=" };
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label8;
        private System.Data.SqlClient.SqlConnection myConnection;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox8;

        public Options()
        {
            this.InitializeComponent();
            if (File.Exists(Environment.CurrentDirectory + "/settings.ini"))
            {
                settings.AddRange(File.ReadAllLines(Environment.CurrentDirectory + "/settings.ini"));
                /*this.Proxy = GetSetting("Proxy");
                this.ProxyHost = GetSetting("ProxyHost");
                this.ProxyUser = GetSetting("ProxyUser");
                this.serv = GetSetting("SQLHost");
                this.user = GetSetting("SQLUser");
                this.pwd = GetSetting("SQLPass");
                this.accdb = GetSetting("SQLAccountDB");
                this.gamedb = GetSetting("SQLGameDB");
                this.resource = GetSetting("Resources");
                this.resource = this.resource.Replace("{CURRENT}", Environment.CurrentDirectory);
                if (!this.resource.EndsWith(@"\") && !this.resource.EndsWith("/"))
                {
                    this.resource = this.resource + @"\";
                }*/
            }
        }
        ArrayList settings = new ArrayList();
        private string GetSetting(string setting)
        {
            string set = "null"; //Returns null if there is not setting like that.
            //Sort through settings...
            foreach (string e in settings)
            {
                try
                {
                    string[] arr = e.Split('=');
                    if (arr[0] == setting)
                    {
                        set = arr[1];
                    }
                }
                catch { }
            }
            return set;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string newLine = Environment.NewLine;
            string contents = this.IRLines[0] + this.textBox1.Text + newLine + this.IRLines[1] + this.textBox2.Text + newLine + this.IRLines[2] + this.textBox3.Text + newLine + this.IRLines[3] + this.textBox4.Text + newLine + this.IRLines[4] + this.textBox8.Text + newLine + this.IRLines[5] + this.textBox5.Text;
            File.WriteAllText(Environment.CurrentDirectory + "/settings.ini", contents);
            
            base.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "server=" + this.textBox1.Text + ";uid=" + this.textBox2.Text + ";pwd=" + this.textBox3.Text + ";";
            try
            {
                this.myConnection = new System.Data.SqlClient.SqlConnection(connectionString);
                this.myConnection.Open();
                MessageBox.Show("Connection Established!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "\n\n[Help] (Server-side only) This error could be caused by not turning on the 'SQL Browser' process. To do this, goto [Control Panel] -> [Administrative tools] -> [Services] and search for the 'SQL Browser' service. If you find it, open properties and press start. (Make sure it's set to Automatic)");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox5.Text = this.folderBrowserDialog1.SelectedPath;
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
            this.SuspendLayout();
            // 
            // Options
            // 
            this.ClientSize = new System.Drawing.Size(331, 315);
            this.Name = "Options";
            this.ResumeLayout(false);

        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            base.Hide();
        }
    }
}

