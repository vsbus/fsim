using System.ComponentModel;
using System.Drawing;
using Parameters;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public sealed partial class fsPermeabilityControl : fsCalculatorControl
    {
        enum fsCalculationOption
        {
            [Description("Pc0, rc0, alpha0")]
            CalcPc0Rc0Alpha0,
            [Description("nc")]
            CalcNc,
            [Description("Pressure (Dp)")]
            CalcPressure,
            [Description("Pc, rc, alpha")]
            CalcPcRcAlpha
        }

        public fsPermeabilityControl()
        {
            InitializeComponent();

            Calculators.Add(new fsPermeabilityCalculator());

            var solidsGroup = AddGroup(
                fsParameterIdentifier.SolidsDensity);
            var porosityGroup = AddGroup(
                fsParameterIdentifier.Porosity);
            var pc0Rc0A0Group = AddGroup(
                fsParameterIdentifier.Pc0,
                fsParameterIdentifier.Rc0,
                fsParameterIdentifier.Alpha0);
            var ncGroup = AddGroup(
                fsParameterIdentifier.Nc);
            var pressureGroup = AddGroup(
                fsParameterIdentifier.Pressure);
            var pcRcAGroup = AddGroup(
                fsParameterIdentifier.Pc,
                fsParameterIdentifier.Rc,
                fsParameterIdentifier.Alpha);

            AddGroupToUI(dataGrid, solidsGroup, Color.FromArgb(230, 230, 255));
            AddGroupToUI(dataGrid, porosityGroup, Color.FromArgb(255, 255, 230));
            AddGroupToUI(dataGrid, pc0Rc0A0Group, Color.FromArgb(230, 230, 255));
            AddGroupToUI(dataGrid, ncGroup, Color.FromArgb(255, 255, 230));
            AddGroupToUI(dataGrid, pressureGroup, Color.FromArgb(230, 230, 255));
            AddGroupToUI(dataGrid, pcRcAGroup, Color.FromArgb(255, 230, 230));

            AssignCalculationOption(fsCalculationOption.CalcPc0Rc0Alpha0, pc0rc0alpha0RadioButton, pc0Rc0A0Group);
            AssignCalculationOption(fsCalculationOption.CalcPressure, pressureRadioButton, pressureGroup);
            AssignCalculationOption(fsCalculationOption.CalcNc, ncRadioButton, ncGroup);
            AssignCalculationOption(fsCalculationOption.CalcPcRcAlpha, pcrcalphaRadioButton, pcRcAGroup);

            CalculationOption = fsCalculationOption.CalcPcRcAlpha;
            fsMisc.FillComboBox(calculateSelectionComboBox.Items, typeof(fsCalculationOption));
            UpdateUIFromData();

            UpdateCalculationOptionAndInputGroupsFromUI();

            ConnectUIWithDataUpdating(dataGrid);
            UpdateUIFromData();
        }

        #region Routine Methods

        override protected void UpdateCalculationOptionAndInputGroupsFromUI()
        {
            base.UpdateCalculationOptionAndInputGroupsFromUI();
            CalculationOption =
                (fsCalculationOption)fsMisc.GetEnum(typeof(fsCalculationOption), calculateSelectionComboBox.Text);
        }

        protected override void UpdateUIFromData()
        {
            base.UpdateUIFromData();
            calculateSelectionComboBox.Text = fsMisc.GetEnumDescription((fsCalculationOption)CalculationOption);
        }

        protected override void ConnectUIWithDataUpdating(fmDataGrid.fmDataGrid grid)
        {
            base.ConnectUIWithDataUpdating(grid);
            calculateSelectionComboBox.TextChanged += RadioButtonCheckedChanged;
        }

        #endregion
    }
}
