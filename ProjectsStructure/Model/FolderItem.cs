using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsStructure.Model
{
   // Описание папки в структуре
   public class FolderItem
   {      
      private string _name; // имя папки
      private string _template; // шаблон папки с правами доступа. Которые нужно назначить этой папке в структуре.
      private string _link; // ссылка
      private Structure _innerStructure; // вложенная структура - структура внутри этой папки
      private string _innerStructureName; // имя вложенной структуры
      private FolderItem _parentFolder; // родитель
      private Dictionary<string, FolderItem> _childFolder; // дочерние папки в этой папке

      public FolderItem (string name, FolderItem fiParent)
      {
         _name = name;
         _parentFolder = fiParent;
      }
   }
}
