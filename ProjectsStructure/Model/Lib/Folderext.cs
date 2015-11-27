using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsStructure.Model.Lib
{
   public class FolderExt
   {
      /// <summary>
      /// Копирование прав доступа папки шаблона в папку назначения.
      /// Копируются только не унаследованные права
      /// </summary>
      /// <param name="template">папка шаблона прав. Должна существовать</param>
      /// <param name="dest">папка назначения. Если нет, то создается</param>
      /// <exception cref="DirectoryNotFoundException">Папка шаблона не найдена.</exception>
      /// <exception cref="IOException">Создание папки назначения.</exception>
      public static void FolderCopyAcces(String template, String dest)
      {
         DirectoryInfo templateDir = new DirectoryInfo(template);
         DirectoryInfo destDir;

         if (!templateDir.Exists)
         {
            throw new DirectoryNotFoundException("Папка шаблона не найдена: " + template);
         }

         if (!Directory.Exists(dest))
         {
            destDir = Directory.CreateDirectory(dest);
         }
         else
         {
            destDir = new DirectoryInfo(dest);
         }

         DirectorySecurity security = templateDir.GetAccessControl();

         security.SetAccessRuleProtection(false, true);
         destDir.SetAccessControl(security);         
      }
   }
}
