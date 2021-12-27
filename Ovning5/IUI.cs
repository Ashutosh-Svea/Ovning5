using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    internal interface IUI
    {
        void PrintMainChoices();
        void PrintGarageChoices();
        void PrintVehicleChoices();
        int GetUserChoice();
    }
}
