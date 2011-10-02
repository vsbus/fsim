using System.Drawing;
using Parameters;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public partial class fsPermeabilityControl : fsCalculatorControl
    {
        enum fsCalculationOption
        {
            CalcPc0Rc0Alpha0,
            CalcPressure,
            CalcNc,
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
            UpdateCalculationOptionAndInputGroups();

            ConnectUIWithDataUpdating(dataGrid);
            UpdateUIFromData();
        }

    }
}
