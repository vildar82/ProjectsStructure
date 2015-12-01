using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsStructure.Model.Structures
{
   /// <summary>
   /// Ссылка - символьная
   /// </summary>
   public class Link
   {
      // папка ссылки - имя папки = имя ссылки
      public FolderItem FolderItem { get; private set; }
      public string TargetPath { get; private set; }
      public string ErrMsg { get; private set; }
      private string targetOriginal;

      // Конструктор для шаблона структур
      public Link (FolderItem fi, string target)
      {
         FolderItem = fi;
         targetOriginal = target;
         // раскрытие переменных в ссылке (Определенных в конфиге - Variables)
         TargetPath = target.Expand();
         // Раскрытие относительного пути ссылки
         if (!Path.IsPathRooted(target)) // Если цель ссылки не начинается с корневой папки, то это относительный путь
         {
            string path = Path.GetDirectoryName(fi.FullPath());
            var absPath = Path.Combine(path, target);
            TargetPath = Path.GetFullPath(absPath);
         }
         // проверка ссылки
         Check();
      }      

      private void Check()
      {
         if (!Directory.Exists(TargetPath))
         {
            if (FolderItem is FolderItemTemplate)
            {
               ErrMsg = string.Format(
                  "Ошибка определения ссылки - цель ссылки не найдена. Шаблон структуры {0}, строка {1}, имя ссылки {2}, цель ссылки {3}",
                  FolderItem.Structure.Name, ((FolderItemTemplate)FolderItem).Row, FolderItem.Name, TargetPath);
            }
            else
            {
               ErrMsg = string.Format(
                  "Ошибка определения ссылки - цель ссылки не найдена. Структура {0}, ссылка {1}, цель ссылки {2}",
                  FolderItem.Structure.Name, FolderItem.FullPath(), TargetPath);
            }            
            FolderItem.Structure.SS.Inspector.AddError(new Errors.Error(ErrMsg));
         }
         else
         {
            ErrMsg = "Ошибок нет.";
         }
      }
   }
}
