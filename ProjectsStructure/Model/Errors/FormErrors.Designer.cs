﻿namespace ProjectsStructure.Model.Errors
{
   partial class FormErrors
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
         this.listBoxErrors = new System.Windows.Forms.ListBox();
         this.textBoxError = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // listBoxErrors
         // 
         this.listBoxErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listBoxErrors.FormattingEnabled = true;
         this.listBoxErrors.Location = new System.Drawing.Point(12, 12);
         this.listBoxErrors.Name = "listBoxErrors";
         this.listBoxErrors.Size = new System.Drawing.Size(555, 277);
         this.listBoxErrors.TabIndex = 0;
         // 
         // textBoxError
         // 
         this.textBoxError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxError.Location = new System.Drawing.Point(12, 305);
         this.textBoxError.Multiline = true;
         this.textBoxError.Name = "textBoxError";
         this.textBoxError.ReadOnly = true;
         this.textBoxError.Size = new System.Drawing.Size(555, 158);
         this.textBoxError.TabIndex = 1;
         // 
         // FormErrors
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(575, 470);
         this.Controls.Add(this.textBoxError);
         this.Controls.Add(this.listBoxErrors);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FormErrors";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "FormErrors";
         this.TopMost = true;
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ListBox listBoxErrors;
      private System.Windows.Forms.TextBox textBoxError;
   }
}