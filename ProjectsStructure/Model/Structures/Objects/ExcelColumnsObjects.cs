using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace ProjectsStructure.Model.Structures.Objects
{
   public class ExcelColumnsObjects
   {
      private ExcelWorksheet _ws;
      private Service _service;

      public string ProjectName { get; private set; }
      public int ColumnStructureFirst { get; private set; }
      public int RowStructureFirst { get; private set; }
      public int ColumnObjectsTypePart { get; private set; }
      public int RowObjectsTypePart { get; private set; }
      public int ColumnObjectsNode { get; private set; }// столбец Узел - имя объекта

      public ExcelColumnsObjects(ExcelWorksheet ws, Service service)
      {
         _ws = ws;
         _service = service;         
      }

      public void Parse()
      {
         // имя проекта
         var rangeProjectName = _ws.Names["ProjectName"];
         this.ProjectName = _ws.Cells[rangeProjectName.Start.Row, rangeProjectName.Start.Column].Text;

         // ячейка первой структуры
         var rangeFirstTemplate = _ws.Names["FirstStructure"];
         ColumnStructureFirst = rangeFirstTemplate.Start.Column;
         RowStructureFirst = rangeFirstTemplate.Start.Column;

         // Тип раздела - ячейка начала шапки таблицы объектов
         var rangeTypePart = _ws.Names["TypePart"];
         this.ColumnObjectsTypePart = rangeTypePart.Start.Column;
         this.RowObjectsTypePart = rangeTypePart.Start.Row;

         // определение столбца узла (имени объекта)                  
         for (int i = ColumnObjectsTypePart + 1; i < ColumnStructureFirst; i++)
         {
            var value = _ws.Cells[RowObjectsTypePart, i].Text;
            if (string.Equals(value, "Узел", StringComparison.CurrentCultureIgnoreCase))
            {
               ColumnObjectsNode = i;
               break;
            }            
         }
         if (ColumnObjectsNode == 0)
         {
            throw new Exception("Не определен столбец 'Узел'");
         }
      }
   }
}
