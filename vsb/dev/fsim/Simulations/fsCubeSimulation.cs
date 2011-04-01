using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace Simulations
{
    public class fsCubeSimulation : fsSimulation
    {
        override protected void InitParameters()
        {
            AddParameter(fsParameterIdentifier.volume);
            AddParameter(fsParameterIdentifier.height);
            AddParameter(fsParameterIdentifier.length);
            AddParameter(fsParameterIdentifier.width);
        }

        override public void Run()
        {
            for (int i = 0; i < Steps.Count; ++i)
            {
                Steps[i].SetInputParametersDependingFromPreviousStep(Parameters.Values);
                Steps[i].Calculate();
                Steps[i].GetParameters(Parameters.Values);
            }
        }

        public string GetDataString()
        {
            string res = "";
            foreach (fsSimulationParameter parameter in Parameters.Values)
            {
                res += parameter.Identifier.Name + " = " + parameter.Value.ToString() + "; ";
            }
            return res;
        }
    }
}
