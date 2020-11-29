using System;
using System.Collections.Generic;
using System.Text;

namespace Mir.AutoTests.TestEngine.Notifications
{
  /// <summary>
  /// Оповещение о результатах тестов
  /// </summary>
  public interface INotification
  {
    /// <summary>
    /// Отправить оповещение
    /// </summary>
    void SendNotification();
  }
}
