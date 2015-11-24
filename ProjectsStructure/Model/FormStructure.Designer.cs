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
         this.textBoxExcelFileStructure = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.buttonBrowse = new System.Windows.Forms.Button();
         this.buttonRead = new System.Windows.Forms.Button();
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.comboBoxStructures = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.buttonViewStructures = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // textBoxExcelFileStructure
         // 
         this.textBoxExcelFileStructure.Location = new System.Drawing.Point(12, 22);
         this.textBoxExcelFileStructure.Name = "textBoxExcelFileStructure";
         this.textBoxExcelFileStructure.Size = new System.Drawing.Size(489, 20);
         this.textBoxExcelFileStructure.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 6);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(117, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Excel файл структуры";
         // 
         // buttonBrowse
         // 
         this.buttonBrowse.Location = new System.Drawing.Point(507, 20);
         this.buttonBrowse.Name = "buttonBrowse";
         this.buttonBrowse.Size = new System.Drawing.Size(27, 23);
         this.buttonBrowse.TabIndex = 2;
         this.buttonBrowse.Text = "...";
         this.toolTip1.SetToolTip(this.buttonBrowse, "Выбор файла Excel структур");
         this.buttonBrowse.UseVisualStyleBackColor = true;
         this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
         // 
         // buttonRead
         // 
         this.buttonRead.Location = new System.Drawing.Point(540, 20);
         this.buttonRead.Name = "buttonRead";
         this.buttonRead.Size = new System.Drawing.Size(57, 23);
         this.buttonRead.TabIndex = 3;
         this.buttonRead.Text = "Read";
         this.toolTip1.SetToolTip(this.buttonRead, "Считывание структур из файла");
         this.buttonRead.UseVisualStyleBackColor = true;
         this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click);
         // 
         // comboBoxStructures
         // 
         this.comboBoxStructures.FormattingEnabled = true;
         this.comboBoxStructures.Location = new System.Drawing.Point(12, 72);
         this.comboBoxStructures.Name = "comboBoxStructures";
         this.comboBoxStructures.Size = new System.Drawing.Size(132, 21);
         this.comboBoxStructures.TabIndex = 4;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 56);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(60, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Структуры";
         // 
         // buttonViewStructures
         // 
         this.buttonViewStructures.Location = new System.Drawing.Point(150, 72);
         this.buttonViewStructures.Name = "buttonViewStructures";
         this.buttonViewStructures.Size = new System.Drawing.Size(40, 23);
         this.buttonViewStructures.TabIndex = 5;
         this.buttonViewStructures.Text = "View";
         this.buttonViewStructures.UseVisualStyleBackColor = true;
         this.buttonViewStructures.Click += new System.EventHandler(this.buttonViewStructures_Click);
         // 
         // FormStructure
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(607, 320);
         this.Controls.Add(this.buttonViewStructures);
         this.Controls.Add(this.comboBoxStructures);
         this.Controls.Add(this.buttonRead);
         this.Controls.Add(this.buttonBrowse);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.textBoxExcelFileStructure);
         this.Name = "FormStructure";
         this.Text = "Form1";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox textBoxExcelFileStructure;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button buttonBrowse;
      private System.Windows.Forms.ToolTip toolTip1;
      private System.Windows.Forms.Button buttonRead;
      private System.Windows.Forms.ComboBox comboBoxStructures;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button buttonViewStructures;
   }
}

