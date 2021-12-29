using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    public interface ILogger
    {
        void init();
        void close();
        void log(string log);
    }
}
