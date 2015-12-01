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
   public class StructureService
   {
      public ProjectsCollection Projects { get; private set; }
      public StructureTemplateCollection STC { get; private set; }
      public Inspector Inspector { get; private set; }                        

      /// <summary>
      /// Считывание файла конфигурации
      /// Считывание существующих проектов в Share и WIP
      /// </summary>
      public void Initialize()
      {
         // Ошибки
         Inspector = new Inspector();
         // проверка настроек
         CheckSettings();
         // считывание шаблонов структур
         STC = new StructureTemplateCollection(this);         
         STC.ReadStructuresFromExcel();

         //считывание проектов в Share
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
         Expansive.DefaultTokenStyle = TokenStyle.NAnt; // "${token}"
         Dictionary<string, string> tokens = new Dictionary<string, string>();
         if (Settings.Instance.Variables.Count > 0)
         {
            foreach (var varItem in Settings.Instance.Variables)
            {
               try
               {
                  tokens.Add(varItem.Key, varItem.Value);
               }
               catch (Exception ex)
               {
                  Inspector.AddError(new Error(string.Format("Повторное определение переменной в файле настроек. Переменная {0}. Ошибка - {1}",
                                                varItem.Key, ex)));
               }
            }
         }
         Expansive.DefaultExpansionFactory = name => tokens[name];
      }
   }
}
