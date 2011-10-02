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
    public partial class MsusAndHcControl : CalculatorControl
    {
        #region Calculation Data

        enum MachineTypeOption
        {
            PLAIN_AREA,
            CONVEX_CYLINDRIC,
            CONCAVE_CYLINDRIC
        }
        private MachineTypeOption machineTypeOption;

        enum CalculationOption
        {
            DENISITIES_CALCULATED,
            CONCENTREATIONS_CALCULATED,
            POROSITY_KAPPA_CALCULATED,
            MACHINE_DIAMETER_CALCULATED,
            MACHINE_A_B_CALCULATED,
            CAKE_HEIGHT_CALCULATED,
            MASS_VOLUME_CALCULATED
        }
        private CalculationOption calculationOption;

        #endregion

        #region Routine Data

        ParametersGroup filtrateGroup;
        ParametersGroup densitiesGroup;
        ParametersGroup concentrationGroup;
        ParametersGroup epsKappaGroup;
        ParametersGroup diameterGroup;
        ParametersGroup areaBGroup;
        ParametersGroup cakeHeightGroup;
        ParametersGroup massVolumeGroup;

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

            filtrateGroup = AddGroup(
                fsParameterIdentifier.FiltrateDensity);
            densitiesGroup = AddGroup(
                fsParameterIdentifier.SolidsDensity,
                fsParameterIdentifier.SuspensionDensity);
            concentrationGroup = AddGroup(
                fsParameterIdentifier.SolidsMassFraction,
                fsParameterIdentifier.SolidsVolumeFraction,
                fsParameterIdentifier.SolidsConcentration);
            epsKappaGroup = AddGroup(
                fsParameterIdentifier.Porosity,
                fsParameterIdentifier.Kappa);
            diameterGroup = AddGroup(
                fsParameterIdentifier.FilterDiameter);
            areaBGroup = AddGroup(
                fsParameterIdentifier.FilterArea,
                fsParameterIdentifier.FilterB,
                fsParameterIdentifier.FilterBOverDiameter);
            cakeHeightGroup = AddGroup(
                fsParameterIdentifier.CakeHeight);
            massVolumeGroup = AddGroup(
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

            AssignCalculationOption(CalculationOption.DENISITIES_CALCULATED, denisitiesRadioButton, densitiesGroup);
            AssignCalculationOption(CalculationOption.CONCENTREATIONS_CALCULATED, concentrationRadioButton, concentrationGroup);
            AssignCalculationOption(CalculationOption.POROSITY_KAPPA_CALCULATED, epsKappaRadioButton, epsKappaGroup);
            AssignCalculationOption(CalculationOption.MACHINE_DIAMETER_CALCULATED, diameterRadioButton, diameterGroup);
            AssignCalculationOption(CalculationOption.MACHINE_A_B_CALCULATED, areaRadioButton, areaBGroup);
            AssignCalculationOption(CalculationOption.CAKE_HEIGHT_CALCULATED, cakeHeightRadioButton, cakeHeightGroup);
            AssignCalculationOption(CalculationOption.MASS_VOLUME_CALCULATED, massVolumeRadioButton, massVolumeGroup);
            
            calculationOption = CalculationOption.MASS_VOLUME_CALCULATED;
            UpdateCalculationOptionAndInputGroups();

            machineTypeOption = MachineTypeOption.PLAIN_AREA;
            UpdateMachineTypeOptionUI();

            ConnectUIWithDataUpdating();
            UpdateUIFromData();
        }

        private void UpdateMachineTypeOptionUI()
        {
            if (planeAreaRadioButton.Checked)
            {
                machineTypeOption = MachineTypeOption.PLAIN_AREA;
            }
            if (convexAreaRadioButton.Checked)
            {
                machineTypeOption = MachineTypeOption.CONVEX_CYLINDRIC;
            }
            if (concaveAreaRadioButton.Checked)
            {
                machineTypeOption = MachineTypeOption.CONCAVE_CYLINDRIC;
            }
        }

        #region Routine Methods

        protected override void UpdateUIFromData()
        {
            UpdateMachineRadioButtonsAndVisibleControls();

            UpdateCellForeColors();

            WriteValuesToDataGrid();

            calculationOptionToRadioButton[calculationOption].Checked = true;

            textBox1.Lines = Calculators[0].GetStatusMessage().Split('\n');
        }

        private void UpdateMachineRadioButtonsAndVisibleControls()
        {
            if (machineTypeOption == MachineTypeOption.PLAIN_AREA)
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
            if (machineTypeOption == MachineTypeOption.CONVEX_CYLINDRIC)
            {
                convexAreaRadioButton.Checked = true;
                ParameterToCell[fsParameterIdentifier.FilterDiameter].OwningRow.Visible = true;
                ParameterToCell[fsParameterIdentifier.FilterB].OwningRow.Visible = false;
                ParameterToCell[fsParameterIdentifier.FilterBOverDiameter].OwningRow.Visible = false;
                diameterRadioButton.Visible = true;
                Calculators = convexCylindricAreaCalculators;
                areaBGroup.Representator = fsParameterIdentifier.FilterArea;
            }
            if (machineTypeOption == MachineTypeOption.CONCAVE_CYLINDRIC)
            {
                concaveAreaRadioButton.Checked = true;
                ParameterToCell[fsParameterIdentifier.FilterDiameter].OwningRow.Visible = true;
                ParameterToCell[fsParameterIdentifier.FilterB].OwningRow.Visible = true;
                ParameterToCell[fsParameterIdentifier.FilterBOverDiameter].OwningRow.Visible = true;
                diameterRadioButton.Visible = true;
                Calculators = concaveCylindricAreaCalculators;
            }
        }

        protected override void UpdateCalculationOptionAndInputGroups()
        {
            foreach (var pair in calculationOptionToRadioButton)
            {
                if (pair.Value.Checked)
                {
                    calculationOption = (CalculationOption)pair.Key;
                    break;
                }
            }

            foreach (var group in Groups)
            {
                SetGroupInput(group, calculationOptionToGroup[calculationOption] != group);
            }
        }

        protected override void ConnectUIWithDataUpdating()
        {
            dataGrid.CellValueChangedByUser += new DataGridViewCellEventHandler(dataGridCellValueChangedByUser);
            foreach (var radioButton in calculationOptionToRadioButton.Values)
            {
                radioButton.CheckedChanged += new EventHandler(radioButtonCheckedChanged);
            }
            planeAreaRadioButton.CheckedChanged += new EventHandler(radioButtonCheckedChanged);
            convexAreaRadioButton.CheckedChanged += new EventHandler(radioButtonCheckedChanged);
            concaveAreaRadioButton.CheckedChanged += new EventHandler(radioButtonCheckedChanged);
        }

        void radioButtonCheckedChanged(object sender, EventArgs e)
        {
            UpdateCalculationOptionAndInputGroups();
            UpdateMachineTypeOptionUI();
            Recalculate();
            WriteValuesToDataGrid();
            UpdateUIFromData();
        }

        void dataGridCellValueChangedByUser(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView)
            {
                ProcessNewEntry(((DataGridView)sender).CurrentCell);
            }
            UpdateUIFromData();
        }

        #endregion
    }
}
