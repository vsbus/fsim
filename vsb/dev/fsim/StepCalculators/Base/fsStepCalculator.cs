﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public abstract class fsStepCalculator
    {
        private Dictionary<fsParameterIdentifier, fsCalculatorParameter> m_parameters = new Dictionary<fsParameterIdentifier, fsCalculatorParameter>();
        
        private List<fsCalculatorEquation> m_equations = new List<fsCalculatorEquation>();
        protected List<fsCalculatorEquation> Equations
        {
            get { return m_equations; }
            set { m_equations = value; }
        }

        public fsStepCalculator()
        {
            InitParameters();
            InitEquations();
        }

        protected fsCalculatorParameter InitParameter(fsParameterIdentifier identifier)
        {
            fsCalculatorParameter p = new fsCalculatorParameter(identifier);
            m_parameters[identifier] = p;
            return p;
        }

        protected abstract void InitParameters();

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
                if (!p.IsInputed && !p.IsProcessed)
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

        public void ReadParametersValues(Dictionary<fsParameterIdentifier, fsSimulationParameter> target)
        {
            foreach (fsParameterIdentifier p in target.Keys)
            {
                if (m_parameters.ContainsKey(p))
                {
                    target[p].Value = m_parameters[p].Value;
                }
            }
        }

        public void WriteParametersData(Dictionary<fsParameterIdentifier, fsSimulationParameter> source)
        {
            foreach (fsParameterIdentifier p in source.Keys)
            {
                if (m_parameters.ContainsKey(p))
                {
                    m_parameters[p].Value = source[p].Value;
                    m_parameters[p].IsInputed = source[p].IsInputed;
                }
            }
        }
    }
}
