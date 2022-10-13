// See https://aka.ms/new-console-template for more information



using Modele.Business.DiceFolder;
using Microsoft.Extensions.Logging;
using LoggingConfig.LogConfig;
using Modele.Manager.DiceManagerFolder;
using NLog.Extensions.Logging;

LoggerConfig.SetModelConfig();
var logger = LoggerFactory.Create(builder => builder.AddNLog()).CreateLogger<SimpleDiceManager>();