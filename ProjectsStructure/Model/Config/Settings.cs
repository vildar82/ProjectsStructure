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

      #region Properties      

      [Browsable(true)]
      [Category("Общие")]
      [Description("Путь к папке проектов в Share")]
      public string PathFolderShareProjects { get; set; }

      [Browsable(true)]
      [Category("Шаблоны структур")]
      [Description("Переменные подстановки в именах, путях")]
      public List<Variable> Variables { get; set; }

      [Browsable(true)]
      [Category("Шаблоны структур")]
      [Description("Путь к файлу шаблонов в Excel")]
      public string ExcelFileTemplates { get; set; }

      #endregion Properties

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
         PathFolderShareProjects = @"c:\temp\test\Project\share";
         Variables = new List<Variable>();
         Variables.Add(new Variable("Key1", "Value1"));
         ExcelFileTemplates = @"c:\temp\test\Project\templates\Templates.xlsx";
      }      
   }
}
