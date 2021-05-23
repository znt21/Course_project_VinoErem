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
    // user info
    public struct UserData
    {
        public string username;
        public string password;

        public int type;
    }

    // types of users in program
    public enum USER_TYPE
    {
        STUDENT,
        TEACHER
    }

    public partial class EnterForm : Form
    {
        private List<string> UserNames = new List<string>();
        private List<string> Passwords = new List<string>();
        private List<string> UserType = new List<string>();

        private string databaseData;
        private UserData ud;

        private void readDatabase()
        {
            string pathToFile = "simple_database.txt";

            // check file
            // if not exist
            if (!File.Exists(pathToFile))
            {
                // Create a file
                StreamWriter sw = File.CreateText(pathToFile);
                sw.Close();
            }
            else
            {
                // read file and save data
                databaseData = System.IO.File.ReadAllText(pathToFile, System.Text.Encoding.UTF8);
            }
        }

        public EnterForm()
        {
            InitializeComponent();
        }

        // read data in lists
        private void readUserDatabase()
        {
            string[] lines = databaseData.Split('\n');

            for(int i = 0; i < lines.Length; ++i)
            {
                string[] data = lines[i].Split(' ');
                
                if(data[0] != "\0")
                {
                    UserNames.Add(data[0]);
                    Passwords.Add(data[1]);
                    UserType.Add(data[2]);
                }
            }
        }

        private void deleteDatabase()
        {
            for(int i = 0; i < UserNames.Count; ++i)
            {
                UserNames.RemoveAt(0);
                Passwords.RemoveAt(0);
                UserType.RemoveAt(0);
            }
        }

        private int searchInDatabase(string username, string password)
        {
            string tmp = username.Replace(' ', '_');

            for(int i = 0; i < UserNames.Count; ++i)
            {
                if ((UserNames[i] == username || UserNames[i] == tmp) && Passwords[i] == password)
                    return i;
            }

            return -1;
        }

        // enter into program as <user>
        private void EnterBtn_Click(object sender, EventArgs e)
        {
            bool searchFl = false;

            // read users data from simple database
            readDatabase();
            databaseData += '\0';

            // save in lists users data
            readUserDatabase();

            // read username and password
            ud.username = textBox1.Text;
            ud.password = textBox2.Text;
            ud.type = 0;

            int pos = searchInDatabase(ud.username, ud.password);

            if (pos != -1) 
            {
                // save user type
                ud.type = Int32.Parse(UserType[pos]);

                searchFl = true;
            }

            // if not found user
            if (searchFl == false)
            {
                MessageBox.Show("Not found user in database.\n Maybe incorrect data.", "ERROR");
                return;
            }

            // open start test window
            Main mn = new Main(ud);
            this.Hide();

            deleteDatabase();
            // just hide first window
            mn.Show();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            // fill data about new user
            RegisterForm rf = new RegisterForm(ref ud, this);
            rf.Show();
            this.Hide();
        }
    }
}
