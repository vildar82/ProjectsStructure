using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsStructure.Model.Errors
{
   public class Error
   {
      private string _message;
      private string _shortMsg;
      
      public Error(string message)
      {
         _message = message;
      }

      public string Message { get { return _message; } }
      public string ShortMsg
      {
         get
         {
            if(_shortMsg== null)
            {
               _shortMsg = _message.Substring(0, 100);
            }
            return _shortMsg;
         }
      }
   }
}
