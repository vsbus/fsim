using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace Calculator.Calculation_Controls
{
    public class ParametersGroup
    {
        public List<fsParameterIdentifier> Parameters { get; private set; }
        public fsParameterIdentifier Representator { get; set; }
        public bool IsInput { get; set; }

        public ParametersGroup()
        {
            Parameters = new List<fsParameterIdentifier>();
            Representator = null;
            IsInput = false;
        }
    }
}
