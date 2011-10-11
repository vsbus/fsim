using System.Collections.Generic;
using Parameters;

namespace Calculator.Calculation_Controls
{
    public class fsParametersGroup
    {
        public List<fsParameterIdentifier> Parameters { get; private set; }
        public fsParameterIdentifier Representator { get; set; }
        public bool IsInput { get; set; }

        public fsParametersGroup()
        {
            Parameters = new List<fsParameterIdentifier>();
            Representator = null;
            IsInput = false;
        }
    }
}
