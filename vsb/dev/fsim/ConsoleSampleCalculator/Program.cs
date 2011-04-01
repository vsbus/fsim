using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simulations;
using SimulationSteps.CubeSteps;
using Value;
using Parameters;

namespace ConsoleSampleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            fsCubeSimulation cube = new fsCubeSimulation();
            fsCubeFormationStep formationStep = new fsCubeFormationStep();
            cube.Steps.Add(formationStep);
            fsCubeHeightFromWidthScalingStep heightDefStep = new fsCubeHeightFromWidthScalingStep();
            cube.Steps.Add(heightDefStep);

            DateTime startTime = DateTime.Now;
            for (int it = 0; it < 50000; ++it)
            {
                formationStep.SetParameterInputedAndAssignValue(fsParameterIdentifier.volume, new fsValue(8));
                heightDefStep.SetParameterInputedFlag(fsParameterIdentifier.width, true);
                heightDefStep.SetParameterInputedFlag(fsParameterIdentifier.length, true);
                heightDefStep.SetParameterInputedAndAssignValue(fsParameterIdentifier.coefficient, new fsValue(0.5));

                cube.Run();
                //Console.WriteLine(cube.ToString());

                heightDefStep.SetParameterInputedAndAssignValue(fsParameterIdentifier.coefficient, new fsValue(2));

                cube.Run();
                //Console.WriteLine(cube.ToString());

                formationStep.volume.Value = new fsValue(27);

                cube.Run();
                //Console.WriteLine(cube.ToString());
            }
            DateTime endTime = DateTime.Now;
            Console.WriteLine((endTime - startTime).TotalMilliseconds);
        }
    }
}
