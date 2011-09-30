using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace MapOrReflection
{
    public class reflectionBase
    {
        public void CopyValuesToStorage(Dictionary<fsParameterIdentifier, fsSimulationParameter> target)
        {
            foreach (var propertie in this.GetType().GetProperties())
            {
                object obj = propertie.GetValue(this, null);
                if (obj is fsCalculatorVariable)
                {
                    fsSimulationParameter parameter = (fsCalculatorVariable)obj;
                    if (target.ContainsKey(parameter.Identifier))
                    {
                        target[parameter.Identifier].Value = parameter.Value;
                    }
                }
                
            }
        }

        public void ReadDataFromStorage(Dictionary<fsParameterIdentifier, fsSimulationParameter> source)
        {
            foreach (var propertie in this.GetType().GetProperties())
            {
                object obj = propertie.GetValue(this, null);
                if (obj is fsSimulationParameter)
                {
                    fsSimulationParameter parameter = (fsSimulationParameter)obj;
                    if (source.ContainsKey(parameter.Identifier))
                    {
                        parameter.Value = source[parameter.Identifier].Value;
                    }
                }
            }
        }
    }
}
