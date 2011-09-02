using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace Equations
{
    public abstract class fsCalculatorEquation
    {
        #region Parameters

        private List<fsIEquationParameter> m_parameters = new List<fsIEquationParameter>();

        #endregion

        #region Formulas

        protected delegate void Formula();

        private List<KeyValuePair<fsIEquationParameter, Formula>> m_formulas = null;

        protected void AddFormula(fsIEquationParameter result, Formula formula)
        {
            m_formulas.Add(new KeyValuePair<fsIEquationParameter, Formula>(result, formula));
        }

        protected abstract void InitFormulas();

        #endregion

        protected fsCalculatorEquation(params fsIEquationParameter[] parameters)
        {
            foreach (var p in parameters)
            {
                m_parameters.Add(p);
            }
        }

        #region Calculate

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
            //int sum = 0;
            //for (int i = 0; i < 50000000; ++i)
            //{
            //    sum += i;
            //}
            //sum -= 10;

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

        #endregion
    }
}
