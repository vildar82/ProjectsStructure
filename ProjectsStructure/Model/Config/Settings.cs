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
      private static Settings instance;

      private Settings() { }      

      public static Settings Instance {
         get
         {
            if (instance == null) Load();
            return instance;
         }
      }
      private static string FileSettings
      {
         get
         {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");
         }
      }

      //public string ProjectsShareFolder { get; set; }      
      //public string ProjectsWipFolder { get; set; }
      [Description("Имя шаблона структуры для проекта в области Share. Имя шаблоны структуры = имени листа в Excel.")]
      public string TemplateStructureProjectShare { get; set; }
      [Description("Имя шаблона структуры для проекта в области WIP. Имя шаблоны структуры = имени листа в Excel.")]
      public string TemplateStructureProjectWIP { get; set; }
      //[Description("Имя шаблона структуры для проекта в области BIM. Имя шаблоны структуры = имени листа в Excel.")]
      //public string TemplateStructureProjectBIM { get; set; }
      //[Description("Имя шаблона структуры для проекта в области Civil. Имя шаблоны структуры = имени листа в Excel.")]
      //public string TemplateStructureProjectCivil { get; set; }      
      [Description("Excel файл шаблона проекта")]
      public string TemplateProjectExcelFile { get; set; }
      [Description("Excel файл шаблонов структур")]
      public string TemplatesExcelFile { get; set; }
      [Description("Папка с папками определяющими шаблоны прав доступа.")]
      public string TemplatesAccessFolder { get; set; }
      [Description("Текстовый файл с именами создаваемых проектов. Строка начинающаяся на # не учитывается")]
      public string ProjectListFileToCreate { get; set; }
      [Description("Переменные. Используются при определении путей в шаблонах структур в файлe Excel. Использовать в стиле ${key}. Переменные project и object - зарезервированы. Должны быть определены переменные share и wip - места расположения проектов.")]
      public List<Variable> Variables { get; set; }

      public static void Load()
      {
         if (File.Exists(FileSettings))
         {
            try
            {
               SerializerXml ser = new SerializerXml(FileSettings);
               instance = ser.DeserializeXmlFile<Settings>();
            }
            catch (Exception ex)
            {
               Program.Log.Error(ex, "Загрузка файла настроек.");
               throw;
            }
         }
         else
         {
            instance = new Settings();
            instance.Default();
            try
            {
               instance.Save();
            }
            catch (Exception ex)
            {
               Program.Log.Error(ex, "Сохранение файла настроек.");
            }            
         }
      }

      public void Save()
      {
         SerializerXml ser = new SerializerXml(FileSettings);
         ser.SerializeList(this);
      }

      public void Default()
      {
         //ProjectsShareFolder = @"c:\temp\test\Project\share";
         //ProjectsWipFolder = @"c:\temp\test\Project\wip"; 

         TemplateProjectExcelFile = @"c:\temp\test\Project\_fld-str-current\templates\projectTempl.xlsx";
         TemplatesExcelFile = @"c:\temp\test\Project\_fld-str-current\templates\mk_fs-35_list-v.xlsm";
         TemplatesAccessFolder = @"c:\temp\test\Project\_fld-str-current\templates\folders";
         TemplateStructureProjectShare = "fld-35-sp";
         TemplateStructureProjectWIP = "fld-35-wp";

         //TemplateStructureProjectBIM = "{BIM}";
         //TemplateStructureProjectCivil = "{Civil}";

         ProjectListFileToCreate = @"c:\temp\test\Project\_fld-str-current\projectList_all.txt";

         Variables = new List<Variable>();
         Variables.Add(new Variable("share", @"c:\temp\test\Project\share"));
         Variables.Add(new Variable("wip", @"c:\temp\test\Project\wip"));
         //Variables.Add(new Variable("bim", @"c:\temp\test\Project\wip\_BIM"));
         //Variables.Add(new Variable("bim", @"${wip}\_BIM"));
         //Variables.Add(new Variable("civil", @"c:\temp\test\Project\wip\_Civil3D"));
         //Variables.Add(new Variable("civil", @"${wip}\_Civil3D"));
      }

      public void LogInfo()
      {
         Program.Log.Info("Настройки:");
         var typeSett = this.GetType();
         var props = typeSett.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
         props.Sort((p1, p2)=> p1.Name.CompareTo(p2.Name));
         foreach (var prop in props)
         {
            var value = prop.GetValue(this);
            if (value is List<Variable>)
            {
               var valString = string.Join("; ",((List<Variable>)value));
               value = valString;
            }
            Program.Log.Info("{0}: {1}", prop.Name, value);
         }
      }
   }
}
