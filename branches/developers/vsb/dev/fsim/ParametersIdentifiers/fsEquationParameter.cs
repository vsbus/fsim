using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Value;

namespace Parameters
{
    public class fsEquationParameter
    {
        private fsValue m_value;
        public fsValue Value
        {
            get { return m_value; }
            set { m_value = value; }
        }

        public fsEquationParameter()
        {
            m_value = new fsValue();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
