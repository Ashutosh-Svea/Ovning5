using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    internal class GarageHandler : IHandler
    {
        private ILogger logger;
        IGarage? garage;
        

        public GarageHandler(ILogger _logger)
        {
            logger = _logger;
        }

        public void CreateGarage(string name, int capacity)
        {
            garage = new Garage(logger, name, capacity);
        }

        public bool FetchFromGarage(Vehicle vehicle)
        {
            if (garage is not null)
                return garage.Fetch(vehicle);
            else
                return false;
        }

        public int FreeParkingSlotsInGarage()
        {
            if (garage is not null)
                return garage.FreeParkingSlots();
            else
                return -1;
        }

        public bool IsGarageFull()
        {
            if (garage is not null)
                return garage.IsFull();
            else
                return false;
        }

        public bool IsParkedInGarage(Vehicle vehicle)
        {
            if (garage is not null)
                return garage.IsParked(vehicle);
            else
                return false;
        }

        public Vehicle[]? ListAllVehiclesInGarage()
        {
            if (garage is not null)
                return garage.ListAllVehicles();
            else
                return null;
        }

        public bool ParkInGarage(Vehicle vehicle)
        {
            if (garage is not null)
                return garage.Park(vehicle);
            else
                return false;
        }

        public void PrintAllInGarage()
        {
            if (garage is not null)
                garage.PrintAll();
        }
    }
}
