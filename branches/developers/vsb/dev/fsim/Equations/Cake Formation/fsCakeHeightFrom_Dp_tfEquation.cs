using System;
using System.Collections.Generic;
using System.Text;
using Parameters;
using Value;

namespace Equations
{
    public class fsCakeHeightFrom_Dp_tf : fsCalculatorEquation
    {
        #region Parameters

        fsIEquationParameter CakeHeight;
        fsIEquationParameter hce;
        fsIEquationParameter Pc;
        fsIEquationParameter kappa;
        fsIEquationParameter Pressure;
        fsIEquationParameter FormationTime;
        fsIEquationParameter etaf;

        #endregion

        public fsCakeHeightFrom_Dp_tf(
            fsIEquationParameter CakeHeight,
            fsIEquationParameter hce,
            fsIEquationParameter Pc,
            fsIEquationParameter kappa,
            fsIEquationParameter Pressure,
            fsIEquationParameter FormationTime,
            fsIEquationParameter etaf)
            : base(
                CakeHeight, 
                hce, 
                Pc, 
                kappa, 
                Pressure, 
                FormationTime, 
                etaf)
        {
            this.CakeHeight = CakeHeight;
            this.hce = hce;
            this.Pc = Pc;
            this.kappa = kappa;
            this.Pressure = Pressure;
            this.FormationTime = FormationTime;
            this.etaf = etaf;

        }

        protected override void InitFormulas()
        {
            AddFormula(CakeHeight, CakeHeightFormula);
        }

        #region Formulas

        private void CakeHeightFormula()
        {
            CakeHeight.Value = fsValue.Sqrt(hce.Value * hce.Value + 2 * Pc.Value * kappa.Value * Pressure.Value * FormationTime.Value / etaf.Value) - hce.Value;
        }

        #endregion
    }
}
