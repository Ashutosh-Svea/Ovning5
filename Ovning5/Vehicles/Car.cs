using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    internal class Car : Vehicle
    {
        private int engine;

        public Car(ILogger logger, string id, string type, string color, string make, int wheels, int _engine) : base(logger, id, type, color, make, wheels)
        {
            engine = _engine;
        }
        public int Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public override string PrintDetails() => $"Registration Id: {RegistrationId}, Type: {Type}, Color: {Color}, Make: {Make}, Wheels: {Wheels}, Engine: {Engine}";
    }
}
