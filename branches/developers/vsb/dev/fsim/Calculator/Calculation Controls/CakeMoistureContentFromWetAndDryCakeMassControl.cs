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
    public partial class CakeMoistureContentFromWetAndDryCakeMassControl : fsCalculatorControl
    {
        #region Calculation Data

        private fsRfFromWetDryCakeCalculator.fsSaltContentOption m_saltContentOption;
        private fsRfFromWetDryCakeCalculator.fsConcentrationOption m_concentrationOption;

        #endregion

        private fsCakePorosityCalculator m_calculator = new fsCakePorosityCalculator();

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

            //m_saltContentOption = fsCakePorosityCalculator.fsSaltContentOption.Neglected;
            //m_saturationOption = fsCakePorosityCalculator.fsSaturationOption.NotSaturatedCake;
            //m_machineTypeOption = fsCakePorosityCalculator.fsMachineTypeOption.PlainArea;
            UpdateCalculationOptionAndInputGroupsFromUI();

            ConnectUIWithDataUpdating(dataGrid);
            UpdateUIFromData();
        }
    }
}
