using Equations;
using Equations.Belt_Filters_with_Reversible_Trays;
using Parameters;
using Value;

namespace StepCalculators.Simulation_Calculators
{
    public class fsBeltFiltersWithReversibleTraysCalculator : fsCalculator
    {
        public fsBeltFiltersWithReversibleTraysCalculator()
        {
            #region Parameters Initialization

            IEquationParameter etaf = AddConstant(fsParameterIdentifier.MotherLiquidViscosity);
            IEquationParameter rhoS = AddConstant(fsParameterIdentifier.SolidsDensity);
            IEquationParameter rhoF = AddConstant(fsParameterIdentifier.FiltrateDensity);
            IEquationParameter rhoSus = AddConstant(fsParameterIdentifier.SuspensionDensity);
            IEquationParameter cv = AddConstant(fsParameterIdentifier.SuspensionSolidsVolumeFraction);
            IEquationParameter pc0 = AddConstant(fsParameterIdentifier.CakePermeability0);
            IEquationParameter nc = AddConstant(fsParameterIdentifier.CakeCompressibility);
            IEquationParameter hce0 = AddConstant(fsParameterIdentifier.FilterMediumResistanceHce0);
            IEquationParameter ttech0 = AddConstant(fsParameterIdentifier.ttech0);
            IEquationParameter lambda = AddConstant(fsParameterIdentifier.lambda);

            IEquationParameter rhoCd = AddConstant(fsParameterIdentifier.DryCakeDensity);
            IEquationParameter kappa = AddConstant(fsParameterIdentifier.Kappa);

            IEquationParameter ns = AddVariable(fsParameterIdentifier.ns);
            IEquationParameter Qms = AddVariable(fsParameterIdentifier.Qms);
            IEquationParameter Qs = AddVariable(fsParameterIdentifier.Qs);
            IEquationParameter Qmsus = AddVariable(fsParameterIdentifier.SuspensionMassFlowrate);
            IEquationParameter Qsus = AddVariable(fsParameterIdentifier.Qsus);
            
            IEquationParameter ls = AddVariable(fsParameterIdentifier.ls);
            IEquationParameter lOverB = AddVariable(fsParameterIdentifier.l_over_b);
            IEquationParameter lsOverB = AddVariable(fsParameterIdentifier.ls_over_b);

            IEquationParameter u = AddVariable(fsParameterIdentifier.u);
            IEquationParameter n = AddVariable(fsParameterIdentifier.RotationalSpeed);
            IEquationParameter tc = AddVariable(fsParameterIdentifier.CycleTime);
            IEquationParameter nsf = AddVariable(fsParameterIdentifier.nsf);
            IEquationParameter nsr = AddVariable(fsParameterIdentifier.nsr);
            IEquationParameter sf = AddVariable(fsParameterIdentifier.SpecificFiltrationTime);
            IEquationParameter sr = AddVariable(fsParameterIdentifier.SpecificResidualTime);
            IEquationParameter tr = AddVariable(fsParameterIdentifier.ResidualTime);

            IEquationParameter cakeHeigth = AddVariable(fsParameterIdentifier.CakeHeight);
            IEquationParameter filtrationTime = AddVariable(fsParameterIdentifier.FiltrationTime);

            IEquationParameter pressureDifference = AddVariable(fsParameterIdentifier.PressureDifference);

            IEquationParameter Pc = AddVariable(fsParameterIdentifier.CakePermeability);

            IEquationParameter ttech = AddVariable(fsParameterIdentifier.TechnicalTime);

            IEquationParameter filterArea = AddVariable(fsParameterIdentifier.FilterArea);
            IEquationParameter filterAreaAs = AddVariable(fsParameterIdentifier.As);
            IEquationParameter machineWidth = AddVariable(fsParameterIdentifier.MachineWidth);
            IEquationParameter filterLength = AddVariable(fsParameterIdentifier.FilterLength);

            IEquationParameter qft = AddVariable(fsParameterIdentifier.qft);
            IEquationParameter qmft = AddVariable(fsParameterIdentifier.qmft);

            #region Help Parameters and Constants

            var constantOne = new fsCalculatorConstant(new fsParameterIdentifier("1")) {Value = fsValue.One};
            var constantTwo = new fsCalculatorConstant(new fsParameterIdentifier("1")) {Value = new fsValue(2)};
            IEquationParameter hcAdd2Hce = AddVariable(new fsParameterIdentifier("hc + 2 hce"));

            #endregion

            #endregion

            #region Equations Initialization

            Equations.Add(new fsAreaOfBeltWithReversibleTraysEquation(filterArea, lsOverB, ns, Qms, rhoCd, u, cakeHeigth));

            Equations.Add(new fsProductEquation(Qms, rhoS, Qs));
            Equations.Add(new fsProductEquation(Qmsus, rhoSus, Qsus));
            Equations.Add(new fsProductEquation(Qs, Qsus, cv));
            Equations.Add(new fsProductsEquation(
                new[] {ls, rhoCd, u, cakeHeigth},
                new[] {lsOverB, Qms}));
            Equations.Add(new fsProductEquation(lOverB, ns, lsOverB));
            Equations.Add(new fsProductEquation(nsf, ns, sf));
            Equations.Add(new fsFrom0AndDpEquation(Pc, pc0, pressureDifference, nc));
            Equations.Add(new fsTechnicalTimeFrom0Equation(ttech, ttech0, filterAreaAs, lambda));
            Equations.Add(new fsProductsEquation(
                new[] { filterAreaAs, lsOverB },
                new[] { ls, ls }));
            Equations.Add(new fsProductEquation(filterLength, ns, ls));
            Equations.Add(new fsProductEquation(filterLength, tc, u));
            Equations.Add(new fsDivisionInverseEquation(tc, n));
            Equations.Add(new fsCakeHeightFromDpTf(cakeHeigth, hce0, Pc, kappa, pressureDifference, filtrationTime, etaf));
            Equations.Add(new fsSumEquation(ns, nsf, nsr));
            Equations.Add(new fsSumEquation(tc, tr, filtrationTime));
            Equations.Add(new fsSumEquation(constantOne, sr, sf));
            Equations.Add(new fsProductEquation(tr, tc, sr));
            Equations.Add(new fsProductEquation(filtrationTime, tc, sf));
            Equations.Add(new fsProductEquation(ls, lsOverB, machineWidth));
            Equations.Add(new fsSfFromEtafHcHceKappaPcDpNsLsUTtechEquation(
                sf, etaf, cakeHeigth, hce0, kappa, Pc, pressureDifference, ns, ls, u, ttech));
            Equations.Add(new fsUFromLsOverBQmsHcDpTtech0LambdaNsfMaterialEquation(
                u, lambda, nsf, lsOverB, Qms, rhoCd, cakeHeigth, etaf, hce0, kappa, Pc, pressureDifference, ttech0));
            Equations.Add(new fsSumsEquation(
                new[] { hcAdd2Hce },
                new[] { cakeHeigth, hce0, hce0 }));
            Equations.Add(new fsProductsEquation(
                new[] { qft, etaf, hcAdd2Hce },
                new[] { constantTwo, Pc, pressureDifference }));
            Equations.Add(new fsProductEquation(qmft, qft, rhoF));

            #endregion
        }
    }
}
