using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    internal class Garage : IGarage
    {
        private ILogger logger;
        private IVehicle[] vehicleList;

        public int OccupiedCount { get; set; } = 0;

        private int garageCapacity = 0;

        public int GarageCapacity
        {
            get { return garageCapacity; }
            set { garageCapacity = value; }
        }

        private string garageName = "";

        public string GarageName
        {
            get { return garageName; }
            set { garageName = value; }
        }

        public Garage(ILogger _logger, string _name = "", int _garageCapacity =0)
        {
            GarageName = _name;
            GarageCapacity = _garageCapacity;
            vehicleList = new IVehicle[garageCapacity];
            logger = _logger;
        }
        public bool Fetch(IVehicle vehicle)
        {
            try
            {
                logger.log($"Finding {vehicle.GetRegistrationId()} in Garage {GarageName} ");
                vehicle.TryFetch();
                return true;
            }
            catch (Exception e)
            {
                logger.log($"{vehicle.GetRegistrationId()} is not Available");
                logger.log(e.Message);
                return false;
            }
        }

        public void Find()
        {
            throw new NotImplementedException();
        }

        public int FreeParkingSlots()
        {
            return GarageCapacity - OccupiedCount;
        }

        public bool IsFull()
        {
            return GarageCapacity == OccupiedCount; 
        }

        public bool IsParked(IVehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public IVehicle[] ListAllVehicles()
        {
            return vehicleList;
        }

        public bool Park(IVehicle vehicle)
        {
            try
            {
                logger.log($"Parking {vehicle.GetRegistrationId()} in Garage {GarageName} ");
                vehicle.TryPark();
                return true;
            }
            catch (Exception e)
            {
                logger.log($"Unable to park {vehicle.GetRegistrationId()}");
                logger.log(e.Message);
                return false;
            }
        }

        public void PrintAll()
        {
            throw new NotImplementedException();
        }
    }
}
