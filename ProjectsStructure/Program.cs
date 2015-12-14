using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using ProjectsStructure.Model;
using ProjectsStructure.Model.Config;
using ProjectsStructure.Model.Structures.Live;
using ProjectsStructure.Model.Structures.Objects;

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
            Log.Error(ex, "Есть ошибки при считывании структур. Файл шаблонов структур {0}", Settings.Instance.TemplatesExcelFile);
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
               service.CreateProjects();
            }
            catch (Exception ex)
            {               
               Log.Error(ex, "Есть ошибки при создании проектов. Файл списка создаваемых проектов {0}", Settings.Instance.ProjectListFileToCreate);
               Exit();
               return;
            }            
         }
         else if (mode == EnumMode.Objects)
         {
            // Создание объектов - нужно знать имя проекта для которого создавать объекты. Список объектов получить из файла шаблона проекта в корне проекта в Share
            string projectName = "0000_Test";
            string fileProjectTemplate = @"c:\temp\test\Project\share\0000_Test\0000_Test.xlsx";

            // Считывание списка объектов для проекта из файла шаблона проекта.
            // проверка откроется ли epplus файл который открыть у пользователя
            try
            {
               service.CreateObjects(projectName, fileProjectTemplate);
            }
            catch (Exception ex)
            {
               Program.Log.Error(ex, "Ошибка создания объектов. Проект {0}, шаблон проета {1}", projectName, fileProjectTemplate);
            }            
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
