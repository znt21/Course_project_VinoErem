using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_project_VinoErem
{
    public partial class Settings : Form
    {
        private Label info = new Label();
        bool infoFlag;
        public Settings()
        {
            InitializeComponent();
            infoFlag = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!infoFlag){
                this.Width = 540;
                this.Height = 400;
                infoFlag = true;
            }
            else{
                this.Width = 200;
                this.Height = 75;
                infoFlag = false;
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            // set data of label info
            info.Text = "version --> 0.0.1\nИнструкция:\n1.Нажмите на кнопку \"Открыть текст\" и выберите предметную область для теста в формате docx,dox,txt.\n2.Нажмите кнопку \"Начать тест\" и программа сгенерирует вопросы в тестовой форме.\n3.Далее выбирайте ответ \"Да\" или \"Нет\".\n4.По окончании теста появится результат тестирования.\n";
            info.BackColor = Color.White;
            info.Size = new System.Drawing.Size(365, 400);
            info.Location = new System.Drawing.Point(12, 75);

            this.Controls.Add(info);
        }
    }
}
