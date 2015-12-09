namespace ProjectsStructure.Test
{
   partial class FormTestProjects
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
         this.listBoxRojects = new System.Windows.Forms.ListBox();
         this.listBoxObjects = new System.Windows.Forms.ListBox();
         this.checkBoxShare = new System.Windows.Forms.CheckBox();
         this.checkBoxWIP = new System.Windows.Forms.CheckBox();
         this.checkBoxBIM = new System.Windows.Forms.CheckBox();
         this.checkBoxCivil = new System.Windows.Forms.CheckBox();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.buttonCreate = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // listBoxRojects
         // 
         this.listBoxRojects.AllowDrop = true;
         this.listBoxRojects.ImeMode = System.Windows.Forms.ImeMode.On;
         this.listBoxRojects.Location = new System.Drawing.Point(27, 52);
         this.listBoxRojects.Name = "listBoxRojects";
         this.listBoxRojects.Size = new System.Drawing.Size(179, 134);
         this.listBoxRojects.TabIndex = 0;
         this.listBoxRojects.SelectedIndexChanged += new System.EventHandler(this.listBoxRojects_SelectedIndexChanged);
         // 
         // listBoxObjects
         // 
         this.listBoxObjects.FormattingEnabled = true;
         this.listBoxObjects.Location = new System.Drawing.Point(212, 52);
         this.listBoxObjects.Name = "listBoxObjects";
         this.listBoxObjects.Size = new System.Drawing.Size(184, 147);
         this.listBoxObjects.TabIndex = 1;
         // 
         // checkBoxShare
         // 
         this.checkBoxShare.AutoSize = true;
         this.checkBoxShare.Location = new System.Drawing.Point(37, 296);
         this.checkBoxShare.Name = "checkBoxShare";
         this.checkBoxShare.Size = new System.Drawing.Size(54, 17);
         this.checkBoxShare.TabIndex = 2;
         this.checkBoxShare.Text = "Share";
         this.checkBoxShare.UseVisualStyleBackColor = true;
         // 
         // checkBoxWIP
         // 
         this.checkBoxWIP.AutoSize = true;
         this.checkBoxWIP.Location = new System.Drawing.Point(37, 319);
         this.checkBoxWIP.Name = "checkBoxWIP";
         this.checkBoxWIP.Size = new System.Drawing.Size(47, 17);
         this.checkBoxWIP.TabIndex = 2;
         this.checkBoxWIP.Text = "WIP";
         this.checkBoxWIP.UseVisualStyleBackColor = true;
         // 
         // checkBoxBIM
         // 
         this.checkBoxBIM.AutoSize = true;
         this.checkBoxBIM.Location = new System.Drawing.Point(37, 342);
         this.checkBoxBIM.Name = "checkBoxBIM";
         this.checkBoxBIM.Size = new System.Drawing.Size(45, 17);
         this.checkBoxBIM.TabIndex = 2;
         this.checkBoxBIM.Text = "BIM";
         this.checkBoxBIM.UseVisualStyleBackColor = true;
         // 
         // checkBoxCivil
         // 
         this.checkBoxCivil.AutoSize = true;
         this.checkBoxCivil.Location = new System.Drawing.Point(37, 365);
         this.checkBoxCivil.Name = "checkBoxCivil";
         this.checkBoxCivil.Size = new System.Drawing.Size(45, 17);
         this.checkBoxCivil.TabIndex = 2;
         this.checkBoxCivil.Text = "Civil";
         this.checkBoxCivil.UseVisualStyleBackColor = true;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(27, 192);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 3;
         this.button1.Text = "button1";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(212, 205);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(75, 23);
         this.button2.TabIndex = 3;
         this.button2.Text = "button1";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(24, 36);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(52, 13);
         this.label1.TabIndex = 4;
         this.label1.Text = "Проекты";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(209, 36);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(53, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "Объекты";
         // 
         // buttonCreate
         // 
         this.buttonCreate.Location = new System.Drawing.Point(268, 313);
         this.buttonCreate.Name = "buttonCreate";
         this.buttonCreate.Size = new System.Drawing.Size(75, 23);
         this.buttonCreate.TabIndex = 5;
         this.buttonCreate.Text = "Создать";
         this.buttonCreate.UseVisualStyleBackColor = true;
         this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
         // 
         // FormTestProjects
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(693, 438);
         this.Controls.Add(this.buttonCreate);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.checkBoxCivil);
         this.Controls.Add(this.checkBoxBIM);
         this.Controls.Add(this.checkBoxWIP);
         this.Controls.Add(this.checkBoxShare);
         this.Controls.Add(this.listBoxObjects);
         this.Controls.Add(this.listBoxRojects);
         this.Name = "FormTestProjects";
         this.Text = "FormTestProjects";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ListBox listBoxRojects;
      private System.Windows.Forms.ListBox listBoxObjects;
      private System.Windows.Forms.CheckBox checkBoxShare;
      private System.Windows.Forms.CheckBox checkBoxWIP;
      private System.Windows.Forms.CheckBox checkBoxBIM;
      private System.Windows.Forms.CheckBox checkBoxCivil;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button buttonCreate;
   }
}