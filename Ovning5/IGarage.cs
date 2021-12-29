using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    public interface IGarage<T>
    {
        public bool Park(T vehicle);

        public bool Fetch(string regId);

//        public Vehicle[]? ListAllVehicles();

        public int FreeParkingSlots();

        public bool IsParked(T vehicle);

        public bool IsFull();

        public void PrintAll();

    }
}
