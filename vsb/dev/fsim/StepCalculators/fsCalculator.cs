using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

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
        private Dictionary<fsParameterIdentifier, fsCalculatorParameter> m_parameters = new Dictionary<fsParameterIdentifier, fsCalculatorParameter>();
        private Dictionary<fsParameterIdentifier, fsCalculatorConstant> m_constants = new Dictionary<fsParameterIdentifier, fsCalculatorConstant>();
        private List<fsCalculatorEquation> m_equations = new List<fsCalculatorEquation>();

        protected abstract void InitParametersAndConstants();
        protected abstract void InitEquations();

        public void Calculate()
        {
            foreach (var p in m_parameters.Values)
            {
                p.IsProcessed = false;
            }
            bool somethingChanged = true;
            while (somethingChanged)
            {
                somethingChanged = false;
                foreach (var equation in m_equations)
                {
                    if (equation.CanBeCalculated())
                    {
                        equation.Calculate();
                        somethingChanged = true;
                    }
                }
            }
        }
        public string GetStatusMessage()
        {
            string message = "";
            foreach (var p in m_parameters.Values)
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
        public void CopyValuesToStorage(Dictionary<fsParameterIdentifier, fsSimulationParameter> target)
        {
            foreach (fsParameterIdentifier p in target.Keys)
            {
                if (m_parameters.ContainsKey(p))
                {
                    target[p].Value = m_parameters[p].Value;
                }
            }
        }
        public void ReadDataFromStorage(Dictionary<fsParameterIdentifier, fsSimulationParameter> source)
        {
            foreach (fsParameterIdentifier p in source.Keys)
            {
                if (m_parameters.ContainsKey(p))
                {
                    m_parameters[p].Value = source[p].Value;
                    m_parameters[p].isInput = source[p].isInput;
                }
                if (m_constants.ContainsKey(p))
                {
                    m_constants[p].Value = source[p].Value;
                }
            }
        }
        public fsCalculator()
        {
            InitParametersAndConstants();
            InitEquations();
        }
        public string GetEquationWeights()
        {
            string res = "";
            foreach (var e in m_equations)
            {
                res += e.ToString() + ": " + e.GetWeight() + "\n";
            }
            return res;
        }

        protected fsCalculatorParameter InitParameter(fsParameterIdentifier identifier)
        {
            var p = new fsCalculatorParameter(identifier);
            m_parameters[identifier] = p;
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
    }
}
