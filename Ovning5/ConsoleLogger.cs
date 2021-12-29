using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    public class ConsoleLogger : ILogger
    {
        //private static string? LogFile = ConfigurationManager.AppSettings["LogFile"];

        public void init()
        {

        }

        public void log(string log)
        {
            Console.WriteLine(log);
        }

        public void close()
        {
        }

    }
}
