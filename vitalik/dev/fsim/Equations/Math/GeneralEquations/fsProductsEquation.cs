using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Value;

namespace Equations
{
    public class fsProductsEquation : fsCalculatorEquation
    {
        // This class can calculate any parameter from equation of the next kind:
        //
        // L1 * L2 * ... * Ln  ==  R1 * R2 * ... * Rm;
        // 
        // But be careful with duplicate parameters. If you try to calculate parameter that
        // appears several times in the equation then solution won't work.
        // Actually it is possible to fix by adding counting and root of k-th degree.

        #region Parameters

        private readonly IEnumerable<IEquationParameter> m_leftElements;
        private readonly IEnumerable<IEquationParameter> m_rightElements;

        #endregion

        public fsProductsEquation(
            IEnumerable<IEquationParameter> leftElements,
            IEnumerable<IEquationParameter> rightElements)
            : base(leftElements, rightElements)
        {
            m_leftElements = leftElements;
            m_rightElements = rightElements;
        }

        protected override void InitFormulas()
        {
            // no specific formulas in this class
        }

        protected override bool Calculate(IEquationParameter result)
        {
            fsValue leftProduct = GetElementsProduct(m_leftElements, result);
            fsValue rightProduct = GetElementsProduct(m_rightElements, result);

            if (m_leftElements.Contains(result))
            {
                result.Value = rightProduct / leftProduct;
            }
            else
            {
                result.Value = leftProduct / rightProduct;
            }

            return true;
        }

        private static fsValue GetElementsProduct(
            IEnumerable<IEquationParameter> elements,
            IEquationParameter result)
        {
            fsValue product = fsValue.One;
            foreach (IEquationParameter equationParameter in elements)
            {
                if (equationParameter != result)
                {
                    product = product * equationParameter.Value;
                }
            }
            return product;
        }
    }
}
