using System;
using System.Collections.Generic;
using System.Text;
using Parameters;

namespace Equations
{
    public abstract class fsCalculatorEquation
    {
        #region Parameters

        private List<IEquationParameter> m_parameters = new List<IEquationParameter>();

        #endregion

        #region Formulas

        protected delegate void Formula();

        private List<KeyValuePair<IEquationParameter, Formula>> m_formulas = null;

        protected void AddFormula(IEquationParameter result, Formula formula)
        {
            m_formulas.Add(new KeyValuePair<IEquationParameter, Formula>(result, formula));
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
                m_formulas = new List<KeyValuePair<IEquationParameter, Formula>>();
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
