using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    internal abstract class Vehicle 
    {
        public Vehicle(string _registrationId, string _type, string _color, string _make, int _wheels)
        {
            registrationId = _registrationId;
            type = _type;
            color = _color;
            make = _make;
            wheels = _wheels;
        }

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

    }
}
