namespace ProjectsStructure
{
   partial class FormStructure
   {
      /// <summary>
      /// Обязательная переменная конструктора.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Освободить все используемые ресурсы.
      /// </summary>
      /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Код, автоматически созданный конструктором форм Windows

      /// <summary>
      /// Требуемый метод для поддержки конструктора — не изменяйте 
      /// содержимое этого метода с помощью редактора кода.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.buttonTemplates = new System.Windows.Forms.Button();
         this.labelProjectsShare = new System.Windows.Forms.Label();
         this.buttonNewProject = new System.Windows.Forms.Button();
         this.buttonNewObject = new System.Windows.Forms.Button();
         this.labelObjectsShare = new System.Windows.Forms.Label();
         this.comboBoxProjectsShare = new System.Windows.Forms.ComboBox();
         this.comboBoxObjectsShare = new System.Windows.Forms.ComboBox();
         this.buttonViewProjectsShare = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // buttonTemplates
         // 
         this.buttonTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonTemplates.Location = new System.Drawing.Point(545, 12);
         this.buttonTemplates.Name = "buttonTemplates";
         this.buttonTemplates.Size = new System.Drawing.Size(75, 23);
         this.buttonTemplates.TabIndex = 4;
         this.buttonTemplates.Text = "Шаблоны";
         this.toolTip1.SetToolTip(this.buttonTemplates, "Просмотр Структур, Прав, Переменных)");
         this.buttonTemplates.UseVisualStyleBackColor = true;
         this.buttonTemplates.Click += new System.EventHandler(this.buttonTemplates_Click);
         // 
         // labelProjectsShare
         // 
         this.labelProjectsShare.AutoSize = true;
         this.labelProjectsShare.Location = new System.Drawing.Point(12, 9);
         this.labelProjectsShare.Name = "labelProjectsShare";
         this.labelProjectsShare.Size = new System.Drawing.Size(92, 13);
         this.labelProjectsShare.TabIndex = 0;
         this.labelProjectsShare.Text = "Проекты в Share";
         // 
         // buttonNewProject
         // 
         this.buttonNewProject.Location = new System.Drawing.Point(91, 52);
         this.buttonNewProject.Name = "buttonNewProject";
         this.buttonNewProject.Size = new System.Drawing.Size(54, 23);
         this.buttonNewProject.TabIndex = 2;
         this.buttonNewProject.Text = "Новый";
         this.buttonNewProject.UseVisualStyleBackColor = true;
         // 
         // buttonNewObject
         // 
         this.buttonNewObject.Location = new System.Drawing.Point(162, 52);
         this.buttonNewObject.Name = "buttonNewObject";
         this.buttonNewObject.Size = new System.Drawing.Size(54, 23);
         this.buttonNewObject.TabIndex = 2;
         this.buttonNewObject.Text = "Новый";
         this.buttonNewObject.UseVisualStyleBackColor = true;
         // 
         // labelObjectsShare
         // 
         this.labelObjectsShare.AutoSize = true;
         this.labelObjectsShare.Location = new System.Drawing.Point(159, 9);
         this.labelObjectsShare.Name = "labelObjectsShare";
         this.labelObjectsShare.Size = new System.Drawing.Size(167, 13);
         this.labelObjectsShare.TabIndex = 0;
         this.labelObjectsShare.Text = "Объекты в выбранном проекте";
         // 
         // comboBoxProjectsShare
         // 
         this.comboBoxProjectsShare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxProjectsShare.FormattingEnabled = true;
         this.comboBoxProjectsShare.Location = new System.Drawing.Point(12, 25);
         this.comboBoxProjectsShare.Name = "comboBoxProjectsShare";
         this.comboBoxProjectsShare.Size = new System.Drawing.Size(133, 21);
         this.comboBoxProjectsShare.TabIndex = 3;
         this.comboBoxProjectsShare.SelectedIndexChanged += new System.EventHandler(this.comboBoxProjectsShare_SelectedIndexChanged);
         // 
         // comboBoxObjectsShare
         // 
         this.comboBoxObjectsShare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxObjectsShare.FormattingEnabled = true;
         this.comboBoxObjectsShare.Location = new System.Drawing.Point(162, 25);
         this.comboBoxObjectsShare.Name = "comboBoxObjectsShare";
         this.comboBoxObjectsShare.Size = new System.Drawing.Size(140, 21);
         this.comboBoxObjectsShare.TabIndex = 3;
         // 
         // buttonViewProjectsShare
         // 
         this.buttonViewProjectsShare.Location = new System.Drawing.Point(12, 52);
         this.buttonViewProjectsShare.Name = "buttonViewProjectsShare";
         this.buttonViewProjectsShare.Size = new System.Drawing.Size(47, 23);
         this.buttonViewProjectsShare.TabIndex = 5;
         this.buttonViewProjectsShare.Text = "View";
         this.buttonViewProjectsShare.UseVisualStyleBackColor = true;
         this.buttonViewProjectsShare.Click += new System.EventHandler(this.buttonViewProjectsShare_Click);
         // 
         // FormStructure
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(632, 275);
         this.Controls.Add(this.buttonViewProjectsShare);
         this.Controls.Add(this.buttonTemplates);
         this.Controls.Add(this.comboBoxObjectsShare);
         this.Controls.Add(this.comboBoxProjectsShare);
         this.Controls.Add(this.buttonNewObject);
         this.Controls.Add(this.buttonNewProject);
         this.Controls.Add(this.labelObjectsShare);
         this.Controls.Add(this.labelProjectsShare);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FormStructure";
         this.Text = "Project Strucuture";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.Label labelProjectsShare;
      private System.Windows.Forms.Button buttonNewProject;
      private System.Windows.Forms.Button buttonNewObject;
      private System.Windows.Forms.Label labelObjectsShare;
      private System.Windows.Forms.ComboBox comboBoxProjectsShare;
      private System.Windows.Forms.ComboBox comboBoxObjectsShare;
      private System.Windows.Forms.Button buttonTemplates;
      private System.Windows.Forms.Button buttonViewProjectsShare;
   }
}

