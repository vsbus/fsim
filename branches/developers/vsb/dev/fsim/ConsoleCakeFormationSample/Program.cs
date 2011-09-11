using System;
using System.Collections.Generic;

using System.Text;
using Parameters;
using Value;
using StepCalculators;

namespace ConsoleCakeFormationSample
{
    class Program
    {
        static void Main(string[] args)
        {
            fsSimulationParameter[] paramsArray = {
                new fsSimulationParameter(fsParameterIdentifier.SuspensionDensity),
                new fsSimulationParameter(fsParameterIdentifier.Hce0),
                new fsSimulationParameter(fsParameterIdentifier.FiltrateViscosity),
                new fsSimulationParameter(fsParameterIdentifier.Pc),
                new fsSimulationParameter(fsParameterIdentifier.Kappa),
                new fsSimulationParameter(fsParameterIdentifier.FilterArea),
                new fsSimulationParameter(fsParameterIdentifier.Pressure),
                new fsSimulationParameter(fsParameterIdentifier.RotationalSpeed),
                new fsSimulationParameter(fsParameterIdentifier.CycleTime),
                new fsSimulationParameter(fsParameterIdentifier.FormationRelativeTime),
                new fsSimulationParameter(fsParameterIdentifier.FormationTime),
                new fsSimulationParameter(fsParameterIdentifier.CakeHeight),
                new fsSimulationParameter(fsParameterIdentifier.SuspensionMass),
                new fsSimulationParameter(fsParameterIdentifier.SuspensionVolume)                
            };

            Dictionary<fsParameterIdentifier, fsSimulationParameter> data = new Dictionary<fsParameterIdentifier, fsSimulationParameter>();
            foreach (var p in paramsArray)
            {
                data[p.Identifier] = p;
            }

            fsCakeFormationDpConstCalculator calculator = new fsCakeFormationDpConstCalculator();
            TestCakeFormation_A_Dp_n_sf(data, calculator);
            TestCakeFormation_A_Dp_tc_sf(data, calculator);
            //             TestCakeFormation_A_Dp_tc_tf(data, calculator);
            //             TestCakeFormation_A_Dp_tc_hc(data, calculator);
            //             TestCakeFormation_A_Dp_tc_Msus(data, calculator);
        }

        private static void TestCakeFormation_A_Dp_tc_sf(
            Dictionary<fsParameterIdentifier, fsSimulationParameter> data, 
            fsCakeFormationDpConstCalculator calculator)
        {
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("TestCakeFormation_A_Dp_tc_sf");

            ResetAllPArameters(data);
            SetParameter(data, fsParameterIdentifier.SuspensionDensity, 1070);
            SetParameter(data, fsParameterIdentifier.FiltrateViscosity, 1e-3);
            SetParameter(data, fsParameterIdentifier.Hce0, 10e-3);
            SetParameter(data, fsParameterIdentifier.Pc, 0.885e-13);
            SetParameter(data, fsParameterIdentifier.Kappa, 0.396);
            SetParameter(data, fsParameterIdentifier.FilterArea, 0.5);
            SetParameter(data, fsParameterIdentifier.Pressure, 1.5e5);
            SetParameter(data, fsParameterIdentifier.CycleTime, 0.5);
            SetParameter(data, fsParameterIdentifier.FormationRelativeTime, 0.75);

            calculator.ReadDataFromStorage(data);
            calculator.Calculate();
            System.Console.WriteLine("Calculator message: " + calculator.GetStatusMessage());
            calculator.CopyValuesToStorage(data);
            foreach (var p in data)
            {
                System.Console.WriteLine(p.ToString());
            }
        }

        private static void TestCakeFormation_A_Dp_n_sf(
            Dictionary<fsParameterIdentifier, fsSimulationParameter> data,
            fsCakeFormationDpConstCalculator calculator)
        {
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("TestCakeFormation_A_Dp_n_sf");
            
            ResetAllPArameters(data);
            SetParameter(data, fsParameterIdentifier.SuspensionDensity, 1070);
            SetParameter(data, fsParameterIdentifier.FiltrateViscosity, 1e-3);
            SetParameter(data, fsParameterIdentifier.Hce0, 10e-3);
            SetParameter(data, fsParameterIdentifier.Pc, 0.885e-13);
            SetParameter(data, fsParameterIdentifier.Kappa, 0.396);
            SetParameter(data, fsParameterIdentifier.FilterArea, 0.5);
            SetParameter(data, fsParameterIdentifier.Pressure, 1.5e5);
            SetParameter(data, fsParameterIdentifier.RotationalSpeed, 2);
            SetParameter(data, fsParameterIdentifier.FormationRelativeTime, 0.75);
            
            calculator.ReadDataFromStorage(data);
            calculator.Calculate();
            System.Console.WriteLine("Calculator message: " + calculator.GetStatusMessage());
            calculator.CopyValuesToStorage(data);
            foreach (var p in data)
            {
                System.Console.WriteLine(p.ToString());
            }
        }

        private static void SetParameter(Dictionary<fsParameterIdentifier, fsSimulationParameter> data, fsParameterIdentifier identifier, double value)
        {
            data[identifier].IsInput = true;
            data[identifier].Value = new fsValue(value);
        }

        private static void ResetAllPArameters(Dictionary<fsParameterIdentifier, fsSimulationParameter> data)
        {
            foreach (var p in data.Values)
            {
                p.IsInput = false;
                p.Value = new fsValue();
            }
        }
    }
}
