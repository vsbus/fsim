﻿using System.Drawing;
using Parameters;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public sealed partial class fsCakePorossityControl : fsCalculatorControl
    {
        #region Calculation Data

        private fsCakePorosityCalculator.fsSaltContentOption m_saltContentOption;
        private fsCakePorosityCalculator.fsSaturationOption m_saturationOption;
        private fsCakePorosityCalculator.fsMachineTypeOption m_machineTypeOption;

        #endregion

        private readonly fsCakePorosityCalculator m_calculator = new fsCakePorosityCalculator();

        public fsCakePorossityControl()
        {
            InitializeComponent();

            Calculators.Add(m_calculator);

            var machineDiameterGroup = AddGroup(fsParameterIdentifier.MachineDiameter);
            var areaBGroup = AddGroup(fsParameterIdentifier.FilterB,
                fsParameterIdentifier.FilterBOverDiameter,
                fsParameterIdentifier.FilterArea);
            var filterElementDiameterGroup = AddGroup(fsParameterIdentifier.FilterElementDiameter);
            var cakeHeightGroup = AddGroup(fsParameterIdentifier.CakeHeight);
            var wetGroup = AddGroup(fsParameterIdentifier.WetCakeMass);
            var dryGroup = AddGroup(fsParameterIdentifier.DryCakeMass);
            var concentrationGroup = AddGroup(fsParameterIdentifier.SolidsConcentration);
            var liquidGroup = AddGroup(fsParameterIdentifier.LiquidDensity);
            var solidsGroup = AddGroup(fsParameterIdentifier.SolidsDensity);
            var porosityGroup = AddGroup(fsParameterIdentifier.Porosity);

            var groups = new[] {
                machineDiameterGroup, 
                areaBGroup, 
                filterElementDiameterGroup,
                cakeHeightGroup,
                wetGroup, 
                dryGroup, 
                concentrationGroup,
                liquidGroup, 
                solidsGroup, 
                porosityGroup
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
            porosityGroup.IsInput = false;
            ParameterToCell[fsParameterIdentifier.Porosity].ReadOnly = true;

            SetRowColor(dataGrid, ParameterToCell[fsParameterIdentifier.FilterArea].RowIndex, Color.FromArgb(255, 230, 230));
            SetRowColor(dataGrid, ParameterToCell[fsParameterIdentifier.FilterB].RowIndex, Color.FromArgb(255, 230, 230));
            SetRowColor(dataGrid, ParameterToCell[fsParameterIdentifier.FilterBOverDiameter].RowIndex, Color.FromArgb(255, 230, 230));

            m_saltContentOption = fsCakePorosityCalculator.fsSaltContentOption.Neglected;
            m_saturationOption = fsCakePorosityCalculator.fsSaturationOption.NotSaturatedCake;
            m_machineTypeOption = fsCakePorosityCalculator.fsMachineTypeOption.PlainArea;
            UpdateCalculationOptionAndInputGroupsFromUI();

            ConnectUIWithDataUpdating(dataGrid);
            UpdateUIFromData();
        }

        #region Routine Methods

        override protected void UpdateCalculationOptionAndInputGroupsFromUI()
        {
            if (saltNeglectedRadioButton.Checked)
            {
                m_saltContentOption = fsCakePorosityCalculator.fsSaltContentOption.Neglected;
            }
            if (saltNotNeglectedRadioButton.Checked)
            {
                m_saltContentOption = fsCakePorosityCalculator.fsSaltContentOption.NotNeglected;
            }

            if (genaralCaseRadioButton.Checked)
            {
                m_saturationOption = fsCakePorosityCalculator.fsSaturationOption.NotSaturatedCake;
            }
            if (cakeSaturatedCaseRadioButton.Checked)
            {
                m_saturationOption = fsCakePorosityCalculator.fsSaturationOption.SaturatedCake;
            }

            if (plainAreaRadioButton.Checked)
            {
                m_machineTypeOption = fsCakePorosityCalculator.fsMachineTypeOption.PlainArea;
            }
            if (convexAreaRadioButton.Checked)
            {
                m_machineTypeOption = fsCakePorosityCalculator.fsMachineTypeOption.ConvexCylindric;
            }
            if (concaveAreaRadioButton.Checked)
            {
                m_machineTypeOption = fsCakePorosityCalculator.fsMachineTypeOption.ConcaveCylindric;
            }

            m_calculator.SaltContentOption = m_saltContentOption;
            m_calculator.SaturationOption = m_saturationOption;
            m_calculator.MachineTypeOption = m_machineTypeOption;
            m_calculator.RebuildEquationsList();

            base.UpdateCalculationOptionAndInputGroupsFromUI();
        }

        protected override void UpdateUIFromData()
        {
            if (m_saturationOption == fsCakePorosityCalculator.fsSaturationOption.NotSaturatedCake)
            {
                genaralCaseRadioButton.Checked = true;
                machineTypePanel.Visible = true;
            }
            if (m_saturationOption == fsCakePorosityCalculator.fsSaturationOption.SaturatedCake)
            {
                cakeSaturatedCaseRadioButton.Checked = true;
                machineTypePanel.Visible = false;
            }

            if (m_saltContentOption == fsCakePorosityCalculator.fsSaltContentOption.Neglected)
            {
                saltNeglectedRadioButton.Checked = true;
            }
            if (m_saltContentOption == fsCakePorosityCalculator.fsSaltContentOption.NotNeglected)
            {
                saltNotNeglectedRadioButton.Checked = true;
            }

            if (m_machineTypeOption == fsCakePorosityCalculator.fsMachineTypeOption.PlainArea)
            {
                plainAreaRadioButton.Checked = true;
            }
            if (m_machineTypeOption == fsCakePorosityCalculator.fsMachineTypeOption.ConvexCylindric)
            {
                convexAreaRadioButton.Checked = true;
            }
            if (m_machineTypeOption == fsCakePorosityCalculator.fsMachineTypeOption.ConcaveCylindric)
            {
                concaveAreaRadioButton.Checked = true;
            }

            bool isSaltContentNeglected = m_saltContentOption == fsCakePorosityCalculator.fsSaltContentOption.Neglected;
            bool isSaturated = m_saturationOption == fsCakePorosityCalculator.fsSaturationOption.SaturatedCake;

            bool geometryVisible = !isSaturated;
            bool filterElementDiameterVisible = m_machineTypeOption == fsCakePorosityCalculator.fsMachineTypeOption.ConvexCylindric;
            bool machineDiameterVisible = m_machineTypeOption == fsCakePorosityCalculator.fsMachineTypeOption.ConcaveCylindric;
            bool bAndBOverDVisible = m_machineTypeOption == fsCakePorosityCalculator.fsMachineTypeOption.ConcaveCylindric;
            ParameterToCell[fsParameterIdentifier.FilterArea].OwningRow.Visible = geometryVisible;
            ParameterToCell[fsParameterIdentifier.MachineDiameter].OwningRow.Visible = geometryVisible && machineDiameterVisible;
            ParameterToCell[fsParameterIdentifier.FilterElementDiameter].OwningRow.Visible = geometryVisible && filterElementDiameterVisible;
            ParameterToCell[fsParameterIdentifier.FilterB].OwningRow.Visible = geometryVisible && bAndBOverDVisible;
            ParameterToCell[fsParameterIdentifier.FilterBOverDiameter].OwningRow.Visible = geometryVisible && bAndBOverDVisible;

            ParameterToCell[fsParameterIdentifier.SolidsConcentration].OwningRow.Visible = !isSaltContentNeglected;
            ParameterToCell[fsParameterIdentifier.WetCakeMass].OwningRow.Visible = !isSaltContentNeglected || isSaturated;
            ParameterToCell[fsParameterIdentifier.LiquidDensity].OwningRow.Visible = !isSaltContentNeglected || isSaturated;
            ParameterToCell[fsParameterIdentifier.CakeHeight].OwningRow.Visible = !isSaturated;

            base.UpdateUIFromData();
        }

        protected override void ConnectUIWithDataUpdating(fmDataGrid.fmDataGrid grid)
        {
            base.ConnectUIWithDataUpdating(grid);
            saltNeglectedRadioButton.CheckedChanged += RadioButtonCheckedChanged;
            saltNotNeglectedRadioButton.CheckedChanged += RadioButtonCheckedChanged;
            genaralCaseRadioButton.CheckedChanged += RadioButtonCheckedChanged;
            cakeSaturatedCaseRadioButton.CheckedChanged += RadioButtonCheckedChanged;
            plainAreaRadioButton.CheckedChanged += RadioButtonCheckedChanged;
            convexAreaRadioButton.CheckedChanged += RadioButtonCheckedChanged;
            concaveAreaRadioButton.CheckedChanged += RadioButtonCheckedChanged;
        }

        #endregion
    }
}