using System.Drawing;
using Parameters;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public sealed partial class fsCakeWashOutContentControl : fsOptionsOneTableAndCommentsCalculatorControl
    {
        private readonly fsCakeWashOutContentCalculator m_calculator = new fsCakeWashOutContentCalculator();

        public fsCakeWashOutContentControl()
        {
            InitializeComponent();

            Calculators.Add(m_calculator);

            var wetMassGroup = AddGroup(fsParameterIdentifier.WetCakeMass);
            var liquidGroup = AddGroup(fsParameterIdentifier.LiquidMass);
            var cwmGroup = AddGroup(fsParameterIdentifier.WashOutMassFraction);
            var rholGroup = AddGroup(fsParameterIdentifier.LiquidDensity);
            var cwGroup = AddGroup(fsParameterIdentifier.WashOutConcentration);
            var phGroup = AddGroup(fsParameterIdentifier.Ph);
            var dryMassGroup = AddGroup(fsParameterIdentifier.DryCakeMass);
            var outGroup = AddGroup(
                fsParameterIdentifier.PHcake,
                fsParameterIdentifier.CakeMoistureContent,
                fsParameterIdentifier.CakeWashOutContent);

            var groups = new[] {
                wetMassGroup,
                liquidGroup,
                rholGroup,
                cwGroup,
                cwmGroup,
                dryMassGroup,
                phGroup,
                outGroup
            };

            var colors = new[] {
                Color.FromArgb(255, 255, 230),
                Color.FromArgb(255, 230, 255)
            };

            for (int i = 0; i < groups.Length; ++i)
            {
                AddGroupToUI(dataGrid, groups[i], colors[i % colors.Length]);
                SetGroupInput(groups[i], true);
            }
            SetGroupInput(outGroup, false);

            fsMisc.FillList(fromComboBox.Items, typeof(fsCalculationOptions.fsFromCalculationOption));
            EstablishCalculationOption(fsCalculationOptions.fsFromCalculationOption.WashOutContent);
            AssignCalculationOptionAndControl(typeof(fsCalculationOptions.fsFromCalculationOption), fromComboBox);

            fsMisc.FillList(washOutContentComboBox.Items, typeof(fsCalculationOptions.fsWashOutContentOption));
            EstablishCalculationOption(fsCalculationOptions.fsWashOutContentOption.AsConcentration);
            AssignCalculationOptionAndControl(typeof(fsCalculationOptions.fsWashOutContentOption), washOutContentComboBox);

            UpdateGroupsInputInfoFromCalculationOptions();
            UpdateEquationsFromCalculationOptions();
            Recalculate();
            UpdateUIFromData();
            ConnectUIWithDataUpdating(dataGrid,
                fromComboBox,
                washOutContentComboBox);
        }

        #region Routine Methods

        protected override void UpdateGroupsInputInfoFromCalculationOptions()
        {
            // this control has only one calculation group -- RF
        }

        protected override void UpdateEquationsFromCalculationOptions()
        {
            m_calculator.FromCalculationOption =
                (fsCalculationOptions.fsFromCalculationOption)
                CalculationOptions[typeof(fsCalculationOptions.fsFromCalculationOption)];
            m_calculator.WashOutContentOption =
                (fsCalculationOptions.fsWashOutContentOption)
                CalculationOptions[typeof(fsCalculationOptions.fsWashOutContentOption)];
            m_calculator.RebuildEquationsList();
        }

        protected override void UpdateUIFromData()
        {
            var fromContentOption =
                (fsCalculationOptions.fsFromCalculationOption)
                CalculationOptions[typeof(fsCalculationOptions.fsFromCalculationOption)];
            bool isFromWashOutConcentration = fromContentOption == fsCalculationOptions.fsFromCalculationOption.WashOutContent;

            washOutContentLabel.Visible = isFromWashOutConcentration;
            washOutContentComboBox.Visible = isFromWashOutConcentration;

            var washOutContentOption =
                (fsCalculationOptions.fsWashOutContentOption)
                CalculationOptions[typeof(fsCalculationOptions.fsWashOutContentOption)];
            bool isCmInput = washOutContentOption ==
                             fsCalculationOptions.fsWashOutContentOption.AsMassFraction;

            ParameterToCell[fsParameterIdentifier.WashOutMassFraction].OwningRow.Visible = isFromWashOutConcentration && isCmInput;
            ParameterToCell[fsParameterIdentifier.WashOutConcentration].OwningRow.Visible = isFromWashOutConcentration && !isCmInput;
            ParameterToCell[fsParameterIdentifier.LiquidDensity].OwningRow.Visible = !isFromWashOutConcentration || !isCmInput;
            ParameterToCell[fsParameterIdentifier.Ph].OwningRow.Visible = !isFromWashOutConcentration;
            ParameterToCell[fsParameterIdentifier.PHcake].OwningRow.Visible = !isFromWashOutConcentration;

            base.UpdateUIFromData();
        }

        #endregion
    }
}
