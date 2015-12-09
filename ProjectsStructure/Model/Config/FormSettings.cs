using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectsStructure.Model.Config
{
   public partial class FormSettings : Form
   {
      public FormSettings(Settings settings)
      {
         InitializeComponent();
         propertyGrid1.SelectedObject = settings;
      }
   }
}
