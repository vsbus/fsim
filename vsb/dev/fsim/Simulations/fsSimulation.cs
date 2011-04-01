using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using SimulationSteps;

namespace Simulations
{
    abstract public class fsSimulation
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

        abstract protected void InitParameters();
        abstract public void Run();

        protected void AddParameter(fsParameterIdentifier identifier)
        {
            m_parameters[identifier] = new fsSimulationParameter(identifier);
        }
        protected fsSimulation()
        {
            InitParameters();
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
