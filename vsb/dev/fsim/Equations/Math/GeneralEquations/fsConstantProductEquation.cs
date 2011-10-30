using Parameters;
using Value;

namespace Equations
{
    public class fsConstantProductEquation : fsCalculatorEquation
    {
        // const = a * b * c * d * ... (any amount of parameters)

        #region Parameters

        readonly double m_const;
        readonly IEquationParameter[] m_elements;
        
        #endregion

        public fsConstantProductEquation(
            double constValue,
            params IEquationParameter [] elements)
            : base (elements)
        {
            m_const = constValue;
            m_elements = elements;
        }

        protected override void InitFormulas()
        {
            // no specific formulas in this class
        }

        protected override bool Calculate(IEquationParameter result)
        {
            fsValue product = fsValue.One;
            foreach (var equationParameter in m_elements)
            {
                if (equationParameter != result)
                {
                    product = product * equationParameter.Value;
                }
            }
            result.Value = m_const / product;
            return true;
        }
    }
}
