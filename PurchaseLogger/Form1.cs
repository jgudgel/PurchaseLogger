using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;


namespace PurchaseLogger
{
    public partial class PurchaseLoggerForm : Form
    {
        ExcelWriter ew = null;
        string category = "";
        string date = "";
        double value = 0;
        bool fe;

        public PurchaseLoggerForm()
        {
            ew = new ExcelWriter();
            ConnectToBudget(ew);
            InitializeComponent();
        }


        private void SubmitButton_Click(object sender, EventArgs e)
        {
            category = CategoryTextBox.Text;

            date = DateTextBox.Text;
            if (date == "")
            {
                date = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                    DateTime.Now.Day.ToString();
            }
            else 
            { 
                date = DateTextBox.Text; 
            }

            try
            {
                value = Convert.ToDouble(ValueTextBox.Text);
                fe = false;
            }
            catch (FormatException)
            {
                fe = true;
            }

            //TODO add check for valid entries

            ew.WriteToExcel(category,value,date);
        }


        void ConnectToBudget(ExcelWriter ew)
        {
            if (ew.xlAppExists()) { KillSpecificExcelFileProcess("Budget"); }
            if (!ew.CreateExcelDoc())
            {
                ew.OpenExcelDoc();
            }
        }

        static void KillSpecificExcelFileProcess(string fileName)
        {
            var processes = from p in Process.GetProcessesByName("EXCEL")
                            select p;

            foreach (var process in processes)
            {
                if (process.MainWindowTitle.Contains(fileName))
                    process.Kill();
                //Console.WriteLine(process.MainWindowTitle);
            }
        }

        /*private void PurchaseLoggerForm_Load(object sender, EventArgs e)
        {
            ew.Close();
        }*/
    }


}
