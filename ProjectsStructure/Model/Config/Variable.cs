using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsStructure.Model.Config
{
   public class Variable
   {
      public string Key { set; get; }
      public string Value { set; get; }

      public Variable() { }

      public Variable (string key, string value)
      {
         Key = key;
         Value = value;
      }
   }
}
