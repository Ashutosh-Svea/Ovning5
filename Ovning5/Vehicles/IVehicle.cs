using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    public interface IVehicle
    {
        string PrintDetails();
        void TryPark();
        void TryFetch();
    }
}
