using Value;

namespace Parameters
{
    public class fsNamedValueParameter : fsJustValueParameter
    {
        public fsParameterIdentifier Identifier { get; set; }

        public fsNamedValueParameter(fsParameterIdentifier identifier)
        {
            Identifier = identifier;
        }

        public fsNamedValueParameter(fsParameterIdentifier identifier, fsValue value)
            : base(value)
        {
            Identifier = identifier;
        }

        public override string ToString()
        {
            return Identifier.Name + " = " + Value;
        }
    }
}
