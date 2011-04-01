using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parameters
{
    public class fsStepParameter : fsSimulationParameter
    {
        private bool m_isInputed;
        public bool IsInputed
        {
            get { return m_isInputed; }
            set { m_isInputed = value; }
        }

        private bool m_isProcessed;
        public bool IsProcessed
        {
            get { return m_isProcessed; }
            set { m_isProcessed = value; }
        }

        private bool m_isDependFromPreviousStep;
        public bool IsDependingFromPreviousStep
        {
            get { return m_isDependFromPreviousStep; }
            set { m_isDependFromPreviousStep = value; }
        }

        public fsStepParameter(
            fsParameterIdentifier identifier,
            bool isDependingFromPreviousStep)
            : base(identifier)
        {
            m_isDependFromPreviousStep = isDependingFromPreviousStep;
            m_isInputed = false;
            m_isProcessed = false;
        }
    }
}
