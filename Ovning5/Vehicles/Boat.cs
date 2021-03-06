using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    public class Boat : Vehicle
    {
        private string fuelType;

        public Boat (ILogger logger, string id, string type, string color, string make, int wheels, string _fuelType) : base(logger, id, type, color, make, wheels)
        {   
            fuelType = _fuelType ;
        }
        public string FuelType
        {
            get { return fuelType; }
            set { fuelType = value; }
        }


        public override string PrintDetails() => $"Registration Id: {RegistrationId}, Type: {Type}, Color: {Color}, Make: {Make}, Wheels: {Wheels}, FuelType: {FuelType}";    }
}
