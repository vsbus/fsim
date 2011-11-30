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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rightPanel.Visible)
            {
                rightPanel.Visible = false;
                showHideCommnetsButton.Text = ">";
                if (Parent != null)
                {
                    Parent.Width -= rightPanel.Width;
                }
                rightPanel.Width = 0;
            }
            else
            {
                rightPanel.Visible = true;
                showHideCommnetsButton.Text = "<";
                Width = leftPanel.Width;
                rightPanel.Width = 200;
                if (Parent != null)
                {
                    Parent.Width += rightPanel.Width;
                }
            }
        }
    }
}
