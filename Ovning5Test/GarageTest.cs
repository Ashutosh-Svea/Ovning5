using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ovning5;

namespace Ovning5Test
{
    [TestClass]
    public class GarageTest
    {
        private GarageHandler? gHandler;
        private IGarage<Vehicle>? garage;
        private ILogger? logger;
        [TestInitialize]
        public void SetupBeforeEachTest()
        {
            logger = new ConsoleLogger();
            gHandler = new GarageHandler(logger);
            gHandler.CreateGarage("All vehicles Garage", 10);
            garage = gHandler.Garage;

            Airplane airplane = new Airplane(logger, "SAS1", "Jumbojet", "Silver", "Boeing", 5, 100);
            Motorcycle motorcycle = new Motorcycle(logger, "m1", "Dirtbike", "Silver", "yamaha", 2, 2);
            Car car = new Car(logger, "c1", "car1", "Silver", "merc", 4, 2);
            Bus bus = new Bus(logger, "B1", "Tourist", "Silver", "Volvo", 4, 20);
            Boat boat = new Boat(logger, "boat1", "Speedboat", "Black", "Sailor", 4, "Diesel");

            garage!.Park(boat);
            garage.Park(bus);
            garage.Park(airplane);
            garage.Park(motorcycle);
            garage.Park(car);

             

        }

        [TestCleanup]
        public void CleanUpAfterEachTest()
        {
            System.Console.WriteLine("Clean up after each test");
        }

        [TestMethod]
        public void FindVehicleTest_Valid()
        {
            Assert.AreEqual(garage!.Fetch("SAS1"), true);
        }

        [TestMethod]
        public void FindVehicleTest_InValid()
        {
            Assert.AreEqual(garage!.Fetch("Sfsf"), false);

        }
        
        [TestMethod]
        public void FreeParkingSlotTestUsingMock_Valid()
        {
            logger = new ConsoleLogger();
            gHandler = new GarageHandler(logger);
            gHandler.CreateGarage("All vehicles Garage", 10);
            garage = gHandler.Garage;

            Airplane airplane = new Airplane(logger, "SAS1", "Jumbojet", "Silver", "Boeing", 5, 100);

            Mock<Garage<Vehicle>> mockGarage = new Mock<Garage<Vehicle>>();
            mockGarage.Setup(x => x.FreeParkingSlots()).Returns(5);
            var handler = new GarageHandler(logger);
            handler.Garage = mockGarage.Object;

            var expected = 5;
            var actual = handler.FreeParkingSlotsInGarage();

            Assert.AreEqual(garage!.FreeParkingSlots(), expected);
        }

        [TestMethod]
        public void FreeParkingSlotTest_Valid()
        {
 
            Assert.AreEqual(garage!.FreeParkingSlots(), 5);
        }

        [TestMethod]
        public void IsFullTest_Valid()
        {
            Assert.AreEqual(garage!.IsFull(), false);
        }

        [TestMethod]
        public void ParkTest_Valid()
        {
            Boat boat = new Boat(logger!, "boat2", "Speedboat", "Black", "Sailor", 4, "Diesel");
            bool actual = garage!.Park(boat);
            bool expected = true;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ParkTest_InValid()
        {
            Boat boat = new Boat(logger!, "boat1", "Speedboat", "Black", "Sailor", 4, "Diesel");
            bool actual = garage!.Park(boat);
            bool expected = false;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void FetchTest_Valid()
        {
            bool actual = garage!.Fetch("boat1");
            bool expected = true;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void FetchTest_InValid()
        {
            bool actual = garage!.Fetch("boat2");
            bool expected = false;
            Assert.AreEqual(actual, expected);
        }

    }
}