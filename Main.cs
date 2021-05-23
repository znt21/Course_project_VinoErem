using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// for office
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;

namespace Course_project_VinoErem
{
    public partial class Main : Form
    {
        private UserData userInfo;
        public string result = " ";
        private string configData = "";

        string file;

        public Main(UserData ud)
        {
            InitializeComponent();

            // filters for open files
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|Word Files(*.doc)|*.doc|Word Files XML(*.docx)|*.docx|All files(*.*)|*.*";
            this.MaximizeBox = false;

            // save user data
            userInfo = ud;

            // display username
            Username.Text = "Имя пользователя: " + userInfo.username.ToString();
            // display type of user
            if (userInfo.type == 0)
            {
                Type.Text = "Статус: Ученик";
                startTest.Enabled = true;

                label4.Hide();
                numQuestions.Hide();
                openResults.Hide();
            }
            else 
            {
                Type.Text = "Статус: Учитель";
                startTest.Enabled = false;
            }

            // read config file and num_of questions
            string configName = "config.txt";
            if (!File.Exists(configName))
            {
                // Create a file
                StreamWriter sw = File.CreateText(configName);
                sw.WriteLine("num_questions:  10");
                sw.Close();
            }
            else
            {
                // read file and save data
                configData = System.IO.File.ReadAllText(configName, System.Text.Encoding.UTF8);

                string[] frazes = configData.Split('\n');

                string[] frazeData = frazes[0].Split(' ');

                try
                {
                    numQuestions.Value = Int32.Parse(frazeData[1]);
                }
                catch
                {
                    // Create a file
                    StreamWriter sw = File.CreateText(configName);
                    sw.WriteLine("num_questions:  10");
                    sw.Close();
                }
            }
        }

        // open file button action
        private void openText_Click(object sender, EventArgs e)
        {
            string fileText = "";

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            // open file
            string filename = openFileDialog1.FileName;
            file = GetFileName(filename);
            // display name of file and data in file
            label3.Text = "Текущий файл: " + file;

            string exten = GetExten(file);

            if(GetExten(file) == "txt" || GetExten(file) == "TXT"){
                // read file
                fileText = System.IO.File.ReadAllText(filename, Encoding.UTF8);
            }
            else if(GetExten(file) == "doc" || GetExten(file) == "docx")
            {
                // open docx/doc files
                // Open a doc file.
                Application application = new Application();
                Document document = application.Documents.Open(filename);

                // Loop through all words in the document.
                int count = document.Words.Count;
                for (int i = 1; i <= count; i++)
                {
                    // Write the word.
                    fileText += document.Words[i].Text;
                }
                // Close word.
                application.Quit();
            }

            testTextBox.Text = fileText;
            // show message about open file
            MessageBox.Show("Файл открыт");
        }

        // fuction for reverse string
        public string Reverce(String str){
            return new string(str.ToCharArray().Reverse().ToArray());
        }

        // function for get file name without full way
        public string GetFileName(String str){
            string tmp = "";

            // read from end only name of file
            for(int i = str.Length - 1; i > 0; --i){
                if (str[i] == '\\')
                    break;
                
                tmp += str[i];
            }

            tmp = Reverce(tmp);

            return tmp;
        }

        // get extension 
        private string GetExten(String str)
        {
            string tmp = "";
            int i = str.Length - 1;

            while(str[i] != '.') 
            {
                tmp += str[i];
                --i;
            }

            tmp = Reverce(tmp);

            return tmp;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Settings sett = new Settings();
            sett.Show();
        }

        private void startTest_Click(object sender, EventArgs e)
        {
            string tmp = testTextBox.Text;

            if (tmp.Length <= 100)
            {
                MessageBox.Show("WARNING: Слишком маленький размер текста.\nHELP_INFO: Допишите сами, откройте другой текст\n\t    или добавьте к текущему;", "WARNING");
                return;
            }
            // create test object
            Test tst = new Test( file, userInfo, this, tmp, Convert.ToInt32(numQuestions.Value));

            tst.createTest();
            tst.startQuiz();

            this.Hide();
        }

        // close program from second window
        private void Main_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        // change result 
        private void Main_VisibleChanged(object sender, EventArgs e)
        {
            Result.Text = "Последний результат: " +  result;
        }

        private void numQuestions_ValueChanged(object sender, EventArgs e)
        {
            // write in config file
            string configName = "config.txt";

            // Create a file
            StreamWriter sw = new StreamWriter(new FileStream(configName, FileMode.Create, FileAccess.Write), System.Text.Encoding.UTF8);
            sw.WriteLine("num_questions: " + numQuestions.Value);
            sw.Close();
        }

        private string readDatabaseResults()
        {
            string nameDatabaseResults = "results_database.txt";
            string result = "";

            // check file
            // if not exist
            if (File.Exists(nameDatabaseResults))
            {
                // read file and save data
                result = System.IO.File.ReadAllText(nameDatabaseResults, System.Text.Encoding.UTF8);
            }

            return result;
        }

        private void openResults_Click(object sender, EventArgs e)
        {
            string tmp = readDatabaseResults();

            if (tmp != "")
            {
                DatabaseDisplay dd = new DatabaseDisplay(tmp);
                dd.Show();
            }
            else
                MessageBox.Show("ERROR: Can't open database;","ERROR");
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
