// See https://aka.ms/new-console-template for more information



using Modele.Business.DiceFolder;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using LoggingConfig.LogConfig;
using Modele.Manager.DiceManagerFolder;

LoggerConfig.SetModelConfig();
var logger = LoggerFactory.Create(builder => builder.AddNLog()).CreateLogger<SimpleDiceManager>();