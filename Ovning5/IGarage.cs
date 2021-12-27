using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    internal interface IGarage
    {
        public void Find();
        public bool Park(IVehicle vehicle);

        public bool Fetch(IVehicle vechicle);

        public IVehicle[] ListAllVehicles();

        public int FreeParkingSlots();

        public bool IsParked(IVehicle vehicle);

        public bool IsFull();

        public void PrintAll();

    }
}
