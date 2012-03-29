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
using StepCalculators.Material_Calculators;
using StepCalculators.Simulation_Calculators;


namespace CalculatorModules.Hydrocyclone
{
    public partial class HydrocycloneControl : OptionsSingleTableWithPanelAndCommentsCalculatorControl
    {
        #region Calculation Option

        private enum fsCalculationOption
        {
            [Description("Dp")]
            Dp,
            [Description("Q")]
            Q,
            [Description("n")]
            n
        }

        #endregion

        public HydrocycloneControl()
        {
            InitializeComponent();

            #region Calculators

            Calculators.Add(new fsDensityConcentrationCalculator());

            #endregion

            var colors = new[]
                             {
                                 Color.FromArgb(255, 255, 230),
                                 Color.FromArgb(255, 230, 255)
                             };

            #region Groups

            fsParametersGroup etaGroup = AddGroup(
               fsParameterIdentifier.MotherLiquidDensity);    //eta

            fsParametersGroup rhoGroup = AddGroup(
                fsParameterIdentifier.FiltrateDensity);       //rho

            fsParametersGroup densitiesGroup = AddGroup(
                fsParameterIdentifier.SolidsDensity,        //rho_s
                fsParameterIdentifier.SuspensionDensity);   //rho_sus

            fsParametersGroup cGroup = AddGroup(
                fsParameterIdentifier.SuspensionSolidsMassFraction,     //cm
                fsParameterIdentifier.SuspensionSolidsVolumeFraction,   //cv
                fsParameterIdentifier.SuspensionSolidsConcentration);   //c

            var groups = new[]
                             {
                                etaGroup,
                                rhoGroup,
                                densitiesGroup,
                                cGroup,
                             };

            for (int i = 0; i < groups.Length; ++i)
            {
                AddGroupToUI(dataGrid, groups[i], colors[i % colors.Length]);
                SetGroupInput(groups[i], true);
            }
            

            #endregion

            fsMisc.FillList(comboBoxCalculationOption.Items, typeof(fsCalculationOption));
            EstablishCalculationOption(fsCalculationOption.Dp);
            AssignCalculationOptionAndControl(typeof(fsCalculationOption), comboBoxCalculationOption);
            UpdateUIFromData();
            ConnectUIWithDataUpdating(dataGrid, comboBoxCalculationOption);

        }

        #region Routine Methods

        protected override void UpdateGroupsInputInfoFromCalculationOptions()
        {
            //override
        }

        protected override void UpdateEquationsFromCalculationOptions()
        {
            //override
        }

        protected override void UpdateUIFromData()
        {
            //override

            base.UpdateUIFromData();
        }

        #endregion


        }
    }

