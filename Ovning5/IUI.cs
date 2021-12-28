using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    internal interface IUI
    {
        void Run();
        void PrintMainChoices();
        void ProcessGarageChoice();
        void PrintVehicleChoices();
        //void GetVehicleDetails();
        int GetUserChoice();
    }
}
