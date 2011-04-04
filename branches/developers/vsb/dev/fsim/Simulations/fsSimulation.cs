using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using SimulationSteps;

namespace Simulations
{
    public class fsSimulation
    {
        private Dictionary<fsParameterIdentifier, fsSimulationParameter> m_parameters = new Dictionary<fsParameterIdentifier, fsSimulationParameter>();
        public Dictionary<fsParameterIdentifier, fsSimulationParameter> Parameters
        {
            get { return m_parameters; }
            set { m_parameters = value; }
        }

        private List<fsStep> m_steps = new List<fsStep>();
        public List<fsStep> Steps
        {
            get { return m_steps; }
            set { m_steps = value; }
        }

        public fsSimulation(params fsParameterIdentifier[] parameters)
        {
            foreach (fsParameterIdentifier parameter in parameters)
            {
                AddParameter(parameter);
            }
        }
        public void Run()
        {
            for (int i = 0; i < Steps.Count; ++i)
            {
                Steps[i].SetValuesOfInputParametersDependingFromPreviousStep(Parameters.Values);
                Steps[i].Calculate();
                Steps[i].GetParameters(Parameters.Values);
            }
        }
        
        private void AddParameter(fsParameterIdentifier identifier)
        {
            m_parameters[identifier] = new fsSimulationParameter(identifier);
        }
        public override string ToString()
        {
            string res = "";
            foreach (fsSimulationParameter parameter in Parameters.Values)
            {
                res += parameter.Identifier.Name + " = " + parameter.Value.ToString() + "; ";
            }
            return res;
        }
    }
}
