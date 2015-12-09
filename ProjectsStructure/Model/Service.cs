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
using ProjectsStructure.Properties;

namespace ProjectsStructure.Model
{
   public class Service
   {      
      public string AreaShare { get; private set; } // Область проектов в Share - полный путь
      public string AreaWip { get; private set; }
      public string AreaBim { get; private set; }
      public string AreaCivil { get; private set; }
      public ProjectsCollection Projects { get; private set; }
      public StructureTemplateCollection STC { get; private set; }
      public Inspector Inspector { get; private set; }
      public Dictionary<string, string> Tokens { get; set; }

      /// <summary>
      /// Считывание файла конфигурации
      /// Считывание существующих проектов в Share и WIP
      /// </summary>
      public void ReadTemplates()
      {
         // Ошибки
         Inspector = new Inspector();

         // проверка настроек
         CheckSettings();        

         // считывание шаблонов структур
         STC = new StructureTemplateCollection(this);         
         STC.ReadStructuresFromExcel();
         
         if (Inspector.HasError)
         {
            Inspector.Show();
            Inspector.Clear();
         }
      }

      public void ReadProjects()
      {
         //считывание проектов
         Projects = new ProjectsCollection(this);
         Projects.ReadProjects();

         if (Inspector.HasError)
         {
            Inspector.Show();
            Inspector.Clear();
         }
      }

      public void CheckSettings()
      {
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
         AreaBim = CheckArea("bim", tokens);
         AreaCivil = CheckArea("civil", tokens);
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
            // Ошибка - не определена переменная share
            Inspector.AddError(new Error(string.Format("Не определена переменная {0}", area)));
         }
         return valArea;
      }
   }
}
