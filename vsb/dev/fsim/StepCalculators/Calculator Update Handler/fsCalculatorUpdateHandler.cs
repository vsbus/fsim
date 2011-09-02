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
        private Control m_statusControl = null;

        public fsCalculatorUpdateHandler(Control statusControl)
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

        public void SetProgress(double progress)
        {
            if (m_parentHandler == null)
            {
                m_statusControl.Text = ((int)(progress * 100 + 0.5)).ToString() + "%";
                m_statusControl.Refresh();
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
