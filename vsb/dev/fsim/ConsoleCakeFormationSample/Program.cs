using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Value;

namespace ConsoleCakeFormationSample
{
    class Program
    {
        static void Main(string[] args)
        {
            StepCalculators.fsCakeFormationDpConstCalculator calculator = new StepCalculators.fsCakeFormationDpConstCalculator();
            fsSimulationParameter[] a = {
                new fsSimulationParameter(fsParameterIdentifier.FilterArea, true, new fsValue(2)),
                new fsSimulationParameter(fsParameterIdentifier.Pressure, true, new fsValue(2)),
                new fsSimulationParameter(fsParameterIdentifier.FormationTime, false),
                new fsSimulationParameter(fsParameterIdentifier.CakeHeight, true, new fsValue(4)),
                new fsSimulationParameter(fsParameterIdentifier.CycleTime, true, new fsValue(3))};
            Dictionary<fsParameterIdentifier, fsSimulationParameter> data = new Dictionary<fsParameterIdentifier, fsSimulationParameter>();
            foreach (var p in a)
            {
                data[p.Identifier] = p;
            }
            calculator.WriteParametersData(data);
            calculator.Calculate();
            calculator.ReadParametersValues(data);
            foreach (var p in data)
            {
                System.Console.WriteLine(p.ToString());
            }
        }
    }
}
