using NLog;
using NLog.Targets;
using NLog.Targets.Wrappers;

namespace LoggerHelper
{
  public class LoggerHelper
  {
    public static void Shutdown() => NLog.LogManager.Shutdown(); //Закрытие логов
    public static void Flush() => NLog.LogManager.Flush(); //Запись логов целиком
  }
}
