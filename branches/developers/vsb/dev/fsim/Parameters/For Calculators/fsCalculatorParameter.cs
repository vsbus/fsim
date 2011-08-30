using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parameters
{
    public class fsCalculatorParameter : fsSimulationParameter
    {
        private bool m_isProcessed;
        public bool IsProcessed
        {
            get { return m_isProcessed; }
            set { m_isProcessed = value; }
        }

        public fsCalculatorParameter(fsParameterIdentifier identifier)
            : base(identifier)
        {
            m_isProcessed = false;
        }

        public fsCalculatorParameter(fsParameterIdentifier identifier, bool isInput)
            : base(identifier, isInput)
        {
            m_isProcessed = false;
        }

        public override string ToString()
        {
            return Identifier.Name 
                + "(" + (isInput ? "Inputed" : "Calculated") + ", " + (m_isProcessed == false ? "Not " : "") + "Processed" + ")" 
                + " = " + Value.ToString();
        }
    }
}
