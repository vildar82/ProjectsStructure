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
      private Service _service;

      // Имя проекта - имя корневой папки
      public string Name { get; private set; }
      public string Area { get; private set; } // Область размещения проекта
      // Полный путь к папке проекта
      public DirectoryInfo Dir { get; private set; }
      // Структура проекта
      public StructureLive StructureLive { get; private set; }
      public StructureTemplate StructureTemplate { get; set; }
      // Объекты ??? Имена. Объекты могут быть расположены в нескольких местах в структуре проекта.
      public List<string> ObjectsLive { get; private set; }
      /// <summary>
      /// Ссылка на коллекцию проектов
      /// </summary>
      public ProjectsCollection Projects { get; private set; }
      public bool HasError { get { return Error != null; } }
      public Error Error { get; private set; }

      

      public Project(DirectoryInfo dir, Service service)
      {
         _service = service;
         Dir = dir;
         Projects = _service.Projects;
         Name = Dir.Name;
      }      

      /// <summary>
      /// Считывание проекта из папки
      /// </summary>
      public void ReadStructure()
      {         
         // Структура
         StructureLive = new StructureLive(Dir, Projects.Service);
         StructureLive.Read();
         // Список объектов??? - по шаблону структуры проекта - определить места размещения папок [Объект]
         ObjectsLive = GetObjects();         
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
         if (StructureTemplate == null)
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

      public void CreateObjects(List<ObjectInfo> objects)
      {
         // TODO: Создание объектов в живой структуре
         // Если папка объекта существует, то она пропускается.

         // Найти в шаблоне структуры место размещения объекта
         // найти соответствующее расположение этой папки в существующей структуре проекта
         foreach (var fiObject in this.StructureTemplate.ObjectsFolders)
         {
            // Путь к этой папке объекта относительно корня сущ проекта
            DirectoryInfo dirObject = new DirectoryInfo(Path.Combine(Dir.FullName, fiObject.FullPath()));
            fiObject.Create(dirObject, objects);
         }
      }

      /// <summary>
      /// Создание файла шаблона проекта в корне папки проекта
      /// </summary>
      public void CreateFileProjectTemplate()
      {
         // скопировать файл шаблона проекта
         FileInfo fiTemplate = new FileInfo(Settings.Instance.TemplateProjectExcelFile);
         string fileProjectTemplate = Path.Combine(Dir.FullName, Name + ".xlsx");
         try
         {
            FileInfo fiProject = fiTemplate.CopyTo(fileProjectTemplate);
            // TODO Подпись имени проекта в файле
         }
         catch (Exception ex)
         {
            this._service.Inspector.AddError(new Error("Ошибка при копировании файла шаблона - {0}. Проект {1} в файл {2}. Шаблон {3}. ",
                     ex.Message, Name, fileProjectTemplate, Settings.Instance.TemplateProjectExcelFile));
         }  
      }

      public override string ToString()
      {
         return Name;
      }
   }
}
