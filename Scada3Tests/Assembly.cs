using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using NLog.Config;
using NLog;
using NLog.Targets;
using LoggerHelper;

namespace Scada3Tests
{
  [SetUpFixture]
  public class Assembly
  {

    [OneTimeSetUp]
    public static void SetUp()
    {
      LoggerFactory = ConfigurationLogger.CreateLoggerFactory();
    }

    [OneTimeTearDown] 
    public static void TearDown()
    {
      LoggerHelper.LoggerHelper.Flush(); //Запись логов целиком
      LoggerHelper.LoggerHelper.Shutdown(); //Закрытие логов*/
    }

    /// Версия тестируемой ПК Заря
    /// </summary>
    public static string SunriseVersion { get; set; } //TODO: Получение версии из артефактов сборки
    /// <summary>
    /// Фабрика логгеров
    /// </summary>
    public static ILoggerFactory LoggerFactory { get; set; }
 
  }
}
