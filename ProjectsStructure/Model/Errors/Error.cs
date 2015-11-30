using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsStructure.Model.Errors
{
   public class Error
   {      
      private string shortMsg;
      
      public Error(string message)
      {
         Message = message;
      }

      public string Message { get; private set; }

      public string ShortMsg
      {
         get
         {
            if(shortMsg== null)
            {
               shortMsg = Message.Substring(0, 100);
            }
            return shortMsg;
         }
      }

      public override string ToString()
      {
         return Message;
      }
   }
}
