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
                try
                {
                    //message.
                    //message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1);
                    //message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "brclancy111@hotmail.com");
                    //message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "182SIXTxd");
                    message.To.Add("brclancy111@hotmail.com");
                    message.Subject = "(ToPAST Bug REPORT): "+"["+textBox2.Text+"] - "+textBox1.Text;
                    message.From = new System.Net.Mail.MailAddress(textBox2.Text + "@ToPAST_Bug_Reporter.com");
                    message.Body = richTextBox1.Text;
                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com",587);
                    smtp.Credentials = new System.Net.NetworkCredential("brclancy111@gmail.com", "182Txd");
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                }
                catch(Exception e1) { MessageBox.Show("Error in sending bug request\n\n"+e1.Message); }
                base.Close();
            }
            else
            {
                MessageBox.Show("One of the boxes isn't filled.");
            }
        }
    }
}
