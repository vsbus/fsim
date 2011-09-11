using Value;

namespace Parameters
{
    public class fsJustValueParameter
    {
        public fsValue Value { get; set; }

        public fsJustValueParameter()
        {
            Value = new fsValue();
        }

        public fsJustValueParameter(fsValue value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
