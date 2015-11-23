using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace ProjectsStructure.Model
{
   public class ExcelStructureColumns
   {
      private int _levelFirst;
      private int _levelLast;
      private int _structure;
      private int _template;
      private int _link;

      public int LevelFirst { get { return _levelFirst; } }
      public int LevelLast { get { return _levelLast; } }
      public int Structure { get { return _structure; } }
      public int Template { get { return _template; } }
      public int Link { get { return _link; } }

      public ExcelStructureColumns(ExcelWorksheet ws, StructureService structService)
      {         
         // определение первого и последнего столбца уровня
         defLevelColumns(ws, structService);         
         // определение остальных столбццов
         defOtherColumns(ws, structService);                  
      }     

      private void defLevelColumns(ExcelWorksheet ws, StructureService structService)
      {
         // определение первого и последнего столбца уровня
         string colName = string.Empty;
         int col = 1;
         do
         {
            colName = ws.Cells[1, col].Text;
            if (colName.StartsWith("Уровень", StringComparison.OrdinalIgnoreCase))
            {
               if (_levelFirst == 0)
               {
                  _levelFirst = col;
               }
               _levelLast = col;
            }
            else
            {
               colName = string.Empty;
            }
            col++;
         } while (!string.IsNullOrEmpty(colName));
         // Проверка определенных столбцов
         checkLevelsDefColums(ws, structService);
      }

      private void checkLevelsDefColums(ExcelWorksheet ws, StructureService structService)
      {
         // Проверка определенных столбцов уровней
         if (_levelFirst == 0 || _levelLast == 0)
         {
            string errColDef = "начальный";
            if (_levelFirst == 0 && _levelLast == 0)
            {
               errColDef += " и конечный";
            }
            else if (_levelLast == 0)
            {
               errColDef = "конечный";
            }
            string errMsg = string.Format(
                     "Не определен {0} столбец уровней на листе шаблона структуры {1} в файле {2}",
                     errColDef, ws.Name, ws.Workbook.Properties.Title);
            structService.Inspector.AddError(new Errors.Error(errMsg));
            throw new Exception(errMsg);
         }
      }

      private void defOtherColumns(ExcelWorksheet ws, StructureService structService)
      {
         string colName = string.Empty;
         int col = _levelLast++;
         do
         {
            colName = ws.Cells[1, col].Text.ToUpper();
            if (string.IsNullOrEmpty(colName) )
            {
               break;
            }
            switch (colName)
            {
               case "СТРУКТУРА":
                  _structure = col;
                  break;
               case "ШАБЛОН":
                  _template = col;
                  break;
               case "ССЫЛКА":
                  _link = col;
                  break;
               default:
                  string errMsg = string.Format("Непредвиденный столбец на листе шаблона структуры {0} в файле {1}",
                                    ws.Name, ws.Workbook.Properties.Title);
                  structService.Inspector.AddError(new Errors.Error(errMsg));
                  break;
            }
            col++;
         } while (!string.IsNullOrEmpty(colName));
         // Проверка определенных столбцов
         checkOtherDefColums(ws, structService);
      }

      private void checkOtherDefColums(ExcelWorksheet ws, StructureService structService)
      {
         // Проверка определенных остальных столбцов
         string errColDef = string.Empty;
         if (_structure == 0)
         {
            errColDef += "'Структура' ";
         }
         if (_template == 0)
         {
            errColDef += "'Шаблон' ";
         }
         if (_link == 0)
         {
            errColDef += "'Ссылка' ";
         }
         if (string.IsNullOrEmpty(errColDef))
         {
            string errMsg = string.Format(
                        "Не определены столбцы {0} на листе шаблона структуры {1} в файле {2}",
                        errColDef, ws.Name, ws.Workbook.Properties.Title);
            structService.Inspector.AddError(new Errors.Error(errMsg));
            throw new Exception(errMsg);
         }
      }
   }
}
