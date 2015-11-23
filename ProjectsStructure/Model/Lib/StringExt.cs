using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
   public static class StringExt
   {
      public static string ClearForStructure(this string input)
      {
         return input.Trim();
      }
   }
}
