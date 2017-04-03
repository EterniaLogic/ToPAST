using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ToP_Tools
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            //Y = new Thread(new ThreadStart(yy));
            //Y.Start();
            //this.Show();

            //this.Hide();
            //Thread.Sleep(2000);
            //y1 = new TMAIN();
            //y1.Show();
            /*while (true)
            {
                Thread.Sleep(1000);
                if (TMAIN.ActiveForm.Name == "TMAIN") { this.Dispose(); break; }
            }*/
            //this.BringToFront();
            label1.Text = TMAIN.tr[321]+": "+TMAIN.Version;
        }
        //public TMAIN y1;//=new TMAIN();
    }
}
