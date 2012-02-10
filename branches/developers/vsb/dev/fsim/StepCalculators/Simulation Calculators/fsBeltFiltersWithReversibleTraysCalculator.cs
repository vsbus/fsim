using Equations;
using Equations.Belt_Filters_with_Reversible_Trays;
using Parameters;

namespace StepCalculators.Simulation_Calculators
{
    public class fsBeltFiltersWithReversibleTraysCalculator : fsCalculator
    {
        public fsBeltFiltersWithReversibleTraysCalculator()
        {
            #region Parameters Initialization

            IEquationParameter filterArea = AddVariable(fsParameterIdentifier.FilterArea);
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

            IEquationParameter Dp = AddVariable(fsParameterIdentifier.PressureDifference);

            IEquationParameter eps = AddVariable(fsParameterIdentifier.CakePorosity);
            IEquationParameter kappa = AddVariable(fsParameterIdentifier.Kappa);
            IEquationParameter Pc = AddVariable(fsParameterIdentifier.CakePermeability);

            IEquationParameter etaf = AddConstant(fsParameterIdentifier.ViscosityFiltrate);
            IEquationParameter rho_s = AddConstant(fsParameterIdentifier.SolidsDensity);
            IEquationParameter rho_sus = AddConstant(fsParameterIdentifier.SuspensionDensity);
            IEquationParameter cv = AddConstant(fsParameterIdentifier.SuspensionSolidsVolumeFraction);
            IEquationParameter rho_cd0 = AddConstant(fsParameterIdentifier.CakeDrySolidsDensity0);
            IEquationParameter eps0 = AddConstant(fsParameterIdentifier.CakePorosity0);
            IEquationParameter Pc0 = AddConstant(fsParameterIdentifier.CakePermeability0);
            IEquationParameter ne = AddConstant(fsParameterIdentifier.Ne);
            IEquationParameter nc = AddConstant(fsParameterIdentifier.CakeCompressibility);
            IEquationParameter hce0 = AddConstant(fsParameterIdentifier.FilterMediumResistanceHce0);
            IEquationParameter ttech = AddConstant(fsParameterIdentifier.ttech0);

            #endregion

            #region Equations Initialization

            Equations.Add(new fsAreaOfBeltWithReversibleTraysEquation(
                filterArea,
                lsOverB,
                ns,
                Qms,
                rho_s,
                u,
                cakeHeigth));

            Equations.Add(new fsProductEquation(Qms, rho_s, Qs));
            Equations.Add(new fsProductEquation(Qmsus, rho_sus, Qsus));
            Equations.Add(new fsProductEquation(Qs, Qsus, cv));
            Equations.Add(new fsProductsEquation(new IEquationParameter[] {ls, rho_cd0, u, cakeHeigth},
                                                new IEquationParameter[] {lsOverB, Qms}));
            Equations.Add(new fsProductEquation(lOverB, ns, lsOverB));
            Equations.Add(new fsProductEquation(nsf, ns, sf));

            Equations.Add(new fsFrom0AndDpEquation(eps, eps0, Dp, ne));
            Equations.Add(new fsFrom0AndDpEquation(Pc, Pc0, Dp, nc));
            Equations.Add(new fsEpsKappaCvEquation(eps, kappa, cv));

            Equations.Add(new fsSfFromEtafHcHceKappaPcDpNsLsUTtechEquation(sf, etaf, cakeHeigth, hce0, kappa,
                                                                           Pc, Dp, ns, ls, u, ttech));

            #endregion
        }
    }
}
