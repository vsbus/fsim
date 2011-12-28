﻿using Value;

namespace ParametersIdentifiers.Ranges
{
    public class fsRange
    {
        public fsRange()
        {
            From = new fsValue();
            To = new fsValue();
        }

        public fsRange(fsValue from, fsValue to)
        {
            From = from;
            To = to;
        }

        public fsValue From { get; set; }
        public fsValue To { get; set; }
    }
}