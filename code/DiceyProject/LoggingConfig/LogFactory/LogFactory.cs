using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LoggingConfig.LogConfig;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

[assembly:InternalsVisibleTo("Modele")]
[assembly:InternalsVisibleTo("FunctionalTest")]

namespace LoggingConfig.LogFactory
{
    internal class LogFactory<T>
    {
        internal static NLog.Logger? GetLogger(Choice c, T t)
        {

            switch (c) {
                case Choice.Model:
                    LoggerConfig.SetModelConfig();
                    return (NLog.Logger)LoggerFactory.Create(builder => builder.AddNLog()).CreateLogger<T>();
            }
            return null;

        }

    }
}
