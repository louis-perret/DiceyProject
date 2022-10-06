using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LoggingConfig.LogConfig;
using Microsoft.Extensions.Logging;

[assembly:InternalsVisibleTo("Modele")]

namespace LoggingConfig.LogFactory
{
    internal class LogFactory
    {
        internal static ILogger GetLogger(Choice c)
        {

            switch (c)
            {
                case Choice.Model:
                    LoggerConfig.SetModelConfig();
                    return (ILogger)NLog.LogManager.GetLogger();

                default:
                    return (ILogger)NLog.LogManager.GetLogger(className);
            }


        }

    }
}
