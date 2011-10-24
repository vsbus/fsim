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
    public sealed partial class CakeWashOutContentControl : fsCalculatorControl
    {
        #region Calculation Option

        private readonly fsCakeWashOutContentCalculator m_calculator = new fsCakeWashOutContentCalculator();

        #endregion

        public CakeWashOutContentControl()
        {
            InitializeComponent();

            Calculators.Add(m_calculator);

            var wetMassGroup = AddGroup(fsParameterIdentifier.WetCakeMass);
            var dryMassGroup = AddGroup(fsParameterIdentifier.DryCakeMass);
            var liquidGroup = AddGroup(fsParameterIdentifier.LiquidMass);
            var cmGroup = AddGroup(fsParameterIdentifier.SolidsMassFraction);
            var cGroup = AddGroup(fsParameterIdentifier.SolidsConcentration);
            var rholGroup = AddGroup(fsParameterIdentifier.LiquidDensity);
            var phGroup = AddGroup(fsParameterIdentifier.pH);
            var outGroup = AddGroup(
                fsParameterIdentifier.pHcake,
                fsParameterIdentifier.CakeMoistureContent,
                fsParameterIdentifier.CakeWashOutContent);

            var groups = new[] {
                wetMassGroup,
                dryMassGroup,
                liquidGroup,
                cmGroup,
                cGroup,
                rholGroup,
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

            fsMisc.FillList(fromComboBox.Items, typeof(fsCakeWashOutContentCalculator.fsFromCalculationOption));
            EstablishCalculationOption(fsCakeWashOutContentCalculator.fsFromCalculationOption.WashOutConcentration);
            AssignCalculationOptionAndControl(typeof(fsCakeWashOutContentCalculator.fsFromCalculationOption), fromComboBox);

            fsMisc.FillList(washOutContentComboBox.Items, typeof(fsCakeWashOutContentCalculator.fsWashOutContentOption));
            EstablishCalculationOption(fsCakeWashOutContentCalculator.fsWashOutContentOption.AsMassFraction);
            AssignCalculationOptionAndControl(typeof(fsCakeWashOutContentCalculator.fsWashOutContentOption), washOutContentComboBox);

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
                (fsCakeWashOutContentCalculator.fsFromCalculationOption)
                CalculationOptions[typeof(fsCakeWashOutContentCalculator.fsFromCalculationOption)];
            m_calculator.WashOutContentOption =
                (fsCakeWashOutContentCalculator.fsWashOutContentOption)
                CalculationOptions[typeof(fsCakeWashOutContentCalculator.fsWashOutContentOption)];
            m_calculator.RebuildEquationsList();
        }

        protected override void UpdateUIFromData()
        {
            var fromContentOption =
                (fsCakeWashOutContentCalculator.fsFromCalculationOption)
                CalculationOptions[typeof(fsCakeWashOutContentCalculator.fsFromCalculationOption)];
            bool isFromWashOutConcentration = fromContentOption == fsCakeWashOutContentCalculator.fsFromCalculationOption.WashOutConcentration;

            washOutContentLabel.Visible = isFromWashOutConcentration;
            washOutContentComboBox.Visible = isFromWashOutConcentration;

            var washOutContentOption =
                (fsCakeWashOutContentCalculator.fsWashOutContentOption)
                CalculationOptions[typeof(fsCakeWashOutContentCalculator.fsWashOutContentOption)];
            bool isCmInput = washOutContentOption ==
                             fsCakeWashOutContentCalculator.fsWashOutContentOption.AsMassFraction;

            ParameterToCell[fsParameterIdentifier.SolidsMassFraction].OwningRow.Visible = isFromWashOutConcentration && isCmInput;
            ParameterToCell[fsParameterIdentifier.SolidsConcentration].OwningRow.Visible = isFromWashOutConcentration && !isCmInput;
            ParameterToCell[fsParameterIdentifier.LiquidDensity].OwningRow.Visible = !isFromWashOutConcentration || !isCmInput;
            ParameterToCell[fsParameterIdentifier.pH].OwningRow.Visible = !isFromWashOutConcentration;
            ParameterToCell[fsParameterIdentifier.pHcake].OwningRow.Visible = !isFromWashOutConcentration;

            base.UpdateUIFromData();
        }

        #endregion
    }
}
