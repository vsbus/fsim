namespace Parameters
{
    public class fsCalculatorVariable : fsSimulationParameter, IEquationParameter
    {
        public bool IsProcessed { get; set; }

        public fsCalculatorVariable(fsParameterIdentifier identifier)
            : base(identifier)
        {
            IsProcessed = false;
        }

        public fsCalculatorVariable(fsParameterIdentifier identifier, bool isInput)
            : base(identifier, isInput)
        {
            IsProcessed = false;
        }
    }
}
