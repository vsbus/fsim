using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parameters
{
    public class fsParameterIdentifier
    {
        private string m_name;
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public fsParameterIdentifier(string name)
        {
            m_name = name;
        }

        public override string ToString()
        {
            return m_name;
        }

        public static fsParameterIdentifier height = new fsParameterIdentifier("height");
        public static fsParameterIdentifier length = new fsParameterIdentifier("length");
        public static fsParameterIdentifier width = new fsParameterIdentifier("width");
        public static fsParameterIdentifier side = new fsParameterIdentifier("side");
        public static fsParameterIdentifier volume = new fsParameterIdentifier("volume");
        public static fsParameterIdentifier coefficient = new fsParameterIdentifier("coefficient");
    }
}
