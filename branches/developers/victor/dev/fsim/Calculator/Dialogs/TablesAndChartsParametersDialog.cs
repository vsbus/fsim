using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Parameters;

namespace Calculator.Dialogs
{
    public partial class TablesAndChartsParametersDialog : Form
    {
        public TablesAndChartsParametersDialog()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        internal void FillAxis(
            ListView axisListView,
            ICollection<fsParameterIdentifier> involvedParameters,
            ICollection<fsParameterIdentifier> checkedParameters)
        {
            foreach (fsParameterIdentifier p in involvedParameters)
            {
                axisListView.Items.Add(p.Name).Checked = checkedParameters.Contains(p);
            }
        }

        internal void FillAxis(
            ICollection<fsParameterIdentifier> involvedParameters,
            CalculatorModules.User_Controls.fsTableAndChart.fsAllowedParameters allowedParameters)
        {
            FillAxis(xAxisListView, involvedParameters, allowedParameters.xAxis);
            FillAxis(yAxisListView, involvedParameters, allowedParameters.yAxis);
            FillAxis(y2AxisListView, involvedParameters, allowedParameters.y2Axis);
        }
    }
}
