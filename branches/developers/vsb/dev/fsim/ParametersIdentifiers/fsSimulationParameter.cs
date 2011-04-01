using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parameters
{
    public class fsSimulationParameter : fsEquationParameter
    {
        private fsParameterIdentifier m_identifier;
        public fsParameterIdentifier Identifier
        {
            get { return m_identifier; }
            set { m_identifier = value; }
        }

        public fsSimulationParameter(fsParameterIdentifier identifier)
            : base()
        {
            m_identifier = identifier;
        }

        public override string ToString()
        {
            return m_identifier.Name + " = " + Value.ToString();
        }
    }
}
