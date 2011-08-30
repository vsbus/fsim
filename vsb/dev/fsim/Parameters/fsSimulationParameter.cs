using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Value;

namespace Parameters
{
    public class fsSimulationParameter : fsCalculatorConstant
    {
        private bool m_isInputed;
        public bool IsInputed
        {
            get { return m_isInputed; }
            set { m_isInputed = value; }
        }

        public fsSimulationParameter(fsParameterIdentifier identifier)
            : base(identifier)
        {
            m_isInputed = false;
        }

        public fsSimulationParameter(fsParameterIdentifier identifier, bool isInputed)
            : base(identifier)
        {
            m_isInputed = isInputed;
        }

        public fsSimulationParameter(fsParameterIdentifier identifier, fsValue value)
            : base(identifier, value)
        {
            m_isInputed = false;
        }

        public fsSimulationParameter(fsParameterIdentifier identifier, bool isInputed, fsValue value)
            : base(identifier, value)
        {
            m_isInputed = isInputed;
        }

        public override string ToString()
        {
            return Identifier.Name + "(" + (m_isInputed ? "Inputed" : "Calculated") + ")" + " = " + Value.ToString();
        }
    }
}
