using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LoggingConfig.LogConfig;
using Microsoft.Extensions.Logging;

[assembly:InternalsVisibleTo("Modele")]
[assembly:InternalsVisibleTo("FunctionalTest")]

namespace LoggingConfig.LogFactory
{
    internal class LogFactory
    {
        internal static NLog.Logger GetLogger(Choice c)
        {

            switch (c)
            {
                case Choice.Model:
                    LoggerConfig.SetModelConfig();
                    return NLog.LogManager.GetCurrentClassLogger();

                default:
                    return NLog.LogManager.GetCurrentClassLogger();
            }


        }

    }
}
