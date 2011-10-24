using System.Drawing;
using Parameters;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public sealed partial class fsCakeMoistureContentFromWetAndDryCakeMassControl : fsCalculatorControl
    {
        private readonly fsRfFromWetDryCakeCalculator m_calculator = new fsRfFromWetDryCakeCalculator();

        public fsCakeMoistureContentFromWetAndDryCakeMassControl()
        {
            InitializeComponent();

            Calculators.Add(m_calculator);

            var wetMassGroup = AddGroup(fsParameterIdentifier.WetCakeMass);
            var dryMassGroup = AddGroup(fsParameterIdentifier.DryCakeMass);
            var cmGroup = AddGroup(fsParameterIdentifier.SaltMassFractionInTheCakeLiquid);
            var cGroup = AddGroup(fsParameterIdentifier.SaltConcentrationInTheCakeLiquid);
            var rholGroup = AddGroup(fsParameterIdentifier.LiquidDensity);
            var rfGroup = AddGroup(fsParameterIdentifier.CakeMoistureContent);
            
            var groups = new[] {
                wetMassGroup,
                dryMassGroup,
                cmGroup,
                cGroup,
                rholGroup,
                rfGroup
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
            SetGroupInput(rfGroup, false);

            fsMisc.FillList(saltContentComboBox.Items, typeof(fsRfFromWetDryCakeCalculator.fsSaltContentOption));
            EstablishCalculationOption(fsRfFromWetDryCakeCalculator.fsSaltContentOption.Neglected);
            AssignCalculationOptionAndControl(typeof(fsRfFromWetDryCakeCalculator.fsSaltContentOption), saltContentComboBox);

            fsMisc.FillList(concentrationComboBox.Items, typeof(fsRfFromWetDryCakeCalculator.fsConcentrationOption));
            EstablishCalculationOption(fsRfFromWetDryCakeCalculator.fsConcentrationOption.SolidsMassFraction);
            AssignCalculationOptionAndControl(typeof(fsRfFromWetDryCakeCalculator.fsConcentrationOption), concentrationComboBox);

            UpdateGroupsInputInfoFromCalculationOptions();
            UpdateEquationsFromCalculationOptions();
            Recalculate();
            UpdateUIFromData();
            ConnectUIWithDataUpdating(dataGrid,
                saltContentComboBox,
                concentrationComboBox);
        }

        #region Routine Methods

        protected override void UpdateGroupsInputInfoFromCalculationOptions()
        {
            // this control has only one calculation group -- RF
        }

        protected override void UpdateEquationsFromCalculationOptions()
        {
            m_calculator.SaltContentOption =
                (fsRfFromWetDryCakeCalculator.fsSaltContentOption)
                CalculationOptions[typeof (fsRfFromWetDryCakeCalculator.fsSaltContentOption)];
            m_calculator.ConcentrationOption =
                (fsRfFromWetDryCakeCalculator.fsConcentrationOption)
                CalculationOptions[typeof (fsRfFromWetDryCakeCalculator.fsConcentrationOption)];
            m_calculator.RebuildEquationsList();
        }

        protected override void UpdateUIFromData()
        {
            var saltContentOption =
                (fsRfFromWetDryCakeCalculator.fsSaltContentOption)
                CalculationOptions[typeof (fsRfFromWetDryCakeCalculator.fsSaltContentOption)];
            bool isSaltContConsidered = saltContentOption == fsRfFromWetDryCakeCalculator.fsSaltContentOption.Considered;

            concentrationLabel.Visible = isSaltContConsidered;
            concentrationComboBox.Visible = isSaltContConsidered;

            var concentrationOption =
                (fsRfFromWetDryCakeCalculator.fsConcentrationOption)
                CalculationOptions[typeof (fsRfFromWetDryCakeCalculator.fsConcentrationOption)];
            bool isCmInput = concentrationOption ==
                             fsRfFromWetDryCakeCalculator.fsConcentrationOption.SolidsMassFraction;

            ParameterToCell[fsParameterIdentifier.SaltMassFractionInTheCakeLiquid].OwningRow.Visible = isSaltContConsidered && isCmInput;
            ParameterToCell[fsParameterIdentifier.SaltConcentrationInTheCakeLiquid].OwningRow.Visible = isSaltContConsidered && !isCmInput;
            ParameterToCell[fsParameterIdentifier.LiquidDensity].OwningRow.Visible = isSaltContConsidered && !isCmInput;

            base.UpdateUIFromData();
        }

        #endregion
    }
}
