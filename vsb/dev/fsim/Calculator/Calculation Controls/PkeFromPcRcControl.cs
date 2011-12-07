﻿using System.ComponentModel;
using System.Drawing;
using Parameters;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public sealed partial class fsPkeFromPcRcControl : fsOptionsOneTableAndCommentsCalculatorControl
    {
        private readonly fsPkeFromPcRcCalculator m_calculator = new fsPkeFromPcRcCalculator();

        public fsPkeFromPcRcControl()
        {
            InitializeComponent();

            Calculators.Add(m_calculator);

            var permeabilityGroup = AddGroup(
                fsParameterIdentifier.CakePermeability);
            var resistanceGroup = AddGroup(
                fsParameterIdentifier.CakeResistance);
            var alphaGroup = AddGroup(
                fsParameterIdentifier.CakeResistanceAlpha);
            var rhosGroup = AddGroup(
                fsParameterIdentifier.SolidsDensity);
            var epsGroup = AddGroup(
                fsParameterIdentifier.CakePorosity);
            var rhosBulkGroup = AddGroup(
                fsParameterIdentifier.BulkDensityDrySolids);
            var sigmaGroup = AddGroup(
                fsParameterIdentifier.SurfaceTensionLiquidOfCake);
            var pkestGroup = AddGroup(
                fsParameterIdentifier.StandartCapillaryPressure);
            var pkeGroup = AddGroup(
                fsParameterIdentifier.CapillaryPressure);

            var groups = new[]
            {
                permeabilityGroup,
                resistanceGroup,
                alphaGroup,
                rhosGroup,
                epsGroup,
                rhosBulkGroup,
                sigmaGroup,
                pkestGroup,
                pkeGroup
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
            SetGroupInput(pkeGroup, false);

            fsMisc.FillList(inputCakeComboBox.Items, typeof(fsCalculationOptions.fsCakeInputOption));
            AssignCalculationOptionAndControl(typeof(fsCalculationOptions.fsCakeInputOption), inputCakeComboBox);
            EstablishCalculationOption(fsCalculationOptions.fsCakeInputOption.PermeabilityPc);

            fsMisc.FillList(enterSolidsDensityComboBox.Items, typeof(fsCalculationOptions.fsEnterSolidsDensity));
            AssignCalculationOptionAndControl(typeof(fsCalculationOptions.fsEnterSolidsDensity), enterSolidsDensityComboBox);
            EstablishCalculationOption(fsCalculationOptions.fsEnterSolidsDensity.BulkDensityDrySolids);

            UpdateGroupsInputInfoFromCalculationOptions();
            UpdateEquationsFromCalculationOptions();
            Recalculate();
            UpdateUIFromData();
            ConnectUIWithDataUpdating(dataGrid,
                inputCakeComboBox,
                enterSolidsDensityComboBox);
        }

        #region Routine Methods

        protected override void UpdateGroupsInputInfoFromCalculationOptions()
        {
            m_calculator.CakeInputOption =
                (fsCalculationOptions.fsCakeInputOption)
                CalculationOptions[typeof (fsCalculationOptions.fsCakeInputOption)];
            m_calculator.EnterSolidsOption =
                (fsCalculationOptions.fsEnterSolidsDensity)
                CalculationOptions[typeof (fsCalculationOptions.fsEnterSolidsDensity)];
            m_calculator.RebuildEquationsList();
        }

        protected override void UpdateEquationsFromCalculationOptions()
        {
            // this control uses only one calculator
        }

        protected override void UpdateUIFromData()
        {
            var cakeInputOption = (fsCalculationOptions.fsCakeInputOption)CalculationOptions[typeof(fsCalculationOptions.fsCakeInputOption)];
            ParameterToCell[fsParameterIdentifier.CakePermeability].OwningRow.Visible =
                cakeInputOption == fsCalculationOptions.fsCakeInputOption.PermeabilityPc;
            ParameterToCell[fsParameterIdentifier.CakeResistance].OwningRow.Visible =
                cakeInputOption == fsCalculationOptions.fsCakeInputOption.ResistanceRc;
            ParameterToCell[fsParameterIdentifier.CakeResistanceAlpha].OwningRow.Visible =
                cakeInputOption == fsCalculationOptions.fsCakeInputOption.ResistanceAlpha;

            bool isAlpha = cakeInputOption == fsCalculationOptions.fsCakeInputOption.ResistanceAlpha;
            enterSolidsDensityLabel.Visible = isAlpha;
            enterSolidsDensityComboBox.Visible = isAlpha;

            var enterSolidsDensityOption = (fsCalculationOptions.fsEnterSolidsDensity)CalculationOptions[typeof(fsCalculationOptions.fsEnterSolidsDensity)];
            bool isBulk = enterSolidsDensityOption == fsCalculationOptions.fsEnterSolidsDensity.BulkDensityDrySolids;
            ParameterToCell[fsParameterIdentifier.BulkDensityDrySolids].OwningRow.Visible = isAlpha && isBulk;
            ParameterToCell[fsParameterIdentifier.SolidsDensity].OwningRow.Visible = isAlpha && !isBulk;
            ParameterToCell[fsParameterIdentifier.CakePorosity].OwningRow.Visible = isAlpha && !isBulk;

            base.UpdateUIFromData();
        }

        #endregion
    }
}