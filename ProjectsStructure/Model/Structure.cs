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
   // Структура папок
   public class Structure
   {      
      private FolderItem _structure;
      private string _name; // Имя структуры = имя листа в файле Excel шаблонов структур

      public Structure(string name)
      {
         _name = name;
      }

      public void ReadSheet(ExcelWorksheet ws, StructureService structService)
      {
         _structure = new FolderItem(ws.Name, null); // корень структуры
         // считывание заголовков столбцов - уровни/Структура/Шаблон/Ссылка
         var structColums = new ExcelStructureColumns(ws, structService);

         int row = 2; // начальная строчка (1 - шапка)         
         // определение папки
         var fi = getFolderItem(ws, structColums, row);
      }

      private static FolderItem getFolderItem(ExcelWorksheet ws, ExcelStructureColumns structColums, int row)
      {
         FolderItem fi = null;
         for (int iCol = structColums.LevelFirst; iCol <= structColums.LevelLast; iCol++)
         {
            string valFolder = ws.Cells[row, iCol].Text;// имя папки
         }
         return fi;
      }
   }
}
