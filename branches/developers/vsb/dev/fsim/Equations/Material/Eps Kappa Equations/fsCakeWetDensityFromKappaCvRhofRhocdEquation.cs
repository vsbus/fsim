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
        private readonly IEquationParameter m_suspensionSolidsVolumeFraction;
        private readonly IEquationParameter m_kappa;
        

        #endregion

        public fsCakeWetDensityFromKappaCvRhofRhocdEquation(
            IEquationParameter cakeWetDensity,
            IEquationParameter cakeDrySolidsDensity,
            IEquationParameter filtrateDensity,
            IEquationParameter suspensionSolidsVolumeFraction,
            IEquationParameter kappa)
            : base(cakeWetDensity, cakeDrySolidsDensity, filtrateDensity, suspensionSolidsVolumeFraction, kappa)
        {
            m_cakeWetDensity = cakeWetDensity;
            m_cakeDrySolidsDensity = cakeDrySolidsDensity;
            m_filtrateDensity = filtrateDensity;
            m_suspensionSolidsVolumeFraction = suspensionSolidsVolumeFraction;
            m_kappa = kappa;
        }

        protected override void InitFormulas()
        {
            AddFormula(m_cakeWetDensity, CakeWetDensityFormula);
        }

        #region Formulas

        private void CakeWetDensityFormula()
        {
            m_cakeWetDensity.Value = m_cakeDrySolidsDensity.Value / m_suspensionSolidsVolumeFraction.Value
                                     - m_filtrateDensity.Value / m_kappa.Value;
        }

        #endregion
    }
}
