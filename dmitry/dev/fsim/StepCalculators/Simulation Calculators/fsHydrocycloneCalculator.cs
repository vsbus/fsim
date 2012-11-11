﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parameters;
using Value;
using Units;
using Equations;
using Equations.Hydrocyclone;

namespace StepCalculators.Simulation_Calculators
{
    public class fsHydrocycloneCalculator : fsCalculator
    {
        // Introducing the clone of the parameter NumberOfCyclClones is the easiest way to deal with
        // the copy of NumberOfCyclClones (as only calculated) in  other fsParametersWithValuesTable.
        public static fsParameterIdentifier NumberOfCyclClone =
            new fsParameterIdentifier("n", "Number of Cyclones", fsCharacteristic.NoUnits);

        public fsHydrocycloneCalculator()
        {  
            #region Parameters Initialization

            IEquationParameter etaf = AddConstant(fsParameterIdentifier.MotherLiquidViscosity);
            IEquationParameter rhoS = AddConstant(fsParameterIdentifier.SolidsDensity);
            IEquationParameter rhoF = AddConstant(fsParameterIdentifier.MotherLiquidDensity);
            IEquationParameter rhoSus = AddConstant(fsParameterIdentifier.SuspensionDensity);
            IEquationParameter cv = AddConstant(fsParameterIdentifier.SuspensionSolidsVolumeFraction);
            IEquationParameter cm = AddConstant(fsParameterIdentifier.SuspensionSolidsMassFraction);

            IEquationParameter xG = AddVariable(fsParameterIdentifier.xg);
            IEquationParameter sigmaG = AddVariable(fsParameterIdentifier.sigma_g);
            IEquationParameter sigmaS = AddVariable(fsParameterIdentifier.sigma_s);

            IEquationParameter rf = AddVariable(fsParameterIdentifier.rf);
            IEquationParameter DuOverD = AddVariable(fsParameterIdentifier.DuOverD);
            IEquationParameter xRed50 = AddVariable(fsParameterIdentifier.ReducedCutSize);
            IEquationParameter D = AddVariable(fsParameterIdentifier.MachineDiameter);

            IEquationParameter xoi = AddVariable(fsParameterIdentifier.OverflowParticleSize);
            IEquationParameter xui = AddVariable(fsParameterIdentifier.UnderflowParticleSize);
            IEquationParameter i = AddVariable(fsParameterIdentifier.PercentageOfParticles);

            IEquationParameter xo50 = AddVariable(fsParameterIdentifier.OverflowMeanParticleSize);
            IEquationParameter xu50 = AddVariable(fsParameterIdentifier.UnderflowMeanParticleSize);

            IEquationParameter numberOfCyclones = AddVariable(fsParameterIdentifier.NumberOfCyclones);
            IEquationParameter Dp = AddVariable(fsParameterIdentifier.PressureDifference);

            IEquationParameter Q = AddVariable(fsParameterIdentifier.FeedVolumeFlowRate);
            IEquationParameter Qm = AddVariable(fsParameterIdentifier.FeedSolidsMassFlowRate);
            IEquationParameter Qms = AddVariable(fsParameterIdentifier.Qms);

            IEquationParameter Cu = AddVariable(fsParameterIdentifier.UnderflowSolidsConcentration);
            IEquationParameter Co = AddVariable(fsParameterIdentifier.OverflowSolidsConcentration);
            IEquationParameter C = AddConstant(fsParameterIdentifier.SuspensionSolidsConcentration);

            IEquationParameter ReducedTotalEfficiency = AddVariable(fsParameterIdentifier.ReducedTotalEfficiency);
            IEquationParameter TotalEfficiency = AddVariable(fsParameterIdentifier.TotalEfficiency);

            IEquationParameter StokesNumber = AddVariable(fsParameterIdentifier.StokesNumber);
            IEquationParameter EulerNumber = AddVariable(fsParameterIdentifier.EulerNumber);
            IEquationParameter ReynoldsNumber = AddVariable(fsParameterIdentifier.ReynoldsNumber);
            IEquationParameter v = AddVariable(fsParameterIdentifier.AverageVelocity);

            
            IEquationParameter alpha1 = AddVariable(fsParameterIdentifier.Alpha1);
            IEquationParameter alpha2 = AddVariable(fsParameterIdentifier.Alpha2);
            IEquationParameter alpha3 = AddVariable(fsParameterIdentifier.Alpha3);
            IEquationParameter beta1 = AddVariable(fsParameterIdentifier.Beta1);
            IEquationParameter beta2 = AddVariable(fsParameterIdentifier.Beta2);
            IEquationParameter beta3 = AddVariable(fsParameterIdentifier.Beta3);
            IEquationParameter gamma1 = AddVariable(fsParameterIdentifier.Gamma1);
            IEquationParameter gamma2 = AddVariable(fsParameterIdentifier.Gamma2);
            IEquationParameter gamma3 = AddVariable(fsParameterIdentifier.Gamma3);

            IEquationParameter LOverD = AddVariable(fsParameterIdentifier.bigLOverD);
            IEquationParameter lOverD = AddVariable(fsParameterIdentifier.smallLOverD);
            IEquationParameter DiOverD = AddVariable(fsParameterIdentifier.DiOverD);
            IEquationParameter DoOverD = AddVariable(fsParameterIdentifier.DoOverD);

            IEquationParameter L = AddVariable(fsParameterIdentifier.CycloneLength);
            IEquationParameter l = AddVariable(fsParameterIdentifier.LengthOfCylindricalPart);
            IEquationParameter Di = AddVariable(fsParameterIdentifier.InletDiameter);
            IEquationParameter Do = AddVariable(fsParameterIdentifier.OutletDiameter);
            IEquationParameter Du = AddVariable(fsParameterIdentifier.UnderflowDiameter);
            IEquationParameter Qo = AddVariable(fsParameterIdentifier.OverflowVolumeFlowRate);
            IEquationParameter Qu = AddVariable(fsParameterIdentifier.UnderflowVolumeFlowRate);
            IEquationParameter Qmo = AddVariable(fsParameterIdentifier.OverflowMassFlowRate);
            IEquationParameter Qmu = AddVariable(fsParameterIdentifier.UnderflowMassFlowRate);
            IEquationParameter Qso = AddVariable(fsParameterIdentifier.OverflowSolidsMassFlowRate);
            IEquationParameter Qsu = AddVariable(fsParameterIdentifier.UnderflowSolidsMassFlowRate);
            IEquationParameter cmo = AddVariable(fsParameterIdentifier.OverflowSolidsMassFraction);
            IEquationParameter cmu = AddVariable(fsParameterIdentifier.UnderflowSolidsMassFraction);
            IEquationParameter cvo = AddVariable(fsParameterIdentifier.OverflowSolidsVolumeFraction);
            IEquationParameter cvu = AddVariable(fsParameterIdentifier.UnderflowSolidsVolumeFraction);
            
            #region Help Parameters and Constants

            var constantZero = new fsCalculatorConstant(new fsParameterIdentifier("0")) { Value = fsValue.Zero };
            var constantHalf = new fsCalculatorConstant(new fsParameterIdentifier("0.5")) { Value = new fsValue(0.5) };
            var constantOne = new fsCalculatorConstant(new fsParameterIdentifier("1")) { Value = fsValue.One };
            var constantTwo = new fsCalculatorConstant(new fsParameterIdentifier("2")) { Value = new fsValue(2) };
            var constantPi = new fsCalculatorConstant(new fsParameterIdentifier("Pi")) { Value = new fsValue(Math.PI) };
            var constantFour = new fsCalculatorConstant(new fsParameterIdentifier("4")) { Value = new fsValue(4) };
            var constantEighteen = new fsCalculatorConstant(new fsParameterIdentifier("18")) { Value = new fsValue(18) };


            IEquationParameter numberOfCyclClone = AddVariable(NumberOfCyclClone);
            Equations.Add(new fsSumEquation(numberOfCyclones, constantZero, numberOfCyclClone));

            IEquationParameter rhoSMinusRhoF = AddVariable(new fsParameterIdentifier("rho_s - rho_f"));
            Equations.Add(new fsSumEquation(rhoS, rhoF, rhoSMinusRhoF));

            IEquationParameter rhoSusOverflow = AddVariable(new fsParameterIdentifier("rho_sus_overflow"));
            IEquationParameter rhoSusUnderflow = AddVariable(new fsParameterIdentifier("rho_sus_underflow"));

            #endregion

            #endregion

            #region Equations Initialization

            Equations.Add(new fsProductEquation(Qm, Q, rhoSus)); // (6)
            Equations.Add(new fsProductEquation(Qms, Qm, cm));   // (7)

            Equations.Add(new fsReducedTotalEfficiencyEquation(ReducedTotalEfficiency, xG, xRed50, sigmaG, sigmaS)); // (2)
            Equations.Add(new fsTotalEfficiencyEquation(TotalEfficiency, rf, ReducedTotalEfficiency)); // (1)

            Equations.Add(new fsProductEquation(Qu, rf, Q)); // (3)
            Equations.Add(new fsCUnderflowEquation(Cu, C, rf, ReducedTotalEfficiency)); // (4)
            Equations.Add(new fsCOverflowEquation(Co, C, ReducedTotalEfficiency)); // (5)

            Equations.Add(new fsDFromxRed50QnDuOverDEquation(D, xRed50, Q, numberOfCyclones, DuOverD, rhoS, rhoF, etaf, cv, alpha1, alpha2, alpha3, beta1, beta2, beta3, gamma1, gamma2, gamma3)); // (30)
            
            Equations.Add(new fsProductsEquation( // (13)
                new[] { v, constantPi, D, D, numberOfCyclones },
                new[] { constantFour, Q }));
            Equations.Add(new fsProductsEquation( // (10)
                new[] { StokesNumber, constantEighteen, etaf, D },
                new[] { xRed50, xRed50, rhoSMinusRhoF, v }));
            Equations.Add(new fsProductsEquation( // (11)
                new[] { EulerNumber, rhoF, v, v },
                new[] { constantTwo, Dp }));
            Equations.Add(new fsProductsEquation( // (12)
                new[] { ReynoldsNumber, etaf },
                new[] { rhoF, D, v }));

            Equations.Add(new fsDFromxRed50QnRfEquation(D, xRed50, rhoS, rhoF, Q, etaf, numberOfCyclones, cv, rf, alpha1, alpha2, alpha3, beta1, beta2, beta3)); // (14)
            Equations.Add(new fsDuOverDrfEuEquation(DuOverD, rf, EulerNumber, gamma1, gamma2, gamma3)); // (9)
            Equations.Add(new fsEulerReynoldsConnectionEquation(EulerNumber, ReynoldsNumber, cv, beta1, beta2, beta3)); // (8)
            Equations.Add(new fsReynoldsFromXRed50Equation(ReynoldsNumber, xRed50, rhoS, rhoF, etaf, Dp, rf, cv, alpha1, alpha2, alpha3)); // (29)
            Equations.Add(new fsvDuOverDxRed50Equation(v, DuOverD, xRed50, rhoS, rhoF, etaf, Dp, cv, alpha1, alpha2, alpha3, beta1, beta2, beta3, gamma1, gamma2, gamma3)); // (31)
            Equations.Add(new fsQnDpDEquation(Q, Dp, numberOfCyclones, D, rhoF, etaf, cv, beta1, beta2, beta3)); // (32)

            Equations.Add(new fsReducedTotalEfficiencyFromCmoEquation(ReducedTotalEfficiency, cmo, C, rhoS, rhoF)); // (33)
            Equations.Add(new fsXRed50Equation(xRed50, D, Q, numberOfCyclones, rhoS, rhoF, etaf, C, Cu, cv, xG, sigmaG, sigmaS, alpha1, alpha2, alpha3, beta1, beta2, beta3)); // (34)
            Equations.Add(new fsXoiXred50Equation(xRed50, xoi, sigmaG, sigmaS, xG, i));  // (35)
            Equations.Add(new fsXuiXred50RfEquation(xRed50, xui, sigmaG, sigmaS, xG, i, rf));  // (36)
            Equations.Add(new fsXRed50XuiDuOverDQnEquation(DuOverD, Q, numberOfCyclones, xRed50, alpha1, alpha2, alpha3, beta1, beta2, beta3, gamma1, gamma2, gamma3, cv, rhoF, rhoS, etaf, sigmaS, sigmaG, xG, xui, i)); // (37)
            Equations.Add(new fsXRed50XuiDuOverDDpEquation(DuOverD, Dp, xRed50, alpha1, alpha2, alpha3, beta1, beta2, beta3, gamma1, gamma2, gamma3, cv, rhoF, rhoS, etaf, sigmaS, sigmaG, xG, xui, i)); // (38)
            Equations.Add(new fsXRed50XuiCuCEquation(Cu, C, xRed50, sigmaS, sigmaG, xG, xui, i));  // (39)

            Equations.Add(new fsXoiXred50Equation(xRed50, xo50, sigmaG, sigmaS, xG, constantHalf)); // (35)
            Equations.Add(new fsXuiXred50RfEquation(xRed50, xu50, sigmaG, sigmaS, xG, constantHalf, rf));  // (36)
            Equations.Add(new fsXRed50XuiDuOverDQnEquation(DuOverD, Q, numberOfCyclones, xRed50, alpha1, alpha2, alpha3, beta1, beta2, beta3, gamma1, gamma2, gamma3, cv, rhoF, rhoS, etaf, sigmaS, sigmaG, xG, xu50, constantHalf)); // (37)
            Equations.Add(new fsXRed50XuiDuOverDDpEquation(DuOverD, Dp, xRed50, alpha1, alpha2, alpha3, beta1, beta2, beta3, gamma1, gamma2, gamma3, cv, rhoF, rhoS, etaf, sigmaS, sigmaG, xG, xu50, constantHalf)); // (38)
            Equations.Add(new fsXRed50XuiCuCEquation(Cu, C, xRed50, sigmaS, sigmaG, xG, xu50, constantHalf));  // (39)
            
            Equations.Add(new fsProductEquation(L, LOverD, D)); // (28)
            Equations.Add(new fsProductEquation(l, lOverD, D)); // (27)
            Equations.Add(new fsProductEquation(Di, DiOverD, D)); // (26)
            Equations.Add(new fsProductEquation(Do, DoOverD, D)); // (25)
            Equations.Add(new fsProductEquation(Du, DuOverD, D)); // (24)
            Equations.Add(new fsSumEquation(Q, Qo, Qu)); // (19)
            Equations.Add(new fsQmFromQCEquation(Qmo, Qo, Co, rhoF, rhoS)); // (23)
            Equations.Add(new fsQmFromQCEquation(Qmu, Qu, Cu, rhoF, rhoS)); // (22)
            Equations.Add(new fsProductEquation(Qsu, Qu, Cu)); // (20)
            Equations.Add(new fsProductEquation(Qso, Qo, Co)); // (21)
            Equations.Add(new fsConcentrationEquation(Co, rhoF, rhoS, rhoSusOverflow)); // (15)
            Equations.Add(new fsConcentrationEquation(Cu, rhoF, rhoS, rhoSusUnderflow)); // (16)
            Equations.Add(new fsMassConcentrationEquation(cmu, rhoF, rhoS, rhoSusUnderflow)); // (16)
            Equations.Add(new fsMassConcentrationEquation(cmo, rhoF, rhoS, rhoSusOverflow)); // (15)
            Equations.Add(new fsVolumeConcentrationEquation(cvu, rhoF, rhoS, rhoSusUnderflow)); // (18)
            Equations.Add(new fsVolumeConcentrationEquation(cvo, rhoF, rhoS, rhoSusOverflow)); // (17)

            #endregion
        }
    }
}
