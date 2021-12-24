using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    internal class Motorcycle : Vehicle, IVehicle
    {
        private int cylinderCount;

        public Motorcycle(string id, string type, string color, string make, int wheels, int _cylinderCount) : base(id, type, color, make, wheels)
        {
            cylinderCount = _cylinderCount;
        }
        public int CylinderCount
        {
            get { return cylinderCount; }
            set { cylinderCount = value; }
        }

        public string PrintDetails() => $"Registration Id: {RegistrationId}, Type: {Type}, Color: {Color}, Make: {Make}, Wheels: {Wheels}, Cylinder Count: {CylinderCount}";
    }
}
