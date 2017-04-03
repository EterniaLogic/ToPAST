namespace ToP_Tools
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class RenderGrid : UserControl
    {
        private int _wheelHPos;
        private int _wheelPos;
        private IContainer components;
        private ArrayList Labels = new ArrayList();
        private Panel panel1;
        private Panel panel2;
        private ArrayList Texts = new ArrayList();
        private VScrollBar vScrollBar1;
        private const int WHEEL_DELTA = 120;

        public RenderGrid()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public string[] GetData()
        {
            string[] strArray = new string[this.Texts.Count];
            for (int i = 0; i < this.Texts.Count; i++)
            {
                strArray[i] = ((TextBox) this.panel2.Controls[(string) this.Texts[i]]).Text;
            }
            return strArray;
        }

        private void InitializeComponent()
        {
            this.vScrollBar1 = new VScrollBar();
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.vScrollBar1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            this.vScrollBar1.Location = new Point(0x111, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new Size(0x11, 300);
            this.vScrollBar1.TabIndex = 0;
            this.vScrollBar1.Scroll += new ScrollEventHandler(this.vScrollBar1_Scroll);
            this.panel1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x110, 300);
            this.panel1.TabIndex = 1;
            this.panel2.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.panel2.Location = new Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x108, 2);
            this.panel2.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            //base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.vScrollBar1);
            base.Controls.Add(this.panel1);
            base.Name = "RenderGrid";
            base.Size = new Size(290, 300);
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        public void InsertGrid(string[] ToBeInserted)
        {
            for (int i = 0; i < this.Texts.Count; i++)
            {
                TextBox box = (TextBox) this.panel2.Controls[(string) this.Texts[i]];
                try
                {
                    box.Text = ToBeInserted[i];
                }
                catch
                {
                    box.Text = "";
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            this._wheelPos += e.Delta;
            while (this._wheelPos >= 120)
            {
                this.ScrollLine(-1);
                this._wheelPos -= 120;
            }
            while (this._wheelPos <= -120)
            {
                this.ScrollLine(1);
                this._wheelPos += 120;
            }
        }

        private void ScrollLine(int numLines)
        {
            this.vScrollBar1.Value = Math.Max(this.vScrollBar1.Minimum, Math.Min(this.vScrollBar1.Maximum, this.vScrollBar1.Value + numLines));
            this.panel2.Top = -Convert.ToInt32((double) (Convert.ToDouble(this.vScrollBar1.Value) * (Convert.ToDouble(this.panel2.Height) / Convert.ToDouble(this.vScrollBar1.Maximum))));
        }

        public void SetGrid(string[] ToBeRendered)
        {
            this.panel2.Controls.Clear();
            this.Texts.Clear();
            this.Labels.Clear();
            int num = 0x17;
            int num2 = 100;
            int num3 = 0;
            foreach (string str in ToBeRendered)
            {
                Label label = new Label {
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = str,
                    Height = num + 1,
                    Width = num2,
                    Top = num3 * num,
                    Name = "N" + num3,
                    Left = 0,
                    BorderStyle = BorderStyle.FixedSingle
                };
                this.panel2.Controls.Add(label);
                this.Labels.Add(label.Name);
                TextBox box = new TextBox {
                    Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top,
                    Width = (this.panel2.Width - num2) - 10,
                    Top = (num3 * num) + 2,
                    Left = num2 + 5,
                    Name = "T" + num3
                };
                this.panel2.Controls.Add(box);
                this.Texts.Add(box.Name);
                this.panel2.Height += num;
                if (this.panel2.Height > (this.panel1.Height + 3))
                {
                    this.vScrollBar1.Visible = true;
                    this.vScrollBar1.Maximum = this.panel2.Height / 0x10;
                }
                else
                {
                    this.vScrollBar1.Visible = false;
                }
                num3++;
            }
        }

        private void ShowArray(string[] ARRay)
        {
            string str = "";
            for (int i = 0; i < ARRay.Length; i++)
            {
                str = str + ARRay[i] + "\n";
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.panel2.Top = -Convert.ToInt32((double) (Convert.ToDouble(this.vScrollBar1.Value) * (Convert.ToDouble(this.panel2.Height) / Convert.ToDouble(this.vScrollBar1.Maximum))));
        }
    }
}

