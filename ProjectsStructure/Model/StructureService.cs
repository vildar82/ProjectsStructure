using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using ProjectsStructure.Model.Errors;

namespace ProjectsStructure.Model
{
   public class StructureService
   {      
      private List<Structure> _structures;
      private Inspector _inspector;
      private string _fileExceStructure;  

      public List<Structure> Structures { get { return _structures; } }
      public Inspector Inspector { get { return _inspector; } }
      public string FileExceStructure { get { return _fileExceStructure; } }

      // считывание шаблонов структур из файла Excel
      public void ReadStructuresFromExcel(string fileExcelStructure)
      {
         if (!File.Exists(fileExcelStructure))
         {
            MessageBox.Show(string.Format("Не найден файл шаблонов структур - {0}", fileExcelStructure));
            Log.Error("Не найден файл шаблонов структур - {0}", fileExcelStructure);
            return;
         }
         _fileExceStructure = fileExcelStructure;
         _structures = new List<Structure>();
         _inspector = new Inspector();

         // Открытие файла Excel
         using (ExcelPackage excelStructure = new ExcelPackage())
         {
            using (var stream = File.OpenRead(fileExcelStructure))
            {
               excelStructure.Load(stream);
            }
            var wbStructure = excelStructure.Workbook;
            foreach (var ws in wbStructure.Worksheets)
            {
               if (ws.Name.StartsWith("{"))
               {
                  Structure structure = new Structure(ws, this);
                  _structures.Add(structure);
               }
            }
            List<Structure> errorStructures = new List<Structure>();
            foreach (var structure in _structures)
            {            
               try
               {
                  structure.ReadSheet();                  
               }
               catch (Exception ex)
               {
                  Log.Error(ex, "Ошибка чтения лтиста шаблона структуры {0} из файла {1}", structure.Name, fileExcelStructure);
                  errorStructures.Add(structure);
               }
            }
            errorStructures.ForEach(s => _structures.Remove(s));
            // проверка структур, подстановка вложенных структур
            foreach (var structure in _structures)
            {
               structure.Root.CheckInnerStructure();
            }
         }

         if (_inspector.HasError)
         {
            _inspector.Show();
            _inspector.Clear();
         }         
      }
   }
}
