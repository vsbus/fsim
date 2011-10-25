﻿using System.Drawing;
using Parameters;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public sealed partial class fsCakeWashOutContentControl : fsCalculatorControl
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
            var phGroup = AddGroup(fsParameterIdentifier.pH);
            var dryMassGroup = AddGroup(fsParameterIdentifier.DryCakeMass);
            var outGroup = AddGroup(
                fsParameterIdentifier.pHcake,
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

            fsMisc.FillList(fromComboBox.Items, typeof(fsCakeWashOutContentCalculator.fsFromCalculationOption));
            EstablishCalculationOption(fsCakeWashOutContentCalculator.fsFromCalculationOption.WashOutContent);
            AssignCalculationOptionAndControl(typeof(fsCakeWashOutContentCalculator.fsFromCalculationOption), fromComboBox);

            fsMisc.FillList(washOutContentComboBox.Items, typeof(fsCakeWashOutContentCalculator.fsWashOutContentOption));
            EstablishCalculationOption(fsCakeWashOutContentCalculator.fsWashOutContentOption.AsConcentration);
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
            bool isFromWashOutConcentration = fromContentOption == fsCakeWashOutContentCalculator.fsFromCalculationOption.WashOutContent;

            washOutContentLabel.Visible = isFromWashOutConcentration;
            washOutContentComboBox.Visible = isFromWashOutConcentration;

            var washOutContentOption =
                (fsCakeWashOutContentCalculator.fsWashOutContentOption)
                CalculationOptions[typeof(fsCakeWashOutContentCalculator.fsWashOutContentOption)];
            bool isCmInput = washOutContentOption ==
                             fsCakeWashOutContentCalculator.fsWashOutContentOption.AsMassFraction;

            ParameterToCell[fsParameterIdentifier.WashOutMassFraction].OwningRow.Visible = isFromWashOutConcentration && isCmInput;
            ParameterToCell[fsParameterIdentifier.WashOutConcentration].OwningRow.Visible = isFromWashOutConcentration && !isCmInput;
            ParameterToCell[fsParameterIdentifier.LiquidDensity].OwningRow.Visible = !isFromWashOutConcentration || !isCmInput;
            ParameterToCell[fsParameterIdentifier.pH].OwningRow.Visible = !isFromWashOutConcentration;
            ParameterToCell[fsParameterIdentifier.pHcake].OwningRow.Visible = !isFromWashOutConcentration;

            base.UpdateUIFromData();
        }

        #endregion
    }
}
