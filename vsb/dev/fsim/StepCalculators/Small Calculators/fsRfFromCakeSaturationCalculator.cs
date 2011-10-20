using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;

namespace StepCalculators
{
    public class fsRfFromCakeSaturationCalculator : fsCalculator
    {
        readonly fsCalculatorConstant m_liquidDensity;
        readonly fsCalculatorConstant m_solidsDensity;
        readonly fsCalculatorVariable m_cakePorosity;
        readonly fsCalculatorVariable m_cakeSaturation;
        readonly fsCalculatorVariable m_cakeMoistureContent;

        public fsRfFromCakeSaturationCalculator()
        {
            #region Parameters Initialization

            m_liquidDensity = AddConstant(fsParameterIdentifier.LiquidDensity);
            m_solidsDensity = AddConstant(fsParameterIdentifier.SolidsDensity);
            m_cakePorosity = AddVariable(fsParameterIdentifier.CakePorosity);
            m_cakeSaturation = AddVariable(fsParameterIdentifier.CakeSaturation);
            m_cakeMoistureContent = AddVariable(fsParameterIdentifier.CakeMoistureContent);

            #endregion

            #region Equations Initialization

            #endregion
        }
    }
}
