using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public abstract class fsCalculatorEquation
    {
        private List<fsIEquationParameter> m_inputs = new List<fsIEquationParameter>();

        private fsIEquationParameter m_result;
        protected fsIEquationParameter Result
        {
            get { return m_result; }
            set { m_result = value; }
        }

        protected fsCalculatorEquation(params fsIEquationParameter[] parameters)
        {
            foreach (var p in parameters)
            {
                m_inputs.Add(p);
            }
        }

        public bool CanBeCalculated()
        {
            if (m_result.IsProcessed)
                return false;
            foreach (var p in m_inputs)
                if (p != m_result && !p.IsProcessed)
                    return false;
            return true;
        }

        public virtual void Calculate()
        {
            m_result.IsProcessed = true;
        }

        public double GetWeight()
        {
            return 0;
//             List<fsCalculatorParameter> oldInputs = new List<fsCalculatorParameter>();
//             foreach (var p in Inputs)
//             {
//                 var np = new fsCalculatorParameter(p.Identifier, p.IsInputed);
//                 np.IsProcessed = p.IsProcessed;
//                 np.Value = p.Value;
//                 oldInputs.Add(np);
//                 p.IsProcessed = false;
//                 p.IsInputed = true;
//                 p.Value = fsValue.One;
//             }
//             fsCalculatorParameter oldResult = new fsCalculatorParameter(Result.Identifier, Result.IsInputed);
//             oldResult.IsProcessed = Result.IsProcessed;
//             oldResult.Value = Result.Value;
//             Result.IsInputed = false;
// 
//             double startTime = DateTime.Now.TimeOfDay.TotalSeconds;
//             int iterationsCount = 0;
//             while (DateTime.Now.TimeOfDay.TotalSeconds - startTime <= 1)
//             {
//                 ++iterationsCount;
//                 Calculate();
//             }
//             double result = (DateTime.Now.TimeOfDay.TotalSeconds - startTime) / iterationsCount;
//             // todo: restore old values
//             return result;
        }
    }
}
