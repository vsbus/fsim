using System;

namespace Parameters
{
    public class fsCalculatorConstant : fsSimulationParameter, IEquationParameter
    {
        public bool IsProcessed
        {
            get
            {
                return true;
            }
            set
            {
                throw new Exception("Set is processed is restricted for Consts");
            }
        }

        public fsCalculatorConstant(fsParameterIdentifier identifier)
            : base(identifier)
        {
        }
    }
}
