using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators.Cake_Formation.DPConstEquations
{
    public class fsFakeEquation : fsCalculatorEquation
    {
        private fsCalculatorParameter A;
        private fsCalculatorParameter Dp;
        private fsCalculatorParameter tc;
        private fsCalculatorParameter hc;
        private fsCalculatorParameter tf;

        public fsFakeEquation(
            fsCalculatorParameter A,
            fsCalculatorParameter Dp,
            fsCalculatorParameter tc,
            fsCalculatorParameter hc,
            fsCalculatorParameter tf)
        {
            this.A = A;
            this.Dp = Dp;
            this.tc = tc;
            this.hc = hc;
            this.tf = tf;

            Result = tf;
            Inputs.Add(A);
            Inputs.Add(Dp);
            Inputs.Add(tc);
            Inputs.Add(hc);
        }

        public override void Calculate()
        {
            tf.Value = A.Value * Dp.Value * tc.Value * hc.Value;
            base.Calculate();
        }
    }

    public class fsFake2Equation : fsCalculatorEquation
    {
        private fsCalculatorParameter A;
        private fsCalculatorParameter Dp;

        public fsFake2Equation(
            fsCalculatorParameter A,
            fsCalculatorParameter Dp)
        {
            this.A = A;
            this.Dp = Dp;

            Result = A;
            Inputs.Add(Dp);
        }

        public override void Calculate()
        {
            A.Value = Dp.Value * 10;
            base.Calculate();
        }
    }
}