using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using ProjectsStructure.Model.Config;
using ProjectsStructure.Model.Errors;

namespace ProjectsStructure.Model.Structures.Objects
{
   public class ObjectInfoService
   {
      private Service _service;
      private string _fileProjectTepmlate;
      private DirectoryInfo _projectDir;

      public ExcelColumnsObjects Columns { get; private set; }
      public List<ObjectInfo> Objects { get; private set; }

      public ObjectInfoService(Service service, DirectoryInfo projectDir, string fileProjectTepmlate)
      {
         _service = service;
         _fileProjectTepmlate = fileProjectTepmlate;
         _projectDir = projectDir;
      }

      public void GetObjects()
      {
         Objects = new List<ObjectInfo>();
         // TODO: Считывание списка объектов из файла шаблона проекта
         // файл шаблона проекта
         var fileProjTemplate = getFileProjectTemplate(_fileProjectTepmlate);

         // считывание объектов в ексель файле
         using (ExcelPackage excelProjTempl = new ExcelPackage())
         {
            try
            {
               using (var stream = File.OpenRead(fileProjTemplate.FullName))
               {
                  excelProjTempl.Load(stream);
               }
            }
            catch (Exception ex)
            {
               string errMsg = string.Format("Не удалось прочитать файл Excel {0} - {1}", Settings.Instance.TemplatesExcelFile, ex);
               _service.Inspector.AddError(new Error(errMsg));
               throw;
            }
            var wbStructure = excelProjTempl.Workbook;
            // Лист Структура - со списком объектов
            var ws = wbStructure.Worksheets["Структура"];

            // определение столбцов
            Columns = new ExcelColumnsObjects(ws, _service);
            Columns.Parse();

            // считывание строк объектов
            int row = Columns.RowObjectsTypePart + 1; // первая строка первого объекта
            bool proceed = true;
            do
            {
               var valueTypePart = ws.Cells[Columns.ColumnObjectsTypePart, row].Text;
               proceed = !string.IsNullOrEmpty(valueTypePart);
               if (string.Equals(valueTypePart, "Объект", StringComparison.CurrentCultureIgnoreCase))
               {
                  var objectName = ws.Cells[Columns.ColumnObjectsTypePart, row].Text;
                  ObjectInfo objectInfo = new ObjectInfo(objectName, ws, row, Columns, _service);
                  objectInfo.ParseModifiers();
                  Objects.Add(objectInfo);
               }
            } while (proceed);                 
         }
      }

      private FileInfo getFileProjectTemplate(string fileProjectTepmlate)
      {
         FileInfo projTempl = new FileInfo(fileProjectTepmlate);
         if (!projTempl.Exists)
         {
            throw new Exception(string.Format("Файл шаблона проекта не найден {0}",
                           fileProjectTepmlate));
         }
         return projTempl;
         //// Определение расположения файла проекта
         //var files = projectDir.EnumerateFiles("*.*", SearchOption.TopDirectoryOnly).
         //         Where (s=> s.Name.EndsWith(".xlsx") || s.Name.EndsWith(".xlsm") || s.Name.EndsWith(".xls"));
         //foreach (var fileExcel in files)
         //{
         //   if (fileExcel.Name.IndexOf(projectDir.Name)!=-1)
         //   {
         //      // Первый попавшийся файл ексель с именем проекта в имени считаем шаблоном проекта.
         //   }
         //}         
      }
   }
}
