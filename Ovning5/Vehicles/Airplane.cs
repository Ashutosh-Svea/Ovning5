using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{

    internal class Airplane : Vehicle
    {
        private int length;

        public Airplane(string id, string type, string color, string make, int wheels, int _length) : base(id, type, color, make, wheels)
        {
            length = _length;
        }
        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public override string PrintDetails() => $"Registration Id: {RegistrationId}, Type: {Type}, Color: {Color}, Make: {Make}, Wheels: {Wheels}, Length: {Length}";
    }
}
