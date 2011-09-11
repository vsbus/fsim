using System.Collections.Generic;
using Parameters;

namespace Equations
{
    public abstract class fsCalculatorEquation
    {
        #region Parameters

        private readonly List<IEquationParameter> m_parameters = new List<IEquationParameter>();

        #endregion

        #region Formulas

        protected delegate void fsFormula();

        private List<KeyValuePair<IEquationParameter, fsFormula>> m_formulas;

        protected void AddFormula(IEquationParameter result, fsFormula formula)
        {
            m_formulas.Add(new KeyValuePair<IEquationParameter, fsFormula>(result, formula));
        }

        protected abstract void InitFormulas();

        #endregion

        protected fsCalculatorEquation(params IEquationParameter[] parameters)
        {
            foreach (var p in parameters)
            {
                m_parameters.Add(p);
            }
        }

        #region Calculate

        public bool Calculate()
        {
            IEquationParameter result = null;
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

        private bool Calculate(IEquationParameter result)
        {
//             int sum = 0;
//             for (int i = 0; i < 50000000; ++i)
//             {
//                 sum += i;
//             }
//             sum -= 10;

            if (m_formulas == null)
            {
                m_formulas = new List<KeyValuePair<IEquationParameter, fsFormula>>();
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

        #endregion
    }
}
