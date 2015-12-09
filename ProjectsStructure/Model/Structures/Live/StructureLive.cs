using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsStructure.Model.Structures.Live
{
   public class StructureLive : Structure
   {
      public DirectoryInfo Dir { get; private set; }

      public StructureLive (DirectoryInfo dir, Service service) : base (dir.Name, service)
      {
         Dir = dir;
      }

      // Считывание структуры папки
      public void Read()
      {
         Root = new FolderItemLive(Dir, this,null);
         ((FolderItemLive)Root).ReadChildFolders();
      }
   }
}
