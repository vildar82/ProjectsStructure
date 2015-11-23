using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsStructure.Model.Errors
{
   public class Inspector
   {
      private List<Error> _errors;

      public Inspector()
      {
         _errors = new List<Error>();
      }

      public List<Error> Errors { get { return _errors; } }

      public bool HasError { get { return _errors.Count > 0; } }

      public void AddError (Error error)
      {
         _errors.Add(error);
      }      

      public void Show()
      {
         FormErrors formErr = new FormErrors(this);
         formErr.Show();
      }

      public void Clear()
      {
         _errors = new List<Error>();
      }
   }
}
