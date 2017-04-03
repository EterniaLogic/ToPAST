using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ToP_Tools.help
{
    public partial class help : Form
    {
        public help()
        {
            InitializeComponent();
            //ScaleImg(ref reflectionImage1);
            reflectionImage1.Image = imageList1.Images[1];
            reflectionImage2.Image = imageList1.Images[1];
            reflectionImage3.Image = imageList1.Images[6];
            reflectionImage4.Image = imageList1.Images[7];
            reflectionImage5.Image = imageList1.Images[8];
            reflectionImage6.Image = imageList1.Images[9];
            reflectionImage7.Image = imageList1.Images[11];

            reflectionImage8.Image = imageList1.Images[2];
            reflectionImage9.Image = imageList1.Images[5];
            reflectionImage10.Image = imageList1.Images[3];
            reflectionImage11.Image = imageList1.Images[4];
            
            reflectionImage12.Image = imageList1.Images[12];
            reflectionImage13.Image = imageList1.Images[13];
            reflectionImage24.Image = imageList1.Images["02.gif"];
            reflectionImage23.Image = imageList1.Images["03.gif"];
            reflectionImage22.Image = imageList1.Images["04.gif"];
            reflectionImage21.Image = imageList1.Images["05.gif"];
            reflectionImage26.Image = imageList1.Images["01.gif"];

            //Fix inside color Scheme
            //tabControl2.ColorScheme = DevComponents.DotNetBar.
            
            rev();
        }
        private void rev()
        {
            this.tabItem2.Text = TMAIN.tr[105];
            this.groupPanel3.Text = TMAIN.tr[102];
            this.groupPanel1.Text = TMAIN.tr[268];
            this.buttonX6.Text = TMAIN.tr[263];
            this.buttonX3.Text = TMAIN.tr[267];
            this.buttonX5.Text = TMAIN.tr[264];
            this.buttonX2.Text = TMAIN.tr[266];
            this.buttonX1.Text = TMAIN.tr[265];
            this.tabItem4.Text = TMAIN.tr[257];
            this.groupPanel5.Text = TMAIN.tr[102];
            this.groupPanel6.Text = TMAIN.tr[252];
            this.tabItem5.Text = TMAIN.tr[274];
            this.groupPanel7.Text = TMAIN.tr[102];
            this.groupPanel8.Text = TMAIN.tr[252];
            this.tabItem3.Text = TMAIN.tr[262];
            this.groupPanel4.Text = TMAIN.tr[102];
            this.groupPanel2.Text = TMAIN.tr[252];
            this.tabItem6.Text = TMAIN.tr[261];
            this.tabItem1.Text = TMAIN.tr[260];
            this.groupPanel15.Text = TMAIN.tr[102];
            this.groupPanel16.Text = TMAIN.tr[268];
            this.buttonX9.Text = TMAIN.tr[253];
            this.buttonX10.Text = TMAIN.tr[254];
            this.tabItem14.Text = TMAIN.tr[257];
            this.groupPanel11.Text = TMAIN.tr[102];
            this.groupPanel12.Text = TMAIN.tr[252];
            this.tabItem12.Text = TMAIN.tr[259];
            this.groupPanel13.Text = TMAIN.tr[102];
            this.groupPanel14.Text = TMAIN.tr[252];
            this.tabItem13.Text = TMAIN.tr[255];
            this.tabItem7.Text = TMAIN.tr[256];
            this.groupPanel17.Text = TMAIN.tr[102];
            this.tabItem11.Text = TMAIN.tr[106];
            this.groupPanel23.Text = TMAIN.tr[102];
            this.tabItem20.Text = TMAIN.tr[152];
            this.groupPanel24.Text = TMAIN.tr[102];
            this.tabItem25.Text = TMAIN.tr[26];
            this.groupPanel28.Text = TMAIN.tr[102];
            this.tabItem26.Text = TMAIN.tr[168];
            this.groupPanel27.Text = TMAIN.tr[102];
            this.tabItem27.Text = TMAIN.tr[182];
            this.groupPanel26.Text = TMAIN.tr[102];
            this.tabItem28.Text = TMAIN.tr[122];
            this.groupPanel25.Text = TMAIN.tr[102];
            this.tabItem29.Text = TMAIN.tr[46];
            this.tabItem21.Text = TMAIN.tr[166];
            this.tabItem15.Text = TMAIN.tr[284];
            this.groupPanel21.Text = TMAIN.tr[102];
            this.tabItem24.Text = TMAIN.tr[55];
            this.tabItem18.Text = TMAIN.tr[34];
            this.groupPanel19.Text = TMAIN.tr[102];
            this.tabItem22.Text = TMAIN.tr[68];
            this.groupPanel20.Text = TMAIN.tr[102];
            this.tabItem23.Text = TMAIN.tr[275];
            this.tabItem17.Text = TMAIN.tr[69];
            this.groupPanel18.Text = TMAIN.tr[102];
            this.tabItem16.Text = TMAIN.tr[198];
            this.groupPanel22.Text = TMAIN.tr[102];
            this.tabItem19.Text = TMAIN.tr[32];
            this.tabItem10.Text = TMAIN.tr[269];
            this.groupPanel10.Text = TMAIN.tr[102];
            this.tabItem9.Text = TMAIN.tr[278];
            this.groupPanel9.Text = TMAIN.tr[102];
            this.tabItem8.Text = TMAIN.tr[258];
            this.fileToolStripMenuItem.Text = TMAIN.tr[76];
            this.exitToolStripMenuItem.Text = TMAIN.tr[77];
            this.Text = TMAIN.tr[101];



            this.reflectionLabel2.Text = TMAIN.tr[227];
            this.reflectionLabel22.Text = TMAIN.tr[228];
            this.reflectionLabel18.Text = TMAIN.tr[229];
            this.reflectionLabel21.Text = TMAIN.tr[230];
            this.reflectionLabel20.Text = TMAIN.tr[231];
            this.reflectionLabel19.Text = TMAIN.tr[232];
            this.reflectionLabel17.Text = TMAIN.tr[233];
            this.reflectionLabel15.Text = TMAIN.tr[234];
            this.reflectionLabel14.Text = TMAIN.tr[235];
            this.labelX14.Text = TMAIN.tr[236];
            this.reflectionLabel13.Text = TMAIN.tr[237];
            this.reflectionLabel12.Text = TMAIN.tr[238];
            this.reflectionLabel11.Text = TMAIN.tr[239];
            this.labelX11.Text = TMAIN.tr[240];
            this.reflectionLabel16.Text = TMAIN.tr[241];
            this.labelX16.Text = TMAIN.tr[242];
            this.reflectionLabel1.Text = TMAIN.tr[243];
            this.reflectionLabel4.Text = TMAIN.tr[244];
            this.reflectionLabel5.Text = TMAIN.tr[245];
            this.reflectionLabel3.Text = TMAIN.tr[246];
            this.reflectionLabel9.Text = TMAIN.tr[247];
            this.reflectionLabel7.Text = TMAIN.tr[248];
            this.reflectionLabel8.Text = TMAIN.tr[249];
            this.reflectionLabel10.Text = TMAIN.tr[250];
            this.reflectionLabel6.Text = TMAIN.tr[251];
            this.labelX22.Text = TMAIN.tr[345];
            this.labelX21.Text = TMAIN.tr[344];
            this.labelX20.Text = TMAIN.tr[343];
            this.labelX19.Text = TMAIN.tr[341];
            this.labelX15.Text = TMAIN.tr[338];
            this.labelX13.Text = TMAIN.tr[337];
            this.labelX12.Text = TMAIN.tr[336];
            this.labelX10.Text = TMAIN.tr[335];
            this.labelX6.Text = TMAIN.tr[349];
            this.labelX2.Text = TMAIN.tr[342];
            this.labelX1.Text = TMAIN.tr[334];
            this.labelX9.Text = TMAIN.tr[352];
            this.labelX7.Text = TMAIN.tr[350];
            this.labelX5.Text = TMAIN.tr[348];
            this.labelX3.Text = TMAIN.tr[346];
            this.labelX4.Text = TMAIN.tr[347];
            this.labelX17.Text = TMAIN.tr[339];
            this.labelX18.Text = TMAIN.tr[340];
            this.labelX8.Text = TMAIN.tr[351];

        }
        private void listViewEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewEx1_Click(sender, e);
        }
        IMGVIEWER IMG = new IMGVIEWER();
        private void listViewEx1_Click(object sender, EventArgs e)
        {
            //show Image viewer...
            try { IMG.SetImg((string)((Control)sender).Tag); 
                IMG.Show(); 
                IMG.BringToFront(); }
            catch { }

        }

        private void reflectionImage4_Click(object sender, EventArgs e)
        {

        }

        private void reflectionImage8_MouseClick(object sender, MouseEventArgs e)
        {
            listViewEx1_Click(sender, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://go.microsoft.com/fwlink/?linkid=65212");
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://go.microsoft.com/fwlink/?linkid=65110");
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.microsoft.com/express/Database/");
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.microsoft.com/downloads/details.aspx?familyid=08e52ac2-1d62-45f6-9a4a-4b76a8564a2b&displaylang=en#filelist");
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://forum.ragezone.com/f440/guide-mini-setup-1-35-server-494256/");
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.megaupload.com/?d=WJ0TWRS9");

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.megaupload.com/?d=IXM1KPPG");
        }

        private void labelX17_Click(object sender, EventArgs e)
        {

        }

    }
}
