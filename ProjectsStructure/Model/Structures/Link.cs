using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsStructure.Model.Lib;

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
      private Service _service;

      // Конструктор для шаблона структур
      public Link(FolderItem fi, string target)
      {
         _service = fi.Structure.Service;
         FolderItem = fi;
         targetOriginal = target;
         TargetPath = target;
         if (fi is FolderItemTemplate)
         {
            // Могут использоваться переменные - значения которых могут быть определены только при создании структуры проекта (Project и Object).
            // раскрытие переменных в ссылке (Определенных в конфиге - Variables)
            //TargetPath = target.Expand();
         }
         else
         {            
            // Раскрытие относительного пути ссылки
            if (!Path.IsPathRooted(TargetPath)) // Если цель ссылки не начинается с корневой папки, то это может быть относительный путь
            {
               string path = Path.GetDirectoryName(fi.FullPath());
               var absPath = Path.Combine(path, TargetPath);
               TargetPath = Path.GetFullPath(absPath);
            }
            // проверка ссылки
            Check();
         }         
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
            _service.Inspector.AddError(new Errors.Error(ErrMsg));
         }
         else
         {
            ErrMsg = "Ошибок нет.";
         }
      }

      /// <summary>
      /// Создание ссылки
      /// </summary>
      /// <param name="dirLocation">Место расположения ссылки</param>
      public void Create(DirectoryInfo dirLocation)
      {
         string linkPath = Path.Combine(dirLocation.FullName, FolderItem.Name.Expand());
         string targetPath = Path.Combine(TargetPath.Expand());
         try
         {
            SymbolicLink.CreateDirectoryLink(linkPath, targetPath);
            //// тест - создание текстового файла в папке назначения ссылки - с текстом полного пути
            //using (var txt = File.CreateText(Path.Combine(targetPath, FolderItem.Name + ".txt")))
            //{
            //   txt.WriteLine(targetPath);               
            //}
         }
         catch (Exception ex)
         {
            string errMsg = string.Format("Ошибка создания ссылки {0}. Цель ссылки {1}. Ошибка {2}",
               linkPath, targetPath, ex.ToString());
            _service.Inspector.AddError(new Errors.Error(errMsg));
         }         
      }
   }
}
