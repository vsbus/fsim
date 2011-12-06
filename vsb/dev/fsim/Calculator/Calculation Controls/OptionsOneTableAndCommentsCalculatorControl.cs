using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator.Calculation_Controls
{
    public partial class fsOptionsOneTableAndCommentsCalculatorControl : fsCalculatorControl
    {
        public bool AllowCommentsView
        {
            set
            {
                showHideCommnetsButton.Visible = value;
            }
        }

        public fsOptionsOneTableAndCommentsCalculatorControl()
        {
            InitializeComponent();
            splitContainer1.Panel2Collapsed = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rightPanel.Visible)
            {
                rightPanel.Visible = false;
                showHideCommnetsButton.Text = ">";
                if (Parent != null)
                {
                    Parent.Width -= splitContainer1.Panel2.Width + splitContainer1.SplitterWidth;
                }
                splitContainer1.Panel2Collapsed = true;
                rightPanel.Width = 0;
            }
            else
            {
                rightPanel.Visible = true;
                showHideCommnetsButton.Text = "<";
                if (Parent != null)
                {
                    //Parent.Width * (Parent.Width + splitContainer1.Panel2.Width + splitContainer1.SplitterWidth) / 
                    splitContainer1.Panel2Collapsed = false;
                    int w = splitContainer1.Width;
                    int a = splitContainer1.Panel1.Width;
                    int s = splitContainer1.SplitterWidth;
                    int newWidth = (2 * w * w + s * a) / (2 * a);
                    Parent.Width += newWidth - w;
                }
                
            }
        }
    }
}
