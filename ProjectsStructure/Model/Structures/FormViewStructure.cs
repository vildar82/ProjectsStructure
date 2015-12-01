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
      private List<Structure> structures;

      public FormViewStructure(List<Structure> structures)
      {
         this.structures = structures;
         InitializeComponent();

         FillImageList();

         Rebinding();
      }

      private void FillImageList()
      {
         imageList1.Images.Add("Folder", Properties.Resources.folder);
         imageList1.Images.Add("Link", Properties.Resources.link);
         imageList1.Images.Add("Structure", Properties.Resources.structure);
         imageList1.Images.Add("Template", Properties.Resources.template);
      }

      private void Rebinding()
      {
         comboBoxStructures.DataSource = null;
         comboBoxStructures.DataSource = structures;
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
            int imageIndex = getNodeImage(item);
            newNode.ImageIndex = imageIndex;            
            newNode.SelectedImageIndex = imageIndex;
            newNode.Tag = item;
            FillNode(item.ChildFolders.Values.ToList(), newNode);
         }
      }

      private int getNodeImage(FolderItem fiItem)
      {
         return (int)fiItem.Type;
      }

      private void treeViewStructure_AfterSelect(object sender, TreeViewEventArgs e)
      {
         FolderItem fiSelect = e.Node.Tag as FolderItem;
         richTextBoxInfo.Text = fiSelect.GetInfo();
      }

      private void buttonExpandAll_Click(object sender, EventArgs e)
      {
         treeViewStructure.ExpandAll();
      }

      private void buttonCollapsAll_Click(object sender, EventArgs e)
      {
         treeViewStructure.CollapseAll();
      }
   }
}
