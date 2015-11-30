using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsStructure.Model.Errors
{
   public class Inspector
   {
      public Inspector()
      {
         Errors = new List<Error>();
      }

      public List<Error> Errors { get; private set; }

      public bool HasError { get { return Errors.Count > 0; } }

      public void AddError (Error error)
      {
         Errors.Add(error);         
      }      

      public void Show()
      {
         string errMsgs = string.Join(";\n", Errors);
         Log.Error(errMsgs);
         FormErrors formErr = new FormErrors(this);
         formErr.Show();
      }

      public void Clear()
      {
         Errors = new List<Error>();
      }
   }
}
