using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    internal interface IHandler
    {
        public bool IsGarageCreated();
        public void CreateGarage(string name, int capacity);
        public bool ParkInGarage(Vehicle vehicle);

        public bool FetchFromGarage(Vehicle vechicle);

        public Vehicle[]? ListAllVehiclesInGarage();

        public int FreeParkingSlotsInGarage();

        public bool IsParkedInGarage(Vehicle vehicle);

        public bool IsGarageFull();

        public void PrintAllInGarage();

    }
}
