using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Log
{
    public class LogHelper
    {
        private ILog logger;

        public LogHelper(Type type)
        {
            logger = LogManager.GetLogger(type);
        }
    }
}
