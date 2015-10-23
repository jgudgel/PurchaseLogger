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

        const string HINTY = "yyyy";
        const string HINTM = "mm";
        const string HINTD = "dd";
        const string HINTCAT = "e.g. Food, Furniture...";
        const string HINTVAL = "e.g. 3.99, 8, 750.00...";
        const string EMPTY = "";

        public PurchaseLoggerForm()
        {
            InitializeComponent();

            //this.FormClosing += Form_Closing;

            CategoryTextBox.Enter += new System.EventHandler(CategoryTextBox_EnterHint);
            ValueTextBox.Enter += new System.EventHandler(ValueTextBox_EnterHint);
            DateTextBoxY.Enter += new System.EventHandler(DateTextBoxY_EnterHint);
            DateTextBoxM.Enter += new System.EventHandler(DateTextBoxM_EnterHint);
            DateTextBoxD.Enter += new System.EventHandler(DateTextBoxD_EnterHint);

            CategoryTextBox.Leave += new System.EventHandler(CategoryTextBox_LeaveEmpty);
            ValueTextBox.Leave += new System.EventHandler(ValueTextBox_LeaveEmpty);
            DateTextBoxY.Leave += new System.EventHandler(DateTextBoxY_LeaveEmpty);
            DateTextBoxM.Leave += new System.EventHandler(DateTextBoxM_LeaveEmpty);
            DateTextBoxD.Leave += new System.EventHandler(DateTextBoxD_LeaveEmpty);

            ew = new ExcelWriter();
        }


        private void SubmitButton_Click(object sender, EventArgs e)
        {

            ConnectToBudget(ew);
            
            category = CategoryTextBox.Text;

            date = DateTextBoxY.Text + DateTextBoxM.Text + DateTextBoxD.Text;

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
            if (!fe)
            {
                ew.WriteToExcel(category, value, date);
                MessageBox.Show("Purchase Logger has written \"" + date + ", " + category + ", "
                                + value + "\" to " + ew.getDocPath() + "... \n"
                                + "Submit another entry or close the app.");
            }
            else
            {
                MessageBox.Show("Invalid Number Entry.");
            }

            ew.Close();
        }


        void ConnectToBudget(ExcelWriter ew)
        {
            if (ew.xlAppDNE()) { KillSpecificExcelFileProcess("Budget"); }
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

        private void TodayButton_Click(object sender, EventArgs e)
        {
            DateTextBoxY.Text = DateTime.Now.Year.ToString();
            DateTextBoxM.Text = DateTime.Now.Month.ToString();
            DateTextBoxD.Text = DateTime.Now.Day.ToString();
            DateTextBoxY.ForeColor = SystemColors.WindowText;
            DateTextBoxM.ForeColor = SystemColors.WindowText;
            DateTextBoxD.ForeColor = SystemColors.WindowText;
        }

        // Entering textbox with hints
        private void CategoryTextBox_EnterHint(object sender, EventArgs e)
        {
            if (CategoryTextBox.Text == HINTCAT)
            {
                CategoryTextBox.Text = EMPTY;
                CategoryTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void ValueTextBox_EnterHint(object sender, EventArgs e)
        {
            if (ValueTextBox.Text == HINTVAL)
            {
                ValueTextBox.Text = EMPTY;
                ValueTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void DateTextBoxY_EnterHint(object sender, EventArgs e)
        {
            if (DateTextBoxY.Text == HINTY)
            {
                DateTextBoxY.Text = EMPTY;
                DateTextBoxY.ForeColor = SystemColors.WindowText;
            }
        }

        private void DateTextBoxM_EnterHint(object sender, EventArgs e)
        {
            if (DateTextBoxM.Text == HINTM)
            {
                DateTextBoxM.Text = EMPTY;
                DateTextBoxM.ForeColor = SystemColors.WindowText;
            }
        }

        private void DateTextBoxD_EnterHint(object sender, EventArgs e)
        {
            if (DateTextBoxD.Text == HINTD)
            {
                DateTextBoxD.Text = EMPTY;
                DateTextBoxD.ForeColor = SystemColors.WindowText;
            }
        }

        // Leaving blank text box shows hints
        private void CategoryTextBox_LeaveEmpty(object sender, EventArgs e)
        {
            if (CategoryTextBox.Text == EMPTY)
            {
                CategoryTextBox.Text = HINTCAT;
                CategoryTextBox.ForeColor = SystemColors.GrayText;
            }
        }

        private void ValueTextBox_LeaveEmpty(object sender, EventArgs e)
        {
            if (ValueTextBox.Text == EMPTY)
            {
                ValueTextBox.Text = HINTVAL;
                ValueTextBox.ForeColor = SystemColors.GrayText;
            }
        }

        private void DateTextBoxY_LeaveEmpty(object sender, EventArgs e)
        {
            if (DateTextBoxY.Text == EMPTY)
            {
                DateTextBoxY.Text = HINTY;
                DateTextBoxY.ForeColor = SystemColors.GrayText;
            }
        }

        private void DateTextBoxM_LeaveEmpty(object sender, EventArgs e)
        {
            if (DateTextBoxM.Text == EMPTY)
            {
                DateTextBoxM.Text = HINTM;
                DateTextBoxM.ForeColor = SystemColors.GrayText;
            }
        }

        private void DateTextBoxD_LeaveEmpty(object sender, EventArgs e)
        {
            if (DateTextBoxD.Text == EMPTY)
            {
                DateTextBoxD.Text = HINTD;
                DateTextBoxD.ForeColor = SystemColors.GrayText;
            }
        }

        /*private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            ew.Close();
        }*/
    }


}
