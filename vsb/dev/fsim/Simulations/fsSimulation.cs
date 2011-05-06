using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using SimulationSteps;
using System.Threading;

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

        private Thread m_calculatingThread = null;

        public fsSimulation(params fsParameterIdentifier[] parameters)
        {
            foreach (fsParameterIdentifier parameter in parameters)
            {
                AddParameter(parameter);
            }
        }
		
        public void RunCalculations()
        {
            if (m_calculatingThread != null)
            {
                throw new Exception("Attempt to run simulation calculations before previous call was finished. Please check calls of StopCalculation() in proper places");
            }
            m_calculatingThread = new Thread(new ThreadStart(DoCalculations));
            m_calculatingThread.Start();
        }
		
        public void StopCalculations()
        {
            if (m_calculatingThread != null)
            {
                m_calculatingThread.Abort();
                m_calculatingThread = null;
            }
        }
		
        public bool IsCalculating()
        {
            return m_calculatingThread != null;
        }

        private void DoCalculations()
        {
            for (int i = 0; i < Steps.Count; ++i)
            {
                Steps[i].SetValuesOfInputParametersDependingFromPreviousStep(Parameters.Values);
                Steps[i].Calculate();
                Steps[i].GetParameters(Parameters.Values);
            }
            m_calculatingThread = null;
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
