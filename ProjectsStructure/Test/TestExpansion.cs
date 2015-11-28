using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsStructure.Test
{
   public static class TestExpansion
   {
      public static void Expand()
      {
         Expansive.DefaultTokenStyle = TokenStyle.NAnt;
         var tokenValueDictionary = new Dictionary<string, string> {
                {"name","Structure"},
                {"share",@"c:\Users\khisyametdinovvt\Downloads\NLog-master\src\NLog.Extended\"},
                {"full","${name} - ${share}"}                
         };
         Expansive.DefaultExpansionFactory = name => tokenValueDictionary[name];
         string input = "${name}, ${share}";
         var res = input.Expand();
      }
   }
}
