﻿using System;
using System.Windows.Forms;
using Parameters;

namespace CalculatorModules
{
    public partial class fsOptionsAndCommentsCalculatorControl : fsCalculatorControl
    {
        public fsOptionsAndCommentsCalculatorControl()
        {
            InitializeComponent();
            splitContainer1.Panel2Collapsed = true;
        }

        private bool m_isDiagramVisible;

        public bool GetDiagramVisible()
        {
            return m_isDiagramVisible;
        }

        public void SetDiagramVisible(bool isVisible)
        {
            if (m_isDiagramVisible == isVisible)
            {
                return;
            }

            m_isDiagramVisible = isVisible;

            Control controlToResize = ControlToResizeForExpanding ?? Parent;

            if (isVisible)
            {
                rightPanel.Visible = true;
                showHideCommnetsButton.Text = @"<";
                if (controlToResize != null)
                {
                    splitContainer1.Panel2Collapsed = false;
                    int w = splitContainer1.Width;
                    int a = splitContainer1.Panel1.Width;
                    int s = splitContainer1.SplitterWidth;
                    int newWidth = (2 * w * w + s * a) / (2 * a);
                    controlToResize.Width += newWidth - w;
                }   
            }
            else
            {
                rightPanel.Visible = false;
                showHideCommnetsButton.Text = @">";
                if (controlToResize != null)
                {
                    controlToResize.Width -= splitContainer1.Panel2.Width + splitContainer1.SplitterWidth;
                }
                splitContainer1.Panel2Collapsed = true;
                rightPanel.Width = 0;
            }
        }

        // This property allows user to see 'expand' button
        public bool AllowDiagramView
        {
            set { showHideDiagramPanel.Visible = value; }
        }

        protected void SetDefaultDiagram(
            fsParameterIdentifier xAxisParameter,
            fsParameterIdentifier yAxisParameter,
            fsParameterIdentifier y2AxisParameter)
        {
            fsTableAndChart1.SetDefaultDiagram(xAxisParameter, yAxisParameter, y2AxisParameter);
        }

        #region Internal Routine

        protected override void Recalculate()
        {
            base.Recalculate();
            fsTableAndChart1.AssignCalculatorData(Values,
                Groups,
                ParameterToGroup,
                Calculators);
            fsTableAndChart1.RefreshAndRecalculateAll();
        }

        private void Button1Click(object sender, EventArgs e)
        {
            SetDiagramVisible(!m_isDiagramVisible);
        }

        #endregion
    }
}