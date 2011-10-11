﻿using Parameters;
using Value;

namespace Equations
{
    public class fsSuspensionMassFromHcEpsConcaveCylindircAreaEquation : fsCalculatorEquation
    {
        // Msus * Cm = (1 - eps) * rho_s * A * hc * (1 - hc / d);

        #region Parameters

        readonly IEquationParameter m_suspensionMass;
        readonly IEquationParameter m_porosity;
        readonly IEquationParameter m_solidsDensity;
        readonly IEquationParameter m_filterArea;
        readonly IEquationParameter m_filterDiameter;
        readonly IEquationParameter m_cakeHeight;
        readonly IEquationParameter m_solidsMassFraction;

        #endregion

        public fsSuspensionMassFromHcEpsConcaveCylindircAreaEquation(
            IEquationParameter suspensionMass,
            IEquationParameter porosity,
            IEquationParameter solidsDensity,
            IEquationParameter filterArea,
            IEquationParameter filterDiameter,
            IEquationParameter cakeHeight,
            IEquationParameter solidsMassFraction)
            : base(
                suspensionMass,
                porosity,
                solidsDensity,
                filterArea,
                filterDiameter,
                cakeHeight,
                solidsMassFraction)
        {
            m_suspensionMass = suspensionMass;
            m_porosity = porosity;
            m_solidsDensity = solidsDensity;
            m_filterArea = filterArea;
            m_filterDiameter = filterDiameter;
            m_cakeHeight = cakeHeight;
            m_solidsMassFraction = solidsMassFraction;
        }

        protected override void InitFormulas()
        {
            AddFormula(m_suspensionMass, SuspensionMassFormula);
            AddFormula(m_cakeHeight, CakeHeightFormula);
            AddFormula(m_filterArea, FilterAreaFormula);
            AddFormula(m_filterDiameter, FilterDiameterFormula);
            AddFormula(m_solidsDensity, SolidsDensityFormula);
            AddFormula(m_porosity, PorosityFormula);
            AddFormula(m_solidsMassFraction, SolidsMassFractionFormula);
        }

        #region Formulas

        private void SuspensionMassFormula()
        {
            m_suspensionMass.Value = (1 - m_porosity.Value) * m_solidsDensity.Value * m_filterArea.Value *
                                     m_cakeHeight.Value * (1 - m_cakeHeight.Value / m_filterDiameter.Value) /
                                     m_solidsMassFraction.Value;
        }

        private void CakeHeightFormula()
        {
            fsValue const1 = (1 - m_porosity.Value) * m_solidsDensity.Value * m_filterArea.Value;
            fsValue a = -const1 / m_filterDiameter.Value;
            fsValue b = const1;
            fsValue c = -m_suspensionMass.Value * m_solidsMassFraction.Value;
            fsValue D = b * b - 4 * a * c;
            m_cakeHeight.Value = (-b + fsValue.Sqrt(D)) / (2 * a);
        }

        private void FilterAreaFormula()
        {
            m_filterArea.Value = m_suspensionMass.Value * m_solidsMassFraction.Value /
                                 ((1 - m_porosity.Value) * m_solidsDensity.Value * m_cakeHeight.Value *
                                  (1 - m_cakeHeight.Value / m_filterDiameter.Value));
        }

        private void SolidsDensityFormula()
        {
            m_solidsDensity.Value = m_suspensionMass.Value * m_solidsMassFraction.Value /
                                    ((1 - m_porosity.Value) * m_filterArea.Value * m_cakeHeight.Value *
                                     (1 - m_cakeHeight.Value / m_filterDiameter.Value));
        }

        private void PorosityFormula()
        {
            m_porosity.Value = 1 -
                               m_suspensionMass.Value * m_solidsMassFraction.Value /
                               (m_solidsDensity.Value * m_filterArea.Value * m_cakeHeight.Value *
                                (1 - m_cakeHeight.Value / m_filterDiameter.Value));
        }

        private void SolidsMassFractionFormula()
        {
            m_solidsMassFraction.Value = (1 - m_porosity.Value) * m_solidsDensity.Value * m_filterArea.Value *
                                         m_cakeHeight.Value * (1 - m_cakeHeight.Value / m_filterDiameter.Value) /
                                         m_suspensionMass.Value;
        }

        private void FilterDiameterFormula()
        {
            fsValue left = m_suspensionMass.Value * m_solidsMassFraction.Value;
            fsValue right = (1 - m_porosity.Value) * m_solidsDensity.Value * m_filterArea.Value * m_cakeHeight.Value;
            m_filterDiameter.Value = m_cakeHeight.Value / (1 - left / right);
        }

        #endregion
    }
}