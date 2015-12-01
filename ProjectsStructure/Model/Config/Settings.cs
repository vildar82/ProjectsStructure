using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsStructure.Model.Config
{
   [Serializable]
   public class Settings
   {
      private static Settings instance = Load();

      private Settings() { }

      public static Settings Instance { get { return instance; } }
      private static string FileSettings
      {
         get
         {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");
         }
      }                 
      
      public string ProjectsShareFolder { get; set; }      
      public string ProjectsWipFolder { get; set; }
      public List<Variable> Variables { get; set; }      
      public string TemplatesExcelFile { get; set; }                  
      // Папка с папками шаблонов прав доступа. Шаблон прав - это папка с назначенными ей правами.
      public string TemplatesAccessFolder { get; set; }
      // Шаблон для структуры проекта
      public string TemplateStructureProjectShare { get; set; }

      private static Settings Load()
      {
         if (File.Exists(FileSettings))
         {
            try
            {
               SerializerXml ser = new SerializerXml(FileSettings);
               return ser.DeserializeXmlFile<Settings>();
            }
            catch (Exception ex)
            {
               Log.Error(ex, "Загрузка файла настроек.");
               throw;
            }
         }
         else
         {
            Settings settings = new Settings();
            settings.Default();
            try
            {
               settings.Save();
            }
            catch (Exception ex)
            {
               Log.Error(ex, "Сохранение файла настроек.");
            }
            return settings;
         }
      }

      public void Save()
      {
         SerializerXml ser = new SerializerXml(FileSettings);
         ser.SerializeList(this);
      }

      public void Default()
      {
         ProjectsShareFolder = @"c:\temp\test\Project\share";
         ProjectsWipFolder = @"c:\temp\test\Project\wip";
         Variables = new List<Variable>();
         Variables.Add(new Variable("Key1", "Value1"));
         TemplatesExcelFile = @"c:\temp\test\Project\templates\Templates.xlsx";
         TemplatesAccessFolder = @"c:\temp\test\Project\templates\ШаблоныПрав";
         TemplateStructureProjectShare = "{Проект}";
      }      
   }
}
