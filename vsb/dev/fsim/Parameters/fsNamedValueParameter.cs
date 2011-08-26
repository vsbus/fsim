using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Value;

namespace Parameters
{
    public class fsNamedValueParameter : fsJustValueParameter
    {
        private fsParameterIdentifier m_identifier;
        public fsParameterIdentifier Identifier
        {
            get { return m_identifier; }
            set { m_identifier = value; }
        }

        public fsNamedValueParameter(fsParameterIdentifier identifier)
            : base()
        {
            m_identifier = identifier;
        }

        public fsNamedValueParameter(fsParameterIdentifier identifier, fsValue value)
            : base(value)
        {
            m_identifier = identifier;
        }

        public override string ToString()
        {
            return m_identifier.Name + " = " + Value.ToString();
        }
    }
}
