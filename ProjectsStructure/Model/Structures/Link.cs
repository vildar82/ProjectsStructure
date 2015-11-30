using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsStructure.Model.Structures
{
   /// <summary>
   /// Ссылка - символьная
   /// </summary>
   public class Link
   {
      public FolderItem FolderItem { get; private set; }

      public string TargetPath { get; private set; }

      public Link (FolderItem fi, string target)
      {
         FolderItem = fi;
         TargetPath = target.Expand();
      }
   }
}
