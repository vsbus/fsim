using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Equations.Material.Cake_Moisture_Content_Rf_Equations;
using Parameters;
using Equations;
using Value;
using Equations.Material.Eps_Kappa_Equations;

namespace StepCalculators.Simulation_Calculators.Simulation_Help_Calculators
{
    public class fsRf0Rs0RhoCw0FromDensitiesAndCakePorosity0Calculator : fsCalculator
    {
        readonly fsCalculatorConstant m_filtrateDensity;
        readonly fsCalculatorConstant m_solidsDensity;
        readonly fsCalculatorConstant m_cakePorosity0;
        readonly fsCalculatorConstant m_cakeDrySolidsDensity0;
        readonly fsCalculatorConstant m_suspensionSolidsMassFraction;
        readonly fsCalculatorConstant m_kappa0;
        readonly fsCalculatorVariable m_cakeMoistureContentRf0;
        readonly fsCalculatorVariable m_cakeWetMassSolidsFractionRs0;
        readonly fsCalculatorVariable m_cakeWetDensity0;

        public fsRf0Rs0RhoCw0FromDensitiesAndCakePorosity0Calculator()
        {
            #region Parameters Initialization

            m_filtrateDensity = AddConstant(fsParameterIdentifier.FiltrateDensity);
            m_solidsDensity = AddConstant(fsParameterIdentifier.SolidsDensity);
            m_cakePorosity0 = AddConstant(fsParameterIdentifier.CakePorosity0);
            m_cakeDrySolidsDensity0 = AddConstant(fsParameterIdentifier.DryCakeDensity0);
            m_suspensionSolidsMassFraction = AddConstant(fsParameterIdentifier.SuspensionSolidsMassFraction);
            m_kappa0 = AddConstant(fsParameterIdentifier.Kappa0);
            m_cakeMoistureContentRf0 = AddVariable(fsParameterIdentifier.CakeMoistureContentRf0);
            m_cakeWetMassSolidsFractionRs0 = AddVariable(fsParameterIdentifier.CakeWetMassSolidsFractionRs0);
            m_cakeWetDensity0 = AddVariable(fsParameterIdentifier.CakeWetDensity0);

            #endregion

            #region Equations Initialization

            Equations.Add(new fsMoistureContentFromDensitiesAndPorosityEquation(
                m_cakeMoistureContentRf0,
                m_cakePorosity0,
                m_filtrateDensity,
                m_solidsDensity));

            var one = new fsCalculatorConstant(new fsParameterIdentifier("one")) {Value = fsValue.One};
            Equations.Add(new fsSumEquation(one, m_cakeMoistureContentRf0, m_cakeWetMassSolidsFractionRs0));

            Equations.Add(new fsCakeWetDensityFromKappaCvRhofRhocdEquation(
                m_cakeWetDensity0,
                m_cakeDrySolidsDensity0,
                m_filtrateDensity,
                m_suspensionSolidsMassFraction,
                m_kappa0));

            #endregion
        }
    }
}
