using System.Collections.Generic;
using Parameters;
using ParametersIdentifiers.Interfaces;
using StepCalculators;

namespace Calculator.Calculation_Controls
{
    public static class fsCalculationProcessor
    {
        public static void ProcessCalculatorParameters(
            Dictionary<fsParameterIdentifier, fsMeasuredParameter> values,
            Dictionary<fsParameterIdentifier, fsParametersGroup> parameterToGroup,
            List<fsCalculator> calculators)
        {
            var localValues = new Dictionary<fsParameterIdentifier, fsSimulationParameter>();

            foreach (fsParameterIdentifier parameter in values.Keys)
            {
                fsParametersGroup group = parameterToGroup[parameter];
                localValues[parameter] = group.IsInput && parameter == group.Representator
                                             ? new fsSimulationParameter(parameter, true, values[parameter].Value)
                                             : new fsSimulationParameter(parameter);
            }

            foreach (fsCalculator calc in calculators)
            {
                calc.ReadDataFromStorage(localValues);
                calc.Calculate();
                calc.CopyValuesToStorage(localValues);
            }

            foreach (fsParameterIdentifier parameter in values.Keys)
            {
                values[parameter].Value = localValues[parameter].Value;
            }
        }
    }
}