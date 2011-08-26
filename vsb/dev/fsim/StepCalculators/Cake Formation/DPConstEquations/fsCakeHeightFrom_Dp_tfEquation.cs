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
        fsCalculatorParameter CakeHeight;
        fsCalculatorParameter hce;
        fsCalculatorParameter Pc;
        fsCalculatorParameter kappa;
        fsCalculatorParameter Pressure;
        fsCalculatorParameter FormationTime;
        fsCalculatorParameter etaf;

        public fsCakeHeightFrom_Dp_tf(
            fsCalculatorParameter CakeHeight,
            fsCalculatorParameter hce,
            fsCalculatorParameter Pc,
            fsCalculatorParameter kappa,
            fsCalculatorParameter Pressure,
            fsCalculatorParameter FormationTime,
            fsCalculatorParameter etaf)
        {
            this.CakeHeight = CakeHeight;
            this.hce = hce;
            this.Pc = Pc;
            this.kappa = kappa;
            this.Pressure = Pressure;
            this.FormationTime = FormationTime;
            this.etaf = etaf;

            Result = CakeHeight;
            Inputs.Add(hce);
            Inputs.Add(Pc);
            Inputs.Add(kappa);
            Inputs.Add(Pressure);
            Inputs.Add(FormationTime);
            Inputs.Add(etaf);
        }

        public override void Calculate()
        {
            CakeHeight.Value = fsValue.Sqrt(hce.Value * hce.Value + 2 * Pc.Value * kappa.Value * Pressure.Value * FormationTime.Value / etaf.Value) - hce.Value;
            base.Calculate();
        }
    }
}
