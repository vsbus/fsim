using System;
using System.Windows.Forms;
using Parameters;
using Units;

namespace fsUIControls
{
    public partial class fsMachineSettings : UserControl
    {
        public fsMachineSettings()
        {
            InitializeComponent();
        }

        private void MachineSettingsLoad(object sender, EventArgs e)
        {
            var parameters = new[]
            {
                fsParameterIdentifier.ViscosityFiltrate,
                fsParameterIdentifier.MotherLiquidDensity,
                fsParameterIdentifier.SolidsDensity,
                fsParameterIdentifier.SuspensionSolidsMassFraction,
                fsParameterIdentifier.SuspensionSolidsVolumeFraction,
                fsParameterIdentifier.CakePorosity0,
                fsParameterIdentifier.FilterArea,
                fsParameterIdentifier.PressureDifference,
                fsParameterIdentifier.FiltrationTime
            };

            foreach (fsParameterIdentifier parameter in parameters)
            {
                int index = dataGrid.Rows.Add();
                
                dataGrid.Rows[index].Cells[0].Value = parameter.FullName;

                var comboBoxCell = (DataGridViewComboBoxCell) dataGrid.Rows[index].Cells[1];
                comboBoxCell.FlatStyle = FlatStyle.Flat;
                fsUnit[] units = parameter.MeasurementCharacteristic.Units;
                var unitsNames = new string[units.Length];
                for (int i = 0; i < units.Length; ++i)
                {
                    unitsNames[i] = units[i].Name;
                }
                comboBoxCell.Items.AddRange(unitsNames);
                comboBoxCell.Value = parameter.MeasurementCharacteristic.CurrentUnit.Name;
                
                dataGrid.Rows[index].Cells[2].Value = 0;
                
                dataGrid.Rows[index].Cells[3].Value = 100;
            }
        }

        private void DataGridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == UnitsColumn.Index)
            {
                dataGrid.BeginEdit(true);
                var comboBox = (ComboBox)dataGrid.EditingControl;
                comboBox.DroppedDown = true;
            }
        }
    }
}
