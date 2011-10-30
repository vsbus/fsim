using System.Collections.Generic;
using Parameters;
using Value;

namespace Equations
{
    public class fsConstantSumEquation : fsCalculatorEquation
    {
        // const = a + b + c + d + ... (any amount of parameters)

        #region Parameters

        readonly double m_const;
        readonly IEquationParameter[] m_elements;
        
        #endregion

        public fsConstantSumEquation(
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
            fsValue sum = fsValue.Zero;
            foreach (var equationParameter in m_elements)
            {
                if (equationParameter != result)
                {
                    sum = sum + equationParameter.Value;
                }
            }
            result.Value = m_const - sum;
            return true;
        }
    }
}
