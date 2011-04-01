using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using SimulationSteps.StepsEquations;
using Value;

namespace SimulationSteps
{
    abstract public class fsStep
    {
        private Dictionary<fsParameterIdentifier, fsStepParameter> m_parameters = new Dictionary<fsParameterIdentifier, fsStepParameter>();
        private List<fsStepEquation> m_equations = new List<fsStepEquation>();

        public List<fsStepEquation> Equations
        {
            get { return m_equations; }
            set { m_equations = value; }
        }

        abstract protected void DefineParameters();

        abstract protected void DefineEquations();

        public fsStep()
        {
            DefineParameters();
            DefineEquations();
        }

        private bool IsCalculated(List<fsStepParameter> parametersList)
        {
            foreach (fsStepParameter parameter in parametersList)
            {
                if (parameter.IsProcessed == false)
                {
                    return false;
                }
            }
            return true;
        }

        public void Calculate()
        {
            foreach (fsStepParameter parameter in m_parameters.Values)
            {
                parameter.IsProcessed = parameter.IsInputed;
            }
            bool isUpdated = true;
            while (isUpdated)
            {
                isUpdated = false;
                foreach (fsStepEquation equation in m_equations)
                {
                    if (IsCalculated(equation.InputParameters) && !equation.OutputParameter.IsProcessed)
                    {
                        equation.Calculate();
                        equation.OutputParameter.IsProcessed = true;
                        isUpdated = true;
                    }
                }
            }
        }

        public void SetParameterInputedAndAssignValue(fsParameterIdentifier identifier, fsValue value)
        {
            fsStepParameter parameter = this.m_parameters[identifier];
            parameter.IsInputed = true;
            parameter.Value = value;
        }

        public void SetParameterInputedFlag(fsParameterIdentifier identifier, bool isInputed)
        {
            fsStepParameter parameter = this.m_parameters[identifier];
            parameter.IsInputed = isInputed;
        }

        public void SetValuesOfInputParametersDependingFromPreviousStep(IEnumerable<fsSimulationParameter> parameters)
        {
            foreach (fsSimulationParameter srcParameter in parameters)
            {
                if (this.m_parameters.ContainsKey(srcParameter.Identifier))
                {
                    fsStepParameter dstParameter = this.m_parameters[srcParameter.Identifier];
                    if (dstParameter.IsInputed && dstParameter.IsDependingFromPreviousStep)
                    {
                        CopyParameterValue(dstParameter, srcParameter);
                    }
                }
            }
        }

        public void GetParameters(IEnumerable<fsSimulationParameter> parameters)
        {
            foreach (fsSimulationParameter parameter in parameters)
            {
                if (this.m_parameters.ContainsKey(parameter.Identifier))
                {
                    CopyParameterValue(parameter, this.m_parameters[parameter.Identifier]);
                }
            }
        }

        protected fsStepParameter InitParameter(
            fsParameterIdentifier identifier,
            bool isDependingFromPreviousStep)
        {
            fsStepParameter parameter = new fsStepParameter(identifier, isDependingFromPreviousStep);
            m_parameters[identifier] = parameter;
            return parameter;
        }

        private void CopyParameterValue(fsSimulationParameter destParameter, fsSimulationParameter srcParameter)
        {
            destParameter.Value = srcParameter.Value;
        }

    }
}
