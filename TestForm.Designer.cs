namespace Course_project_VinoErem
{
    partial class TestForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.questionLabel = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Next = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.questionLabel);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 94);
            this.panel1.TabIndex = 0;
            // 
            // questionLabel
            // 
            this.questionLabel.Location = new System.Drawing.Point(13, 4);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.ReadOnly = true;
            this.questionLabel.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.questionLabel.Size = new System.Drawing.Size(694, 85);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = "";
            this.questionLabel.UseWaitCursor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(13, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(712, 131);
            this.panel2.TabIndex = 1;
            // 
            // Next
            // 
            this.Next.BackColor = System.Drawing.Color.MistyRose;
            this.Next.Location = new System.Drawing.Point(13, 251);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(712, 32);
            this.Next.TabIndex = 2;
            this.Next.Text = "Далее";
            this.Next.UseVisualStyleBackColor = false;
            this.Next.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 305);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(708, 32);
            this.progressBar1.TabIndex = 3;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(737, 349);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TestForm";
            this.Text = "Окно тестирования";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.RichTextBox questionLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}