using Parameters;
using Equations;

namespace StepCalculators
{
    public class fsPermeabilityCalculator : fsCalculator
    {
        readonly fsCalculatorConstant m_rhoS;
        readonly fsCalculatorConstant m_eps;
        readonly fsCalculatorVariable m_pc0;
        readonly fsCalculatorVariable m_rc0;
        readonly fsCalculatorVariable m_alpha0;
        readonly fsCalculatorVariable m_nc;
        readonly fsCalculatorVariable m_pressure;
        readonly fsCalculatorVariable m_pc;
        readonly fsCalculatorVariable m_rc;
        readonly fsCalculatorVariable m_alpha;

        public fsPermeabilityCalculator()
        {
            #region Parameters Initialization

            m_rhoS = AddConstant(fsParameterIdentifier.SolidsDensity);
            m_eps = AddConstant(fsParameterIdentifier.CakePorosity);
            m_pc0 = AddVariable(fsParameterIdentifier.Pc0);
            m_rc0 = AddVariable(fsParameterIdentifier.Rc0);
            m_alpha0 = AddVariable(fsParameterIdentifier.Alpha0);
            m_nc = AddVariable(fsParameterIdentifier.CakeCompressibility);
            m_pressure = AddVariable(fsParameterIdentifier.Pressure);
            m_pc = AddVariable(fsParameterIdentifier.Pc);
            m_rc = AddVariable(fsParameterIdentifier.Rc);
            m_alpha = AddVariable(fsParameterIdentifier.Alpha);

            #endregion

            #region Equations Initialization

            AddEquation(new fsDivisionInverseEquation(m_pc0, m_rc0));
            AddEquation(new fsAlphaPcEquation(m_alpha0, m_pc0, m_eps, m_rhoS));
            AddEquation(new fsFrom0AndDpEquation(m_pc, m_pc0, m_pressure, m_nc));
            AddEquation(new fsDivisionInverseEquation(m_pc, m_rc));
            AddEquation(new fsAlphaPcEquation(m_alpha, m_pc, m_eps, m_rhoS));

            #endregion
        }
    }
}
