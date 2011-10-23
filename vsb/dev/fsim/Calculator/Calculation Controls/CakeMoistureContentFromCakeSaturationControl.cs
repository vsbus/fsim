using System.ComponentModel;
using System.Drawing;
using Parameters;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public sealed partial class fsCakeMoistureContentFromCakeSaturationControl : fsCalculatorControl
    {
        #region Calculation Option

        enum fsCalculationOption
        {
            [Description("Cake Porosity")]
            CakePorosity,
            [Description("Cake Saturation")]
            CakeSaturation,
            [Description("Cake Moisture Content")]
            CakeMoistureContent
        }

        #endregion

        public fsCakeMoistureContentFromCakeSaturationControl()
        {
            InitializeComponent();

            Calculators.Add(new fsRfFromCakeSaturationCalculator());

            var liquidGroup = AddGroup(
                fsParameterIdentifier.LiquidDensity);
            var solidsGroup = AddGroup(
                fsParameterIdentifier.SolidsDensity);
            var porosityGroup = AddGroup(
                fsParameterIdentifier.CakePorosity);
            var saturationGroup = AddGroup(
                fsParameterIdentifier.CakeSaturation);
            var rfGroup = AddGroup(
                fsParameterIdentifier.CakeMoistureContent);

            var groups = new[] {
                liquidGroup,
                solidsGroup,
                porosityGroup,
                saturationGroup,
                rfGroup
            };

            var colors = new[] {
                Color.FromArgb(255, 255, 230),
                Color.FromArgb(255, 230, 255)
            };

            for (int i = 0; i < groups.Length; ++i)
            {
                groups[i].IsInput = true;
                AddGroupToUI(dataGrid, groups[i], colors[i % colors.Length]);
            }
            rfGroup.IsInput = false;
            ParameterToCell[fsParameterIdentifier.CakeMoistureContent].ReadOnly = true;

            fsMisc.FillList(calculationOptionComboBox.Items, typeof(fsCalculationOption));
            EstablishCalculationOption(fsCalculationOption.CakeMoistureContent);
            AssignCalculationOptionAndControl(typeof(fsCalculationOption), calculationOptionComboBox);

            UpdateGroupsInputInfoFromCalculationOptions();
            UpdateEquationsFromCalculationOptions();
            Recalculate();
            UpdateUIFromData();
            ConnectUIWithDataUpdating(dataGrid, calculationOptionComboBox);
        }

        protected override void UpdateEquationsFromCalculationOptions()
        {
            // this control has only one equation
        }

        protected override void UpdateGroupsInputInfoFromCalculationOptions()
        {
            var calculationOption = (fsCalculationOption)CalculationOptions[typeof(fsCalculationOption)];
            fsParametersGroup calculateGroup = null;
            switch (calculationOption)
            {
                case fsCalculationOption.CakeMoistureContent:
                    calculateGroup = ParameterToGroup[fsParameterIdentifier.CakeMoistureContent];
                    break;
                case fsCalculationOption.CakePorosity:
                    calculateGroup = ParameterToGroup[fsParameterIdentifier.CakePorosity];
                    break;
                case fsCalculationOption.CakeSaturation:
                    calculateGroup = ParameterToGroup[fsParameterIdentifier.CakeSaturation];
                    break;
            }
            foreach (var group in ParameterToGroup.Values)
            {
                SetGroupInput(group, group != calculateGroup);
            }
        }
    }
}
