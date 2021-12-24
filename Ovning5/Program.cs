// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Ovning5;

//Airplane airplane = new Airplane("XAM931", "SUV", "Silver", "Toyota", 4, 100);
Airplane airplane = new Airplane("SAS1", "Jumbojet", "Silver", "Boeing", 5, 100);
Motorcycle motorcycle = new Motorcycle ("m1", "Dirtbike", "Silver", "yamaha", 2, 2);
Car car = new Car ("m1", "Dirtbike", "Silver", "yamaha", 4, 2);
Bus bus = new Bus ("B1", "Tourist", "Silver", "Volvo", 4, 20);
Boat boat = new Boat ("boat1", "Speedboat", "Black", "Sailor", 4, "Diesel");

Console.WriteLine(airplane.PrintDetails());
Console.WriteLine(car.PrintDetails());
Console.WriteLine(motorcycle.PrintDetails());
Console.WriteLine(bus.PrintDetails());
Console.WriteLine(boat.PrintDetails());


try
{
    boat.TryPark();
    boat.TryFetch();
    car.TryFetch();
}
catch (Exception e)
{
    Logger.log(e.Message);
}
