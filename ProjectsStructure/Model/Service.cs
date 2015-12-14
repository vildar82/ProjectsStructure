using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using ProjectsStructure.Model.Config;
using ProjectsStructure.Model.Errors;
using ProjectsStructure.Model.Structures;
using ProjectsStructure.Model.Structures.Live;
using ProjectsStructure.Model.Structures.Objects;
using ProjectsStructure.Model.Structures.Template;

namespace ProjectsStructure.Model
{
   public class Service
   {      
      public string AreaShare { get; private set; } // Область проектов в Share - полный путь
      public string AreaWip { get; private set; }
      //public string AreaBim { get; private set; }
      //public string AreaCivil { get; private set; }
      public ProjectsCollection Projects { get; private set; }
      public StructureTemplateCollection STC { get; private set; }
      public Inspector Inspector { get; private set; }
      public Dictionary<string, string> Tokens { get; set; }

      public Service()
      {
         // Ошибки
         Inspector = new Inspector();
         // проверка настроек
         CheckSettings();
      }

      /// <summary>
      /// Считывание файла конфигурации
      /// Считывание существующих проектов в Share и WIP
      /// </summary>
      public void ReadTemplates()
      {
         Program.Log.Info("Считывание шаблонов структур из файла {0}", Settings.Instance.TemplatesExcelFile);
         // считывание шаблонов структур
         STC = new StructureTemplateCollection(this);
         try
         {
            STC.ReadStructuresFromExcel();
         }
         catch (Exception ex)
         {
            Inspector.AddError(new Error(ex));
         }              

         IfHasError("Найдены ошибки при считывании структур.");         
      }

      public void CreateProjects()
      {
         Inspector.Clear();
         // считывание создаваемых проектов из файла         
         var lines = File.ReadAllLines(Settings.Instance.ProjectListFileToCreate, Encoding.Default);
         foreach (var line in lines)
         {
            if (!line.StartsWith("#"))
            {
               var projName = line.Trim();

               // Создание проекта в WIP
               TryCreateProject(projName, STC.StructureWip, Tokens["wip"]);

               // Создание проекта в Share                 
               var dirProjShare = TryCreateProject(projName, STC.StructureShare, Tokens["share"]);

               // Создание файла Excel шаблона проекта.
               Project projShare = new Project(dirProjShare, this);
               projShare.CreateFileProjectTemplate();
            }
         }
         IfHasError("Есть ошибки при создании проектов.");         
      }

      public void CreateObjects(string projectName, string fileProjectTepmlate)
      {
         // Создание объектов для проекта         
         // Список объектов считывается из файла шаблона проекта в корне папки проекта.

         // Папка проекта
         var dirProjShare = new DirectoryInfo(Path.Combine(Tokens["share"], projectName));

         // Получение списка объектов у проекта
         ObjectInfoService objectService = new ObjectInfoService(this, dirProjShare, fileProjectTepmlate);
         objectService.GetObjects();        
         
         // создание объектов в проекте в WIP
         Project projWip = new Project(dirProjShare, this);
         projWip.StructureTemplate = STC.StructureWip;
         projWip.CreateObjects(objectService.Objects);

         // создание объектов в проекте в Share
         Project projShare = new Project(dirProjShare, this);
         projShare.StructureTemplate = STC.StructureShare;
         projShare.CreateObjects(objectService.Objects);
      }

      private DirectoryInfo TryCreateProject(string projectName, StructureTemplate structure, string dir)
      {         
         try
         {
            Program.Log.Info("Создание проекта {0} по шаблону структуры {1} в {2}:", projectName, structure.Name, dir);
            return structure.Create(new DirectoryInfo(dir), projectName, null);            
         }
         catch (Exception ex)
         {
            Inspector.AddError(new Error(ex));
            return null;
         }         
      }

      /// <summary>
      /// Считывание проектов в Share и Wip. Результат см в Projects
      /// </summary>
      public void ReadProjects()
      {
         //считывание проектов
         Projects = new ProjectsCollection(this);
         Projects.ReadProjects();

         IfHasError("Найдены ошибки при считывании проектов.");
      }

      public void IfHasError(string caption)
      {
         if (Inspector.HasError)
         {
            Inspector.Show();
            Inspector.Clear();
            throw new Exception(caption);
         }
      }

      public void CheckSettings()
      {
         // Лог настроек
         Settings.Instance.LogInfo();                

         // Проверка переменных
         CheckVariables();        
      }

      private void CheckVariables()
      {
         // Проверка переменных
         Expansive.DefaultTokenStyle = TokenStyle.NAnt; // Стиль переменных "${token}"
         Tokens = new Dictionary<string, string>();
         if (Settings.Instance.Variables.Count > 0)
         {
            foreach (var varItem in Settings.Instance.Variables)
            {
               try
               {
                  Tokens.Add(varItem.Key, varItem.Value);
               }
               catch (Exception ex)
               {
                  Inspector.AddError(new Error(string.Format("Повторное определение переменной в файле настроек. Переменная {0}. Ошибка - {1}",
                                                varItem.Key, ex)));
               }
            }
         }
         // Добавление переменных project и object
         if (!Tokens.ContainsKey("project"))
         {
            Tokens.Add("project", "");
         }
         if (!Tokens.ContainsKey("object"))
         {
            Tokens.Add("object", "");
         }
         Expansive.DefaultExpansionFactory = name => Tokens[name];

         // Должны быть определены области проектов share, wip, bim, civil
         CheckProjectAreas(Tokens);
      }

      private void CheckProjectAreas(Dictionary<string, string> tokens)
      {
         AreaShare = CheckArea("share", tokens);
         AreaWip = CheckArea("wip", tokens);
         //AreaBim = CheckArea("bim", tokens);
         //AreaCivil = CheckArea("civil", tokens);
      }

      private string CheckArea(string area, Dictionary<string, string> tokens)
      {
         string valArea;
         if (tokens.TryGetValue(area, out valArea))
         {
            valArea = valArea.Expand();
            if (!Directory.Exists(valArea))
            {
               // Ошибка - не найден каталог проектов в области
               Inspector.AddError(new Error(string.Format("Не найдена папка области {0}", area)));
            }
         }
         else
         {
            // Ошибка - не определена переменная области
            Inspector.AddError(new Error(string.Format("Не определена переменная {0}", area)));
         }
         return valArea;
      }
   }
}
