using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStructureConsole
{
   public enum EnumMode
   {
      None,
      Projects,
      Objects,
      Options
   }

   class Program
   {
      static void Main(string[] args)
      {
         var mode = getMode();
      }

      private static EnumMode getMode()
      {
         EnumMode mode = EnumMode.None;
         Console.WriteLine("Выбор режима работы: 1 - создание проектов, 2 - создание объектов, 3 - настройки");
         var res = Console.ReadLine();

         int value;
         if (int.TryParse(res, out value) && Enum.IsDefined(typeof(EnumMode), value))
         {
            mode = (EnumMode)value;
         }
         
         if (mode == EnumMode.None)
         {
            Console.WriteLine("Неверный ввод.");
            getMode();
         }
         return mode;
      }
   }
}
