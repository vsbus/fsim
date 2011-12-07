using System.Collections.Generic;
using System.Windows.Forms;
using Parameters;
using System.Drawing;
using StepCalculators;
using ParametersIdentifiers.Interfaces;

namespace Calculator.Calculation_Controls
{
    static public class fsCalculationProcessor
    {
        static public void ProcessCalculatorParameters(
            Dictionary<fsParameterIdentifier, fsMeasuredParameter> values,
            Dictionary<fsParameterIdentifier, fsParametersGroup> parameterToGroup,
            List<fsCalculator> calculators)
        {
            var localValues = new Dictionary<fsParameterIdentifier, fsSimulationParameter>();

            foreach (var parameter in values.Keys)
            {
                var group = parameterToGroup[parameter];
                localValues[parameter] = group.IsInput && parameter == group.Representator
                    ? new fsSimulationParameter(parameter, true, values[parameter].Value)
                    : new fsSimulationParameter(parameter);
            }

            foreach (var calc in calculators)
            {
                calc.ReadDataFromStorage(localValues);
                calc.Calculate();
                calc.CopyValuesToStorage(localValues);
            }

            foreach (var parameter in values.Keys)
            {
                values[parameter].Value = localValues[parameter].Value;
            }
        }

    }
}
