using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsStructure.Model.Config;
using ProjectsStructure.Model.Errors;

namespace ProjectsStructure.Model.Structures.Live
{
   // Проект
   public class Project
   {
      // Имя проекта - имя корневой папки
      public string Name { get; private set; }
      public string Area { get; private set; } // Область размещения проекта
      // Полный путь к папке проекта
      public DirectoryInfo Dir { get; private set; }
      // Структура проекта
      public StructureLive Structure { get; private set; }
      public StructureTemplate Template { get; set; }
      // Объекты ??? Имена. Объекты могут быть расположены в нескольких местах в структуре проекта.
      public List<string> Objects { get; private set; }
      /// <summary>
      /// Ссылка на коллекцию проектов
      /// </summary>
      public ProjectsCollection Projects { get; private set; }
      public bool HasError { get { return Error != null; } }
      public Error Error { get; private set; }

      public Project(DirectoryInfo dir, ProjectsCollection projects)
      {
         Dir = dir;
         Projects = projects;
         Name = Dir.Name;
      }      

      /// <summary>
      /// Считывание проекта из папки
      /// </summary>
      public void ReadStructure()
      {         
         // Структура
         Structure = new StructureLive(Dir, Projects.Service);
         Structure.Read();
         // Список объектов??? - по шаблону структуры проекта - определить места размещения папок [Объект]
         Objects = GetObjects();         
      }

      public void CheckProject()
      {
         // Проверка поекта
         // Имя проекта должно существовать в области Share
         var projectShare = Projects.ProjectsShare.Find(p => string.Equals(p.Name, Name, StringComparison.OrdinalIgnoreCase));
         if (projectShare == null)
         {
            // Ошибка - такого проекта нет в Share
            string errMsg = string.Format("Такого проекта не существует в Share - {0}. ", Name);
            if (Error == null)
            {
               Error = new Error(errMsg);
            }
            else
            {
               Error.Message += errMsg;
            }
         }
         // TODO: Объекты должны существовать в проекте из Share
      }

      private List<string> GetObjects()
      {
         List<string> objects = new List<string>();
         if (Template == null)
         {
            string errMsg = string.Format("Не найден шаблон структуры для проекта в {0} - {1}", 
                           Area ,Settings.Instance.TemplateStructureProjectShare);
            Projects.Service.Inspector.AddError(new Errors.Error(errMsg));
         }
         else
         {
            // Поиск мест размещения объектов в шаблоне.            
               // TODO: Поиск объектов
               //var dirItem = Dir; // начальная папка - корень проекта
               //foreach (var item in fiObject.Paths)
               //{
               //   if (item.Parent != null)// корень структуры пропускаем
               //   {
               //      dirItem = dirItem.GetDirectories(item.Name)?.FirstOrDefault();
               //      if (dirItem == null) break; // Не найдена папка. Остановка                     
               //   }
               //}            
         }
         return objects;
      }

      public override string ToString()
      {
         return Name;
      }
   }
}
