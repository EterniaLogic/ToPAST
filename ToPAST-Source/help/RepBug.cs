using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToP_Tools.help
{
    public partial class RepBug : Form
    {
        public RepBug()
        {
            InitializeComponent();
            label1.Text = TMAIN.tr[332];
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length >= 1 && textBox1.Text.Length >= 1 && richTextBox1.Text.Length >= 1)
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                MessageBox.Show("Disabled");
                base.Close();
            }
            else
            {
                MessageBox.Show("One of the boxes isn't filled.");
            }
        }
    }
}
