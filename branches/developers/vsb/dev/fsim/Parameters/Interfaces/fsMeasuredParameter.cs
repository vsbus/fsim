﻿using Parameters;
using Units;
using Value;

namespace ParametersIdentifiers.Interfaces
{
    public class fsMeasuredParameter : fsNamedValueParameter
    {
        public fsUnit Unit { get; set; }

        #region Constructors

        public fsMeasuredParameter(fsMeasuredParameter other)
            : base(other)
        {
            Unit = other.Unit;
        }

        public fsMeasuredParameter(fsParameterIdentifier identifier)
            : base(identifier)
        {
            Unit = identifier.MeasurementCharacteristic.CurrentUnit;
        }

        public fsMeasuredParameter(fsParameterIdentifier identifier, fsValue value)
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