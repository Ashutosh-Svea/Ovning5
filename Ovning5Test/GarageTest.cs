using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ovning5Test
{
    [TestClass]
    public class GarageTest
    {
        [TestInitialize]
        public void SetupBeforeEachTest()
        {
            System.Console.WriteLine("Setupbefore each test");
        }

        [TestCleanup]
        public void CleanUpAfterEachTest()
        {
            System.Console.WriteLine("Clean up after each test");
        }

        [TestMethod]
        public void FindVehicleTest_Valid()
        {
            System.Console.WriteLine("Testvaild");
        }

        [TestMethod]
        public void FindVehicleTest_InValid()
        {
            System.Console.WriteLine("InValid Testvaild");

        }

    }
}