// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Microsoft.Extensions.Configuration;
using Ovning5;

ILogger logger = InitLog();

ILogger InitLog()
{
    //try to learn the json file reading and dependency injection of logger to all relevant classes
    IConfiguration config = new ConfigurationBuilder()
                        .SetBasePath(Environment.CurrentDirectory)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();

    string logFile = config.GetSection("Garage:LogFile").Value;
    
    switch (logFile)
    {
        case "Console" :    return new ConsoleLogger();
        default:            return new FileLogger(Environment.CurrentDirectory + "\\" + logFile);
    }
}

//Airplane airplane = new Airplane("XAM931", "SUV", "Silver", "Toyota", 4, 100);
Airplane airplane = new Airplane(logger, "SAS1", "Jumbojet", "Silver", "Boeing", 5, 100);
Motorcycle motorcycle = new Motorcycle (logger, "m1", "Dirtbike", "Silver", "yamaha", 2, 2);
Car car = new Car (logger, "m1", "Dirtbike", "Silver", "yamaha", 4, 2);
Bus bus = new Bus (logger, "B1", "Tourist", "Silver", "Volvo", 4, 20);
Boat boat = new Boat (logger, "boat1", "Speedboat", "Black", "Sailor", 4, "Diesel");

logger.log(airplane.PrintDetails());
logger.log(car.PrintDetails());
logger.log(motorcycle.PrintDetails());
logger.log(bus.PrintDetails());
logger.log(boat.PrintDetails());



try
{
    boat.TryPark();
    boat.TryFetch();
    car.TryFetch();
}
catch (Exception e)
{
    logger.log(e.Message);
}


logger.close();