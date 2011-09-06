using System;
using System.Collections.Generic;
using System.Text;
using Parameters;

namespace Equations
{
    public class fsPcrcEquation : fsDivisionInverseEquation
    {
        public fsPcrcEquation(
            fsIEquationParameter Pc,
            fsIEquationParameter rc)
            : base(Pc, rc)
        {          
        }
    }
}
