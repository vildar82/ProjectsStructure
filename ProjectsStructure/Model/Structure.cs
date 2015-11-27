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
      private FolderItem _root; // корень - папка с именем структуры - эта папка не создается, только вложенные            
      private string _name; // Имя структуры = имя листа в файле Excel шаблонов структур
      private StructureService _ss;
      private ExcelWorksheet _ws;
      private ExcelStructureColumns _colums;

      public string Name { get { return _name; } }

      public FolderItem Root { get { return _root; } }

      public Structure(ExcelWorksheet ws, StructureService ss)
      {
         _ws = ws;
         _name = ws.Name;
         _ss = ss;
      }

      public override string ToString()
      {
         return _name;
      }

      public void ReadSheet()
      {
         _root = new FolderItem(_ws.Name, null, this, _ss); // корень структуры         
         // считывание заголовков столбцов - уровни/Структура/Шаблон/Ссылка
         _colums = new ExcelStructureColumns(_ws, _ss);

         int row = 2; // начальная строчка (1 - шапка)         
         // определение папки                  
         FolderItem fiParent = _root;
         do
         {            
            // папка в строке
            var fi = getFolderItem(row, fiParent);
            if (fi == null)
            {
               // конец структуры
               if (_root.ChildFolders.Count == 0)
               {
                  string errMsg = string.Format(
                     "Структура {0} - пустая. Лист {1}, файл {2}",
                     _name, _ws.Name, _ss.FileExceStructure);
                  _ss.Inspector.AddError(new Error(errMsg));
                  throw new Exception(errMsg);
               }
               break;
            }
            // определение вложенной Структуры/ Шаблона / Ссылки
            fi.DefAttributes(_ws, _colums, row);
            fiParent = fi;
            row++;
         } while (fiParent != null);         
      }

      private FolderItem getFolderItem(int row, FolderItem fiParent)
      {         
         FolderItem fiRes = null;
         string valLast = string.Empty;
         FolderItem fiLast = null;
         for (int iCol = _colums.LevelFirst; iCol <= _colums.LevelLast; iCol++)
         {
            string valFolder = _ws.Cells[row, iCol].Text;
            if (!string.IsNullOrEmpty(valFolder) )
            {
               valLast = valFolder;               
               // проверка есть ли такая папка в родительской на данном уровне или нет, тогда создание нового пути.               
               var fiCur = getFolderOnLevel(iCol, valFolder, fiParent);
               if (fiCur == null)
               {
                  if (fiLast == null)
                  {
                     fiLast = _root;
                  }
                  if (fiRes == null)
                  {
                     fiRes = new FolderItem(valFolder, fiLast, this, _ss, row);
                  }
                  else
                  {
                     // ошибка в строке определено больше одного пути.
                     string errMsg = string.Format(
                        "В строке {0} определено две папки - {1} и {2}. Лист {3}, файл {4}",
                        row, fiRes.Name, valFolder, _ws.Name, _ss.FileExceStructure);
                     _ss.Inspector.AddError(new Error(errMsg));
                     throw new Exception(errMsg);
                  }
               }
               else
               {
                  fiLast = fiCur;                  
               }
            }
            else
            {
               // пропус допускается, если еще не был определен новый путь в этой строке
               if (fiRes ==null)
               {
                  // берем папку на этом уровне из предыдущей строки
                  fiLast = getFolderOnLevel(iCol, string.Empty, fiParent);
                  //fiParent = fiLast;
                  //if (fiCur == null)
                  //{
                  //   // ошибка - не определена папка
                  //   string errMsg = string.Format(
                  //      "В строке {0} не определена папка в столбце {1} из предыдущей строки. Лист {2}, файл {3}",
                  //      row, iCol, _ws.Name, _ss.FileExceStructure);
                  //   _ss.Inspector.AddError(new Error(errMsg));
                  //   throw new Exception(errMsg);
                  //}
               }
            }            
         }
         if (fiRes==null && !string.IsNullOrEmpty(valLast))
         {
            string errMsg = string.Format("Не определена новая папка структуры в строке {0} - лист {1}, файл {2}",
                                       row, _ws.Name, _ss.FileExceStructure);
            _ss.Inspector.AddError(new Error(errMsg));
            throw new Exception(errMsg);
         }
         return fiRes;
      }      

      private FolderItem getFolderOnLevel(int iCol, string valFolder, FolderItem fiParent)
      {
         // проверка наличия папки на уровне
         FolderItem res = null;
         // поиск уровня         
         var fiVal = fiParent.GetFolderPathLevel(iCol);
         if (fiVal!= null)
         {
            if (string.IsNullOrEmpty(valFolder))
            {
               res = fiVal;
            }
            else
            {
               if (string.Equals(valFolder, fiVal.Name, StringComparison.OrdinalIgnoreCase))
               {
                  res = fiVal;
               }
            }            
         }         
         return res;
      }
   }
}
