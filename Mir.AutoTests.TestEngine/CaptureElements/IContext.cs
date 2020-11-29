using System;
using System.Collections.Generic;
using System.Text;

namespace Mir.AutoTests.TestEngine.CaptureElements
{
  /// <summary>
  /// Контекст-репозиторий для методов захвата элементов
  /// (Ключ - виртуальный идентификатор объекта, значение - массив методов захвата элементов)
  /// </summary>
  public interface IContext
  {
    /// <summary>
    /// Получить методы захвата элемента по ключу
    /// </summary>
    /// <param name="key">Внутренний "виртуальный" идентификатор элемента</param>
    /// <returns>Массив описателей методов захвата элемента</returns>
    IReadOnlyList<CaptureMethod> GetCaptureMethods(string key);

    /// <summary>
    /// Добавить или обновить методы захвата элемента по ключу.
    /// Методы захвата должны быть отсортированы в порядке убывания приоритета
    /// </summary>
    /// <param name="key">Внутренний "виртуальный" идентификатор элемента</param>
    /// <param name="captureMethods"></param>
    void AddOrUpdateCaptureMethods(string key, IReadOnlyList<CaptureMethod> captureMethods);

    /// <summary>
    /// Удалить методы захвата элемента по ключу
    /// </summary>
    /// <param name="key"></param>
    /// <returns>Массив описателей методов захвата элемента</returns>
    IReadOnlyList<CaptureMethod> RemoveCaptureMethods(string key);
  }
}
