using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    internal class Boat : Vehicle, IVehicle
    {
        private string fuelType;

        public Boat (string id, string type, string color, string make, int wheels, string _fuelType) : base(id, type, color, make, wheels)
        {
            fuelType = _fuelType ;
        }
        public string FuelType
        {
            get { return fuelType; }
            set { fuelType = value; }
        }
         
        public string PrintDetails() => $"Registration Id: {RegistrationId}, Type: {Type}, Color: {Color}, Make: {Make}, Wheels: {Wheels}, FuelType: {FuelType}";    }
}
