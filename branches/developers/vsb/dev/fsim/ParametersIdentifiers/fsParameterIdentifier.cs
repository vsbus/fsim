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

        public static fsParameterIdentifier q = new fsParameterIdentifier("q");
        public static fsParameterIdentifier a1 = new fsParameterIdentifier("a1");
        public static fsParameterIdentifier a2 = new fsParameterIdentifier("a2");
        public static fsParameterIdentifier a3 = new fsParameterIdentifier("a3");
        public static fsParameterIdentifier a4 = new fsParameterIdentifier("a4");
        public static fsParameterIdentifier a5 = new fsParameterIdentifier("a5");
    }
}
