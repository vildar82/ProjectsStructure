using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStructureClient
{
   class Program
   {
      static void Main(string[] args)
      {
         ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
         var data = new ServiceReference1.CompositeType();
         data.BoolValue = true;
         data.StringValue = "dfgyhdfsghdhd dh dfgh df dgh dfgh";
         var res = client.GetDataUsingDataContract(data);
      }
   }
}
