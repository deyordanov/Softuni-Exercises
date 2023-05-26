using LogForU.ConsoleApp.CustomLayouts;
using LogForU.Core.Appenders;
using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.IO;
using LogForU.Core.IO.Interfaces;
using LogForU.Core.Layouts;
using LogForU.Core.Loggers;

var xmlLayout = new XmlLayout();
var consoleAppender = new ConsoleAppender(xmlLayout);

ILogFile logFile = new LogFile();
IAppender fileAppender = new FileAppender(xmlLayout, logFile);

var logger = new Logger(fileAppender);

logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");