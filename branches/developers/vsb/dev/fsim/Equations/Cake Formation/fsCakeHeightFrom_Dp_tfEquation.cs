using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Value;

namespace StepCalculators
{
    public class fsCakeHeightFrom_Dp_tf : fsCalculatorEquation
    {
        fsIEquationParameter CakeHeight;
        fsIEquationParameter hce;
        fsIEquationParameter Pc;
        fsIEquationParameter kappa;
        fsIEquationParameter Pressure;
        fsIEquationParameter FormationTime;
        fsIEquationParameter etaf;

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

            Result = CakeHeight;

        }

        public override void Calculate()
        {
            CakeHeight.Value = fsValue.Sqrt(hce.Value * hce.Value + 2 * Pc.Value * kappa.Value * Pressure.Value * FormationTime.Value / etaf.Value) - hce.Value;
            base.Calculate();
        }
    }
}
