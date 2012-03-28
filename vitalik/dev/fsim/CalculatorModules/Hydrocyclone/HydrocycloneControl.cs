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


namespace CalculatorModules.Hydrocyclone
{
    public partial class HydrocycloneControl : OptionsSingleTableWithPanelAndCommentsCalculatorControl
    {
        #region Region Calculation Option

        private enum fsRegionCalculationOption
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

            #region Region Calculators

            // Calculators.Add(new fsRegionCalculators());

            #endregion

            var colors = new[]
                             {
                                 Color.FromArgb(255, 255, 230),
                                 Color.FromArgb(255, 230, 255)
                             };

            #region region groups

            fsParametersGroup etaGroup = AddGroup(
               fsParameterIdentifier.LiquidViscosity);

            fsParametersGroup rhoGroup = AddGroup(
                fsParameterIdentifier.LiquidDensityRho);

            fsParametersGroup densitiesGroup = AddGroup(
                fsParameterIdentifier.SolidsDensity,
                fsParameterIdentifier.SuspensionDensity);

            fsParametersGroup cGroup = AddGroup(
                fsParameterIdentifier.SuspensionSolidsMassFraction,
                fsParameterIdentifier.SuspensionSolidsVolumeFraction,
                fsParameterIdentifier.SuspensionSolidsConcentration);

            var regionGroups = new[]
                             {
                                etaGroup,
                                rhoGroup,
                                densitiesGroup,
                                cGroup,
                             };

            for (int i = 0; i < regionGroups.Length; ++i)
            {
                AddGroupToUI(fmDataGrid, regionGroups[i], colors[i % colors.Length]);
                SetGroupInput(regionGroups[i], true);
            }
            

            #endregion

            fsMisc.FillList(comboBoxCalculationOption.Items, typeof(fsRegionCalculationOption));
            EstablishCalculationOption(fsRegionCalculationOption.Dp);
            AssignCalculationOptionAndControl(typeof(fsRegionCalculationOption), comboBoxCalculationOption);
            UpdateUIFromData();
            ConnectUIWithDataUpdating(fmDataGrid, comboBoxCalculationOption);

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

