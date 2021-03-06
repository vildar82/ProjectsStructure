﻿//http://habrahabr.ru/post/98638/
//Правильное логгирование в Microsoft.NET Framework

//Debug: Получена посылка 1. Проверяю размер…
//Debug: Размер посылки 1: 40x100
//Debug: Взвешиваю посылку…
//Debug: Вес посылки 1: 1кг
//Debug: Проверяю соответствие нормам…
//Info(не Error!): Посылка 1 размером 40x100, весом 1кг, отклонена: превышен максимальный размер
//…
//Info: Посылка 2 размером 20x60, весом 0.5 кг передана на обработку оператору 1
//…
//Warn: Отказано в обработке для посылки 3: дата на посылке относится к будущему: 2050-01-01
//…
//Error: Не удалось отдать посылку оператору: оператор не отвечает: таймаут ожидания ответа оператора
//…
//Fatal: Произошёл отказ весов.Посылки не будут приниматься до восстановления работоспособности.

using System;
using System.IO;
using System.Reflection;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace ProjectsStructure
{
   ///<summary>
   ///Debug: сообщения отладки, профилирования. В production системе обычно сообщения этого уровня включаются при первоначальном запуске системы или для поиска узких мест (bottleneck-ов).
   ///Info: обычные сообщения, информирующие о действиях системы.Реагировать на такие сообщения вообще не надо, но они могут помочь, например, при поиске багов, расследовании интересных ситуаций итд.
   ///Warn: записывая такое сообщение, система пытается привлечь внимание обслуживающего персонала.Произошло что-то странное. Возможно, это новый тип ситуации, ещё не известный системе. Следует разобраться в том, что произошло, что это означает, и отнести ситуацию либо к инфо-сообщению, либо к ошибке.Соответственно, придётся доработать код обработки таких ситуаций.
   ///Error: ошибка в работе системы, требующая вмешательства. Что-то не сохранилось, что-то отвалилось. Необходимо принимать меры довольно быстро! Ошибки этого уровня и выше требуют немедленной записи в лог, чтобы ускорить реакцию на них.Нужно понимать, что ошибка пользователя – это не ошибка системы. Если пользователь ввёл в поле -1, где это не предполагалось – не надо писать об этом в лог ошибок.
   ///Fatal: это особый класс ошибок. Такие ошибки приводят к неработоспособности системы в целом, или неработоспособности одной из подсистем.Чаще всего случаются фатальные ошибки из-за неверной конфигурации или отказов оборудования. Требуют срочной, немедленной реакции. Возможно, следует предусмотреть уведомление о таких ошибках по SMS.
   ///</summary>
   public static class Log
   {
      private static Logger _logger;

      static Log()
      {
         _logger = LogManager.GetLogger("ProjectsStructure");         
      }

      /// <summary>
      /// Debug: сообщения отладки, профилирования. В production системе обычно сообщения этого уровня включаются при первоначальном запуске системы или для поиска узких мест (bottleneck-ов).
      /// </summary>
      /// <param name="message"></param>
      public static void Debug(string message)
      {
         _logger.Debug(message);
      }

      public static void Debug(string message, params object[] args)
      {
         _logger.Debug(message, args);
      }

      public static void Debug(Exception ex, string message, params object[] args)
      {
         _logger.Debug(ex, message, args);
      }

      /// <summary>
      /// Error: ошибка в работе системы, требующая вмешательства. Что-то не сохранилось, что-то отвалилось. Необходимо принимать меры довольно быстро! Ошибки этого уровня и выше требуют немедленной записи в лог, чтобы ускорить реакцию на них.Нужно понимать, что ошибка пользователя – это не ошибка системы. Если пользователь ввёл в поле -1, где это не предполагалось – не надо писать об этом в лог ошибок.
      /// </summary>
      /// <param name="message"></param>
      public static void Error(string message)
      {
         _logger.Error(message);
      }

      public static void Error(Exception ex, string message, params object[] args)
      {
         _logger.Error(ex, message, args);
      }

      public static void Error(string message, params object[] args)
      {
         _logger.Error(message, args);
      }

      /// <summary>
      /// Fatal: это особый класс ошибок. Такие ошибки приводят к неработоспособности системы в целом, или неработоспособности одной из подсистем.Чаще всего случаются фатальные ошибки из-за неверной конфигурации или отказов оборудования. Требуют срочной, немедленной реакции. Возможно, следует предусмотреть уведомление о таких ошибках по SMS.
      /// </summary>
      /// <param name="message"></param>
      public static void Fatal(string message)
      {
         _logger.Fatal(message);
      }

      public static void Fatal(Exception ex, string message, params object[] args)
      {
         _logger.Fatal(ex, message, args);
      }

      public static void Fatal(string message, params object[] args)
      {
         _logger.Fatal(message, args);
      }

      /// <summary>
      /// Info: обычные сообщения, информирующие о действиях системы.Реагировать на такие сообщения вообще не надо, но они могут помочь, например, при поиске багов, расследовании интересных ситуаций итд.
      /// </summary>
      /// <param name="message"></param>
      public static void Info(string message)
      {
         _logger.Info(message);
      }

      public static void Info(string message, params object[] args)
      {
         _logger.Info(message, args);
      }

      public static void Info(Exception ex, string message, params object[] args)
      {
         _logger.Info(ex, message, args);
      }

      /// <summary>
      /// Warn: записывая такое сообщение, система пытается привлечь внимание обслуживающего персонала.Произошло что-то странное. Возможно, это новый тип ситуации, ещё не известный системе. Следует разобраться в том, что произошло, что это означает, и отнести ситуацию либо к инфо-сообщению, либо к ошибке.Соответственно, придётся доработать код обработки таких ситуаций.
      /// </summary>
      /// <param name="message"></param>
      public static void Warn(string message)
      {
         _logger.Warn(message);
      }

      public static void Warn(string message, params object[] args)
      {
         _logger.Warn(message, args);
      }

      public static void Warn(Exception ex, string message, params object[] args)
      {
         _logger.Warn(ex, message, args);
      }      
   }
}