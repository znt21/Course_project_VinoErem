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

namespace Course_project_VinoErem
{
    public partial class RegisterForm : Form
    {
        UserData ud;
        EnterForm ef;

        public RegisterForm(ref UserData user_d, EnterForm enterF)
        {
            InitializeComponent();
            ud = user_d;
            ef = enterF;
        }

        private void saveDataInBase(UserData ud)
        {
            string pathToFile = "simple_database.txt";

            // check file
            // if not exist
            if (!File.Exists(pathToFile))
            {
                // Create a file
                StreamWriter sw = File.CreateText(pathToFile);
                sw.WriteLine(ud.username + " " + ud.password + " " + ud.type);
                sw.Close();
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(pathToFile, FileMode.Append, FileAccess.Write), System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(ud.username + " " + ud.password + " " + ud.type);
                }
            }
        }

        // instead space set _
        string space(string str)
        {
            char[] tmp = str.ToCharArray();
            string res = "";

            for (int i = 0; i < tmp.Length; ++i)
                if (tmp[i] == ' ')
                    res += '_';
                else
                    res += tmp[i];

            return res;
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.ToString();
            string password = textBox2.Text.ToString();
            int type;

            if(password.Contains(' '))
            {
                MessageBox.Show("ERROR: illegal symbol (maybe you used space symbol;)", "ERROR");
                return;
            }

            username = space(username);
            password = space(password);

            if(username.Length < 6 || password.Length < 6)
            {
                MessageBox.Show("ERROR: Need more symbols in username or password;", "ERROR");
                return;
            }

            if (rbTeacher.Checked)
                type = 1;
            else if (rbStudent.Checked)
                type = 0;
            else
            {
                MessageBox.Show("Error: need choose type;", "ERROR");
                return;
            }

            ud.username = username;
            ud.password = password;
            ud.type = type;

            // save new user
            saveDataInBase(ud);

            // open start test window
            Main mn = new Main(ud);

            // just hide first window
            mn.Show();

            this.Close();
        }
    }
}
