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
         this.panel1 = new System.Windows.Forms.Panel();
         this.panel2 = new System.Windows.Forms.Panel();
         this.buttonInit = new System.Windows.Forms.Button();
         this.buttonOptions = new System.Windows.Forms.Button();
         this.buttonTest = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // buttonTemplates
         // 
         this.buttonTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonTemplates.Location = new System.Drawing.Point(773, 12);
         this.buttonTemplates.Name = "buttonTemplates";
         this.buttonTemplates.Size = new System.Drawing.Size(75, 23);
         this.buttonTemplates.TabIndex = 4;
         this.buttonTemplates.Text = "Шаблоны";
         this.toolTip1.SetToolTip(this.buttonTemplates, "Просмотр Структур, Прав, Переменных)");
         this.buttonTemplates.UseVisualStyleBackColor = true;
         this.buttonTemplates.Click += new System.EventHandler(this.buttonTemplates_Click);
         // 
         // panel1
         // 
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel1.Location = new System.Drawing.Point(144, 201);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(200, 100);
         this.panel1.TabIndex = 5;
         // 
         // panel2
         // 
         this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel2.Location = new System.Drawing.Point(350, 201);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(200, 100);
         this.panel2.TabIndex = 5;
         // 
         // buttonInit
         // 
         this.buttonInit.Location = new System.Drawing.Point(79, 12);
         this.buttonInit.Name = "buttonInit";
         this.buttonInit.Size = new System.Drawing.Size(55, 23);
         this.buttonInit.TabIndex = 6;
         this.buttonInit.Text = "Read";
         this.buttonInit.UseVisualStyleBackColor = true;
         this.buttonInit.Click += new System.EventHandler(this.buttonInit_Click);
         // 
         // buttonOptions
         // 
         this.buttonOptions.Location = new System.Drawing.Point(12, 12);
         this.buttonOptions.Name = "buttonOptions";
         this.buttonOptions.Size = new System.Drawing.Size(61, 23);
         this.buttonOptions.TabIndex = 7;
         this.buttonOptions.Text = "Settings";
         this.buttonOptions.UseVisualStyleBackColor = true;
         this.buttonOptions.Click += new System.EventHandler(this.buttonOptions_Click);
         // 
         // buttonTest
         // 
         this.buttonTest.Location = new System.Drawing.Point(323, 371);
         this.buttonTest.Name = "buttonTest";
         this.buttonTest.Size = new System.Drawing.Size(75, 23);
         this.buttonTest.TabIndex = 8;
         this.buttonTest.Text = "Тест";
         this.buttonTest.UseVisualStyleBackColor = true;
         this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
         // 
         // FormStructure
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(860, 486);
         this.Controls.Add(this.buttonTest);
         this.Controls.Add(this.buttonOptions);
         this.Controls.Add(this.buttonInit);
         this.Controls.Add(this.panel2);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.buttonTemplates);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FormStructure";
         this.Text = "Project Strucuture";
         this.ResumeLayout(false);

      }

      #endregion
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.Button buttonTemplates;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Button buttonInit;
      private System.Windows.Forms.Button buttonOptions;
      private System.Windows.Forms.Button buttonTest;
   }
}

