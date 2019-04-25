using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.PublicTools
{
    public class NLogTool
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void InfoLog(string message)
        {
            logger.Info(message);
        }

        public static void ErrorLog(string message)
        {
            logger.Error(message);
        }
    }
}
