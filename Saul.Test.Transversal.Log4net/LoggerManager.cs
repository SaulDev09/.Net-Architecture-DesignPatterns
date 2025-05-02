using log4net;
using Saul.Test.Transversal.Common;
using System.Reflection;


namespace Saul.Test.Transversal.Log4net
{
    public class LoggerManager : ILoggerManager
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public LoggerManager()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            var fileInfo = new FileInfo("log4net.config");
            log4net.Config.XmlConfigurator.Configure(logRepository, fileInfo);
        }

        public void LogInfo(string message)
        {
            log.Info(message);
        }

        public void LogWarn(string message)
        {
            log.Warn(message);
        }

        public void LogDebug(string message)
        {
            log.Debug(message);
        }

        public void LogError(string message)
        {
            log.Error(message);
        }
    }
}
