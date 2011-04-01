using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simulations;
using SimulationSteps.CubeSteps;
using Value;

namespace ConsoleSampleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            fsCubeSimulation cube = new fsCubeSimulation();
            fsCubeFormationStep formationStep = new fsCubeFormationStep();
            formationStep.volume.IsInputed = true;
            formationStep.volume.Value = new fsValue(8);
            cube.Steps.Add(formationStep);
            fsCubeHeightFromWidthScalingStep heightDefStep = new fsCubeHeightFromWidthScalingStep();
            heightDefStep.width.IsInputed = true;
            heightDefStep.length.IsInputed = true;
            heightDefStep.coefficient.IsInputed = true;
            heightDefStep.coefficient.Value = new fsValue(0.5);
            cube.Steps.Add(heightDefStep);

            cube.Run();
            Console.WriteLine(cube.GetDataString());

            heightDefStep.coefficient.IsInputed = true;
            heightDefStep.coefficient.Value = new fsValue(2.0);

            cube.Run();
            Console.WriteLine(cube.GetDataString());

            formationStep.volume.Value = new fsValue(27);

            cube.Run();
            Console.WriteLine(cube.GetDataString());
        }
    }
}
