using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectsStructure.Model.Lib;

namespace ProjectsStructure.Test
{
   public partial class FormTestFolderAccessCopy : Form
   {
      public FormTestFolderAccessCopy()
      {
         InitializeComponent();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         try
         {
            FolderExt.FolderCopyAcces(textBoxTemplate.Text, textBoxDest.Text);
            MessageBox.Show("Ok");
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
            Program.Log.Error(ex, "FolderCopyAcces (template {0}, dest {1})", textBoxTemplate.Text, textBoxDest.Text);
         }
      }
   }
}
