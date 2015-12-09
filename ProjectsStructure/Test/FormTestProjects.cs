using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectsStructure.Model;
using ProjectsStructure.Model.Config;

namespace ProjectsStructure.Test
{
   public partial class FormTestProjects : Form
   {
      private List<ProjectItem> projects;
      private int i = 0;
      private BindingSource bindingProj;
      private Service service;

      public FormTestProjects(Service s)
      {
         this.service = s;
         InitializeComponent();
         projects = new List<ProjectItem>();
         bindingProj = new BindingSource();
         bindingProj.DataSource = projects;
         listBoxRojects.DataSource = bindingProj;
      }

      private void button1_Click(object sender, EventArgs e)
      {
         string projName = i++.ToString("0000") + "project";
         projects.Add(new ProjectItem(projName));
         RebindProj();
      }

      private void RebindProj()
      {
         bindingProj.ResetBindings(false);
      }

      public class ProjectItem
      {
         public string Name { get; set; }
         public List<string> Objects { get; set; }
         private int i;

         public ProjectItem (string name)
         {
            Name = name;
            Objects = new List<string>();
         }

         public void AddObject()
         {
            Objects.Add("Object" + i++);
         }

         public override string ToString()
         {
            return Name; 
         }
      }

      private void listBoxRojects_SelectedIndexChanged(object sender, EventArgs e)
      {
         ProjectItem proj = (ProjectItem)listBoxRojects.SelectedItem;
         RebindObjects(proj);
      }

      private void RebindObjects(ProjectItem proj)
      {
         listBoxObjects.DataSource = null;
         listBoxObjects.DataSource = proj.Objects;
      }

      private void button2_Click(object sender, EventArgs e)
      {
         ProjectItem proj = (ProjectItem)listBoxRojects.SelectedItem;
         proj.AddObject();
         RebindObjects(proj);
      }

      private void buttonCreate_Click(object sender, EventArgs e)
      {
         var dirShare = new DirectoryInfo(service.Tokens["share"]);
         foreach (var proj in projects)
         {
            service.STC.StructureShare.Create(dirShare, proj.Name, proj.Objects);
         }
      }
   }
}
