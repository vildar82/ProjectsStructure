using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectsStructure.Model.Structures;

namespace ProjectsStructure.Model.ViewStructure
{
   public partial class FormViewStructure : Form
   {
      private StructureService ss;

      public FormViewStructure(StructureService ss)
      {
         this.ss = ss;
         InitializeComponent();

         Rebinding();
      }

      private void Rebinding()
      {
         comboBoxStructures.DataSource = null;
         comboBoxStructures.DataSource = ss.STC.StructureTemplates;
      }

      private void comboBoxStructures_SelectedIndexChanged(object sender, EventArgs e)
      {
         FillTreeView();
      }

      private void FillTreeView()
      {
         treeViewStructure.Nodes.Clear();

         StructureTemplate s = comboBoxStructures.SelectedItem as StructureTemplate;
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
            FolderItemTemplate fiItem = (FolderItemTemplate)item;
            TreeNode newNode = nodesCollection.Add(item.Name, item.Name);
            newNode.ImageIndex = (int)fiItem.Type;
            newNode.SelectedImageIndex = (int)fiItem.Type;
            newNode.Tag = item;
            FillNode(item.ChildFolders.Values.ToList(), newNode);
         }
      }

      private void treeViewStructure_AfterSelect(object sender, TreeViewEventArgs e)
      {
         FolderItemTemplate fiSelect = e.Node.Tag as FolderItemTemplate;
         labelInfo.Text = fiSelect.GetTypeName();
      }
   }
}
