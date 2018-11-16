using log4net;

namespace Common
{
    public class Log4NetWriter : ILogWriter
    {
        public void WriteLog(string str)
        {
            log4net.Config.XmlConfigurator.Configure();
            ILog logwriter = LogManager.GetLogger("Logger");
            logwriter.Error(str);
        }
    }
}
