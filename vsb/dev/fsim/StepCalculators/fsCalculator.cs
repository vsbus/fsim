using System;
using System.Collections.Generic;

using System.Text;
using Parameters;
using Equations;
using UpdateHandler;
using Value;

namespace StepCalculators
{
    /*
     * fsStepCalculator is a base abstract class for all calculators
     * it consists of three main components
     *     m_constants:     values that calculated before and used in current calculator like constants
     *     m_parameters:    input by user/calculated or just calculated parameters
     *     m_equations:     set of equations that can be used for calculating values from m_parameters
     *     
     * In derivative classes user must override 
     *     InitParametersAndConstants():    here he must to initialize all constants and parameters
     *     InitEquations():                 here he must to add all corresponding equations
     *     
     * Then calculator can be used with public methods
     * 
     * */
    public abstract class fsCalculator
    {
        private Dictionary<fsParameterIdentifier, fsCalculatorVariable> m_variables = new Dictionary<fsParameterIdentifier, fsCalculatorVariable>();
        private Dictionary<fsParameterIdentifier, fsCalculatorConstant> m_constants = new Dictionary<fsParameterIdentifier, fsCalculatorConstant>();
        private List<fsCalculatorEquation> m_equations = new List<fsCalculatorEquation>();
        private fsCalculatorUpdateHandler m_updateHandler = null;

        #region Constructors
        
        public fsCalculator()
        {
            InitParameters();
            InitEquations();
        }

        #endregion

        protected abstract void InitParameters();
        protected abstract void InitEquations();

        #region Service Methods

        protected fsCalculatorVariable InitVariable(fsParameterIdentifier identifier)
        {
            var p = new fsCalculatorVariable(identifier);
            m_variables[identifier] = p;
            return p;
        }

        protected fsCalculatorConstant InitConstant(fsParameterIdentifier identifier)
        {
            var c = new fsCalculatorConstant(identifier);
            m_constants[identifier] = c;
            return c;
        }

        protected void AddEquation(fsCalculatorEquation equation)
        {
            m_equations.Add(equation);
        }

        #endregion

        public int GetToCalculateAmount()
        {
            int result = 0;
            foreach (var v in m_variables.Values)
            {
                result += v.isInput ? 0 : 1;
            }
            return result;
        }

        public void SetUpdateHandler(fsCalculatorUpdateHandler updateHandler)
        {
            m_updateHandler = updateHandler;
        }
        
        public void Calculate()
        {
            foreach (var p in m_variables.Values)
            {
                p.IsProcessed = p.isInput;
                if (p.IsProcessed == false)
                {
                    p.Value = new fsValue();
                }
            }
            
            #region Update Hander
            
            int startCount = 0;
            foreach (var p in m_variables.Values)
            {
                startCount += p.IsProcessed ? 1 : 0;
            }
            int currentCount = startCount;
            if (m_updateHandler != null)
            {
                m_updateHandler.SetProgress(0);
            }

            #endregion

            bool somethingChanged = true;
            while (somethingChanged)
            {
                somethingChanged = false;
                foreach (var equation in m_equations)
                    if (equation.Calculate())
                    {
                        somethingChanged = true;

                        #region Update Handler

                        ++currentCount;
                        if (m_updateHandler != null)
                        {
                            m_updateHandler.SetProgress((double)(currentCount - startCount) / (m_variables.Count - startCount));
                        }

                        #endregion
                    }
            }

            #region Update Handler

            if (m_updateHandler != null)
            {
                m_updateHandler.SetProgress(1);
            }

            #endregion
        }

        public string GetStatusMessage()
        {
            string message = "";
            foreach (var p in m_variables.Values)
            {
                if (!p.isInput && !p.IsProcessed)
                {
                    message += "     - Unable to calculate " + p.Identifier.Name + "\n";
                }
            }
            if (message.Length == 0)
            {
                message = " + All parameters was calculated successfully.\n";
            }
            else
            {
                message = " - Some parameters impossible to calculate:\n" + message;
            }
            return message;
        }

        #region Get/Set Values Data

        public void CopyValuesToStorage(Dictionary<fsParameterIdentifier, fsSimulationParameter> target)
        {
            foreach (fsParameterIdentifier p in target.Keys)
            {
                if (m_variables.ContainsKey(p))
                {
                    target[p].Value = m_variables[p].Value;
                }
            }
        }

        public void ReadDataFromStorage(Dictionary<fsParameterIdentifier, fsSimulationParameter> source)
        {
            foreach (fsParameterIdentifier p in source.Keys)
            {
                if (m_variables.ContainsKey(p))
                {
                    m_variables[p].Value = source[p].Value;
                    m_variables[p].isInput = source[p].isInput;
                }
                if (m_constants.ContainsKey(p))
                {
                    m_constants[p].Value = source[p].Value;
                }
            }
        }

        #endregion
    }
}
