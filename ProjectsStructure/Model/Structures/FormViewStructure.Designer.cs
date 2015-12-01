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
         this.label1 = new System.Windows.Forms.Label();
         this.comboBoxStructures = new System.Windows.Forms.ComboBox();
         this.treeViewStructure = new System.Windows.Forms.TreeView();
         this.imageList1 = new System.Windows.Forms.ImageList(this.components);
         this.buttonCollapsAll = new System.Windows.Forms.Button();
         this.buttonExpandAll = new System.Windows.Forms.Button();
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
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
         this.comboBoxStructures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxStructures.FormattingEnabled = true;
         this.comboBoxStructures.Location = new System.Drawing.Point(12, 25);
         this.comboBoxStructures.Name = "comboBoxStructures";
         this.comboBoxStructures.Size = new System.Drawing.Size(155, 21);
         this.comboBoxStructures.TabIndex = 1;
         this.comboBoxStructures.SelectedIndexChanged += new System.EventHandler(this.comboBoxStructures_SelectedIndexChanged);
         // 
         // treeViewStructure
         // 
         this.treeViewStructure.Dock = System.Windows.Forms.DockStyle.Fill;
         this.treeViewStructure.ImageIndex = 0;
         this.treeViewStructure.ImageList = this.imageList1;
         this.treeViewStructure.Location = new System.Drawing.Point(0, 0);
         this.treeViewStructure.Name = "treeViewStructure";
         this.treeViewStructure.SelectedImageIndex = 0;
         this.treeViewStructure.Size = new System.Drawing.Size(524, 350);
         this.treeViewStructure.TabIndex = 2;
         this.treeViewStructure.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewStructure_AfterSelect);
         // 
         // imageList1
         // 
         this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
         this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
         this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
         // 
         // buttonCollapsAll
         // 
         this.buttonCollapsAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCollapsAll.Location = new System.Drawing.Point(510, 22);
         this.buttonCollapsAll.Name = "buttonCollapsAll";
         this.buttonCollapsAll.Size = new System.Drawing.Size(25, 24);
         this.buttonCollapsAll.TabIndex = 4;
         this.buttonCollapsAll.Text = "-";
         this.toolTip1.SetToolTip(this.buttonCollapsAll, "Свернкть все");
         this.buttonCollapsAll.UseVisualStyleBackColor = true;
         this.buttonCollapsAll.Click += new System.EventHandler(this.buttonCollapsAll_Click);
         // 
         // buttonExpandAll
         // 
         this.buttonExpandAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonExpandAll.Location = new System.Drawing.Point(479, 22);
         this.buttonExpandAll.Name = "buttonExpandAll";
         this.buttonExpandAll.Size = new System.Drawing.Size(25, 24);
         this.buttonExpandAll.TabIndex = 4;
         this.buttonExpandAll.Text = "+";
         this.toolTip1.SetToolTip(this.buttonExpandAll, "Развернуть все");
         this.buttonExpandAll.UseVisualStyleBackColor = true;
         this.buttonExpandAll.Click += new System.EventHandler(this.buttonExpandAll_Click);
         // 
         // richTextBoxInfo
         // 
         this.richTextBoxInfo.BackColor = System.Drawing.Color.WhiteSmoke;
         this.richTextBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
         this.richTextBoxInfo.Location = new System.Drawing.Point(0, 0);
         this.richTextBoxInfo.Name = "richTextBoxInfo";
         this.richTextBoxInfo.ReadOnly = true;
         this.richTextBoxInfo.Size = new System.Drawing.Size(524, 189);
         this.richTextBoxInfo.TabIndex = 5;
         this.richTextBoxInfo.Text = "";
         // 
         // splitContainer1
         // 
         this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.splitContainer1.Location = new System.Drawing.Point(12, 64);
         this.splitContainer1.Name = "splitContainer1";
         this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.treeViewStructure);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.richTextBoxInfo);
         this.splitContainer1.Size = new System.Drawing.Size(524, 543);
         this.splitContainer1.SplitterDistance = 350;
         this.splitContainer1.TabIndex = 6;
         // 
         // FormViewStructure
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(548, 619);
         this.Controls.Add(this.splitContainer1);
         this.Controls.Add(this.buttonExpandAll);
         this.Controls.Add(this.buttonCollapsAll);
         this.Controls.Add(this.comboBoxStructures);
         this.Controls.Add(this.label1);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FormViewStructure";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "FormViewStructure";
         this.TopMost = true;
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox comboBoxStructures;
      private System.Windows.Forms.TreeView treeViewStructure;
      private System.Windows.Forms.ImageList imageList1;
      private System.Windows.Forms.Button buttonCollapsAll;
      private System.Windows.Forms.Button buttonExpandAll;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.RichTextBox richTextBoxInfo;
      private System.Windows.Forms.SplitContainer splitContainer1;
   }
}