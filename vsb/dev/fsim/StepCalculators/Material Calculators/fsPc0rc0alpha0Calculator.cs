using Parameters;
using Equations;

namespace StepCalculators
{
    public class fsPc0Rc0Alpha0Calculator : fsCalculator
    {
        readonly fsCalculatorVariable m_pc0;
        readonly fsCalculatorVariable m_rc0;
        readonly fsCalculatorVariable m_alpha0;
        readonly fsCalculatorConstant m_eps0;
        readonly fsCalculatorConstant m_rhoS;

        public fsPc0Rc0Alpha0Calculator()
        {
            #region Parameters Initialization

            m_pc0 = AddVariable(fsParameterIdentifier.Pc0);
            m_rc0 = AddVariable(fsParameterIdentifier.Rc0);
            m_alpha0 = AddVariable(fsParameterIdentifier.Alpha0);
            m_eps0 = AddConstant(fsParameterIdentifier.CakePorosity0);
            m_rhoS = AddConstant(fsParameterIdentifier.SolidsDensity);

            #endregion

            #region Equations Initialization

            AddEquation(new fsDivisionInverseEquation(m_pc0, m_rc0));
            AddEquation(new fsAlphaPcEquation(m_alpha0, m_pc0, m_eps0, m_rhoS));

            #endregion
        }
    }
}
