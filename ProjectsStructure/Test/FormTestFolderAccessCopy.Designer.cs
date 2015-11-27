namespace ProjectsStructure.Test
{
   partial class FormTestFolderAccessCopy
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
         this.button1 = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.textBoxTemplate = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.textBoxDest = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(253, 116);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(114, 23);
         this.button1.TabIndex = 0;
         this.button1.Text = "Копировать права";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 35);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(51, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Template";
         // 
         // textBoxTemplate
         // 
         this.textBoxTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxTemplate.Location = new System.Drawing.Point(12, 51);
         this.textBoxTemplate.Name = "textBoxTemplate";
         this.textBoxTemplate.Size = new System.Drawing.Size(678, 20);
         this.textBoxTemplate.TabIndex = 2;
         this.textBoxTemplate.Text = "\\\\ab4\\prj$\\Test\\0000\\ТестКопированияПрав\\Шаблон\\01_ГП";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 74);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(29, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Dest";
         // 
         // textBoxDest
         // 
         this.textBoxDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxDest.Location = new System.Drawing.Point(12, 90);
         this.textBoxDest.Name = "textBoxDest";
         this.textBoxDest.Size = new System.Drawing.Size(678, 20);
         this.textBoxDest.TabIndex = 2;
         this.textBoxDest.Text = "\\\\ab4\\prj$\\Test\\0000\\ТестКопированияПрав\\Назначение\\Тест2";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(43, 9);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(524, 13);
         this.label3.TabIndex = 1;
         this.label3.Text = "Тест копирования прав доступа из папки шаблона в папку назначения. Папки должны с" +
    "уществовать";
         // 
         // FormTestFolderAccessCopy
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(702, 157);
         this.Controls.Add(this.textBoxDest);
         this.Controls.Add(this.textBoxTemplate);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.button1);
         this.Name = "FormTestFolderAccessCopy";
         this.Text = "FormTestFolderAccessCopy";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox textBoxTemplate;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox textBoxDest;
      private System.Windows.Forms.Label label3;
   }
}