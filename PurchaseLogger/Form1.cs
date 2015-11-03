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

        bool emptyE;
        bool formatE;
        bool dateE;

        const string HINTY = "yyyy";
        const string HINTM = "mm";
        const string HINTD = "dd";
        const string HINTCAT = "Food, Housing...";
        const string HINTVAL = "3.99, 8, 750.00...";
        const string EMPTY = "";

        public PurchaseLoggerForm()
        {
            InitializeComponent();
            DateTextBoxY.Text = DateTime.Now.ToString("yyyy");
            DateTextBoxM.Text = DateTime.Now.ToString("MM");
            DateTextBoxD.Text = DateTime.Now.ToString("dd");
            DateTextBoxY.ForeColor = SystemColors.WindowText;
            DateTextBoxM.ForeColor = SystemColors.WindowText;
            DateTextBoxD.ForeColor = SystemColors.WindowText;

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

            this.FormClosing += Form_Closing;

            ew = new ExcelWriter();
        }


        private void SubmitButton_Click(object sender, EventArgs e)
        {
            
            category = CategoryTextBox.Text;
            date = DateTextBoxY.Text + DateTextBoxM.Text + DateTextBoxD.Text;
            
            // Date must be actual date
            dateE = !ew.isDate(date);


            // All fields must have entry other than hint
            emptyE = (DateTextBoxY.Text == HINTY || DateTextBoxM.Text == HINTM || 
                        DateTextBoxD.Text == HINTD || CategoryTextBox.Text == HINTCAT ||
                        ValueTextBox.Text == HINTVAL) ? true : false;
            
            // Cannot enter a nonnumber value
            try
            {
                value = Convert.ToDouble(ValueTextBox.Text);
                formatE = false;
            }
            catch (FormatException)
            {
                formatE = true;
            }

            // So user knows what they did wrong ...or right
            if (emptyE)
            {
                MessageBox.Show("Please fill in all fields.");
            }
            else if (formatE)
            {
                MessageBox.Show("Invalid number entry, please try again.");
            }
            else if (dateE)
            {
                MessageBox.Show("Invalid date, please try again.");
            }
            else if (ew.WriteToExcel(category, value, date))
            {
                MessageBox.Show("Purchase Logger has written \"" + date + ", " + category + ", "
                                + value + "\" to " + ew.getDocPath() + "... \n"
                                + "Please submit another entry or close the app.");
            }
            else
            {
                MessageBox.Show("A fatal error occured. Please close this app and try again.");
                Application.Exit();
            }
        }

        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ew.Close();
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
    }


}
