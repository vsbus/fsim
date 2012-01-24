using Equations.Belt_Filters_with_Reversible_Trays;
using Parameters;

namespace StepCalculators.Simulation_Calculators
{
    public class fsBeltFiltersWithReversibleTraysCalculator : fsCalculator
    {
        readonly fsCalculatorVariable m_filterArea;
        readonly fsCalculatorVariable m_ns;
        readonly fsCalculatorVariable m_Qms;
        readonly fsCalculatorVariable m_lsOverB;
        readonly fsCalculatorConstant m_rhoCs;
        readonly fsCalculatorVariable m_u;
        readonly fsCalculatorVariable m_cakeHeigth;
        
        public fsBeltFiltersWithReversibleTraysCalculator()
        {
            #region Parameters Initialization

            m_filterArea = AddVariable(fsParameterIdentifier.FilterArea);
            m_ns = AddVariable(fsParameterIdentifier.ns);
            m_Qms = AddVariable(fsParameterIdentifier.Qms);
            m_lsOverB = AddVariable(fsParameterIdentifier.ls_over_b);
            m_u = AddVariable(fsParameterIdentifier.u);
            m_cakeHeigth = AddVariable(fsParameterIdentifier.CakeHeight);

            m_rhoCs = AddConstant(fsParameterIdentifier.DensityDryCake);

            #endregion

            #region Equations Initialization

            Equations.Add(new fsAreaOfBeltWithReversibleTraysEquation(
                m_filterArea,
                m_lsOverB,
                m_ns,
                m_Qms,
                m_rhoCs,
                m_u,
                m_cakeHeigth));

            #endregion
        }
    }
}
