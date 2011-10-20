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
                fsParameterIdentifier.CakePorosity,
                fsParameterIdentifier.CakeSaturation,
                fsParameterIdentifier.CakeMoistureContent);

            AddGroupToUI(dataGrid, liquidGroup, Color.FromArgb(230, 255, 255));
            AddGroupToUI(dataGrid, solidsGroup, Color.FromArgb(255, 230, 255));
            AddGroupToUI(dataGrid, porosityGroup, Color.FromArgb(255, 255, 230));

            fsMisc.FillList(calculationOptionComboBox.Items, typeof(fsCalculationOption));
            EstablishCalculationOption(fsCalculationOption.CakeMoistureContent);
            AssignCalculationOptionAndControl(typeof(fsCalculationOption), calculationOptionComboBox);

            UpdateGroupsInputInfoFromCalculationOptions();
            UpdateEquationsFromCalculationOptions();
            Recalculate();
            UpdateUIFromData();
            ConnectUIWithDataUpdating(dataGrid);
        }

        protected override void UpdateEquationsFromCalculationOptions()
        {
            // this control has only one equation
        }

        protected override void UpdateGroupsInputInfoFromCalculationOptions()
        {
            // this control hasn't calculation options
        }
    }
}
