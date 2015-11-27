﻿using System;
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
      public const string TypeNameFolder = "Папка";
      public const string TypeNameStructure = "Структура";
      public const string TypeNameTemplate = "Шаблон";
      public const string TypeNameLink = "Ссылка";
      public const string TypeNameUndefined = "Неопределено";

      private int _level; // уровень. 0 - корень; 1 первый уровень и т.д.
      private string _name; // имя папки
      private EnumFolderItem _type;
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
      public bool IsLink { get { return !string.IsNullOrEmpty(_link); } }
      public bool HasTemplate { get { return !string.IsNullOrEmpty(_template); } }
      public bool HasInnerStructure { get { return !string.IsNullOrEmpty(_innerStructureName); } }
      public string InnerStructureName { get { return _innerStructureName; } }

      public EnumFolderItem Type { get { return _type; } }

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
         _template =ws.Cells[row, structColums.Template].Text;
         // ссылка
         _link =ws.Cells[row, structColums.Link].Text;
         // проверка атрибутов
         checkAttributes(ws, row);
      }

      private void checkAttributes(ExcelWorksheet ws, int row)
      {
         bool hasErr = false;
         // если определена ссылка, то не должно быть вложенной структуры и шаблона
         if (!string.IsNullOrEmpty(_link))
         {
            _type = EnumFolderItem.Link;
            if (!string.IsNullOrEmpty(_innerStructureName) || 
               !string.IsNullOrEmpty(_template))
            {
               string errMsg = string.Format(
                           "Для папки {0} неверно заданы атрибуты (структура/шаблон/ссылка) - если определена ссылка, то остальных атрибутов не должно быть. Строка {1}, лист {2}, файл {3}",
                           _name, row, ws.Name, _ss.FileExceStructure);
               _ss.Inspector.AddError(new Errors.Error(errMsg));
               hasErr = true;
            }            
         }

         // Папка со вложенной структурой
         if (!string.IsNullOrEmpty(_innerStructureName))
         {            
            _type = EnumFolderItem.Structure;
            // имя вложенной структуры должно быть из списка структур
            if (!_ss.Structures.Exists(s => string.Equals(s.Name, _innerStructureName, StringComparison.OrdinalIgnoreCase)))
            {
               string errMsg = string.Format(
                   "Для папки {0} неверно задан атрибут структуры {1} - структуры не существует. Строка {2}, лист {3}, файл {4}",
                   _name, _innerStructureName, row, ws.Name, _ss.FileExceStructure);
               _ss.Inspector.AddError(new Errors.Error(errMsg));
               hasErr = true;
            }
         }

         // проверка шаблона
         if (!string.IsNullOrEmpty(_template))
         {
            _type = EnumFolderItem.Template;            
         }

         // По умолчанию папка считается простой - EnumFolderItem.Folder

         if (hasErr)
         {
            throw new Exception(string.Format(
               "Ошибка при определении атрибутов папки {0}. Строка {2}, лист {3}, файл {4}",
               _name, _innerStructureName, row, ws.Name, _ss.FileExceStructure));
         }
      }

      public void CheckInnerStructure()
      {
         // подстановка структур
         foreach (var fiItem  in _childFolder)
         {
            if (fiItem.Value.HasInnerStructure)
            {
               var innerStructure = _ss.Structures.Find(s => s.Name == fiItem.Value.InnerStructureName);
               if (innerStructure != null)
               {
                  fiItem.Value.setInnerStructure(innerStructure);
               }
            }
            fiItem.Value.CheckInnerStructure();
         }
      }

      private void setInnerStructure(Structure innerStructure)
      {
         //присвоение вложенной структуры
         _innerStructure = innerStructure;
         // TODO: если есть дочерние папки, проверить конфликт имен со структурой.
      }

      public string GetTypeName()
      {
         switch (_type)
         {
            case EnumFolderItem.Folder:
               return TypeNameFolder;
            case EnumFolderItem.Link:
               return TypeNameLink;
            case EnumFolderItem.Structure:
               return TypeNameStructure;
            case EnumFolderItem.Template:
               return TypeNameTemplate;
            default:
               return TypeNameUndefined;
         }
      }
   }
}