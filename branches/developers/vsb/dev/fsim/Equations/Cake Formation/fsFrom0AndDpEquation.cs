using Parameters;
using Value;

namespace Equations
{
    public class fsFrom0AndDpEquation : fsCalculatorEquation
    {
        #region Parameters

        readonly IEquationParameter m_x;
        readonly IEquationParameter m_x0;
        readonly IEquationParameter m_pressure;
        readonly IEquationParameter m_degree;

        #endregion

        public fsFrom0AndDpEquation(
            IEquationParameter x,
            IEquationParameter x0,
            IEquationParameter pressure,
            IEquationParameter degree)
            : base(
                x, 
                x0, 
                pressure, 
                degree)
        {
            m_x = x;
            m_x0 = x0;
            m_pressure = pressure;
            m_degree = degree;
        }

        protected override void InitFormulas()
        {
            AddFormula(m_x, XFormula);
        }

        #region Formulas

        private void XFormula()
        {
            m_x.Value = m_x0.Value * fsValue.Pow(m_pressure.Value / 1e5, -m_degree.Value);
        }

        #endregion
    }
}
