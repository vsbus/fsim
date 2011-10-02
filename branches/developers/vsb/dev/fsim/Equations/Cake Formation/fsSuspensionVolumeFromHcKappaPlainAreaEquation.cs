using Parameters;

namespace Equations
{
    public class fsSuspensionVolumeFromHcKappaPlainAreaEquation : fsCalculatorEquation
    {
        // Vsus * kappa = (kappa + 1) * A * hc;

        #region Parameters

        readonly IEquationParameter m_suspensionVolume;
        readonly IEquationParameter m_kappa;
        readonly IEquationParameter m_filterArea;
        readonly IEquationParameter m_cakeHeight;

        #endregion

        public fsSuspensionVolumeFromHcKappaPlainAreaEquation(
            IEquationParameter suspensionVolume,
            IEquationParameter kappa,
            IEquationParameter filterArea,
            IEquationParameter cakeHeight)
            : base(
                suspensionVolume,
                kappa,
                filterArea,
                cakeHeight)
        {
            m_suspensionVolume = suspensionVolume;
            m_kappa = kappa;
            m_filterArea = filterArea;
            m_cakeHeight = cakeHeight;
        }

        protected override void InitFormulas()
        {
            AddFormula(m_suspensionVolume, SuspensionVolumeFormula);
            AddFormula(m_cakeHeight, CakeHeightFormula);
            AddFormula(m_filterArea, FilterAreaFormula);
            AddFormula(m_kappa, KappaFormula);
        }

        #region Formulas

        private void SuspensionVolumeFormula()
        {
            m_suspensionVolume.Value = (m_kappa.Value + 1) / m_kappa.Value * m_filterArea.Value * m_cakeHeight.Value;
        }

        private void CakeHeightFormula()
        {
            m_cakeHeight.Value = m_suspensionVolume.Value * m_kappa.Value / ((m_kappa.Value + 1) * m_filterArea.Value);
        }

        private void FilterAreaFormula()
        {
            m_filterArea.Value = m_suspensionVolume.Value * m_kappa.Value / ((m_kappa.Value + 1) * m_cakeHeight.Value);
        }

        private void KappaFormula()
        {
            m_kappa.Value = 1 / (m_suspensionVolume.Value / (m_filterArea.Value * m_cakeHeight.Value) - 1);
        }

        #endregion
    }
}
