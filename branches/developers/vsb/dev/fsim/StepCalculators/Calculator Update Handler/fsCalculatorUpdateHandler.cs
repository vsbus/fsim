using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StepCalculators
{
    public class fsCalculatorUpdateHandler
    {
        private fsCalculatorUpdateHandler m_parentHandler = null;
        private double m_startValue = 0;
        private double m_endValue = 1;
        private ProgressBar m_progressBar = null;

        public fsCalculatorUpdateHandler(ProgressBar statusControl)
        {
            m_progressBar = statusControl;
        }

        private fsCalculatorUpdateHandler(
            fsCalculatorUpdateHandler parentHandler,
            double startValue,
            double endValue)
        {
            m_parentHandler = parentHandler;
            m_startValue = startValue;
            m_endValue = endValue;
        }

        public void SetProgress(double progress)
        {
            if (m_parentHandler == null)
            {
                //m_progressBar.Text = ((int)(progress * 100 + 0.5)).ToString() + "%";
                int intProgress = (int)(progress * m_progressBar.Maximum + 0.5);
                m_progressBar.Value = intProgress;
                m_progressBar.Refresh();
            }
            else
            {
                m_parentHandler.SetProgress(m_startValue + (m_endValue - m_startValue) * progress);
            }
        }

        public fsCalculatorUpdateHandler CreateSubHandler(double startValue, double endValue)
        {
            return new fsCalculatorUpdateHandler(this, startValue, endValue);
        }
    }

}
