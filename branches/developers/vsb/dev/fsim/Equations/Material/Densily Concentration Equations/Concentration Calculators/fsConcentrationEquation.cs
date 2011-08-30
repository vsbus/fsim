﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Value;

namespace StepCalculators
{
    public class fsConcentrationEquation : fsBaseConcentrationEquation
    {
        private fsCalculatorParameter Concentration;

        public fsConcentrationEquation(
            fsCalculatorParameter Concentration,
            fsCalculatorParameter FiltrateDensity,
            fsCalculatorParameter SolidsDensity,
            fsCalculatorParameter SuspensionDensity)
            : base(
                FiltrateDensity,
                SolidsDensity,
                SuspensionDensity)
        {
            this.Concentration = Concentration;
            Result = Concentration;
        }

        public override void Calculate()
        {
            fsValue rho_s = SolidsDensity.Value;
            fsValue rho_f = FiltrateDensity.Value;
            fsValue rho_sus = SuspensionDensity.Value;
            Concentration.Value = rho_s * (rho_f - rho_sus) / (rho_f - rho_s); ;
            base.Calculate();
        }
    }
}
