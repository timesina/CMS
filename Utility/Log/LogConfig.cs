using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Log
{
    public class LogConfig
    {
        public static void Config(string url)
        {
            XmlConfigurator.Configure(new FileInfo(url));
        }
    }
}
