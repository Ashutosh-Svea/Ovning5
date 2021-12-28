using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    public class Bus : Vehicle
    {
        private int seats;

        public Bus (ILogger logger, string id, string type, string color, string make, int wheels, int _seats) : base(logger, id, type, color, make, wheels)
        {
            seats = _seats;
        }
        public int Seats 
        {
            get { return seats; }
            set { seats = value; }
        }

        public override string PrintDetails() => $"Registration Id: {RegistrationId}, Type: {Type}, Color: {Color}, Make: {Make}, Wheels: {Wheels}, Seats: {Seats}";
    }
}
