using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Parameters;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public partial class PermeabilityControl : CalculatorControl
    {
        #region Routine Data

        private ParametersGroup solidsGroup;
        private ParametersGroup porosityGroup;
        private ParametersGroup pc0rc0a0Group;
        private ParametersGroup ncGroup;
        private ParametersGroup pressureGroup;
        private ParametersGroup pcrcaGroup;

        #endregion

        public PermeabilityControl()
        {
            InitializeComponent();

            Calculators.Add(new fsPermeabilityCalculator());

            solidsGroup = AddGroup(
                fsParameterIdentifier.SolidsDensity);
            porosityGroup = AddGroup(
                fsParameterIdentifier.Porosity);
            pc0rc0a0Group = AddGroup(
                fsParameterIdentifier.Pc0,
                fsParameterIdentifier.Rc0,
                fsParameterIdentifier.Alpha0);
            ncGroup = AddGroup(
                fsParameterIdentifier.Nc);
            pressureGroup = AddGroup(
                fsParameterIdentifier.Pressure);
            pcrcaGroup = AddGroup(
                fsParameterIdentifier.Pc,
                fsParameterIdentifier.Rc,
                fsParameterIdentifier.Alpha);

            AddGroupToUI(dataGrid, solidsGroup, Color.FromArgb(230, 230, 255));
            AddGroupToUI(dataGrid, porosityGroup, Color.FromArgb(255, 255, 230));
            AddGroupToUI(dataGrid, pc0rc0a0Group, Color.FromArgb(230, 230, 255));
            AddGroupToUI(dataGrid, ncGroup, Color.FromArgb(255, 255, 230));
            AddGroupToUI(dataGrid, pressureGroup, Color.FromArgb(230, 230, 255));
            AddGroupToUI(dataGrid, pcrcaGroup, Color.FromArgb(255, 230, 230));

            UpdateCalculationOptionAndInputGroups();
            ConnectUIWithDataUpdating();
            UpdateUIFromData();
        }

        #region Routine Methods

        protected override void UpdateCalculationOptionAndInputGroups()
        {
            foreach (var g in Groups)
            {
                SetGroupInput(g, g != pcrcaGroup);
            }
        }

        protected override void  UpdateUIFromData()
        {
            UpdateCellForeColors();
            WriteValuesToDataGrid();
        }

        protected override void ConnectUIWithDataUpdating()
        {
            dataGrid.CellValueChangedByUser += new DataGridViewCellEventHandler(dataGrid_CellValueChangedByUser);
        }

        void dataGrid_CellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView)
            {
                ProcessNewEntry(((DataGridView)dataGrid).CurrentCell);
            }
        }

        #endregion
    }
}
