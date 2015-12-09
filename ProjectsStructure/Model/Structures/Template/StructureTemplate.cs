using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using ProjectsStructure.Model.Errors;

namespace ProjectsStructure.Model.Structures
{
   public class StructureTemplate : Structure
   {        
      private ExcelWorksheet ws;
      private ExcelStructureColumns colums;     

      public StructureTemplate(ExcelWorksheet sheet, Service service) :
         base (sheet.Name, service)
      {         
         ws = sheet;         
      }

      public override string ToString()
      {
         return Name;
      }

      public void ReadSheet()
      {         
         Root = new FolderItemTemplate(ws.Name, null, this); // корень структуры         
         // считывание заголовков столбцов - уровни/Структура/Шаблон/Ссылка
         colums = new ExcelStructureColumns(ws, Service);         

         int row = 2; // начальная строчка (1 - шапка)         
         // определение папки                  
         FolderItemTemplate fiParent = (FolderItemTemplate)Root;
         do
         {
            // папка в строке
            var fi = getFolderItem(row, fiParent);
            if (fi == null)
            {
               // конец структуры
               if (Root.ChildFolders.Count == 0)
               {
                  string errMsg = string.Format(
                     "Структура {0} - пустая. Лист {1}, файл {2}",
                     Name, ws.Name, Service.STC.ExcelFileTemplates);
                  Service.Inspector.AddError(new Error(errMsg));
                  throw new Exception(errMsg);
               }
               break;
            }
            // определение вложенной Структуры/ Шаблона / Ссылки
            fi.DefAttributes(ws, colums);
            fiParent = fi;
            row++;
         } while (fiParent != null);

         //TODO: Проверка вложенных структур - проверка дублирования имен в папках после раскрытия вложенных структур.

         // Проверка ссылок. В ссылках не должно быть вложенных папок.
         Root.CheckFolderInLinks();
      }

      private FolderItemTemplate getFolderItem(int row, FolderItemTemplate fiParent)
      {
         FolderItemTemplate fiRes = null;
         string valLast = string.Empty;
         FolderItemTemplate fiLast = null;
         for (int iCol = colums.LevelFirst; iCol <= colums.LevelLast; iCol++)
         {
            string valFolder = ws.Cells[row, iCol].Text;
            if (!string.IsNullOrEmpty(valFolder))
            {
               valLast = valFolder;
               // проверка есть ли такая папка в родительской на данном уровне или нет, тогда создание нового пути.               
               FolderItemTemplate fiCur = getFolderOnLevel(iCol, valFolder, fiParent);
               if (fiCur == null)
               {
                  if (fiLast == null)
                  {
                     fiLast = (FolderItemTemplate)Root;
                  }
                  if (fiRes == null)
                  {
                     fiRes = new FolderItemTemplate(valFolder, fiLast, this, row);
                  }
                  else
                  {
                     // ошибка в строке определено больше одного пути.
                     string errMsg = string.Format(
                        "В строке {0} определено две папки - {1} и {2}. Лист {3}, файл {4}",
                        row, fiRes.Name, valFolder, ws.Name, Service.STC.ExcelFileTemplates);
                     Service.Inspector.AddError(new Error(errMsg));
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
               if (fiRes == null)
               {
                  // берем папку на этом уровне из предыдущей строки
                  fiLast = getFolderOnLevel(iCol, string.Empty, fiParent);                  
               }
            }
         }
         if (fiRes == null && !string.IsNullOrEmpty(valLast))
         {
            string errMsg = string.Format("Не определена новая папка структуры в строке {0} - лист {1}, файл {2}",
                                       row, ws.Name, Service.STC.ExcelFileTemplates);
            Service.Inspector.AddError(new Error(errMsg));
            throw new Exception(errMsg);
         }
         return fiRes;
      }

      public void CheckInnerStructure()
      {
         ((FolderItemTemplate)Root).CheckInnerStructure();
      }

      private FolderItemTemplate getFolderOnLevel(int iCol, string valFolder, FolderItemTemplate fiParent)
      {
         // проверка наличия папки на уровне
         FolderItemTemplate res = null;
         // поиск уровня         
         FolderItemTemplate fiVal = (FolderItemTemplate)fiParent.GetFolderPathLevel(iCol);
         if (fiVal != null)
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

      /// <summary>
      /// Создание структуры в папке
      /// </summary>
      /// <param name="dirLocation"></param>
      public void Create(DirectoryInfo dirLocation, string project, List<string>objects)
      {
         // Задать переменные для project и создать корневую папку проекта.
         if (project != null)
         {
            Service.Tokens["project"] = project;
            dirLocation = dirLocation.CreateSubdirectory(project);
         }         
         try
         {            
            ((FolderItemTemplate)Root).Create(dirLocation, objects);
         }
         catch (Exception ex)
         {
            Service.Inspector.AddError(new Error(ex.ToString()));
         }         
      }
   }
}
