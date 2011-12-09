using Parameters;

namespace Equations
{
    public class fsProductEquation : fsCalculatorEquation
    {
        #region Parameters

        private readonly IEquationParameter m_firstFactor;
        private readonly IEquationParameter m_product;
        private readonly IEquationParameter m_secondFactor;

        #endregion

        // product = firstFactor * secondFactor

        public fsProductEquation(
            IEquationParameter product,
            IEquationParameter firstFactor,
            IEquationParameter secondFactor)
            : base(product, firstFactor, secondFactor)
        {
            m_product = product;
            m_firstFactor = firstFactor;
            m_secondFactor = secondFactor;
        }

        protected override void InitFormulas()
        {
            AddFormula(m_product, ProductFormula);
            AddFormula(m_firstFactor, FirstFactorFormula);
            AddFormula(m_secondFactor, SecondFactorFormula);
        }

        #region Formulas

        private void SecondFactorFormula()
        {
            m_secondFactor.Value = m_product.Value / m_firstFactor.Value;
        }

        private void FirstFactorFormula()
        {
            m_firstFactor.Value = m_product.Value / m_secondFactor.Value;
        }

        private void ProductFormula()
        {
            m_product.Value = m_firstFactor.Value * m_secondFactor.Value;
        }

        #endregion
    }
}