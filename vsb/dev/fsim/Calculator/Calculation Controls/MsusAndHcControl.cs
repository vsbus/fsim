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
    public partial class MsusAndHcControl : fsCalculatorControl
    {
        #region Calculation Data

        enum fsMachineTypeOption
        {
            PLAIN_AREA,
            CONVEX_CYLINDRIC,
            CONCAVE_CYLINDRIC
        }
        private fsMachineTypeOption machineTypeOption;

        enum fsCalculationOption
        {
            DENISITIES_CALCULATED,
            CONCENTREATIONS_CALCULATED,
            POROSITY_KAPPA_CALCULATED,
            MACHINE_DIAMETER_CALCULATED,
            MACHINE_A_B_CALCULATED,
            CAKE_HEIGHT_CALCULATED,
            MASS_VOLUME_CALCULATED
        }

        #endregion

        #region Routine Data

        private ParametersGroup areaBGroup;

        private List<fsCalculator> plainAreaCalculators = new List<fsCalculator>();
        private List<fsCalculator> convexCylindricAreaCalculators = new List<fsCalculator>();
        private List<fsCalculator> concaveCylindricAreaCalculators = new List<fsCalculator>();

        #endregion

        public MsusAndHcControl()
        {
            InitializeComponent();

            plainAreaCalculators.Add(new fsMsusHcPlainAreaCalculator());
            convexCylindricAreaCalculators.Add(new fsMsusHcConvexCylindricAreaCalculator());
            concaveCylindricAreaCalculators.Add(new fsMsusHcConcaveCylindricAreaCalculator());
            Calculators = plainAreaCalculators;

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
            var diameterGroup = AddGroup(
                fsParameterIdentifier.FilterDiameter);
            areaBGroup = AddGroup(
                fsParameterIdentifier.FilterArea,
                fsParameterIdentifier.FilterB,
                fsParameterIdentifier.FilterBOverDiameter);
            var cakeHeightGroup = AddGroup(
                fsParameterIdentifier.CakeHeight);
            var massVolumeGroup = AddGroup(
                fsParameterIdentifier.SuspensionVolume,
                fsParameterIdentifier.SuspensionMass
                /*,
                fsParameterIdentifier.FiltrateMass,
                fsParameterIdentifier.CakeMass,
                fsParameterIdentifier.SolidsMass*/);

            var groups = new[] {
                filtrateGroup,
                densitiesGroup,
                concentrationGroup,
                epsKappaGroup,
                diameterGroup,
                areaBGroup,
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

            AssignCalculationOption(fsCalculationOption.DENISITIES_CALCULATED, denisitiesRadioButton, densitiesGroup);
            AssignCalculationOption(fsCalculationOption.CONCENTREATIONS_CALCULATED, concentrationRadioButton, concentrationGroup);
            AssignCalculationOption(fsCalculationOption.POROSITY_KAPPA_CALCULATED, epsKappaRadioButton, epsKappaGroup);
            AssignCalculationOption(fsCalculationOption.MACHINE_DIAMETER_CALCULATED, diameterRadioButton, diameterGroup);
            AssignCalculationOption(fsCalculationOption.MACHINE_A_B_CALCULATED, areaRadioButton, areaBGroup);
            AssignCalculationOption(fsCalculationOption.CAKE_HEIGHT_CALCULATED, cakeHeightRadioButton, cakeHeightGroup);
            AssignCalculationOption(fsCalculationOption.MASS_VOLUME_CALCULATED, massVolumeRadioButton, massVolumeGroup);
            
            base.CalculationOption = fsCalculationOption.MASS_VOLUME_CALCULATED;
            UpdateCalculationOptionAndInputGroups();

            machineTypeOption = fsMachineTypeOption.PLAIN_AREA;
            UpdateMachineTypeOptionUI();

            ConnectUIWithDataUpdating(dataGrid);
            UpdateUIFromData();
        }

        private void UpdateMachineTypeOptionUI()
        {
            if (planeAreaRadioButton.Checked)
            {
                machineTypeOption = fsMachineTypeOption.PLAIN_AREA;
            }
            if (convexAreaRadioButton.Checked)
            {
                machineTypeOption = fsMachineTypeOption.CONVEX_CYLINDRIC;
            }
            if (concaveAreaRadioButton.Checked)
            {
                machineTypeOption = fsMachineTypeOption.CONCAVE_CYLINDRIC;
            }
        }

        #region Routine Methods

        private void UpdateMachineRadioButtonsAndVisibleControls()
        {
            if (machineTypeOption == fsMachineTypeOption.PLAIN_AREA)
            {
                planeAreaRadioButton.Checked = true;
                ParameterToCell[fsParameterIdentifier.FilterDiameter].OwningRow.Visible = false;
                ParameterToCell[fsParameterIdentifier.FilterB].OwningRow.Visible = false;
                ParameterToCell[fsParameterIdentifier.FilterBOverDiameter].OwningRow.Visible = false;
                diameterRadioButton.Visible = false;
                if (diameterRadioButton.Checked)
                {
                    areaRadioButton.Checked = true;
                }
                Calculators = plainAreaCalculators;
                areaBGroup.Representator = fsParameterIdentifier.FilterArea;
            }
            if (machineTypeOption == fsMachineTypeOption.CONVEX_CYLINDRIC)
            {
                convexAreaRadioButton.Checked = true;
                ParameterToCell[fsParameterIdentifier.FilterDiameter].OwningRow.Visible = true;
                ParameterToCell[fsParameterIdentifier.FilterB].OwningRow.Visible = false;
                ParameterToCell[fsParameterIdentifier.FilterBOverDiameter].OwningRow.Visible = false;
                diameterRadioButton.Visible = true;
                Calculators = convexCylindricAreaCalculators;
                areaBGroup.Representator = fsParameterIdentifier.FilterArea;
            }
            if (machineTypeOption == fsMachineTypeOption.CONCAVE_CYLINDRIC)
            {
                concaveAreaRadioButton.Checked = true;
                ParameterToCell[fsParameterIdentifier.FilterDiameter].OwningRow.Visible = true;
                ParameterToCell[fsParameterIdentifier.FilterB].OwningRow.Visible = true;
                ParameterToCell[fsParameterIdentifier.FilterBOverDiameter].OwningRow.Visible = true;
                diameterRadioButton.Visible = true;
                Calculators = concaveCylindricAreaCalculators;
            }
        }

        protected override void UpdateUIFromData()
        {
            UpdateMachineRadioButtonsAndVisibleControls();
            base.UpdateUIFromData();
            textBox1.Lines = Calculators[0].GetStatusMessage().Split('\n');
        }

        protected override void ConnectUIWithDataUpdating(fmDataGrid.fmDataGrid dataGrid)
        {
            base.ConnectUIWithDataUpdating(dataGrid);
            planeAreaRadioButton.CheckedChanged += new EventHandler(RadioButtonCheckedChanged);
            convexAreaRadioButton.CheckedChanged += new EventHandler(RadioButtonCheckedChanged);
            concaveAreaRadioButton.CheckedChanged += new EventHandler(RadioButtonCheckedChanged);
        }

        override protected void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            UpdateMachineTypeOptionUI();
            base.RadioButtonCheckedChanged(sender, e);
        }

        #endregion
    }
}
