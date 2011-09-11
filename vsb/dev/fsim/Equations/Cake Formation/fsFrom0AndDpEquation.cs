using System;
using System.Collections.Generic;
using System.Text;
using Parameters;
using Value;

namespace Equations
{
    public class fsFrom0AndDpEquation : fsCalculatorEquation
    {
        #region Parameters

        private IEquationParameter x;
        private IEquationParameter x0;
        private IEquationParameter Pressure;
        private IEquationParameter degree;

        #endregion

        public fsFrom0AndDpEquation(
            IEquationParameter x,
            IEquationParameter x0,
            IEquationParameter Pressure,
            IEquationParameter degree)
            : base(
                x, 
                x0, 
                Pressure, 
                degree)
        {
            this.x = x;
            this.x0 = x0;
            this.Pressure = Pressure;
            this.degree = degree;
        }

        protected override void InitFormulas()
        {
            AddFormula(x, xFormula);
        }

        #region Formulas

        private void xFormula()
        {
            x.Value = x0.Value * fsValue.Pow(Pressure.Value / 1e5, -degree.Value);
        }

        #endregion
    }
}
