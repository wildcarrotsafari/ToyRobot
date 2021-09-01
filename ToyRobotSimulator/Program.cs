using System;
using System.Collections.Generic;
using ToyRobotSimulator.Support;

namespace ToyRobotSimulator
{
    public class ToyRobotSimulator
    {
        public void ShowHeader()
        {
            Console.WriteLine("\n-----------------------------------------------------------------------\n");
            Console.WriteLine("\n                           Toy Robot Simulator                         \n");
            Console.WriteLine("\n-----------------------------------------------------------------------\n");
        }

        public void RequestInput()
        {
            Console.WriteLine("\nPlease enter instruction and hit enter or type EXIT to leave\n");
        }
       
        public void RobotConsole()
        {
            try
            {
                ToyRobot robot = new ToyRobot();
                ShowHeader();
                string input = null;
                RequestInput();
                while (input != "EXIT")
                {
                    input = Console.ReadLine();
                    robot.ProcessCommand(input);                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured : {ex.Message}");
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();                
            }
        }

        static void Main(string[] args)
        {
            new ToyRobotSimulator().RobotConsole();
        }
    }
}
