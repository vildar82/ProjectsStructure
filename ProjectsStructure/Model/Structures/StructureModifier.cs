using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsStructure.Model.Structures
{
   // Модификатор структуры
   public class StructureModifier
   {
      private Dictionary<string, string> _mods;

      public string NameStructure { get; private set; }      
      
      public StructureModifier(string structureName)
      {
         NameStructure = structureName;
      }

      public void AddModifier(string folderName)
      {
         string key = folderName.Trim().ToUpper();         
         if (!_mods.ContainsKey(key))
         {
            _mods.Add(key, folderName.Trim());
         }
      }
   }
}
