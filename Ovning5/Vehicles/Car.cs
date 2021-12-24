using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    internal class Car : Vehicle, IVehicle
    {
        private int engine;

        public Car(string id, string type, string color, string make, int wheels, int _engine) : base(id, type, color, make, wheels)
        {
            engine = _engine;
        }
        public int Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public string PrintDetails() => $"Registration Id: {RegistrationId}, Type: {Type}, Color: {Color}, Make: {Make}, Wheels: {Wheels}, Engine: {Engine}";
    }
}
