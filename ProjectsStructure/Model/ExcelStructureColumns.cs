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

      private ExcelWorksheet _ws;
      private StructureService _ss;

      public int LevelFirst { get { return _levelFirst; } }
      public int LevelLast { get { return _levelLast; } }
      public int Structure { get { return _structure; } }
      public int Template { get { return _template; } }
      public int Link { get { return _link; } }

      public ExcelStructureColumns(ExcelWorksheet ws, StructureService ss)
      {
         _ws = ws;
         _ss = ss;
         // определение первого и последнего столбца уровня
         defLevelColumns();         
         // определение остальных столбццов
         defOtherColumns();                  
      }     

      private void defLevelColumns()
      {
         // определение первого и последнего столбца уровня
         string colName = string.Empty;
         int col = 1;
         do
         {
            colName = _ws.Cells[1, col].Text;
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
         checkLevelsDefColums();
      }

      private void checkLevelsDefColums()
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
                     errColDef, _ws.Name, _ss.FileExceStructure);
            _ss.Inspector.AddError(new Errors.Error(errMsg));
            throw new Exception(errMsg);
         }
      }

      private void defOtherColumns()
      {
         string colName = string.Empty;
         int col = _levelLast+1;
         do
         {
            colName = _ws.Cells[1, col].Text.ToUpper();
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
                                    _ws.Name, _ss.FileExceStructure);
                  _ss.Inspector.AddError(new Errors.Error(errMsg));
                  break;
            }
            col++;
         } while (!string.IsNullOrEmpty(colName));
         // Проверка определенных столбцов
         checkOtherDefColums();
      }

      private void checkOtherDefColums()
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
         if (!string.IsNullOrEmpty(errColDef))
         {
            string errMsg = string.Format(
                        "Не определены столбцы {0} на листе шаблона структуры {1} в файле {2}",
                        errColDef, _ws.Name, _ss.FileExceStructure);
            _ss.Inspector.AddError(new Errors.Error(errMsg));
            throw new Exception(errMsg);
         }
      }
   }
}
