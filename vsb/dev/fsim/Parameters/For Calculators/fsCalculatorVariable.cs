using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Value;

namespace Parameters
{
    public class fsCalculatorVariable : fsSimulationParameter, fsIEquationParameter
    {
        bool m_isProcessed;
        public bool IsProcessed
        {
            get
            {
                return m_isProcessed || isInput;
            }
            set
            {
                m_isProcessed = value;
            }
        }

        public fsCalculatorVariable(fsParameterIdentifier identifier)
            : base(identifier)
        {
            m_isProcessed = false;
        }

        public fsCalculatorVariable(fsParameterIdentifier identifier, bool isInput)
            : base(identifier, isInput)
        {
            m_isProcessed = false;
        }
    }
}
