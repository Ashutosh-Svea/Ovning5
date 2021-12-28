using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    internal class Garage : IGarage, IEnumerable <Vehicle>
    {
        private ILogger logger;
        private Vehicle[] vehicleList;

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
            vehicleList = new Vehicle[1];  //just a seed vehicle. As vehicles are added and removed, we shall change...
            logger = _logger;
        }
        public bool Fetch(string regId)
        {
            try
            {
                Vehicle? vehicle = TryFindById(regId);
                logger.log($"Finding {regId} in Garage {GarageName} ");
                if (vehicle is not null)
                {
                    vehicle.TryFetch();
                    remove(vehicle); //remove the vehicle in the garage vehicle arrray
                    OccupiedCount--;
                    return true;
                }
                else
                {
                    logger.log("Vehicle not found");
                    return false;
                }

            }
            catch (Exception e)
            {
                logger.log($"{regId} is not available in the garage");
                logger.log(e.Message);
                return false;
            }
        }

        private Vehicle? TryFindById(string regId)
        {
            foreach (Vehicle v in vehicleList)
            {
                if (v is not null)
                {
                    if (String.Compare(v.RegistrationId, regId, comparisonType: StringComparison.OrdinalIgnoreCase) == 0)
                        return v;
                }
            }
            throw (new Exception("Vehicle cannot be found!"));
        }

        private void remove(Vehicle vehicle)
        {            
            vehicleList = vehicleList.Where(v => v is not null && v.RegistrationId != vehicle.RegistrationId).ToArray();
        }

        public int FreeParkingSlots()
        {
            return GarageCapacity - OccupiedCount;
        }

        public bool IsFull()
        {
            return GarageCapacity == OccupiedCount; 
        }

        public bool IsParked(Vehicle vehicle)
        {
            foreach (Vehicle v in vehicleList)
            {
                if (v.RegistrationId == vehicle.RegistrationId)
                    return true;
            }
            return false;
        }

        public Vehicle[]? ListAllVehicles()
        {
            return vehicleList;
        }

        public bool Park(Vehicle vehicle)
        {
            try
            {
                logger.log($"Parking {vehicle.RegistrationId} in Garage {GarageName} ");
                vehicle.TryPark();
                TryAdd(vehicle); //add the vehicle in the garage vehicle arrray
                OccupiedCount++;
                return true;
            }
            catch (Exception e)
            {
                logger.log($"Unable to park {vehicle.RegistrationId}");
                logger.log(e.Message);
                return false;
            }
        }

        private void TryAdd(Vehicle vehicle)
        {
            if (IsFull() is true)
            {
                throw (new Exception("Garage already full. Cannot add more vehicles"));
            }
            else
            {
                //vehicleList = vehicleList.
                  //  Add(vehicle).ToArray();
                vehicleList = vehicleList.Append(vehicle).ToArray();
            }
        }

        public void PrintAll()
        {
            foreach (Vehicle vehicle in vehicleList)
            {
                if (vehicle is not null) //all empty slots in garage are null perhaps...
                    logger.log(vehicle.PrintDetails());
            }
        }

        public IEnumerator<Vehicle> GetEnumerator()
        {
            foreach (Vehicle vehicle in vehicleList)
                yield return vehicle;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
