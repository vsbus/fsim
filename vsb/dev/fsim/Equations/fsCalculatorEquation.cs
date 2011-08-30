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

        public double GetWeight()
        {
            List<fsCalculatorParameter> oldInputs = new List<fsCalculatorParameter>();
            foreach (var p in Inputs)
            {
                var np = new fsCalculatorParameter(p.Identifier, p.IsInputed);
                np.IsProcessed = p.IsProcessed;
                np.Value = p.Value;
                oldInputs.Add(np);
                p.IsProcessed = false;
                p.IsInputed = true;
                p.Value = fsValue.One;
            }
            fsCalculatorParameter oldResult = new fsCalculatorParameter(Result.Identifier, Result.IsInputed);
            oldResult.IsProcessed = Result.IsProcessed;
            oldResult.Value = Result.Value;
            Result.IsInputed = false;

            double startTime = DateTime.Now.TimeOfDay.TotalSeconds;
            int iterationsCount = 0;
            while (DateTime.Now.TimeOfDay.TotalSeconds - startTime <= 1)
            {
                ++iterationsCount;
                Calculate();
            }
            double result = (DateTime.Now.TimeOfDay.TotalSeconds - startTime) / iterationsCount;
            // todo: restore old values
            return result;
        }
    }
}
