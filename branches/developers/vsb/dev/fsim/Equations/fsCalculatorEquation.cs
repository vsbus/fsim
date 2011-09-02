using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace Equations
{
    public abstract class fsCalculatorEquation
    {
        protected delegate void Formula();
        private List<KeyValuePair<fsIEquationParameter, Formula>> m_formulas = null;

        private List<fsIEquationParameter> m_parameters = new List<fsIEquationParameter>();

        protected fsCalculatorEquation(params fsIEquationParameter[] parameters)
        {
            foreach (var p in parameters)
            {
                m_parameters.Add(p);
            }
        }

        public bool Calculate()
        {
            fsIEquationParameter result = null;
            foreach (var p in m_parameters)
            {
                if (p.IsProcessed == false)
                    if (result == null)
                        result = p;
                    else
                        return false;
            }
            if (result == null)
                return false;
            if (Calculate(result))
            {
                result.IsProcessed = true;
                return true;
            }
            return false;
        }

        private bool Calculate(fsIEquationParameter result)
        {
            if (m_formulas == null)
            {
                m_formulas = new List<KeyValuePair<fsIEquationParameter, Formula>>();
                InitFormulas();
            }
            foreach (var f in m_formulas)
            {
                if (f.Key == result)
                {
                    f.Value();
                    return true;
                }
            }
            return false;
        }

        protected abstract void InitFormulas();

        protected void AddFormula(fsIEquationParameter result, Formula formula)
        {
            m_formulas.Add(new KeyValuePair<fsIEquationParameter,Formula>(result, formula));
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
