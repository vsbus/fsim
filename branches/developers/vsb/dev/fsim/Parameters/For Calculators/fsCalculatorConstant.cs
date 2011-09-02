using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Value;

namespace Parameters
{
    public class fsCalculatorConstant : fsSimulationParameter, fsIEquationParameter
    {
        public bool IsProcessed
        {
            get
            {
                return true;
            }
            set
            {
                throw new Exception("Set is processed is restricted for Consts");
            }
        }

        public fsCalculatorConstant(fsParameterIdentifier identifier)
            : base(identifier)
        {
        }
    }
}
