using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsStructure.Model.Errors
{
   public class Error
   {  
      public Error(string message)
      {
         Message = message;
      }

      public string Message { get; set; }
      public string ShortMsg { get { return Message.Substring(0, 100); } }

      public override string ToString()
      {
         return Message;
      }
   }
}
