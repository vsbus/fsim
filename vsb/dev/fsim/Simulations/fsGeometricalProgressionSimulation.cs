using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace Simulations
{
    public class fsGeometricalProgressionSimulation : fsSimulation
    {
        override protected void InitParameters()
        {
            AddParameter(fsParameterIdentifier.a1);
            AddParameter(fsParameterIdentifier.a2);
            AddParameter(fsParameterIdentifier.a3);
            AddParameter(fsParameterIdentifier.a4);
            AddParameter(fsParameterIdentifier.a5);
        }
    }
}
