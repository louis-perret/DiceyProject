using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;

namespace LoggingConfig.LogConfig
{
    internal class LoggerConfig
    {
        public static void SetModelConfig()
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "modelLogs.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
            
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);

            NLog.LogManager.Configuration = config;
        }
    }
}
