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
      public Service Service { get; private set; }
      public List<Structure> StructureTemplates { get; private set; }
      public string ExcelFileTemplates { get; private set; }
      public List<TemplateAccess> TemplatesAccess { get; private set; }
      public StructureTemplate StructureShare { get; private set; }
      public StructureTemplate StructureWip { get; private set; }
      //public StructureTemplate StructureBim { get; private set; }
      //public StructureTemplate StructureCivil { get; private set; }

      public StructureTemplateCollection(Service service)
      {
         Service = service;
         StructureTemplates = new List<Structure>();
         ExcelFileTemplates = Settings.Instance.TemplatesExcelFile;
      }

      // считывание шаблонов структур из файла Excel
      public void ReadStructuresFromExcel()
      {
         // считывание шаблонов прав для папок
         TemplatesAccess = TemplateAccess.GetTemplatesAccess(Service);

         if (!File.Exists(ExcelFileTemplates))
         {
            string errMsg = string.Format("Не найден файл шаблонов структур - {0}", ExcelFileTemplates);
            Service.Inspector.AddError(new Error(errMsg));
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
               Service.Inspector.AddError(new Error(errMsg));
               return;
            }
            var wbStructure = excelStructure.Workbook;
            foreach (var ws in wbStructure.Worksheets)
            {
               var structure = new StructureTemplate(ws, Service);
               StructureTemplates.Add(structure);
            }
            List<Structure> errorStructures = new List<Structure>();
            foreach (var structure in StructureTemplates)
            {
               try
               {
                  ((StructureTemplate)structure).ReadSheet();
                  Program.Log.Info("Считан шаблон структуры - {0}", structure.Name);
               }
               catch (Exception ex)
               {
                  Program.Log.Error(ex, "Ошибка чтения лтиста шаблона структуры {0} из файла {1}", structure.Name, Settings.Instance.TemplatesExcelFile);
                  errorStructures.Add(structure);
               }
            }
            errorStructures.ForEach(s => StructureTemplates.Remove(s));

            // Определение структур областей - share, wip, bim, civil
            StructureShare = DefineAreaTemplates(Settings.Instance.TemplateStructureProjectShare);
            StructureWip = DefineAreaTemplates(Settings.Instance.TemplateStructureProjectWIP);
            //StructureBim = DefineAreaTemplates(Settings.Instance.TemplateStructureProjectBIM);
            //StructureCivil = DefineAreaTemplates(Settings.Instance.TemplateStructureProjectCivil);
         }
      }

      private StructureTemplate DefineAreaTemplates(string name)
      {
         StructureTemplate structure = StructureTemplates.Find(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase)) as StructureTemplate;
         if (structure == null)
         {
            // Ошибка - не определена структура проетов в Share
            Service.Inspector.AddError(new Error(string.Format("Ошибка. Не найден шаблон {0}", name)));
         }
         return structure;
      }
   }
}
