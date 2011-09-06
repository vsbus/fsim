using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;

namespace UpdateHandler
{
    public class fsCalculatorUpdateHandler
    {
        private fsCalculatorUpdateHandler m_parentHandler = null;
        private double m_startValue = 0;
        private double m_endValue = 1;
        private fsIUpdatable m_statusControl = null;

        public fsCalculatorUpdateHandler(fsIUpdatable statusControl)
        {
            m_statusControl = statusControl;
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

        private delegate void CallUpdateProgressBar(fsIUpdatable statusControl, int progress);
        static private void UpdateProgressBar(fsIUpdatable statusControl, int progress)
        {
            statusControl.Value = progress;
            statusControl.Refresh();
        }

        public void SetProgress(double progress)
        {
            if (m_parentHandler == null)
            {
                int intProgress = (int)(progress * m_statusControl.Maximum + 0.5);
                m_statusControl.Invoke(
                    new CallUpdateProgressBar(UpdateProgressBar),
                    new object[] { m_statusControl, intProgress });
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
