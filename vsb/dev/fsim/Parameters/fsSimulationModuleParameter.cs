using Parameters;
using Units;
using Value;

namespace ParametersIdentifiers
{
    /*
     * This class is used in Calculator modules,
     * where we need to know parameter Value, Unit and Range
     * 
     * */
    public class fsSimulationModuleParameter : fsNamedValueParameter
    {
        public fsUnit Unit { get; set; }

        #region Constructors

        public fsSimulationModuleParameter(fsSimulationModuleParameter other)
            : base(other)
        {
            Unit = other.Unit;
        }

        public fsSimulationModuleParameter(fsParameterIdentifier identifier)
            : base(identifier)
        {
            Unit = identifier.MeasurementCharacteristic.CurrentUnit;
        }

        public fsSimulationModuleParameter(fsParameterIdentifier identifier, fsValue value)
            : base(identifier, value)
        {
            Unit = identifier.MeasurementCharacteristic.CurrentUnit;
        }

        #endregion

        public fsValue GetValueInUnits()
        {
            return Value / Unit.Coefficient;
        }

        public void SetValueInUnits(fsValue valueInUnits)
        {
            Value = valueInUnits * Unit.Coefficient;
        }

        public override string ToString()
        {
            return Identifier.FullName + " (" + Identifier.Name + ") [" + Unit.Name + "]";
        }
    }
}
