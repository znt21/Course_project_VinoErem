namespace Course_project_VinoErem
{
    partial class Main
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
            this.testTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openText = new System.Windows.Forms.Button();
            this.startTest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.Settings = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Result = new System.Windows.Forms.Label();
            this.Type = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.numQuestions = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.openResults = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestions)).BeginInit();
            this.SuspendLayout();
            // 
            // testTextBox
            // 
            this.testTextBox.Location = new System.Drawing.Point(154, 80);
            this.testTextBox.Name = "testTextBox";
            this.testTextBox.Size = new System.Drawing.Size(629, 299);
            this.testTextBox.TabIndex = 1;
            this.testTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите текст:";
            // 
            // openText
            // 
            this.openText.BackColor = System.Drawing.Color.MistyRose;
            this.openText.Location = new System.Drawing.Point(13, 80);
            this.openText.Name = "openText";
            this.openText.Size = new System.Drawing.Size(119, 43);
            this.openText.TabIndex = 3;
            this.openText.Text = "Открыть текст";
            this.openText.UseVisualStyleBackColor = false;
            this.openText.Click += new System.EventHandler(this.openText_Click);
            // 
            // startTest
            // 
            this.startTest.BackColor = System.Drawing.Color.MistyRose;
            this.startTest.Location = new System.Drawing.Point(12, 129);
            this.startTest.Name = "startTest";
            this.startTest.Size = new System.Drawing.Size(119, 43);
            this.startTest.TabIndex = 4;
            this.startTest.Text = "Начать тест";
            this.startTest.UseVisualStyleBackColor = false;
            this.startTest.Click += new System.EventHandler(this.startTest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Меню";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(514, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Текущий файл: ";
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.SystemColors.Info;
            this.Settings.Location = new System.Drawing.Point(12, 336);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(119, 43);
            this.Settings.TabIndex = 7;
            this.Settings.Text = "Справка";
            this.Settings.UseVisualStyleBackColor = false;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Result);
            this.panel1.Controls.Add(this.Type);
            this.panel1.Controls.Add(this.Username);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 44);
            this.panel1.TabIndex = 8;
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Location = new System.Drawing.Point(529, 12);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(160, 17);
            this.Result.TabIndex = 2;
            this.Result.Text = "Последний результат: ";
            // 
            // Type
            // 
            this.Type.AutoSize = true;
            this.Type.Location = new System.Drawing.Point(322, 12);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(61, 17);
            this.Type.TabIndex = 1;
            this.Type.Text = "Статус: ";
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Location = new System.Drawing.Point(3, 12);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(139, 17);
            this.Username.TabIndex = 0;
            this.Username.Text = "Имя пользователя: ";
            // 
            // numQuestions
            // 
            this.numQuestions.Location = new System.Drawing.Point(20, 204);
            this.numQuestions.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numQuestions.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numQuestions.Name = "numQuestions";
            this.numQuestions.Size = new System.Drawing.Size(111, 22);
            this.numQuestions.TabIndex = 9;
            this.numQuestions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numQuestions.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numQuestions.ValueChanged += new System.EventHandler(this.numQuestions_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Число вопросов: ";
            // 
            // openResults
            // 
            this.openResults.BackColor = System.Drawing.Color.MistyRose;
            this.openResults.Location = new System.Drawing.Point(13, 232);
            this.openResults.Name = "openResults";
            this.openResults.Size = new System.Drawing.Size(118, 43);
            this.openResults.TabIndex = 11;
            this.openResults.Text = "Открыть Результаты";
            this.openResults.UseVisualStyleBackColor = false;
            this.openResults.Click += new System.EventHandler(this.openResults_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 396);
            this.Controls.Add(this.openResults);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numQuestions);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startTest);
            this.Controls.Add(this.openText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.testTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(818, 443);
            this.MinimumSize = new System.Drawing.Size(818, 443);
            this.Name = "Main";
            this.Text = "Курсовой проект";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.VisibleChanged += new System.EventHandler(this.Main_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuestions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox testTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button openText;
        private System.Windows.Forms.Button startTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label Type;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.NumericUpDown numQuestions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button openResults;
    }
}

