using MortalEngines.Core;
using System.Linq;
using System;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            MachinesManager manager = new MachinesManager();

            while (true)
            {
                string input = System.Console.ReadLine();

                if (input== "Quit")
                {
                    break;
                }

                var args = input.Split().ToArray();
                string command = args[0];

                try
                {
                    if (command == "HirePilot")
                    {
                        Console.WriteLine(manager.HirePilot(args[1])); 
                    }
                    else if (command== "ManufactureTank")
                    {
                        double attack = double.Parse(args[2]);
                        double defence = double.Parse(args[3]);
                        Console.WriteLine(manager.ManufactureTank(args[1], attack, defence));
                    }
                    else if (command == "DefenseMode")
                    {

                        Console.WriteLine(manager.ToggleTankDefenseMode(args[1]));
                    }

                    else if (command == "ManufactureFighter")
                    {
                        double attack = double.Parse(args[2]);
                        double defence = double.Parse(args[3]);
                        Console.WriteLine(manager.ManufactureFighter(args[1], attack, defence));
                    }

                    else if (command == "AggressiveMode")
                    {

                        Console.WriteLine(manager.ToggleFighterAggressiveMode(args[1]));
                    }

                    else if (command == "Engage")
                    {

                        Console.WriteLine(manager.EngageMachine(args[1], args[2]));
                    }

                    else if (command == "Attack")
                    {

                        Console.WriteLine(manager.AttackMachines(args[1], args[2]));
                    }

                    else if (command == "MachineReport")
                    {
                        Console.WriteLine(manager.MachineReport(args[1]));
                    }

                    else if (command == "PilotReport")
                    {
                        Console.WriteLine(manager.PilotReport(args[1]));
                    }

                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }
    }
}