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

        IEquationParameter CakeHeight;
        IEquationParameter hce;
        IEquationParameter Pc;
        IEquationParameter kappa;
        IEquationParameter Pressure;
        IEquationParameter FormationTime;
        IEquationParameter etaf;

        #endregion

        public fsCakeHeightFrom_Dp_tf(
            IEquationParameter CakeHeight,
            IEquationParameter hce,
            IEquationParameter Pc,
            IEquationParameter kappa,
            IEquationParameter Pressure,
            IEquationParameter FormationTime,
            IEquationParameter etaf)
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
            AddFormula(FormationTime, CakeFormationTime);
        }

        #region Formulas

        private void CakeHeightFormula()
        {
            CakeHeight.Value = fsValue.Sqrt(hce.Value * hce.Value + 2 * Pc.Value * kappa.Value * Pressure.Value * FormationTime.Value / etaf.Value) - hce.Value;
        }

        private void CakeFormationTime()
        {
            FormationTime.Value = etaf.Value
                * (CakeHeight.Value * CakeHeight.Value + 2 * CakeHeight.Value * hce.Value)
                / (2 * Pc.Value * kappa.Value * Pressure.Value);
        }

        #endregion
    }
}
