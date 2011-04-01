using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace SimulationSteps.StepsEquations
{
    abstract public class fsStepEquation
    {
        private List<fsStepParameter> m_inputParameters = new List<fsStepParameter>();
        public List<fsStepParameter> InputParameters
        {
            get { return m_inputParameters; }
        }

        private fsStepParameter m_outputParameter;
        public fsStepParameter OutputParameter
        {
            get { return m_outputParameter; }
        }

        protected fsEquationParameter InitInputParameter(fsStepParameter parameter)
        {
            m_inputParameters.Add(parameter);
            return parameter;
        }

        protected fsEquationParameter InitOutputParameter(fsStepParameter parameter)
        {
            m_outputParameter = parameter;
            return parameter;
        }

        abstract public void Calculate();
    }
}
