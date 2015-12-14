using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using ProjectsStructure.Model.Structures.Objects;

namespace ProjectsStructure.Model.Structures
{
   public class ObjectInfo
   {
      private ExcelColumnsObjects _columns;
      private string _objectName;
      private int _row;
      private ExcelWorksheet _ws;
      private Service _service;
      private Dictionary<string, StructureModifier> _modifiers;

      public ObjectInfo(string objectName, ExcelWorksheet ws, int row, ExcelColumnsObjects columns, Service service)
      {
         _objectName = objectName;
         _ws = ws;
         _row = row;
         _columns = columns;
         _service = service;
         _modifiers = new Dictionary<string, StructureModifier>();         
      }

      /// <summary>
      /// Имя объекта
      /// </summary>
      public string Name { get; private set; }
      /// <summary>
      /// Модификаторы структур объекта
      /// </summary>
      public List<StructureModifier> StructureModifiers { get { return _modifiers.Values.ToList(); } }

      public void ParseModifiers()
      {
         int col = _columns.ColumnStructureFirst;
         // флажок - если установлен (=1), то создавать эту папку
         var flag = _ws.Cells[_row, col].Value;
         if ((int)flag == 1)
         {
            // Имя структуры
            var structName = _ws.Cells[_columns.RowStructureFirst, col].Text;
            // Папка в структуре            
            var folderName = _ws.Cells[_columns.RowStructureFirst+1, col].Text;
            // Добавление модификатора
            addCreateFlagModifier(structName, folderName);
         }
      }

      private void addCreateFlagModifier(string structName, string folderName)
      {
         // найти модификатор структуры в списке         
         string key = structName.Trim().ToUpper();
         StructureModifier mod;
         if (!_modifiers.TryGetValue(key, out mod))
         {
            mod = new StructureModifier(structName.Trim());
            _modifiers.Add(key, mod);
         }
         mod.AddModifier(folderName);
      }
   }
}
