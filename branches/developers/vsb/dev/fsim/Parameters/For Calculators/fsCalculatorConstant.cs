using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Value;

namespace Parameters
{
    public class fsCalculatorConstant : fsNamedValueParameter
    {
        public fsCalculatorConstant(fsParameterIdentifier identifier)
            : base(identifier)
        {
        }

        public fsCalculatorConstant(fsParameterIdentifier identifier, fsValue value)
            : base(identifier, value)
        {
        }
    }
}
