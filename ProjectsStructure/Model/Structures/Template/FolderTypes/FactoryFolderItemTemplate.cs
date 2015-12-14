using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using ProjectsStructure.Model.Errors;

namespace ProjectsStructure.Model.Structures.Template.FolderTypes
{
   public class FactoryFolderItemTemplate
   {
      private StructureTemplate _structure;
      private Service _service;
      private ExcelWorksheet _ws;
      private ExcelStructureColumns _columns;

      public FactoryFolderItemTemplate(StructureTemplate structureTemplate)
      {
         _structure = structureTemplate;
         _service = _structure.Service;
         _ws = _structure.WS;
         _columns = _structure.Colums;
      }

      public FolderItemTemplate CreateFolderItem(int row, FolderItemTemplate fiPrevious)
      {
         // Определение имени текущей папки и ее родителя
         FolderItemTemplate fiParent;
         string curFolderName = getCurFolderName(row, fiPrevious, out fiParent);

         // в зависимости от атрибутов, создание соответствущего типа папки
         //ссылка
         string linkTarget = _ws.Cells[row, _columns.Link].Text.Trim();
         //вложенная структура
         string innerStructureName = _ws.Cells[row, _columns.Structure].Text.Trim();
         //шаблон(прав доступа)
         string templateName = _ws.Cells[row, _columns.Template].Text.Trim();

         checkAttrs(row, linkTarget, innerStructureName, templateName);

         return createByAttrs(curFolderName, fiParent, linkTarget, innerStructureName, templateName);
      }      

      private FolderItemTemplate createByAttrs(string curFolderName, FolderItemTemplate fiParent,
                                                string linkTarget, string innerStructureName, string templateName)
      {
         if (!string.IsNullOrEmpty(linkTarget))
         {
            // Создание 
         }
      }

      private string getCurFolderName(int row, FolderItemTemplate fiPrevious, out FolderItemTemplate fiParent)
      {
         fiParent = null;
         string curFolderName;
         int curCol;
         // Поиск текущей ячейки в строке - последняя строка со значением в столбцах уровней
         getCurFolder(row, out curFolderName, out curCol);
         if (string.IsNullOrEmpty(curFolderName))
         {
            return string.Empty;
         }
         // Определить родительскую папку
         fiParent = getParent(curFolderName, curCol, row, fiPrevious);
         return curFolderName;       
      }

      /// <summary>
      /// Определение родительской папки для текущей папки в строке
      /// </summary>
      /// <param name="curFolderName">Имя текущей папки в строке</param>
      /// <param name="curCol">Столбец текущей папки</param>
      /// <param name="fiPrevious">Папка определенная на предыдущей строке</param>
      /// <returns></returns>
      private FolderItemTemplate getParent(string curFolderName, int curCol, int row, FolderItemTemplate fiPrevious)
      {
         // Корневой уровень
         if (curCol == 1)
         {
            return (FolderItemTemplate)_structure.Root;
         }

         string prevFolderName = _ws.Cells[row, curCol - 1].Text;

         // проверка уровня предыдущей папки, он должен быть на один уровень меньше
         if (fiPrevious.Level == (curCol - 1))
         {
            if (string.IsNullOrEmpty(prevFolderName))
            {
               // предыдущая папка - родительская
               return fiPrevious;
            }
            else
            {
               // проверка имени предыдущей папки
               if (string.Equals(fiPrevious.Name, curFolderName, StringComparison.OrdinalIgnoreCase))
               {
                  return fiPrevious;
               }               
            }
         }
         // Ошибка - для текущей строки родительской должна быть предыдущая строка, но она не соответствует этому.
         string errMsg = string.Format("Не определена родительская папка для строки {0}. Лист {1}.", row, _ws.Name);
         _service.Inspector.AddError(new Error(errMsg));
         throw new Exception(errMsg);
      }

      /// <summary>
      /// Определение имени папки в строке (последняя значащая ячейка в столбцах уровней)
      /// </summary>
      /// <param name="row">Строка</param>
      /// <param name="curFolderName">Имя папки</param>
      /// <param name="curCol">Столбец</param>
      private void getCurFolder(int row, out string curFolderName, out int curCol)
      {
         curFolderName = string.Empty;
         curCol = 0;
         // поиск с последнего столбца уровней ячейки со значением имени папки
         for (int col = _columns.LevelLast; col <= _columns.LevelFirst; col--)
         {
            string valFolder = _ws.Cells[row, col].Text;
            if (!string.IsNullOrEmpty(valFolder))
            {
               curFolderName = valFolder.Trim();
               curCol = col;
               break;
            }
         }         
      }

      private void checkAttrs(int row, string linkTarget, string innerStructureName, string templateName, out Structure innerStructure)
      {
         bool hasErr = false;
         innerStructure = null;
         // Ссылка
         if (!string.IsNullOrEmpty(linkTarget))
         {            
            // если определена ссылка, то не должно быть вложенной структуры и шаблона
            if (!string.IsNullOrEmpty(innerStructureName) ||
               !string.IsNullOrEmpty(templateName))
            {
               string errMsg = string.Format(
                           "Неверно заданы атрибуты. Если задана ссылка, то не должна быть задана вложенная структура. Строка {1}, лист {2}.",
                           row, _ws.Name);
               _service.Inspector.AddError(new Errors.Error(errMsg));
               hasErr = true;
            }            
         }

         // Папка со вложенной структурой
         if (!string.IsNullOrEmpty(innerStructureName))
         {
            // имя вложенной структуры должно быть из списка структур
            innerStructure = _service.STC.StructureTemplates.Find(
                     s => string.Equals(s.Name, innerStructureName, StringComparison.OrdinalIgnoreCase));
            if (innerStructure == null)
            {
               string errMsg = string.Format("В строке неверно задана структура {0} - такая структура не опрделена. Строка {1}, лист {2}.",
                   innerStructureName, row, _ws.Name);
               _service.Inspector.AddError(new Errors.Error(errMsg));
               hasErr = true;
            }
         }
         // проверка шаблона
         if (!string.IsNullOrEmpty(templateName))
         {
            Type = Type.Add(EnumFolderItem.Template);
            TemplateAccess = Structure.Service.STC.TemplatesAccess.Find(t => string.Equals(t.Name, templateName, StringComparison.OrdinalIgnoreCase));
            if (TemplateAccess == null)
            {
               string errMsg = string.Format(
                   "Для папки {0} неверно задан атрибут шаблона {1} - не найден. Строка {2}, лист {3}, файл {4}",
                   Name, templateName, Row, ws.Name, Structure.Service.STC.ExcelFileTemplates);
               Structure.Service.Inspector.AddError(new Errors.Error(errMsg));
               hasErr = true;
            }
         }

         // По умолчанию папка считается простой - EnumFolderItem.Folder

         if (hasErr)
         {
            throw new Exception(string.Format(
               "Ошибка при определении атрибутов папки {0}. Строка {1}, лист {2}, файл {3}",
               Name, Row, ws.Name, Structure.Service.STC.ExcelFileTemplates));
         }
      }
   }
}
