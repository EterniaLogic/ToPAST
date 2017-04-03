using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ToP_Tools.help
{
    public partial class IMGVIEWER : Form
    {
        public IMGVIEWER()
        {
            InitializeComponent();
            groupPanel1.Text = TMAIN.tr[354];
            buttonX1.Text = TMAIN.tr[355];
        }
        public void SetImg(string toset)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IMGVIEWER));
            Image u = (Image)(resources.GetObject(toset));
            try { this.Size = new Size(u.Size.Width + 12, u.Size.Height + 27); }
            catch { }
            if (this.Size.Height >= Screen.PrimaryScreen.Bounds.Height)
            {
                
                this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            }
            this.Location = new Point(0, 0);
            pictureBox1.Image = u; 
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
