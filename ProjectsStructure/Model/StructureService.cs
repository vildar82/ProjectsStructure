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

      public List<Structure> Structures { get { return _structures; } }

      public Inspector Inspector { get { return _inspector; } }      

      public void ReadStructuresFromExcel(string fileExcelStructure)
      {
         if (!File.Exists(fileExcelStructure))
         {
            MessageBox.Show(string.Format("Не найден файл шаблонов структур - {0}", fileExcelStructure));
            Log.Error("Не найден файл шаблонов структур - {0}", fileExcelStructure);
            return;
         }
         _structures = new List<Structure>();
         _inspector = new Inspector();

         // Открытие файла Excel
         using (ExcelPackage excelStructure = new ExcelPackage(new FileInfo(fileExcelStructure)))
         {
            var wbStructure = excelStructure.Workbook;
            foreach (var ws in wbStructure.Worksheets)
            {
               Structure structure = new Structure(ws.Name);
               try
               {
                  structure.ReadSheet(ws, this);
                  _structures.Add(structure);
               }
               catch (Exception ex)
               {
                  Log.Error(ex, "Ошибка чтения лтиста шаблона структуры {0} из файла {1}", ws.Name, fileExcelStructure);                  
               }
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
