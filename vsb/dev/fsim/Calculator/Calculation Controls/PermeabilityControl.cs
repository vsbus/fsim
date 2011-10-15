using System.ComponentModel;
using System.Drawing;
using Parameters;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public sealed partial class fsPermeabilityControl : fsCalculatorControl
    {

        #region Calculation Option

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

        #endregion

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

            fsMisc.FillList(calculationOptionComboBox.Items, typeof(fsCalculationOption));
            AssignCalculationOptionAndControl(typeof(fsCalculationOption), calculationOptionComboBox);
            EstablishCalculationOption(fsCalculationOption.CalcPcRcAlpha);

            UpdateGroupsInputInfoFromCalculationOptions();
            UpdateEquationsFromCalculationOptions();
            Recalculate();
            UpdateUIFromData();
            ConnectUIWithDataUpdating(dataGrid, calculationOptionComboBox);
        }

        #region Routine Methods

        protected override void UpdateGroupsInputInfoFromCalculationOptions()
        {
            var calculationOption = (fsCalculationOption)CalculationOptions[typeof(fsCalculationOption)];
            fsParametersGroup calculateGroup = null;
            switch (calculationOption)
            {
                case fsCalculationOption.CalcNc:
                    calculateGroup = ParameterToGroup[fsParameterIdentifier.Nc];
                    break;
                case fsCalculationOption.CalcPc0Rc0Alpha0:
                    calculateGroup = ParameterToGroup[fsParameterIdentifier.Pc0];
                    break;
                case fsCalculationOption.CalcPcRcAlpha:
                    calculateGroup = ParameterToGroup[fsParameterIdentifier.Pc];
                    break;
                case fsCalculationOption.CalcPressure:
                    calculateGroup = ParameterToGroup[fsParameterIdentifier.Pressure];
                    break;
            }
            foreach (var group in ParameterToGroup.Values)
            {
                SetGroupInput(group, group != calculateGroup);
            }
        }

        protected override void UpdateEquationsFromCalculationOptions()
        {
            // this control uses only one calculator
        }

        #endregion
    }
}
