using Value;

namespace Parameters
{
    public class fsSimulationParameter : fsNamedValueParameter
    {
        public bool IsInput { get; set; }

        public fsSimulationParameter(fsParameterIdentifier identifier)
            : base(identifier)
        {
            IsInput = false;
        }

        public fsSimulationParameter(fsParameterIdentifier identifier, bool isInput)
            : base(identifier)
        {
            IsInput = isInput;
        }

        public fsSimulationParameter(fsParameterIdentifier identifier, fsValue value)
            : base(identifier, value)
        {
            IsInput = false;
        }

        public fsSimulationParameter(fsParameterIdentifier identifier, bool isInput, fsValue value)
            : base(identifier, value)
        {
            IsInput = isInput;
        }

        public string ValueToStringWithCurrentUnits()
        {
            return (Value / Identifier.MeasurementCharacteristic.CurrentUnit.Coefficient).ToString();
        }

        public override string ToString()
        {
            return Identifier.Name + "(" + (IsInput ? "Inputed" : "Calculated") + ")" + " = " + Value;
        }
    }
}
