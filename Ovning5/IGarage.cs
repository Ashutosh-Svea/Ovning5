using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    internal interface IGarage
    {
        public bool Park(Vehicle vehicle);

        public bool Fetch(Vehicle vechicle);

        public Vehicle[]? ListAllVehicles();

        public int FreeParkingSlots();

        public bool IsParked(Vehicle vehicle);

        public bool IsFull();

        public void PrintAll();

    }
}
