﻿using System.Drawing;
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

            fsParametersGroup wetMassGroup = AddGroup(fsParameterIdentifier.WetCakeMass);
            fsParametersGroup liquidGroup = AddGroup(fsParameterIdentifier.LiquidMass);
            fsParametersGroup cwmGroup = AddGroup(fsParameterIdentifier.WashOutMassFraction);
            fsParametersGroup rholGroup = AddGroup(fsParameterIdentifier.LiquidDensity);
            fsParametersGroup cwGroup = AddGroup(fsParameterIdentifier.WashOutConcentration);
            fsParametersGroup phGroup = AddGroup(fsParameterIdentifier.Ph);
            fsParametersGroup dryMassGroup = AddGroup(fsParameterIdentifier.DryCakeMass);
            fsParametersGroup outGroup = AddGroup(
                fsParameterIdentifier.PHcake,
                fsParameterIdentifier.CakeMoistureContent,
                fsParameterIdentifier.CakeWashOutContent);

            var groups = new[]
                             {
                                 wetMassGroup,
                                 liquidGroup,
                                 rholGroup,
                                 cwGroup,
                                 cwmGroup,
                                 dryMassGroup,
                                 phGroup,
                                 outGroup
                             };

            var colors = new[]
                             {
                                 Color.FromArgb(255, 255, 230),
                                 Color.FromArgb(255, 230, 255)
                             };

            for (int i = 0; i < groups.Length; ++i)
            {
                AddGroupToUI(dataGrid, groups[i], colors[i % colors.Length]);
                SetGroupInput(groups[i], true);
            }
            SetGroupInput(outGroup, false);

            fsMisc.FillList(fromComboBox.Items, typeof (fsCalculationOptions.fsFromCalculationOption));
            EstablishCalculationOption(fsCalculationOptions.fsFromCalculationOption.WashOutContent);
            AssignCalculationOptionAndControl(typeof (fsCalculationOptions.fsFromCalculationOption), fromComboBox);

            fsMisc.FillList(washOutContentComboBox.Items, typeof (fsCalculationOptions.fsWashOutContentOption));
            EstablishCalculationOption(fsCalculationOptions.fsWashOutContentOption.AsConcentration);
            AssignCalculationOptionAndControl(typeof (fsCalculationOptions.fsWashOutContentOption),
                                              washOutContentComboBox);

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
                CalculationOptions[typeof (fsCalculationOptions.fsFromCalculationOption)];
            m_calculator.WashOutContentOption =
                (fsCalculationOptions.fsWashOutContentOption)
                CalculationOptions[typeof (fsCalculationOptions.fsWashOutContentOption)];
            m_calculator.RebuildEquationsList();
        }

        protected override void UpdateUIFromData()
        {
            var fromContentOption =
                (fsCalculationOptions.fsFromCalculationOption)
                CalculationOptions[typeof (fsCalculationOptions.fsFromCalculationOption)];
            bool isFromWashOutConcentration = fromContentOption ==
                                              fsCalculationOptions.fsFromCalculationOption.WashOutContent;

            washOutContentLabel.Visible = isFromWashOutConcentration;
            washOutContentComboBox.Visible = isFromWashOutConcentration;

            var washOutContentOption =
                (fsCalculationOptions.fsWashOutContentOption)
                CalculationOptions[typeof (fsCalculationOptions.fsWashOutContentOption)];
            bool isCmInput = washOutContentOption ==
                             fsCalculationOptions.fsWashOutContentOption.AsMassFraction;

            ParameterToCell[fsParameterIdentifier.WashOutMassFraction].OwningRow.Visible = isFromWashOutConcentration &&
                                                                                           isCmInput;
            ParameterToCell[fsParameterIdentifier.WashOutConcentration].OwningRow.Visible =
                isFromWashOutConcentration && !isCmInput;
            ParameterToCell[fsParameterIdentifier.LiquidDensity].OwningRow.Visible = !isFromWashOutConcentration ||
                                                                                     !isCmInput;
            ParameterToCell[fsParameterIdentifier.Ph].OwningRow.Visible = !isFromWashOutConcentration;
            ParameterToCell[fsParameterIdentifier.PHcake].OwningRow.Visible = !isFromWashOutConcentration;

            base.UpdateUIFromData();
        }

        #endregion
    }
}