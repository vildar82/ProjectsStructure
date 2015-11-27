namespace ProjectsStructure.Test
{
   partial class FormTestLink
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
         this.label1 = new System.Windows.Forms.Label();
         this.textBoxSymlink1 = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.textBoxTarget1 = new System.Windows.Forms.TextBox();
         this.button1 = new System.Windows.Forms.Button();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.textBoxSymlink2 = new System.Windows.Forms.TextBox();
         this.textBoxTarget2 = new System.Windows.Forms.TextBox();
         this.button2 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(51, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Link path";
         // 
         // textBoxSymlink1
         // 
         this.textBoxSymlink1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxSymlink1.Location = new System.Drawing.Point(12, 25);
         this.textBoxSymlink1.Name = "textBoxSymlink1";
         this.textBoxSymlink1.Size = new System.Drawing.Size(703, 20);
         this.textBoxSymlink1.TabIndex = 1;
         this.textBoxSymlink1.Text = "\\\\ab4\\prj$\\Test\\0000\\ТестСимвольнойСсылки\\Link\\Test";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 48);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(62, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Target path";
         // 
         // textBoxTarget1
         // 
         this.textBoxTarget1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxTarget1.Location = new System.Drawing.Point(12, 64);
         this.textBoxTarget1.Name = "textBoxTarget1";
         this.textBoxTarget1.Size = new System.Drawing.Size(703, 20);
         this.textBoxTarget1.TabIndex = 1;
         this.textBoxTarget1.Text = "\\\\ab4\\prj$\\Test\\0000\\ТестСимвольнойСсылки\\Target";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(15, 90);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(121, 23);
         this.button1.TabIndex = 2;
         this.button1.Text = "Создать ссылку";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(12, 132);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(51, 13);
         this.label3.TabIndex = 0;
         this.label3.Text = "Link path";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(12, 171);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(62, 13);
         this.label4.TabIndex = 0;
         this.label4.Text = "Target path";
         // 
         // textBoxSymlink2
         // 
         this.textBoxSymlink2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxSymlink2.Location = new System.Drawing.Point(12, 148);
         this.textBoxSymlink2.Name = "textBoxSymlink2";
         this.textBoxSymlink2.Size = new System.Drawing.Size(703, 20);
         this.textBoxSymlink2.TabIndex = 1;
         this.textBoxSymlink2.Text = "c:\\dev\\Excel\\ProjectsStructure\\Test\\ТестСимЛинк\\СсылкаТут\\ссыль";
         // 
         // textBoxTarget2
         // 
         this.textBoxTarget2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxTarget2.Location = new System.Drawing.Point(12, 187);
         this.textBoxTarget2.Name = "textBoxTarget2";
         this.textBoxTarget2.Size = new System.Drawing.Size(703, 20);
         this.textBoxTarget2.TabIndex = 1;
         this.textBoxTarget2.Text = "c:\\dev\\Excel\\ProjectsStructure\\Test\\ТестСимЛинк\\Назначене";
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(15, 213);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(121, 23);
         this.button2.TabIndex = 2;
         this.button2.Text = "Создать ссылку";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // FormTestLink
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(727, 312);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.textBoxTarget2);
         this.Controls.Add(this.textBoxTarget1);
         this.Controls.Add(this.textBoxSymlink2);
         this.Controls.Add(this.textBoxSymlink1);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label1);
         this.Name = "FormTestLink";
         this.Text = "FormTestLink";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox textBoxSymlink1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox textBoxTarget1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox textBoxSymlink2;
      private System.Windows.Forms.TextBox textBoxTarget2;
      private System.Windows.Forms.Button button2;
   }
}