using System.Collections.Generic;
using Parameters;

namespace Calculator.Calculation_Controls
{
    public class fsParametersGroup
    {
        public fsParametersGroup()
        {
            Parameters = new List<fsParameterIdentifier>();
            Representator = null;
            IsInput = false;
        }

        public List<fsParameterIdentifier> Parameters { get; private set; }
        public fsParameterIdentifier Representator { get; set; }
        public bool IsInput { get; set; }
    }
}