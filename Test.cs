using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Q_TYPE
{
    UNKNOWN,
    TRUE_OR_FALSE,
    DEFIFNITION,
    DEFIFNITION_T_OR_F,
    NUM_WORDS,
    MISSING_WORD
}

namespace Course_project_VinoErem
{
    public struct Quiz
    {
        public string quest;
        public string answerStr;
        public int answer;
        public int type_q;
    }

    public struct MissWords
    {
        public string[] missWords;
        public int numMissWords;
    }

    public class Test
    {
        // data class
        private string basic_text;
        public string res_tmp;
        private string TestName;

        private int cnt_questions;

        // five basic questions
        private string[] firstPartQuest = { "Верно ли данное определение ", 
                                            "Согласны ли вы что ", 
                                            "Определение слова \" \" ",
                                            "Сколько слов \"<word>\" в тексте:",
                                            "Какое слово пропущено в \"<string>\":"};

        private List<Quiz> test = new List<Quiz>();
        private List<string> definitionList = new List<string>();
        private List<MissWords> missWordsList = new List<MissWords>();
        private List<Quiz> result_test = new List<Quiz>();

        UserData userD;
        Main mn;

        public Test( string TestName, UserData ud, Main mainF, string text = "", int cnt_q = 5)
        {
            this.TestName = TestName;

            basic_text = text; // save text in mem
            cnt_questions = cnt_q; // set number of questions

            userD = ud;
            mn = mainF;
        }

        public void createTest()
        {
            Quiz tmp_q;
            int cnt_dots = 0;
            int i = 0;

            basic_text += '\0';

            // count num of frazes
            while (basic_text[i] != '\0')
            {
                // defence from ...
                if (basic_text[i] == '.' && (basic_text[i - 1] != '.' && i > 0))
                    cnt_dots++;
                ++i;
            }

            // split text with dots on frazes
            string[] frazes = basic_text.Split(new char[] { '.' });

            for (i = 0; i < cnt_dots; ++i)
                if(frazes[i] != "\0")
                {
                    tmp_q = searchquestion(frazes[i]);
                    if (tmp_q.type_q != (int)Q_TYPE.UNKNOWN)
                        test.Add(tmp_q);
                }

            createQuestions(i);

            // if need more words
            int j = 0;
            if (result_test.Count < cnt_questions)
                for (i = result_test.Count; i < cnt_questions; ++i)
                {
                    if (j == result_test.Count)
                        j = 0;

                    result_test.Add(result_test[j]);
                    j++;
                }
        }

        // generate questions using the collected data 
        private void createQuestions(int i)
        {
            var rand = new Random();
            int rand_answ = 0;

            // create questions
            int j = 0;
            for (i = 0; i < test.Count; ++i)
                // for definition questions
                if (test[i].type_q == (int)Q_TYPE.DEFIFNITION_T_OR_F)
                {
                    int rand_q_type = rand.Next(0, 5);
                    int q_index = 0;

                    if (rand_q_type > 3)
                        q_index = 2;
                    else if (rand_q_type > 1)
                        q_index = 1;

                    string tmp = firstPartQuest[q_index];

                    if (q_index == 2)
                        tmp = tmp.Insert(19, test[i].quest);
                    else
                        tmp += test[i].quest;

                    // add a little bit chaos
                    // for random generation
                    if (j != definitionList.Count - 1)
                    {
                        rand_answ = rand.Next(0, 10);

                        if (rand_answ > 3)
                            rand_answ = 1;
                        else
                            rand_answ = 0;

                        tmp = tmp + definitionList[j + rand_answ] + ":";
                    }
                    else
                    {
                        rand_answ = rand.Next(-10, 0);

                        if (rand_answ < -4)
                            rand_answ = -1;
                        else
                            rand_answ = 0;

                        tmp = tmp + definitionList[j + rand_answ] + ":";
                    }

                    Quiz data;

                    data.quest = tmp.Replace("\n", " ");
                    data.type_q = test[i].type_q;
                    data.answerStr = "";

                    // check random question answer
                    if (rand_answ == 1 || rand_answ == -1)
                        data.answer = 0;
                    else
                        data.answer = 1;

                    result_test.Add(data);
                    if (result_test.Count == cnt_questions)
                        break;

                    j++;
                    // new type of questions
                }
                else if (test[i].type_q == (int)Q_TYPE.DEFIFNITION)
                {
                    Quiz data;

                    data.quest = firstPartQuest[2].Insert(19, test[i].quest.Replace("\n", " "));
                    data.type_q = test[i].type_q;
                    data.answer = -1;
                    data.answerStr = definitionList[i];

                    // create question
                    result_test.Add(data);
                    if (result_test.Count == cnt_questions)
                        break;

                    j++;
                }
        }

        // search data in text
        public Quiz searchquestion(string text)
        {
            Quiz result;
            MissWords missWordsRes;
            var rand = new Random();

            // data for searching question
            string[] def = { "– это", "–это", " – ", "- это", "-это", " - " , " — ", " — это", "—это" };
            int pos = 0;

            // basic info about question
            result.quest = "";
            result.answer = 0;
            result.type_q = (int)Q_TYPE.UNKNOWN;
            result.answerStr = "";

            for (int i = 0; i < def.Length; ++i)
                // if text has a definition
                if (text.Contains(def[i]))
                {
                    // search pos
                    if(text.Contains(def[i]))
                        pos = text.IndexOf(def[i]);

                    if (pos < 10)
                        break;

                    // save word
                    string tmp = text.Remove(pos, text.Length - pos);

                    // save definiton of word
                    definitionList.Add(text.Remove(0, pos));

                    // save resul data
                    result.quest = tmp;
                    result.type_q = (int)Q_TYPE.DEFIFNITION_T_OR_F;

                    // create new type of questions
                    if (definitionList.Count > 4 && rand.Next(0, 10) >= 2)
                                result.type_q = (int)Q_TYPE.DEFIFNITION;

                    break;
                }

            return result;
        }

        // start test in another form
        public void startQuiz()
        {
            TestForm testWnd = new TestForm( ref definitionList,this.TestName, ref definitionList, ref result_test, mn, userD);
            testWnd.Show();
            testWnd.testFunction();

            res_tmp = testWnd.res_tmp;
        }
    }
}
