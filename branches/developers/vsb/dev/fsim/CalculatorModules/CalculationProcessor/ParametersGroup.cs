using System.Collections.Generic;
using Parameters;

namespace CalculatorModules
{
    public class fsParametersGroup
    {
        #region Constructors

        public fsParametersGroup()
        {
            Parameters = new List<fsParameterIdentifier>();
            Representator = null;
            IsInput = false;
        }

        public fsParametersGroup(fsParametersGroup other)
        {
            Parameters = new List<fsParameterIdentifier>(other.Parameters);
            Representator = other.Representator;
            IsInput = other.IsInput;
        }

        #endregion

        public List<fsParameterIdentifier> Parameters { get; private set; }
        public fsParameterIdentifier Representator { get; set; }
        public bool IsInput { get; set; }
    }
}