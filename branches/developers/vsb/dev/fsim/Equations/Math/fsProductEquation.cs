using System;
using System.Collections.Generic;
using System.Text;
using Parameters;

namespace Equations
{
    public class fsProductEquation : fsCalculatorEquation
    {
        // product = firstFactor * secondFactor

        #region Parameters
        
        private IEquationParameter product;
        private IEquationParameter firstFactor;
        private IEquationParameter secondFactor;
        
        #endregion

        public fsProductEquation(
            IEquationParameter product,
            IEquationParameter firstFactor,
            IEquationParameter secondFactor)
            : base (product, firstFactor, secondFactor)
        {
            this.product = product;
            this.firstFactor = firstFactor;
            this.secondFactor = secondFactor;
        }

        protected override void InitFormulas()
        {
            AddFormula(product, ProductFormula);
            AddFormula(firstFactor, FirstFactorFormula);
            AddFormula(secondFactor, SecondFactorFormula);
        }

        #region Formulas

        private void SecondFactorFormula()
        {
            secondFactor.Value = product.Value / firstFactor.Value; 
        }

        private void FirstFactorFormula()
        {
            firstFactor.Value = product.Value / secondFactor.Value;
        }

        private void ProductFormula()
        {
            product.Value = firstFactor.Value * secondFactor.Value;
        }

        #endregion
    }
}
