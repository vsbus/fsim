using Equations;
using Equations.Belt_Filters_with_Reversible_Trays;
using Parameters;

namespace StepCalculators.Simulation_Calculators
{
    public class fsBeltFiltersWithReversibleTraysCalculator : fsCalculator
    {
        readonly fsCalculatorVariable m_filterArea;
        readonly fsCalculatorVariable m_ns;
        readonly fsCalculatorVariable m_Qms;
        readonly fsCalculatorVariable m_Qs;
        readonly fsCalculatorVariable m_Qmsus;
        readonly fsCalculatorVariable m_Qsus;
        readonly fsCalculatorVariable m_lsOverB;
        readonly fsCalculatorVariable m_u;
        readonly fsCalculatorVariable m_cakeHeigth;

        readonly fsCalculatorConstant m_rho_s;
        readonly fsCalculatorConstant m_rho_sus;
        readonly fsCalculatorConstant m_cv;
        readonly fsCalculatorConstant m_eps0;
        
        public fsBeltFiltersWithReversibleTraysCalculator()
        {
            #region Parameters Initialization

            m_filterArea = AddVariable(fsParameterIdentifier.FilterArea);
            m_ns = AddVariable(fsParameterIdentifier.ns);
            m_Qms = AddVariable(fsParameterIdentifier.Qms);
            m_Qs = AddVariable(fsParameterIdentifier.Qs);
            m_Qmsus = AddVariable(fsParameterIdentifier.SuspensionMassFlowrate);
            m_Qsus = AddVariable(fsParameterIdentifier.Qsus);
            m_lsOverB = AddVariable(fsParameterIdentifier.ls_over_b);
            m_u = AddVariable(fsParameterIdentifier.u);
            m_cakeHeigth = AddVariable(fsParameterIdentifier.CakeHeight);

            m_rho_s = AddConstant(fsParameterIdentifier.SolidsDensity);
            m_rho_sus = AddConstant(fsParameterIdentifier.SuspensionDensity);
            m_cv = AddConstant(fsParameterIdentifier.SuspensionSolidsVolumeFraction);
            m_eps0 = AddConstant(fsParameterIdentifier.CakePorosity0);

            #endregion

            #region Equations Initialization

            Equations.Add(new fsAreaOfBeltWithReversibleTraysEquation(
                m_filterArea,
                m_lsOverB,
                m_ns,
                m_Qms,
                m_rho_s,
                m_u,
                m_cakeHeigth));

            Equations.Add(new fsProductEquation(m_Qms, m_rho_s, m_Qs));
            Equations.Add(new fsProductEquation(m_Qmsus, m_rho_sus, m_Qsus));
            Equations.Add(new fsProductEquation(m_Qs, m_Qsus, m_cv));

            #endregion
        }
    }
}
