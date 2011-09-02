using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace Equations
{
    public class fsProductEquation : fsCalculatorEquation
    {
        // product = firstFactor * secondFactor

        #region Parameters
        
        private fsIEquationParameter product;
        private fsIEquationParameter firstFactor;
        private fsIEquationParameter secondFactor;
        
        #endregion

        public fsProductEquation(
            fsIEquationParameter product,
            fsIEquationParameter firstFactor,
            fsIEquationParameter secondFactor)
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
            firstFactor.Value = product.Value / secondFactor.Value;
        }

        private void FirstFactorFormula()
        {
            secondFactor.Value = product.Value / firstFactor.Value;
        }

        private void ProductFormula()
        {
            product.Value = firstFactor.Value * secondFactor.Value;
        }

        #endregion
    }
}
