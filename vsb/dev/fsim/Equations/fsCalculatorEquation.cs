using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public class fsCalculatorEquation
    {
        private fsCalculatorParameter m_result;
        protected Parameters.fsCalculatorParameter Result
        {
            get { return m_result; }
            set { m_result = value; }
        }

        private List<fsCalculatorParameter> m_inputs = new List<fsCalculatorParameter>();
        protected List<fsCalculatorParameter> Inputs
        {
            get { return m_inputs; }
            set { m_inputs = value; }
        }

        public bool CanBeCalculated()
        {
            if (m_result.isInput || m_result.IsProcessed)
                return false;
            foreach (var p in m_inputs)
                if (!p.isInput && !p.IsProcessed)
                    return false;
            return true;
        }

        public virtual void Calculate()
        {
            m_result.IsProcessed = true;
        }
    }
}
