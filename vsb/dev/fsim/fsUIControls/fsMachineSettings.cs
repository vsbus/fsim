using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Parameters;
using ParametersIdentifiers.Ranges;
using Value;

namespace fsUIControls
{
    public partial class fsMachineSettings : UserControl
    {
        public Dictionary<fsParameterIdentifier, fsRange> Ranges;
        private Dictionary<DataGridViewRow, fsParameterIdentifier> m_rowToParameter;

        public fsMachineSettings()
        {
            InitializeComponent();
        }

        private void MachineSettingsLoad(object sender, EventArgs e)
        {
            Ranges = new Dictionary<fsParameterIdentifier, fsRange>
                         {
                             {fsParameterIdentifier.FiltrateDensity, new fsRange(0, 100)},
                             {fsParameterIdentifier.SolidsDensity, new fsRange(0, 100)},
                             {fsParameterIdentifier.SuspensionDensity, new fsRange(0, 100)},
                             {fsParameterIdentifier.SuspensionSolidsMassFraction, new fsRange(0, 100)},
                             {fsParameterIdentifier.SuspensionSolidsVolumeFraction, new fsRange(0, 100)},
                             {fsParameterIdentifier.SuspensionSolidsConcentration, new fsRange(0, 100)},
                             {fsParameterIdentifier.CakePorosity0, new fsRange(0, 100)},
                             {fsParameterIdentifier.FilterArea, new fsRange(0, 100)},
                             {fsParameterIdentifier.PressureDifference, new fsRange(0, 100)},
                             {fsParameterIdentifier.FiltrationTime, new fsRange(0, 100)},
                             {fsParameterIdentifier.CakeHeight, new fsRange(0, 100)}
                         };

            DisplayRangesInTable();
        }

        private void DisplayRangesInTable()
        {
            m_rowToParameter = new Dictionary<DataGridViewRow, fsParameterIdentifier>();
            foreach (fsParameterIdentifier parameter in Ranges.Keys)
            {
                int index = dataGrid.Rows.Add();
                dataGrid.Rows[index].Cells[0].Value = parameter.FullName;
                dataGrid.Rows[index].Cells[1].Value = parameter.MeasurementCharacteristic.CurrentUnit.Name;
                dataGrid.Rows[index].Cells[2].Value = Ranges[parameter].From;
                dataGrid.Rows[index].Cells[3].Value = Ranges[parameter].To;
                m_rowToParameter.Add(dataGrid.Rows[index], parameter);
            }
        }

        private void DataGridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == UnitsColumn.Index)
            {
                dataGrid.BeginEdit(true);
                var comboBox = (ComboBox) dataGrid.EditingControl;
                comboBox.DroppedDown = true;
            }
        }

        private void DataGridCellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            fsParameterIdentifier parameter = m_rowToParameter[dataGrid.Rows[e.RowIndex]];
            Ranges[parameter].From = fsValue.ObjectToValue(dataGrid[2, e.RowIndex].Value);
            Ranges[parameter].To = fsValue.ObjectToValue(dataGrid[3, e.RowIndex].Value);
        }
    }
}