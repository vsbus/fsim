﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Equations;
using Parameters;

namespace StepCalculators
{
    public class fsMsusHcConvexCylindricAreaCalculator : fsCalculator
    {
        readonly fsCalculatorVariable m_filtrateDensity;
        readonly fsCalculatorVariable m_solidsDensity;
        readonly fsCalculatorVariable m_suspensionDensity;
        readonly fsCalculatorVariable m_solidsMassFraction;
        readonly fsCalculatorVariable m_solidsVolumeFraction;
        readonly fsCalculatorVariable m_solidsConcentration;

        readonly fsCalculatorVariable m_porosity;
        readonly fsCalculatorVariable m_kappa;
        
        readonly fsCalculatorVariable m_filterArea;
        readonly fsCalculatorVariable m_filterDiameter;

        readonly fsCalculatorVariable m_cakeHeight;

        readonly fsCalculatorVariable m_suspensionMass;
        readonly fsCalculatorVariable m_suspensionVolume;

        public fsMsusHcConvexCylindricAreaCalculator()
        {
            #region Parameters Initialization

            m_filtrateDensity = AddVariable(fsParameterIdentifier.FiltrateDensity);
            m_solidsDensity = AddVariable(fsParameterIdentifier.SolidsDensity);
            m_suspensionDensity = AddVariable(fsParameterIdentifier.SuspensionDensity);
            m_solidsMassFraction = AddVariable(fsParameterIdentifier.SolidsMassFraction);
            m_solidsVolumeFraction = AddVariable(fsParameterIdentifier.SolidsVolumeFraction);
            m_solidsConcentration = AddVariable(fsParameterIdentifier.SolidsConcentration);

            m_porosity = AddVariable(fsParameterIdentifier.Porosity);
            m_kappa = AddVariable(fsParameterIdentifier.Kappa);
            
            m_filterArea = AddVariable(fsParameterIdentifier.FilterArea);
            m_filterDiameter = AddVariable(fsParameterIdentifier.FilterDiameter);

            m_cakeHeight = AddVariable(fsParameterIdentifier.CakeHeight);
            m_suspensionMass = AddVariable(fsParameterIdentifier.SuspensionMass);
            m_suspensionVolume = AddVariable(fsParameterIdentifier.SuspensionVolume);

            #endregion

            #region Equations Initialization

            AddEquation(new fsMassConcentrationEquation(m_solidsMassFraction, m_filtrateDensity, m_solidsDensity, m_suspensionDensity));
            AddEquation(new fsVolumeConcentrationEquation(m_solidsVolumeFraction, m_filtrateDensity, m_solidsDensity, m_suspensionDensity));
            AddEquation(new fsConcentrationEquation(m_solidsConcentration, m_filtrateDensity, m_solidsDensity, m_suspensionDensity));

            AddEquation(new fsEpsKappaCvEquation(m_porosity, m_kappa, m_solidsVolumeFraction));

            AddEquation(new fsSuspensionMassFromHcEpsConvexCylindircAreaEquation(m_suspensionMass, m_porosity, m_solidsDensity, m_filterArea, m_filterDiameter, m_cakeHeight, m_solidsMassFraction));
            //AddEquation(new fsSuspensionVolumeFromHcEpsConvexCylindircAreaEquation(m_suspensionVolume, m_porosity, m_filterArea, m_cakeHeight, m_solidsVolumeFraction));
            //AddEquation(new fsSuspensionVolumeFromHcKappaConvexCylindircAreaEquation(m_suspensionVolume, m_kappa, m_filterArea, m_cakeHeight));

            AddEquation(new fsProductEquation(m_suspensionMass, m_suspensionVolume, m_suspensionDensity));
            
            #endregion
        }
    }
}