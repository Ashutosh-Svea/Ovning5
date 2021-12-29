using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    internal class FileLogger : ILogger
    {
        readonly StreamWriter logFile;
        //private static string? LogFile = ConfigurationManager.AppSettings["LogFile"];
        public FileLogger(string fileName)
        {
            //logFile = new StreamWriter(fileName, append: true);
            logFile = new StreamWriter(fileName);

        }
        public void init()
        {
  
        }

        public void log(string log)
        {
            //await logFile.WriteLineAsync(log);
            logFile.WriteLine(log);
        }

        public void close()
        {
            logFile.Close();
        }
    }
}
