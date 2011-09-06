﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace UpdateHandler
{
    public partial class fsLabeledProgressBar : UserControl, fsIUpdatable
    {
        public fsLabeledProgressBar()
        {
            InitializeComponent();
        }

        #region fsIUpdatable Members


        public int Value
        {
            get
            {
                return progressBar1.Value;
            }
            set
            {
                progressBar1.Value = value;
                label1.Text = ((int)(value * 100.0 / progressBar1.Maximum + 0.5)).ToString() + "%";
            }
        }

        public int Maximum
        {
            get
            {
                return progressBar1.Maximum;
            }
            set
            {
                progressBar1.Maximum = value;
            }
        }

        #endregion
    }
}
