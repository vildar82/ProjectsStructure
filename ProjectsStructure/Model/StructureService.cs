using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using ProjectsStructure.Model.Errors;
using ProjectsStructure.Model.Structures;
using ProjectsStructure.Properties;

namespace ProjectsStructure.Model
{
   public class StructureService
   {
      public List<StructureTemplate> StructureTemplates { get; private set; }
      public Inspector Inspector { get; private set; }                  

      /// <summary>
      /// Считывание файла конфигурации
      /// Считывание существующих проектов в Share и WIP
      /// </summary>
      public void Initialize()
      {
         Inspector = new Inspector();
         StructureTemplates = new List<StructureTemplate>();
         // проверка настроек
      }

      // считывание шаблонов структур из файла Excel
      private void ReadStructuresFromExcel()
      {
         if (!File.Exists(Settings.Default.StructureExcelFile))
         {
            MessageBox.Show(string.Format("Не найден файл шаблонов структур - {0}", Settings.Default.StructureExcelFile));
            Log.Error("Не найден файл шаблонов структур - {0}", Settings.Default.StructureExcelFile);
            return;
         }                  

         // Открытие файла Excel
         using (ExcelPackage excelStructure = new ExcelPackage())
         {
            using (var stream = File.OpenRead(Settings.Default.StructureExcelFile))
            {
               excelStructure.Load(stream);
            }
            var wbStructure = excelStructure.Workbook;
            foreach (var ws in wbStructure.Worksheets)
            {
               if (ws.Name.StartsWith("{"))
               {
                  var structure = new StructureTemplate(ws, this);
                  StructureTemplates.Add(structure);
               }
            }
            List<StructureTemplate> errorStructures = new List<StructureTemplate>();
            foreach (var structure in StructureTemplates)
            {            
               try
               {
                  structure.ReadSheet();                  
               }
               catch (Exception ex)
               {
                  Log.Error(ex, "Ошибка чтения лтиста шаблона структуры {0} из файла {1}", structure.Name, Settings.Default.StructureExcelFile);
                  errorStructures.Add(structure);
               }
            }
            errorStructures.ForEach(s => StructureTemplates.Remove(s));
            // проверка структур, подстановка вложенных структур
            foreach (var structure in StructureTemplates)
            {
               ((FolderItemTemplate)structure.Root).CheckInnerStructure();
            }
         }

         if (Inspector.HasError)
         {
            Inspector.Show();
            Inspector.Clear();
         }         
      }
   }
}
