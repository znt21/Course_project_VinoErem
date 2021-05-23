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

namespace Course_project_VinoErem
{
    public partial class DatabaseDisplay : Form
    {
        public DatabaseDisplay(string database)
        {
            InitializeComponent();

            DataBase.Text = database;

            openExcelDatabase();
        }

        private void openExcelDatabase()
        {
            // save full way
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\";
            string fullWay = filePath + "result_database.xls";

            dataGridView1.ColumnCount = 4;
            dataGridView1.RowCount = 200;

            dataGridView1.RowHeadersVisible = true;

            Excel.Application ObjExcel = null;
            Excel.Workbook ObjWorkBook = null;
            Excel.Worksheet ObjWorkSheet = null;

            ObjExcel = new Excel.Application();

            string userName = "";

            try
            {
                ObjExcel = new Excel.Application();
                ObjWorkBook = ObjExcel.Workbooks.Open(fullWay);
                ObjWorkSheet = ObjExcel.ActiveSheet as Excel.Worksheet;
                Excel.Range rg = null;

                Int32 row = 1;
                dataGridView1.Rows.Clear();
                List<String> arr = new List<string>();
                while (ObjWorkSheet.get_Range("a" + row, "a" + row).Value != null || ObjWorkSheet.get_Range("b" + row, "b" + row).Value != null)
                {
                    rg = ObjWorkSheet.get_Range("a" + row, "u" + row);
                    foreach (Microsoft.Office.Interop.Excel.Range item in rg)
                    {
                        try
                        {
                            arr.Add(item.Value.ToString().Trim());
                        }
                        catch { arr.Add(""); }
                    }

                    if (arr[0] != "")
                        userName = arr[0];
                    else
                        arr[0] = userName;

                    dataGridView1.Rows.Add(arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7], arr[8]);
                    arr.Clear();
                    row++;
                }
                MessageBox.Show("Файл успешно считан!", "Считывание файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message, "Ошибка при считывании excel файла", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            {
                if(ObjWorkBook != null)
                    ObjWorkBook.Close(false, "", null);
                ObjExcel.Quit();
                ObjWorkBook = null;
                ObjWorkSheet = null;
                ObjExcel = null;
            }

            if (ObjWorkBook != null)
                ObjWorkBook.Close(false, "", null);
            if(ObjExcel != null)
                ObjExcel.Quit();

            ObjWorkBook = null;
            ObjWorkSheet = null;
            ObjExcel = null;

            // fill headers
            dataGridView1.Columns[0].HeaderText = "User";
            dataGridView1.Columns[1].HeaderText = "Result";
            dataGridView1.Columns[2].HeaderText = "Test";
            dataGridView1.Columns[3].HeaderText = "Data";

            // set rows
            for (int i = 0; (i <= (dataGridView1.Rows.Count - 1)); i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = string.Format((i + 1).ToString(), "0");
            }

            dataGridView1.Refresh();
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
