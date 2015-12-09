using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using ProjectsStructure.Model;
using ProjectsStructure.Model.Config;
using ProjectsStructure.Model.Structures.Live;

namespace ProjectsStructure
{
   public enum EnumMode
   {
      None,
      Projects,
      Objects,      
   }
      
   public class Program
   {
      public static Logger Log = LogManager.GetLogger("ProjectsStructure");
      private static Service service;

      [STAThread]
      static void Main(string[] args)
      {
         Log.Info("Старт программы: аргументы {0}", args);
         service = new Service();

         // Считывание шаблонов структр         
         try
         {
            service.ReadTemplates();
         }
         catch (Exception ex)
         {
            Console.WriteLine("Ошибка. {0}", ex.Message);
            Log.Error(ex, "Ошибка при считывании структур. Файл шаблонов структур {0}", Settings.Instance.TemplatesExcelFile);
            Exit();
            return;
         }

         // Запрос режима работы
         EnumMode mode = getMode();
         Console.WriteLine("Режим {0}", mode);
         
         if (mode == EnumMode.Projects)
         {            
            try
            {
               // Создание проектов
               service.CreateProjectsFromFile();
            }
            catch (Exception ex)
            {
               Console.WriteLine("Ошибка. {0}", ex.Message);
               Log.Error(ex, "Ошибка при создании проетов. Файл списка создаваемых проектов {0}", Settings.Instance.ProjectListFileToCreate);
               Exit();
               return;
            }            
         }
         else if (mode == EnumMode.Objects)
         {
            // Создание объектов - нужно знать имя проекта для которого создавать объекты. Список объектов получить из файла шаблона проекта в корне проекта в Share

         }

         Exit();
      }

      private static void Exit()
      {
         Console.Write("Press any key to exit.");
         Console.ReadKey();
      }

      private static EnumMode getMode()
      {
         EnumMode mode = EnumMode.None;
         Console.WriteLine("Выбор режима работы: 1 - создание проектов, 2 - создание объектов");
         var res = Console.ReadLine();

         int value;
         if (int.TryParse(res, out value) && Enum.IsDefined(typeof(EnumMode), value))
         {
            mode = (EnumMode)value;
         }         

         if (mode == EnumMode.None)
         {
            Console.WriteLine("Неверный ввод.");
            mode = getMode();
         }
         return mode;
      }
   }
}
