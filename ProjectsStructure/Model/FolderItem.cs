using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace ProjectsStructure.Model
{
   // Описание папки в структуре
   public class FolderItem
   {
      private int _level; // уровень. 0 - корень; 1 первый уровень и т.д.
      private string _name; // имя папки
      private string _template; // шаблон папки с правами доступа. Которые нужно назначить этой папке в структуре.
      private string _link; // ссылка
      private Structure _innerStructure; // вложенная структура - структура внутри этой папки
      private Structure _structure; // вложенная структура - структура внутри этой папки
      private string _innerStructureName; // имя вложенной структуры
      private FolderItem _parentFolder; // родитель
      private Dictionary<string, FolderItem> _childFolder; // дочерние папки в этой папке
      private List<FolderItem> _path; // путь - список папкок пути начиная с рут 0 - имя структуры
      private StructureService _ss;

      public Dictionary<string, FolderItem> ChildFolders
      {
         get { return _childFolder; }
         set { _childFolder = value; }
      }

      public string Name { get { return _name; } }
      public int Level { get { return _level; } }

      public FolderItem (string name, FolderItem fiParent, Structure s, StructureService ss, int row = 0)
      {
         _structure = s;
         _ss = ss;
         _name = name;
         _parentFolder = fiParent;
         _childFolder = new Dictionary<string, FolderItem>();
         if (fiParent != null)
         {
            if (fiParent.ChildFolders.ContainsKey(name))
            {
               // Ошибка - не должно быть одинаковых имен папок внутри одной папки. 
               string errMsg = string.Format(
                  "Уже есть такая папка {0} в папке {1}. Строка {2}, лист {3}, файл {4}",
                  name, fiParent.FullPath(), row, s.Name, _ss.FileExceStructure);
               _ss.Inspector.AddError(new Errors.Error(errMsg));
               throw new Exception(errMsg);
            }
            fiParent.ChildFolders.Add(name, this);
            _level = fiParent.Level + 1;
            _path = fiParent._path.ToList(); // копирование списка родителя            
         }
         else
         {
            _level = 0;
            _path = new List<FolderItem>();            
         }
         _path.Add(this);
      }

      private string FullPath()
      {
         return string.Join("\\", _path);
      }

      public override string ToString()
      {
         return _name;
      }

      public FolderItem GetFolderPathLevel(int level)
      {
         // получение папки на указанном уровне пути текущей папки
         if (level >= _path.Count)
         {
            return null;
         }
         return _path[level];
      }

      public void DefAttributes(ExcelWorksheet ws, ExcelStructureColumns structColums, int row)
      {
         // Определение атрибутов папки - вложенная структура, шаблон, ссылка
         // вложенная структура
         _innerStructureName = ws.Cells[row, structColums.Structure].Text;         
         // шаблон (прав доступа)
         _template = ws.Cells[row, structColums.Template].Text;
         // ссылка
         _link = ws.Cells[row, structColums.Link].Text;
         // проверка атрибутов
         checkAttributes(ws, row);
      }

      private void checkAttributes(ExcelWorksheet ws, int row)
      {
         bool hasErr = false;
         // если определена ссылка, то не должно быть вложенной структуры и шаблона
         if (!string.IsNullOrEmpty(_link))
         {
            if (!string.IsNullOrEmpty(_innerStructureName) || 
               !string.IsNullOrEmpty(_template))
            {
               string errMsg = string.Format(
                           "Для папки {0} неверно заданы атрибуты (структура/шаблон/ссылка) - если определена ссылка, то остальных атрибутов не должно быть. Строка {1}, лист {2}, файл {3}",
                           _name, row, ws.Name, _ss.FileExceStructure);
               _ss.Inspector.AddError(new Errors.Error(errMsg));
               hasErr = true;
            }
            // путь ссылки должен существовать
            if (!Directory.Exists(_link))
            {
               string errMsg = string.Format(
                  "Для папки {0} неверно задан атрибут ссылки {1} - путь не существует. Строка {2}, лист {3}, файл {4}",
                  _name, _link, row, ws.Name, _ss.FileExceStructure);
               _ss.Inspector.AddError(new Errors.Error(errMsg));
               hasErr = true;
            }
         }

         // имя вложенной структуры должно быть из списка структур
         if (!string.IsNullOrEmpty(_innerStructureName) &&
            !_ss.Structures.Exists(s => string.Equals(s.Name, _innerStructureName, StringComparison.OrdinalIgnoreCase)))
         {
            string errMsg = string.Format(
                "Для папки {0} неверно задан атрибут структуры {1} - такого имени листа структуры не существует. Строка {2}, лист {3}, файл {4}",
                _name, _innerStructureName, row, ws.Name, _ss.FileExceStructure);
            _ss.Inspector.AddError(new Errors.Error(errMsg));
            hasErr = true;
         }

         // проверка шаблона
         if (!string.IsNullOrEmpty(_template) &&
            !Directory.Exists(_template))
         {
            string errMsg = string.Format(
                  "Для папки {0} неверно задан атрибут шаблона {1} - путь не существует. Строка {2}, лист {3}, файл {4}",
                  _name, _template, row, ws.Name, _ss.FileExceStructure);
            _ss.Inspector.AddError(new Errors.Error(errMsg));
            hasErr = true;
         }

         if (hasErr)
         {
            throw new Exception(string.Format(
               "Ошибка при определении атрибутов папки {0}. Строка {2}, лист {3}, файл {4}",
               _name, _innerStructureName, row, ws.Name, _ss.FileExceStructure));
         }
      }      
   }
}
