using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace Equations.Material.Eps_Kappa_Equations
{
    public class fsCakeWetDensityFromKappaCvRhofRhocdEquation : fsCalculatorEquation
    {
        #region Parameters

        private readonly IEquationParameter m_cakeWetDensity;
        private readonly IEquationParameter m_cakeDrySolidsDensity;
        private readonly IEquationParameter m_filtrateDensity;
        private readonly IEquationParameter m_suspensionSolidsMassFraction;
        private readonly IEquationParameter m_kappa;
        

        #endregion

        public fsCakeWetDensityFromKappaCvRhofRhocdEquation(
            IEquationParameter cakeWetDensity,
            IEquationParameter cakeDrySolidsDensity,
            IEquationParameter filtrateDensity,
            IEquationParameter suspensionSolidsMassFraction,
            IEquationParameter kappa)
            : base(cakeWetDensity, cakeDrySolidsDensity, filtrateDensity, suspensionSolidsMassFraction, kappa)
        {
            m_cakeWetDensity = cakeWetDensity;
            m_cakeDrySolidsDensity = cakeDrySolidsDensity;
            m_filtrateDensity = filtrateDensity;
            m_suspensionSolidsMassFraction = suspensionSolidsMassFraction;
            m_kappa = kappa;
        }

        protected override void InitFormulas()
        {
            AddFormula(m_cakeWetDensity, CakeWetDensityFormula);
        }

        #region Formulas

        private void CakeWetDensityFormula()
        {
            m_cakeWetDensity.Value = m_cakeDrySolidsDensity.Value / m_suspensionSolidsMassFraction.Value
                                     - m_filtrateDensity.Value / m_kappa.Value;
        }

        #endregion
    }
}
