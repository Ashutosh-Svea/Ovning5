using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    class Utils
    {
        public static int errNumberValue = -1;
        public static string errStringValue = "INVALID STRING";

        public static bool CheckNullOrEmptyString(string? str)
        {
            if (str is null)
                return true;
            else if (IsEmptyString(str))
                return true;
            else
                return false;

        }
        public static bool IsEmptyString(string str)
        {
            if (str.Equals(String.Empty))
                return true;
            else
                return false;
        }

        public static bool IsValidSize(int weight)
        {
            if (weight < 0)
                return false;
            else
                return true;
        }
    }
}
