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

        private enum RunState {MainMenu, GarageMenu, VehicleMenu, Exit};

        private RunState runState; 
        public UIConsole()
        {
            runState = RunState.MainMenu;
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

        public void ProcessGarageChoice()
        {
            int garageCapacity;
            while (true)
            {
                if (garageHandler.IsGarageCreated())
                {
                    Console.WriteLine("Right now only one garage can exist. Try using the existing garage");
                    runState = RunState.MainMenu;
                    return;
                }
                Console.WriteLine("1.Enter Garage Capacity");
                if (int.TryParse(Console.ReadLine(), out garageCapacity))
                {             
                   if (Utils.IsValidSize(garageCapacity))
                    {
                        Console.WriteLine("2.Enter Garage Name");
                        string? garageName = Console.ReadLine();
                        if (garageName is null)
                            Console.WriteLine("Invalid input. Try again");
                        else if (Utils.IsEmptyString(garageName))
                            Console.WriteLine("Invalid input. Try again");
                        else
                        {
                            garageHandler.CreateGarage(garageName!, garageCapacity);
                            runState = RunState.MainMenu;
                            return;
                        }
                    }
                   else
                        Console.WriteLine("Invalid input. Try again.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }

            }
        }

        public void PrintMainChoices()
        {
            Console.WriteLine("1.Create Garage");
            Console.WriteLine("2.Close Garage");
            Console.WriteLine("3.Add Vehicle In The Garage");
            Console.WriteLine("4.Remove Vehicle From The Garage");
            Console.WriteLine("5.Find Vehicle");
            Console.WriteLine("6.Exit");
        }

        public void PrintVehicleChoices()
        {
            Console.WriteLine("Choose Vehicle type");
            Console.WriteLine("1. Airplane ");
            Console.WriteLine("2. Boat");
            Console.WriteLine("3. Car");
            Console.WriteLine("4. Motorcycle");
            Console.WriteLine("5. Bus");
            Console.WriteLine("6. Return to Main Menu.");
        }

        public void Run()
        {
            int userChoice = -1;
            do
            {
                switch (runState)
                {
                    case RunState.MainMenu:
                        PrintMainChoices();
                        userChoice = GetUserChoice();
                        processMainMenu(userChoice);
                        break;

                    case RunState.GarageMenu:
                        ProcessGarageChoice();
                        break;

                    case RunState.VehicleMenu:
                        ProcessVehicleChoice();
                        break;

                    case RunState.Exit:
                        Environment.Exit(0);
                        break;
                }
            }
            while (true) ;
        }

        private void ProcessVehicleChoice()
        {
            if (garageHandler.IsGarageCreated() is not true)
            {
                Console.WriteLine("Fist create a garage before adding vehicles.");
                runState = RunState.MainMenu;
                return;
            }
            else
            {
                int choice;
                while (true)
                {
                    PrintVehicleChoices();
                    if (int.TryParse(Console.ReadLine(),out choice))
                    {
                        //Refactor. Move to vehicle class. UI should not know about type of vehicle...tight coupled...
                        switch (choice)
                        {
                            case 1: AddAirplane(); 
                                break;
                            case 2: AddBoat();
                                break;
                            case 3: AddCar();
                                break;
                            case 4: AddMotorcycle();
                                break;
                            case 5: AddBus();
                                break;

                            case 6:
                                runState = RunState.MainMenu;
                                return;
                            default:
                                Console.WriteLine("Invalid choice.Try again");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid chioce. Try again");
                    }

                }
            }
        }

        private void AddAirplane()
        {
            string? id;
            string? type;
            string? color;
            string? make;
            int wheels;
            int length;
            while (true)
            {
                Console.WriteLine("Enter airplane Registration");
                id = Console.ReadLine();

                if (Utils.CheckNullOrEmptyString(id!))
                    Console.WriteLine("Invalid input. Try again");
                else
                {
                    Console.WriteLine("Enter airplane type");
                    type = Console.ReadLine();

                    if (Utils.CheckNullOrEmptyString(type!))
                        Console.WriteLine("Invalid input. Try again");
                    else
                    {
                        Console.WriteLine("Enter airplane Color");
                        color = Console.ReadLine();

                        if (Utils.CheckNullOrEmptyString(color!))
                            Console.WriteLine("Invalid input. Try again");
                        else
                        {
                            Console.WriteLine("Enter airplane make/model");
                            make = Console.ReadLine();

                            if (Utils.CheckNullOrEmptyString(make!))
                                Console.WriteLine("Invalid input. Try again");
                            else
                            {
                                Console.WriteLine("Enter no of airplane wheels");
                                if (int.TryParse(Console.ReadLine(), out wheels) is false)
                                    Console.WriteLine("Invalid input. Try again");
                                else
                                {
                                    Console.WriteLine("Enter airplane length ");
                                    if (int.TryParse(Console.ReadLine(), out length) is false)
                                        Console.WriteLine("Invalid input. Try again");
                                    else
                                    {
                                        Airplane airplane = new Airplane(logger, id!, type!, color!, make!, wheels, length);
                                        garageHandler.ParkInGarage(airplane);
                                        runState = RunState.MainMenu;
                                        return;
                                    }
                                }

                            }
                        }
                    }
                }

            }

        }

        private void AddCar()
        {
            string? id;
            string? type;
            string? color;
            string? make;
            int wheels;
            int engine;
            while (true)
            {
                Console.WriteLine("Enter car Registration");
                id = Console.ReadLine();

                if (Utils.CheckNullOrEmptyString(id!))
                    Console.WriteLine("Invalid input. Try again");
                else
                {
                    Console.WriteLine("Enter car type");
                    type = Console.ReadLine();

                    if (Utils.CheckNullOrEmptyString(type!))
                        Console.WriteLine("Invalid input. Try again");
                    else
                    {
                        Console.WriteLine("Enter car Color");
                        color = Console.ReadLine();

                        if (Utils.CheckNullOrEmptyString(color!))
                            Console.WriteLine("Invalid input. Try again");
                        else
                        {
                            Console.WriteLine("Enter car make/model");
                            make = Console.ReadLine();

                            if (Utils.CheckNullOrEmptyString(make!))
                                Console.WriteLine("Invalid input. Try again");
                            else
                            {
                                Console.WriteLine("Enter no of car wheels");
                                if (int.TryParse(Console.ReadLine(), out wheels) is false)
                                    Console.WriteLine("Invalid input. Try again");
                                else
                                {
                                    Console.WriteLine("Enter car engine capacity in number");
                                    if (int.TryParse(Console.ReadLine(), out engine) is false)
                                        Console.WriteLine("Invalid input. Try again");
                                    else
                                    {
                                        Car car = new Car(logger, id!, type!, color!, make!, wheels, engine);
                                        garageHandler.ParkInGarage(car);
                                        runState = RunState.MainMenu;
                                        return;
                                    }
                                }

                            }
                        }
                    }
                }

            }

        }

        private void AddMotorcycle()
        {
            string? id;
            string? type;
            string? color;
            string? make;
            int wheels;
            int cylinderCount;
            while (true)
            {
                Console.WriteLine("Enter motorcycle Registration");
                id = Console.ReadLine();

                if (Utils.CheckNullOrEmptyString(id!))
                    Console.WriteLine("Invalid input. Try again");
                else
                {
                    Console.WriteLine("Enter motorcycle type");
                    type = Console.ReadLine();

                    if (Utils.CheckNullOrEmptyString(type!))
                        Console.WriteLine("Invalid input. Try again");
                    else
                    {
                        Console.WriteLine("Enter motorcycle Color");
                        color = Console.ReadLine();

                        if (Utils.CheckNullOrEmptyString(color!))
                            Console.WriteLine("Invalid input. Try again");
                        else
                        {
                            Console.WriteLine("Enter motorcycle make/model");
                            make = Console.ReadLine();

                            if (Utils.CheckNullOrEmptyString(make!))
                                Console.WriteLine("Invalid input. Try again");
                            else
                            {
                                Console.WriteLine("Enter no of motorcycle wheels");
                                if (int.TryParse(Console.ReadLine(), out wheels) is false)
                                    Console.WriteLine("Invalid input. Try again");
                                else
                                {
                                    Console.WriteLine("Enter motorcycle cylinder count ");
                                    if (int.TryParse(Console.ReadLine(), out cylinderCount) is false)
                                        Console.WriteLine("Invalid input. Try again");
                                    else
                                    {
                                        Motorcycle motorcycle = new Motorcycle(logger, id!, type!, color!, make!, wheels, cylinderCount);
                                        garageHandler.ParkInGarage(motorcycle);
                                        runState = RunState.MainMenu;
                                        return;
                                    }
                                }

                            }
                        }
                    }
                }

            }

        }

        private void AddBoat()
        {
            string? id;
            string? type;
            string? color;
            string? make;
            int wheels;
            string? fuelType;
            while (true)
            {
                Console.WriteLine("Enter boat Registration");
                id = Console.ReadLine();

                if (Utils.CheckNullOrEmptyString(id!))
                    Console.WriteLine("Invalid input. Try again");
                else
                {
                    Console.WriteLine("Enter boat type");
                    type = Console.ReadLine();

                    if (Utils.CheckNullOrEmptyString(type!))
                        Console.WriteLine("Invalid input. Try again");
                    else
                    {
                        Console.WriteLine("Enter boat Color");
                        color = Console.ReadLine();

                        if (Utils.CheckNullOrEmptyString(color!))
                            Console.WriteLine("Invalid input. Try again");
                        else
                        {
                            Console.WriteLine("Enter boat make/model");
                            make = Console.ReadLine();

                            if (Utils.CheckNullOrEmptyString(make!))
                                Console.WriteLine("Invalid input. Try again");
                            else
                            {
                                Console.WriteLine("Enter no of boat wheels");
                                if (int.TryParse(Console.ReadLine(), out wheels) is false)
                                    Console.WriteLine("Invalid input. Try again");
                                else
                                {
                                    Console.WriteLine("Enter boat fuel type ");
                                    fuelType = Console.ReadLine();
                                    if (Utils.CheckNullOrEmptyString(fuelType!))
                                            Console.WriteLine("Invalid input. Try again");
                                    else
                                    {
                                        Boat boat = new Boat (logger, id!, type!, color!, make!, wheels, fuelType!);
                                        garageHandler.ParkInGarage(boat);
                                        runState = RunState.MainMenu;
                                        return;
                                    }
                                }

                            }
                        }
                    }
                }

            }

        }

        private void AddBus()
        {
            string? id;
            string? type;
            string? color;
            string? make;
            int wheels;
            int seat;
            while (true)
            {
                Console.WriteLine("Enter bus Registration");
                id = Console.ReadLine();

                if (Utils.CheckNullOrEmptyString(id!))
                    Console.WriteLine("Invalid input. Try again");
                else
                {
                    Console.WriteLine("Enter bus type");
                    type = Console.ReadLine();

                    if (Utils.CheckNullOrEmptyString(type!))
                        Console.WriteLine("Invalid input. Try again");
                    else
                    {
                        Console.WriteLine("Enter bus Color");
                        color = Console.ReadLine();

                        if (Utils.CheckNullOrEmptyString(color!))
                            Console.WriteLine("Invalid input. Try again");
                        else
                        {
                            Console.WriteLine("Enter bus make/model");
                            make = Console.ReadLine();

                            if (Utils.CheckNullOrEmptyString(make!))
                                Console.WriteLine("Invalid input. Try again");
                            else
                            {
                                Console.WriteLine("Enter no of bus wheels");
                                if (int.TryParse(Console.ReadLine(), out wheels) is false)
                                    Console.WriteLine("Invalid input. Try again");
                                else
                                {
                                    Console.WriteLine("Enter no of seats in the bus ");
                                    if (int.TryParse(Console.ReadLine(), out seat) is false)
                                        Console.WriteLine("Invalid input. Try again");
                                    else
                                    {
                                        Bus bus = new Bus (logger, id!, type!, color!, make!, wheels, seat);
                                        garageHandler.ParkInGarage(bus);
                                        runState = RunState.MainMenu;
                                        return;
                                    }
                                }

                            }
                        }
                    }
                }

            }

        }


        private void processMainMenu(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    runState = RunState.GarageMenu;
                    //processGarageMenu();
                    break;
                case 2:
                    Console.WriteLine("CloseGarage()");
                    break;
                case 3:
                    runState = RunState.VehicleMenu;
                    break;
                case 4:
                    Console.WriteLine("RemoveVehicle()");
                    break;
                case 5:
                    Console.WriteLine("FindVehicle()");
                    break;
                case 6:
                    runState = RunState.Exit;
                    break;
                default:
                    Console.WriteLine("Invalid input try again");
                    break;
            }
        }

        private void CloseGarage()
        {
        }

        private void CreateGarage()
        {
        }
    }
}
