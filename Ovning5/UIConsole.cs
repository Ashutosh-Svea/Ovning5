using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    internal class UIConsole : IUI
    {
        public IHandler garageHandler;
        public ILogger logger;

        public UIConsole()
        {
            logger = new ConsoleLogger();
            garageHandler = new GarageHandler(logger);
        }
        public int GetUserChoice()
        {
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
                return choice;
            else
                return -1; //error
        }

        public void PrintGarageChoices()
        {
            Console.WriteLine("1.Enter Garage Capacity");
            Console.WriteLine("1.Enter Garage Name");
        }

        public void PrintMainChoices()
        {
            Console.WriteLine("1.Create Garage");
            Console.WriteLine("2.Close Garage");
            Console.WriteLine("1.Add Vehicle In The Garage");
            Console.WriteLine("2.Remove Vehicle From The Garage");
            Console.WriteLine("3.Find Vehicle");
            Console.WriteLine("4.Exit");
        }

        public void PrintVehicleChoices()
        {
            throw new NotImplementedException();
        }
    }
}
