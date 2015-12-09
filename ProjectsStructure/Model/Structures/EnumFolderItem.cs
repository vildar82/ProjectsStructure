using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsStructure.Model
{   
   [Flags]
   public enum EnumFolderItem
   {
      Folder = 0,
      Link = 2,
      Structure = 4,
      Object = 8,
      Template =16         
   }
}
