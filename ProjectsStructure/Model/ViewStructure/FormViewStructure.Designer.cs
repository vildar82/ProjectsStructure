namespace ProjectsStructure.Model.ViewStructure
{
   partial class FormViewStructure
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormViewStructure));
         this.label1 = new System.Windows.Forms.Label();
         this.comboBoxStructures = new System.Windows.Forms.ComboBox();
         this.treeViewStructure = new System.Windows.Forms.TreeView();
         this.imageList1 = new System.Windows.Forms.ImageList(this.components);
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(58, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Структура";
         // 
         // comboBoxStructures
         // 
         this.comboBoxStructures.FormattingEnabled = true;
         this.comboBoxStructures.Location = new System.Drawing.Point(12, 25);
         this.comboBoxStructures.Name = "comboBoxStructures";
         this.comboBoxStructures.Size = new System.Drawing.Size(121, 21);
         this.comboBoxStructures.TabIndex = 1;
         this.comboBoxStructures.SelectedIndexChanged += new System.EventHandler(this.comboBoxStructures_SelectedIndexChanged);
         // 
         // treeViewStructure
         // 
         this.treeViewStructure.ImageIndex = 0;
         this.treeViewStructure.ImageList = this.imageList1;
         this.treeViewStructure.Location = new System.Drawing.Point(12, 52);
         this.treeViewStructure.Name = "treeViewStructure";
         this.treeViewStructure.SelectedImageIndex = 0;
         this.treeViewStructure.Size = new System.Drawing.Size(429, 413);
         this.treeViewStructure.TabIndex = 2;
         // 
         // imageList1
         // 
         this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
         this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList1.Images.SetKeyName(0, "folder.png");
         this.imageList1.Images.SetKeyName(1, "link.png");
         this.imageList1.Images.SetKeyName(2, "structure.png");
         this.imageList1.Images.SetKeyName(3, "template.png");
         // 
         // FormViewStructure
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(704, 474);
         this.Controls.Add(this.treeViewStructure);
         this.Controls.Add(this.comboBoxStructures);
         this.Controls.Add(this.label1);
         this.Name = "FormViewStructure";
         this.Text = "FormViewStructure";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox comboBoxStructures;
      private System.Windows.Forms.TreeView treeViewStructure;
      private System.Windows.Forms.ImageList imageList1;
   }
}