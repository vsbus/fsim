using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simulations;
using SimulationSteps.CubeSteps;
using Value;
using Parameters;
using SimulationSteps.GeometryProgressionSteps;

namespace ConsoleSampleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //CubeSimulationSample();
            GeomericalProgressionSimulationSample();
        }

        private static void GeomericalProgressionSimulationSample()
        {
            fsSimulation gpSim = new fsSimulation(
                fsParameterIdentifier.q,
                fsParameterIdentifier.a1,
                fsParameterIdentifier.a2,
                fsParameterIdentifier.a3,
                fsParameterIdentifier.a4,
                fsParameterIdentifier.a5);
            fsGProgressionInitStep initStep = new fsGProgressionInitStep();
            gpSim.Steps.Add(initStep);

            initStep.SetParameterInputedAndAssignValue(fsParameterIdentifier.q, new fsValue(2));
            initStep.SetParameterInputedAndAssignValue(fsParameterIdentifier.a1, new fsValue(2));

            DateTime startTime = DateTime.Now;
            for (int it = 0; it < 1; ++it)
            {
                gpSim.Run();
                Console.WriteLine(gpSim.ToString());

                initStep.SetParameterInputedFlag(fsParameterIdentifier.q, false);
                initStep.SetParameterInputedFlag(fsParameterIdentifier.a1, false);
                initStep.SetParameterInputedAndAssignValue(fsParameterIdentifier.a3, new fsValue(10));
                initStep.SetParameterInputedAndAssignValue(fsParameterIdentifier.a2, new fsValue(20));
                gpSim.Run();
                Console.WriteLine(gpSim.ToString());
            }
            DateTime endTime = DateTime.Now;
            Console.WriteLine((endTime - startTime).TotalSeconds);
        }

        private static void CubeSimulationSample()
        {
            fsSimulation cube = new fsSimulation(
                fsParameterIdentifier.volume,
                fsParameterIdentifier.height,
                fsParameterIdentifier.length,
                fsParameterIdentifier.width);
            fsCubeFormationStep formationStep = new fsCubeFormationStep();
            cube.Steps.Add(formationStep);
            fsCubeHeightFromWidthScalingStep heightDefStep = new fsCubeHeightFromWidthScalingStep();
            cube.Steps.Add(heightDefStep);

            DateTime startTime = DateTime.Now;
            for (int it = 0; it < 1; ++it)
            {
                formationStep.SetParameterInputedAndAssignValue(fsParameterIdentifier.volume, new fsValue(8));
                heightDefStep.SetParameterInputedFlag(fsParameterIdentifier.width, true);
                heightDefStep.SetParameterInputedFlag(fsParameterIdentifier.length, true);
                heightDefStep.SetParameterInputedAndAssignValue(fsParameterIdentifier.coefficient, new fsValue(0.5));

                cube.Run();
                Console.WriteLine(cube.ToString());

                heightDefStep.SetParameterInputedAndAssignValue(fsParameterIdentifier.coefficient, new fsValue(2));

                cube.Run();
                Console.WriteLine(cube.ToString());

                formationStep.SetParameterInputedAndAssignValue(fsParameterIdentifier.volume, new fsValue(27));
                cube.Run();
                Console.WriteLine(cube.ToString());
            }
            DateTime endTime = DateTime.Now;
            Console.WriteLine((endTime - startTime).TotalSeconds);
        }
    }
}
