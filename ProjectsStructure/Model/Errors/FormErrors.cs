using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectsStructure.Model.Errors
{
   public partial class FormErrors : Form
   {
      private Inspector _inspector;
      private BindingSource _bindingErrors;

      public FormErrors(Inspector inspector)
      {
         InitializeComponent();
         _inspector = inspector;

         _bindingErrors = new BindingSource();
         _bindingErrors.DataSource = _inspector.Errors;
         listBoxErrors.DataSource = _bindingErrors;
         listBoxErrors.DisplayMember = "ShortMsg";
         textBoxError.DataBindings.Add("Text", _bindingErrors, "Message", false, DataSourceUpdateMode.OnPropertyChanged);
      }
   }
}
