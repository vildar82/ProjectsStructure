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
   public partial class FormTestLink : Form
   {
      public FormTestLink()
      {
         InitializeComponent();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         createSymLinkDir(textBoxSymlink1.Text, textBoxTarget1.Text);
      }
      private void button2_Click(object sender, EventArgs e)
      {
         createSymLinkDir(textBoxSymlink2.Text, textBoxTarget2.Text);
      }

      private void createSymLinkDir(string symlink, string target)
      {
         try
         {
            SymbolicLink.CreateDirectoryLink(symlink, target);
            MessageBox.Show("Ok");
         }
         catch (Exception ex)
         {
            Program.Log.Error(ex, "SymLinkExt.Create(имя ссылки {0}, назначение {1})", symlink, target);
            MessageBox.Show(ex.ToString());
         }
      }      
   }
}
