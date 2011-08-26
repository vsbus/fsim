using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Units;

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

        private fsUnits m_units;
        public fsUnits Units
        {
            get { return m_units; }
            set { m_units = value; }
        }

        public fsParameterIdentifier(string name, fsUnits units)
        {
            m_name = name;
            m_units = units;
        }

        public override string ToString()
        {
            return m_name;
        }

        public static fsParameterIdentifier height = new fsParameterIdentifier("height", fsLengthUnits.Instance);
        public static fsParameterIdentifier length = new fsParameterIdentifier("length", fsLengthUnits.Instance);
        public static fsParameterIdentifier width = new fsParameterIdentifier("width", fsLengthUnits.Instance);
        public static fsParameterIdentifier side = new fsParameterIdentifier("side", fsLengthUnits.Instance);
        public static fsParameterIdentifier volume = new fsParameterIdentifier("volume", fsLengthUnits.Instance);
        public static fsParameterIdentifier coefficient = new fsParameterIdentifier("coefficient", fsLengthUnits.Instance);

        public static fsParameterIdentifier q = new fsParameterIdentifier("q", fsLengthUnits.Instance);
        public static fsParameterIdentifier a1 = new fsParameterIdentifier("a1", fsLengthUnits.Instance);
        public static fsParameterIdentifier a2 = new fsParameterIdentifier("a2", fsLengthUnits.Instance);
        public static fsParameterIdentifier a3 = new fsParameterIdentifier("a3", fsLengthUnits.Instance);
        public static fsParameterIdentifier a4 = new fsParameterIdentifier("a4", fsLengthUnits.Instance);
        public static fsParameterIdentifier a5 = new fsParameterIdentifier("a5", fsLengthUnits.Instance);
    }
}
