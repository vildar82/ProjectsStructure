using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectsStructure.Model.ViewStructure
{
   public partial class FormViewStructure : Form
   {
      private StructureService _ss;

      public FormViewStructure(StructureService ss)
      {
         _ss = ss;
         InitializeComponent();

         Rebinding();
      }

      private void Rebinding()
      {
         comboBoxStructures.DataSource = null;
         comboBoxStructures.DataSource = _ss.Structures;         
      }

      private void comboBoxStructures_SelectedIndexChanged(object sender, EventArgs e)
      {
         FillTreeView();
      }

      private void FillTreeView()
      {
         treeViewStructure.Nodes.Clear();

         Structure s = comboBoxStructures.SelectedItem as Structure;
         if (s == null) return;

         FillNode(s.Root.ChildFolders.Values.ToList(), null);
      }

      private void FillNode(List<FolderItem> items, TreeNode node)
      { 
         var nodesCollection = node != null
             ? node.Nodes
             : treeViewStructure.Nodes;

         foreach (var item in items)
         {
            TreeNode newNode = nodesCollection.Add(item.Name, item.Name);
            newNode.Tag = item;
            FillNode(item.ChildFolders.Values.ToList(), newNode);
         }
      }
   }
}
