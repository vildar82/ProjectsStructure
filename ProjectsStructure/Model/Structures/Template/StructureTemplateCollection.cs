using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using ProjectsStructure.Model.Config;
using ProjectsStructure.Model.Errors;

namespace ProjectsStructure.Model.Structures.Template
{
   public class StructureTemplateCollection
   {
      public StructureService SS { get; private set; }
      public List<Structure> StructureTemplates { get; private set; }
      public string ExcelFileTemplates { get; private set; }
      public List<TemplateAccess> TemplatesAccess { get; private set; }

      public StructureTemplateCollection(StructureService ss)
      {
         SS = ss;
         StructureTemplates = new List<Structure>();
         ExcelFileTemplates = Settings.Instance.TemplatesExcelFile;
      }

      // считывание шаблонов структур из файла Excel
      public void ReadStructuresFromExcel()
      {
         // считывание шаблонов прав для папок
         TemplatesAccess = TemplateAccess.GetTemplatesAccess(SS);

         if (!File.Exists(ExcelFileTemplates))
         {
            string errMsg = string.Format("Не найден файл шаблонов структур - {0}", ExcelFileTemplates);
            SS.Inspector.AddError(new Error(errMsg));
            return;
         }

         // Открытие файла Excel
         using (ExcelPackage excelStructure = new ExcelPackage())
         {
            try
            {
               using (var stream = File.OpenRead(Settings.Instance.TemplatesExcelFile))
               {
                  excelStructure.Load(stream);
               }
            }
            catch (Exception ex)
            {
               string errMsg = string.Format("Не удалось прочитать файл Excel {0} - {1}", Settings.Instance.TemplatesExcelFile, ex);
               SS.Inspector.AddError(new Error(errMsg));
               return;
            }
            var wbStructure = excelStructure.Workbook;
            foreach (var ws in wbStructure.Worksheets)
            {
               if (ws.Name.StartsWith("{"))
               {
                  var structure = new StructureTemplate(ws, SS);
                  StructureTemplates.Add(structure);
               }
            }
            List<Structure> errorStructures = new List<Structure>();
            foreach (var structure in StructureTemplates)
            {
               try
               {
                  ((StructureTemplate)structure).ReadSheet();
               }
               catch (Exception ex)
               {
                  Log.Error(ex, "Ошибка чтения лтиста шаблона структуры {0} из файла {1}", structure.Name, Settings.Instance.TemplatesExcelFile);
                  errorStructures.Add(structure);
               }
            }
            errorStructures.ForEach(s => StructureTemplates.Remove(s));

            //TODO: Проверка вложенных структур - проверка дублирования имен в папках после раскрытия вложенных структур.
         }
      }      
   }
}
