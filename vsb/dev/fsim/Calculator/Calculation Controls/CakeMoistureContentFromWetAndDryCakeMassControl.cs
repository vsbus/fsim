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
    public sealed partial class CakeMoistureContentFromWetAndDryCakeMassControl : fsCalculatorControl
    {
        #region Calculation Data

        private fsRfFromWetDryCakeCalculator.fsSaltContentOption m_saltContentOption;
        private fsRfFromWetDryCakeCalculator.fsConcentrationOption m_concentrationOption;

        #endregion

        private fsRfFromWetDryCakeCalculator m_calculator = new fsRfFromWetDryCakeCalculator();

        public CakeMoistureContentFromWetAndDryCakeMassControl()
        {
            InitializeComponent();

            Calculators.Add(m_calculator);

            var wetMassGroup = AddGroup(fsParameterIdentifier.WetCakeMass);
            var dryMassGroup = AddGroup(fsParameterIdentifier.DryCakeMass);
            var cmGroup = AddGroup(fsParameterIdentifier.SolidsMassFraction);
            var cGroup = AddGroup(fsParameterIdentifier.SolidsConcentration);
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
                groups[i].IsInput = true;
                AddGroupToUI(dataGrid, groups[i], colors[i % colors.Length]);
            }
            rfGroup.IsInput = false;

            FillComboBox(saltContentComboBox, typeof(fsRfFromWetDryCakeCalculator.fsSaltContentOption));
            FillComboBox(concentrationComboBox, typeof(fsRfFromWetDryCakeCalculator.fsConcentrationOption));
            m_saltContentOption = fsRfFromWetDryCakeCalculator.fsSaltContentOption.Neglected;
            m_concentrationOption = fsRfFromWetDryCakeCalculator.fsConcentrationOption.SolidsMassFraction;
            UpdateUIFromData();
            UpdateCalculationOptionAndInputGroupsFromUI();

            ConnectUIWithDataUpdating(dataGrid);
            UpdateUIFromData();
        }

        private static void FillComboBox(ComboBox comboBox, Type enumType)
        {
            comboBox.Items.Clear();
            foreach (Enum element in Enum.GetValues(enumType))
            {
                comboBox.Items.Add(fsMisc.GetEnumDescription(element));
            }
        }

        #region Routine Methods

        override protected void UpdateCalculationOptionAndInputGroupsFromUI()
        {
            m_saltContentOption =
                (fsRfFromWetDryCakeCalculator.fsSaltContentOption)
                fsMisc.GetEnum(typeof (fsRfFromWetDryCakeCalculator.fsSaltContentOption),
                               saltContentComboBox.Text);
            m_concentrationOption =
                (fsRfFromWetDryCakeCalculator.fsConcentrationOption)
                fsMisc.GetEnum(typeof (fsRfFromWetDryCakeCalculator.fsConcentrationOption),
                               concentrationComboBox.Text);

            m_calculator.m_saltContentOption = m_saltContentOption;
            m_calculator.m_concentrationOption = m_concentrationOption;
            m_calculator.RebuildEquationsList();

            base.UpdateCalculationOptionAndInputGroupsFromUI();
        }

        protected override void UpdateUIFromData()
        {
            saltContentComboBox.Text = fsMisc.GetEnumDescription(m_saltContentOption);

            bool isSaltContConsidered = m_saltContentOption == fsRfFromWetDryCakeCalculator.fsSaltContentOption.Considered;

            concentrationLabel.Visible = isSaltContConsidered;
            concentrationComboBox.Visible = isSaltContConsidered;
            concentrationComboBox.Text = fsMisc.GetEnumDescription(m_concentrationOption);

            bool isCmInput = m_concentrationOption ==
                             fsRfFromWetDryCakeCalculator.fsConcentrationOption.SolidsMassFraction;
            ParameterToCell[fsParameterIdentifier.SolidsMassFraction].OwningRow.Visible = isSaltContConsidered && isCmInput;
            ParameterToCell[fsParameterIdentifier.SolidsConcentration].OwningRow.Visible = isSaltContConsidered && !isCmInput;
            ParameterToCell[fsParameterIdentifier.LiquidDensity].OwningRow.Visible = isSaltContConsidered && !isCmInput;

            base.UpdateUIFromData();
        }

        protected override void ConnectUIWithDataUpdating(fmDataGrid.fmDataGrid grid)
        {
            base.ConnectUIWithDataUpdating(grid);
            saltContentComboBox.TextChanged += RadioButtonCheckedChanged;
            concentrationComboBox.TextChanged += RadioButtonCheckedChanged;
        }

        #endregion
    }
}
