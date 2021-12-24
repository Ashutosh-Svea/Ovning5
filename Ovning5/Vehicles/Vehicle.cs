using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    internal abstract class Vehicle : IVehicle 
    {
        public Vehicle(string _registrationId, string _type, string _color, string _make, int _wheels)
        {
            registrationId = _registrationId;
            type = _type;
            color = _color;
            make = _make;
            wheels = _wheels;
        }

        public bool IsParked { get; set; }

        private string  registrationId;

        public string  RegistrationId
        {
            get { return registrationId; }
            set { registrationId = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        private string make;

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        private int wheels;

        public int Wheels
        {
            get { return wheels; }
            set { wheels = value; }
        }

        public void TryFetch()
        {
            if (IsParked is true)
            {
                IsParked = false;
                Logger.log($"{RegistrationId} is fetched!");
            }
            else
            {
                Logger.log($"{RegistrationId} is not parked so cannot fetch!");
                throw new Exception($"{RegistrationId} is not parked so cannot fetch!");

            }
        }

        public void TryPark()
        {
            if (IsParked is false)
            {
                IsParked = true;
                Logger.log($"{RegistrationId} is parked!");

            }
            else
            {
                Logger.log($"{RegistrationId} is already parked so cannot park again!");
                throw new Exception($"{RegistrationId} is already parked so cannot park again!");
            }

        }
        public abstract string PrintDetails();
    }
}
