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

      public void CreateProjectsFromFile()
      {
         // считывание создаваемых проектов из файла         
         var lines = File.ReadAllLines(Settings.Instance.ProjectListFileToCreate, Encoding.Default);
         foreach (var line in lines)
         {
            if (!line.StartsWith("#"))
            {
               // Создание проекта в Share          
               TryCreateProject(line.Trim(), STC.StructureShare, Tokens["share"]);
               // Создание проекта в WIP
               TryCreateProject(line.Trim(), STC.StructureWip, Tokens["wip"]);               
            }
         }
         IfHasError("Есть ошибки при создании проектов.");         
      }

      private void TryCreateProject(string projectName, StructureTemplate structure, string dir)
      {
         try
         {
            structure.Create(new DirectoryInfo(dir), projectName, null);
         }
         catch (Exception ex)
         {
            Inspector.AddError(new Error(ex));
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
