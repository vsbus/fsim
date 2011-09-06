using System;
using System.Collections.Generic;

using System.Text;
using Value;

namespace Parameters
{
    public class fsJustValueParameter
    {
        private fsValue m_value;
        public fsValue Value
        {
            get { return m_value; }
            set { m_value = value; }
        }

        public fsJustValueParameter()
        {
            m_value = new fsValue();
        }

        public fsJustValueParameter(fsValue value)
        {
            m_value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
