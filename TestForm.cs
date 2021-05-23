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
using Excel = Microsoft.Office.Interop.Excel;

using System.Runtime.InteropServices;
using Application = Microsoft.Office.Interop.Word.Application;
using Microsoft.Office.Interop.Word;

namespace Course_project_VinoErem
{
    public partial class TestForm : Form
    {
        // save data
        private List<string> data;
        private List<Quiz> test;
        public string res_tmp;
        private string TestName;
        private string answerInfo = "";

        RadioButton trueBtn;
        RadioButton falseBtn;

        // second type
        RadioButton[] Btn;

        Main mn;
        UserData userData;

        int currentQ;
        int currentType;

        int testPoints;
        int userType;
        int number_question;

        int answerFlag;
        string answerStr;

        List<string> def = new List<string>();

        Application app = null;
        Document document;
        Paragraph paragraph;

        public TestForm(ref List<string> definitions, string TestName, ref List<string> firstPartQuest, ref List<Quiz> tst, Main mainF, UserData ud)
        {
            InitializeComponent();

            this.TestName = TestName;

            def = definitions;

            data = firstPartQuest;
            currentQ = 0;
            number_question = 1;
            currentType = (int) Q_TYPE.UNKNOWN;
            testPoints = 0;
            test = tst;
            mn = mainF;

            this.userType = ud.type;
            userData = ud;

            // create and open result word doc
            openWordDoc();
            progressBar1.Maximum = tst.Count;
        }

        public void openWordDoc()
        {
            string fileName = "result.doc";
            
            app = new Application();
            app.Visible = false;

            document = app.Documents.Add();
            document.Activate();

            paragraph = document.Paragraphs.Add();
                
            paragraph.Range.Text = "Test Results\n";
        }

        public void writeWordDoc(string str, bool newLine)
        {
            if (newLine)
                str += "\n";

            paragraph.Range.Text += str;
        }

        public void closeWordDoc()
        {
            if(app != null)
            {
                app.ActiveDocument.SaveAs("TestResults.doc", WdSaveFormat.wdFormatDocument);
                app.Quit();

                Marshal.FinalReleaseComObject(app);
            }
        }

        public void testFunction()
        {
            Quiz tmp_q;

            tmp_q = test[currentQ];

            // if it's definition question with true or false answer
            if (tmp_q.type_q == (int)Q_TYPE.DEFIFNITION_T_OR_F)
            {
                progressBar1.Value = number_question - 1;
                questionLabel.Text = "№ " + number_question + ": " + tmp_q.quest;
                number_question++;

                answerFlag = tmp_q.answer;

                currentType = (int)Q_TYPE.DEFIFNITION_T_OR_F;

                trueBtn = new RadioButton();
                falseBtn = new RadioButton();

                trueBtn.Text = "Да";
                falseBtn.Text = "Нет";

                panel2.Controls.Add(trueBtn);
                panel2.Controls.Add(falseBtn);

                trueBtn.Location = new System.Drawing.Point(12, 20);
                falseBtn.Location = new System.Drawing.Point(12, 50);

                writeWordDoc(tmp_q.quest, true);
            }else if (tmp_q.type_q == (int)Q_TYPE.DEFIFNITION)
            {
                progressBar1.Value = number_question - 1;
                questionLabel.Text = "№ " + number_question + ": " + tmp_q.quest;
                number_question++;

                currentType = (int)Q_TYPE.DEFIFNITION;

                answerStr = tmp_q.answerStr;

                Btn = new RadioButton[4];

                Btn[0] = new RadioButton();
                Btn[1] = new RadioButton();
                Btn[2] = new RadioButton();
                Btn[3] = new RadioButton();

                var rand = new Random();
                string tmp;

                for (int i = 0; i < 4; ++i)
                {
                    Btn[i].AutoSize = true;
                    tmp = def[rand.Next(0, def.Count - 1)];
                    
                    if (tmp.Length > 30) 
                    { 
                        tmp = tmp.Remove(30, tmp.Length - 30);
                        tmp = tmp.Insert(tmp.Length, "...");
                    }

                    Btn[i].Text = tmp;
                    panel2.Controls.Add(Btn[i]);
                }

                answerFlag = rand.Next(0, 3);
                string tmp_answ = tmp_q.answerStr;

                if (tmp_answ.Length > 30)
                {
                    tmp_answ = tmp_answ.Remove(30, tmp_answ.Length - 30);
                    tmp_answ = tmp_answ.Insert(tmp_answ.Length, "...");
                }

                Btn[answerFlag].Text = tmp_answ;

                Btn[0].Location = new System.Drawing.Point(12, 20);
                Btn[1].Location = new System.Drawing.Point(12, 50);
                Btn[2].Location = new System.Drawing.Point(320, 20);
                Btn[3].Location = new System.Drawing.Point(320, 50);

                writeWordDoc(tmp_q.quest, true);
            }
        }

        // next button click
        private void button1_Click(object sender, EventArgs e)
        {
            currentQ++;

            bool checkedFlag = false;
            if (currentType == (int)Q_TYPE.DEFIFNITION) {
                for (int j = 0; j < 4; ++j)
                    if (Btn[j].Checked)
                        checkedFlag = true;
            }
            else
                checkedFlag = true;

            // check answer
            if(!trueBtn.Checked && !falseBtn.Checked)
            {
                MessageBox.Show("ERROR: Нужен ответ;", "ERROR");
                return;
            }

            if (!checkedFlag)
            {
                MessageBox.Show("ERROR: Нужен ответ;", "ERROR");
                return;
            }

            if (currentType == (int)Q_TYPE.DEFIFNITION_T_OR_F) 
            {
                // check answer
                if (answerFlag == 1 && trueBtn.Checked)
                    testPoints++;
                else if(answerFlag == 0 && falseBtn.Checked)
                    testPoints++;

                string userAnswer = "";

                if (answerFlag == 1)
                    userAnswer = "Да";
                else if (answerFlag == 0)
                    userAnswer = "Нет";

                // write user answer in file
                if (trueBtn.Checked)
                {
                    writeWordDoc("Ваш ответ: Да\t", false);
                    answerInfo += "№" + currentQ + "\tВаш ответ: Да\t" + "Правильный ответ: " + userAnswer + "\n";
                }
                else if (falseBtn.Checked)
                {
                    writeWordDoc("Ваш ответ: Нет\t", false);
                    answerInfo += "№" + currentQ + "\tВаш ответ: Нет\t" + "Правильный ответ: " + userAnswer + "\n";
                }

                // if teacher
                if (userType == 1)
                    writeWordDoc("Правильный ответ: " + userAnswer, true);

                trueBtn.Dispose();
                falseBtn.Dispose();
            // second ttype of questions
            }else if (currentType == (int)Q_TYPE.DEFIFNITION)
            {
                if(Btn[answerFlag].Checked)
                    testPoints++;

                int numberChecked = -1;
                for (int i = 0; i < 4; ++i)
                    if (Btn[i].Checked)
                        numberChecked = i;

                string userAnswer = Btn[answerFlag].Text;

                // write user answer in file
                writeWordDoc("Ваш ответ: " + Btn[numberChecked].Text + "\t" , false);
                answerInfo += "№" + currentQ + "\tВаш ответ: " + Btn[numberChecked].Text + "\t" + "Правильный ответ: " + userAnswer + "\n";

                // if teacher
                if (userType == 1)
                    writeWordDoc("  \tПравильный ответ: " + userAnswer, true);

                // delete answers
                for (int i = 0; i < 4; ++i)
                    Btn[i].Dispose();
            }

            currentType = (int)Q_TYPE.UNKNOWN;

            if(currentQ < test.Count)
                testFunction();

            if (currentQ == test.Count)
            {
                this.Close();
                MessageBox.Show("Набрано " + testPoints + "/" + currentQ + ";\n" + answerInfo, "Result");
                res_tmp = testPoints + "/" + (currentQ );

                writeWordDoc("Набрано " + testPoints + "/" + currentQ + ".", true);
                closeWordDoc();

                mn.result = res_tmp;
                saveResultInDatabase(res_tmp);
                saveExcelDatabase(res_tmp);
                mn.Show();
            }
        }

        private void saveExcelDatabase(string result)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "Documents\\";
            string nameDatabaseResults = "results_database.txt";
            string databaseData = "";
            // create new xls or open old
            string fullWay = filePath + "result_database.xls";
            string resExcelDatabase = "result_database.xls";
            Excel.Application ex = new Excel.Application();
            Excel.Workbook workBook;

            // set hidden mode
            ex.Visible = false;
            // num of sheets as 1
            ex.SheetsInNewWorkbook = 2;
            // not display alerts
            ex.DisplayAlerts = false;

            // open old xls or create new
            /*try
            {
                workBook = ex.Workbooks.Open(fullWay,
                  Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                  Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                  Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                  Type.Missing, Type.Missing);
            }
            catch
            {*/
                workBook = ex.Workbooks.Add(Type.Missing);
            //}

            // create sheet
            Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(1);

            // set name of spreadsheet
            sheet.Name = "Student Results";

            if (File.Exists(nameDatabaseResults))
            {
                // read all text
                databaseData = System.IO.File.ReadAllText(nameDatabaseResults, System.Text.Encoding.UTF8);

                string[] frazes = databaseData.Split('\n');

                for(int i = 0; i < frazes.Length; ++i)
                {
                    frazes[i] = frazes[i].Replace('\n', ' ');
                    frazes[i] = frazes[i].Replace('\r', ' ');

                    if (frazes[i] == "")
                        continue;

                    if (frazes[i].Contains("user: "))
                        sheet.Cells[i + 1, 1] = String.Format( frazes[i]);
                    else if(frazes[i].Contains("test: "))
                    {
                        frazes[i] = frazes[i].Replace('\t', '+');
                        frazes[i] = frazes[i].Remove(0, 1);
                        string[] parts = frazes[i].Split('+');

                        //sheet.Cells[i + 1, 2] = String.Format(frazes[i]);

                        sheet.Cells[i + 1, 2] = String.Format(parts[0]);
                        sheet.Cells[i + 1, 3] = String.Format(parts[1]);
                        sheet.Cells[i + 1, 4] = String.Format(parts[2]);
                    }
                }
            }

            // save xls
            workBook.SaveAs( resExcelDatabase, Type.Missing,
                  Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
                  Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


            // close app
            ex.Quit();

            Marshal.FinalReleaseComObject(ex);
        }
        // save result in database for teachers
        private void saveResultInDatabase(string result)
        {
            string nameDatabaseResults = "results_database.txt";
            string databaseData = "";

            // check file
            // if not exist
            if (!File.Exists(nameDatabaseResults))
            {
                // Create a file
                StreamWriter sw = File.CreateText(nameDatabaseResults);
                sw.WriteLine("user: " + userData.username + "\n" + "\ttest: " + result + "\tNameTest: " + this.TestName + "\tDate: " + DateTime.Now.ToString("HH:mm:ss"));
                sw.Close();
            }
            else
            {
                // read file and save data
                databaseData = System.IO.File.ReadAllText(nameDatabaseResults, System.Text.Encoding.UTF8);

                int pos = databaseData.IndexOf("user: " + userData.username);

                if(pos == -1)
                {
                    databaseData += "\nuser: " + userData.username + "\n" + "\ttest: " + result + "\tNameTest: " + this.TestName + "\tDate: " + DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    databaseData = databaseData.Insert(pos + ("user: " + userData.username).Length, "\n\ttest: " + result + "\tNameTest: " + this.TestName + "\tDate: " + DateTime.Now.ToString("HH:mm:ss"));
                }

                StreamWriter sw = new StreamWriter(new FileStream(nameDatabaseResults, FileMode.Create, FileAccess.Write), System.Text.Encoding.UTF8);
                sw.Write(databaseData);
                sw.Close();
            }
        }
    }
}