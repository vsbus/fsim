using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Parameters;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public sealed partial class fsMsusAndHcControl : fsCalculatorControl
    {
        #region Calculation Data

        enum fsCalculationOption
        {
            [Description("Densities")]
            DenisitiesCalculated,
            [Description("Concentrations")]
            ConcentreationsCalculated,
            [Description("Porosity / Kappa")]
            PorosityKappaCalculated,
            [Description("Machine Diameter")]
            MachineDiameterCalculated,
            [Description("Filter Element Diameter")]
            FilterElementDiameterCalculated,
            [Description("Machine Geometry")]
            MachineAreaBCalculated,
            [Description("Cake Height")]
            CakeHeightCalculated,
            [Description("Mass / Volume")]
            MassVolumeCalculated
        }

        #endregion

        #region Routine Data

        private readonly fsParametersGroup m_areaBGroup;

        private readonly List<fsCalculator> m_plainAreaCalculators = new List<fsCalculator>();
        private readonly List<fsCalculator> m_convexCylindricAreaCalculators = new List<fsCalculator>();
        private readonly List<fsCalculator> m_concaveCylindricAreaCalculators = new List<fsCalculator>();

        #endregion

        public fsMsusAndHcControl()
        {
            InitializeComponent();

            m_plainAreaCalculators.Add(new fsMsusHcPlainAreaCalculator());
            m_convexCylindricAreaCalculators.Add(new fsMsusHcConvexCylindricAreaCalculator());
            m_concaveCylindricAreaCalculators.Add(new fsMsusHcConcaveCylindricAreaCalculator());
            Calculators = m_plainAreaCalculators;

            var filtrateGroup = AddGroup(
                fsParameterIdentifier.FiltrateDensity);
            var densitiesGroup = AddGroup(
                fsParameterIdentifier.SolidsDensity,
                fsParameterIdentifier.SuspensionDensity);
            var concentrationGroup = AddGroup(
                fsParameterIdentifier.SolidsMassFraction,
                fsParameterIdentifier.SolidsVolumeFraction,
                fsParameterIdentifier.SolidsConcentration);
            var epsKappaGroup = AddGroup(
                fsParameterIdentifier.Porosity,
                fsParameterIdentifier.Kappa);
            var machineDiameterGroup = AddGroup(
                fsParameterIdentifier.MachineDiameter);
            m_areaBGroup = AddGroup(
                fsParameterIdentifier.FilterB,
                fsParameterIdentifier.FilterBOverDiameter,
                fsParameterIdentifier.FilterArea);
            var diameterFilterElementGroup = AddGroup(
                fsParameterIdentifier.FilterElementDiameter);
            var cakeHeightGroup = AddGroup(
                fsParameterIdentifier.CakeHeight);
            var massVolumeGroup = AddGroup(
                fsParameterIdentifier.SuspensionVolume,
                fsParameterIdentifier.SuspensionMass);

            var groups = new[] {
                filtrateGroup,
                densitiesGroup,
                concentrationGroup,
                epsKappaGroup,
                machineDiameterGroup,
                m_areaBGroup,
                diameterFilterElementGroup,
                cakeHeightGroup,
                massVolumeGroup
            };

            var colors = new[] {
                Color.FromArgb(255, 255, 230),
                Color.FromArgb(255, 230, 255)
            };

            for (int i = 0; i < groups.Length; ++i)
            {
                AddGroupToUI(dataGrid, groups[i], colors[i % colors.Length]);    
            }
            SetRowColor(dataGrid, ParameterToCell[fsParameterIdentifier.FilterArea].RowIndex, Color.FromArgb(255, 230, 230));
            SetRowColor(dataGrid, ParameterToCell[fsParameterIdentifier.FilterB].RowIndex, Color.FromArgb(255, 230, 230));
            SetRowColor(dataGrid, ParameterToCell[fsParameterIdentifier.FilterBOverDiameter].RowIndex, Color.FromArgb(255, 230, 230));

            fsMisc.FillList(machineTypeComboBox.Items, typeof(fsCakePorosityCalculator.fsMachineTypeOption));
            EstablishCalculationOption(fsCakePorosityCalculator.fsMachineTypeOption.PlainArea);
            AssignCalculationOptionAndControl(typeof(fsCakePorosityCalculator.fsMachineTypeOption), machineTypeComboBox);

            EstablishCalculationOption(fsCalculationOption.MassVolumeCalculated);
            FillCalculationComboBox();
            AssignCalculationOptionAndControl(typeof(fsCalculationOption), calculationOptionComboBox);

            UpdateGroupsInputInfoFromCalculationOptions();
            UpdateEquationsFromCalculationOptions();
            Recalculate();
            UpdateUIFromData();
            ConnectUIWithDataUpdating(dataGrid,
                machineTypeComboBox,
                calculationOptionComboBox);
        }
        
        #region Routine Methods

        private void FillCalculationComboBox()
        {
            var machineTypeOption =
              (fsCakePorosityCalculator.fsMachineTypeOption)
              CalculationOptions[typeof(fsCakePorosityCalculator.fsMachineTypeOption)];
            var restrictedOptions = new List<fsCalculationOption>();
            if (machineTypeOption == fsCakePorosityCalculator.fsMachineTypeOption.PlainArea)
            {
                restrictedOptions.Add(fsCalculationOption.MachineDiameterCalculated);
                restrictedOptions.Add(fsCalculationOption.FilterElementDiameterCalculated);
            }
            if (machineTypeOption == fsCakePorosityCalculator.fsMachineTypeOption.ConvexCylindric)
            {
                restrictedOptions.Add(fsCalculationOption.MachineDiameterCalculated);
            }
            if (machineTypeOption == fsCakePorosityCalculator.fsMachineTypeOption.ConcaveCylindric)
            {
                restrictedOptions.Add(fsCalculationOption.FilterElementDiameterCalculated);
            }

            var calculationOption = (fsCalculationOption)CalculationOptions[typeof(fsCalculationOption)];
            if (restrictedOptions.Contains(calculationOption))
            {
                EstablishCalculationOption(fsCalculationOption.MassVolumeCalculated);
            }

            fsMisc.FillList(calculationOptionComboBox.Items, typeof(fsCalculationOption));
            foreach (var restrictedOption in restrictedOptions)
            {
                calculationOptionComboBox.Items.Remove(fsMisc.GetEnumDescription(restrictedOption));
            }
            calculationOptionComboBox.Text =
               fsMisc.GetEnumDescription((fsCalculationOption)CalculationOptions[typeof(fsCalculationOption)]);
        }

        protected override void UpdateGroupsInputInfoFromCalculationOptions()
        {
            var calculationOption = (fsCalculationOption)CalculationOptions[typeof(fsCalculationOption)];
            fsParametersGroup calculateGroup = null;
            switch (calculationOption)
            {
                case fsCalculationOption.DenisitiesCalculated:
                    calculateGroup = ParameterToGroup[fsParameterIdentifier.SolidsDensity];
                    break;
                case fsCalculationOption.ConcentreationsCalculated:
                    calculateGroup = ParameterToGroup[fsParameterIdentifier.SolidsMassFraction];
                    break;
                case fsCalculationOption.PorosityKappaCalculated:
                    calculateGroup = ParameterToGroup[fsParameterIdentifier.Porosity];
                    break;
                case fsCalculationOption.MachineDiameterCalculated:
                    calculateGroup = ParameterToGroup[fsParameterIdentifier.MachineDiameter];
                    break;
                case fsCalculationOption.FilterElementDiameterCalculated:
                    calculateGroup = ParameterToGroup[fsParameterIdentifier.FilterElementDiameter];
                    break;
                case fsCalculationOption.MachineAreaBCalculated:
                    calculateGroup = ParameterToGroup[fsParameterIdentifier.FilterArea];
                    break;
                case fsCalculationOption.CakeHeightCalculated:
                    calculateGroup = ParameterToGroup[fsParameterIdentifier.CakeHeight];
                    break;
                case fsCalculationOption.MassVolumeCalculated:
                    calculateGroup = ParameterToGroup[fsParameterIdentifier.SuspensionMass];
                    break;
            }
            foreach (var group in ParameterToGroup.Values)
            {
                SetGroupInput(group, group != calculateGroup);
            }
        }

        private bool m_isBlockedCalculationOptionChanged = false;

        protected override void CalculationOptionChanged(object sender, EventArgs e)
        {
            if (m_isBlockedCalculationOptionChanged)
                return;

            m_isBlockedCalculationOptionChanged = true;

            UpdateCalculationOptionFromUI();
            FillCalculationComboBox();
           
            m_isBlockedCalculationOptionChanged = false;

            base.CalculationOptionChanged(sender, e);
        }

        protected override void UpdateUIFromData()
        {
            var machineTypeOption =
                (fsCakePorosityCalculator.fsMachineTypeOption)
                CalculationOptions[typeof(fsCakePorosityCalculator.fsMachineTypeOption)];
            List<fsCalculationOption> restrictedOptions = new List<fsCalculationOption>();
            if (machineTypeOption == fsCakePorosityCalculator.fsMachineTypeOption.PlainArea)
            {
                ParameterToCell[fsParameterIdentifier.MachineDiameter].OwningRow.Visible = false;
                ParameterToCell[fsParameterIdentifier.FilterElementDiameter].OwningRow.Visible = false;
                ParameterToCell[fsParameterIdentifier.FilterB].OwningRow.Visible = false;
                ParameterToCell[fsParameterIdentifier.FilterBOverDiameter].OwningRow.Visible = false;
            }
            if (machineTypeOption == fsCakePorosityCalculator.fsMachineTypeOption.ConvexCylindric)
            {
                ParameterToCell[fsParameterIdentifier.MachineDiameter].OwningRow.Visible = false;
                ParameterToCell[fsParameterIdentifier.FilterElementDiameter].OwningRow.Visible = true;
                ParameterToCell[fsParameterIdentifier.FilterB].OwningRow.Visible = false;
                ParameterToCell[fsParameterIdentifier.FilterBOverDiameter].OwningRow.Visible = false;
            }
            if (machineTypeOption == fsCakePorosityCalculator.fsMachineTypeOption.ConcaveCylindric)
            {
                ParameterToCell[fsParameterIdentifier.MachineDiameter].OwningRow.Visible = true;
                ParameterToCell[fsParameterIdentifier.FilterElementDiameter].OwningRow.Visible = false;
                ParameterToCell[fsParameterIdentifier.FilterB].OwningRow.Visible = true;
                ParameterToCell[fsParameterIdentifier.FilterBOverDiameter].OwningRow.Visible = true;
            }

            base.UpdateUIFromData();
        }

        protected override void UpdateEquationsFromCalculationOptions()
        {
            var machineTypeOption =
                (fsCakePorosityCalculator.fsMachineTypeOption)
                CalculationOptions[typeof (fsCakePorosityCalculator.fsMachineTypeOption)];
            if (machineTypeOption == fsCakePorosityCalculator.fsMachineTypeOption.PlainArea)
            {
                Calculators = m_plainAreaCalculators;
                m_areaBGroup.Representator = fsParameterIdentifier.FilterArea;
            }
            if (machineTypeOption == fsCakePorosityCalculator.fsMachineTypeOption.ConvexCylindric)
            {
                Calculators = m_convexCylindricAreaCalculators;
                m_areaBGroup.Representator = fsParameterIdentifier.FilterArea;
            }
            if (machineTypeOption == fsCakePorosityCalculator.fsMachineTypeOption.ConcaveCylindric)
            {
                Calculators = m_concaveCylindricAreaCalculators;
                m_areaBGroup.Representator = fsParameterIdentifier.FilterArea;
            }
        }

        #endregion
    }
}

