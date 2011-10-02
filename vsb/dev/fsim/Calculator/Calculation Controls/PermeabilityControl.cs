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
    public partial class PermeabilityControl : fsCalculatorControl
    {
        enum fsCalculationOption
        {
            CALC_PC0_RC0_ALPHA0,
            CALC_PRESSURE,
            CALC_NC,
            CALC_PC_RC_ALPHA
        }

        public PermeabilityControl()
        {
            InitializeComponent();

            Calculators.Add(new fsPermeabilityCalculator());

            var solidsGroup = AddGroup(
                fsParameterIdentifier.SolidsDensity);
            var porosityGroup = AddGroup(
                fsParameterIdentifier.Porosity);
            var pc0rc0a0Group = AddGroup(
                fsParameterIdentifier.Pc0,
                fsParameterIdentifier.Rc0,
                fsParameterIdentifier.Alpha0);
            var ncGroup = AddGroup(
                fsParameterIdentifier.Nc);
            var pressureGroup = AddGroup(
                fsParameterIdentifier.Pressure);
            var pcrcaGroup = AddGroup(
                fsParameterIdentifier.Pc,
                fsParameterIdentifier.Rc,
                fsParameterIdentifier.Alpha);

            AddGroupToUI(dataGrid, solidsGroup, Color.FromArgb(230, 230, 255));
            AddGroupToUI(dataGrid, porosityGroup, Color.FromArgb(255, 255, 230));
            AddGroupToUI(dataGrid, pc0rc0a0Group, Color.FromArgb(230, 230, 255));
            AddGroupToUI(dataGrid, ncGroup, Color.FromArgb(255, 255, 230));
            AddGroupToUI(dataGrid, pressureGroup, Color.FromArgb(230, 230, 255));
            AddGroupToUI(dataGrid, pcrcaGroup, Color.FromArgb(255, 230, 230));

            AssignCalculationOption(fsCalculationOption.CALC_PC0_RC0_ALPHA0, pc0rc0alpha0RadioButton, pc0rc0a0Group);
            AssignCalculationOption(fsCalculationOption.CALC_PRESSURE, pressureRadioButton, pressureGroup);
            AssignCalculationOption(fsCalculationOption.CALC_NC, ncRadioButton, ncGroup);
            AssignCalculationOption(fsCalculationOption.CALC_PC_RC_ALPHA, pcrcalphaRadioButton, pcrcaGroup);

            base.CalculationOption = fsCalculationOption.CALC_PC_RC_ALPHA;
            UpdateCalculationOptionAndInputGroups();

            ConnectUIWithDataUpdating(dataGrid);
            UpdateUIFromData();
        }

    }
}
