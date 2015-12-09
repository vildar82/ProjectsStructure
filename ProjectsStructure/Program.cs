using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using ProjectsStructure.Model;
using ProjectsStructure.Model.Config;
using ProjectsStructure.Model.Structures.Live;
using ProjectsStructure.Test;

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

         //Application.EnableVisualStyles();
         //Application.SetCompatibleTextRenderingDefault(false);
         //Application.Run(new FormStructure());         

         //service = new Service();

         // Считывание шаблонов структор
         //service.ReadTemplates();

         EnumMode mode = getMode();

         Console.WriteLine("Режим {0}", mode);


         if (mode == EnumMode.Projects)
         {
            // Создание проектов
         }
         else if (mode == EnumMode.Objects)
         {
            // Создание объектов
         }

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
