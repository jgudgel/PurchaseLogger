using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


using Excel = Microsoft.Office.Interop.Excel;

namespace PurchaseLogger
{
    public class ExcelWriter
    {
        Excel.Application xlApp = null;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        Excel.Range catCell, dateCell, valCell;

        object misValue;
        int rowIndex;
        string _myDocPath = "";


        public ExcelWriter()
        {
            _myDocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Budget.xls";

            ConnectToBudget();
        }


        public bool WriteToExcel(string category, double value, string date)
        {
            // Notify adding tuple
            Debug.WriteLine("Writing \"" + date + ", " + category + ", " + value + "\" to " + _myDocPath);
            try
            {
                rowIndex = xlWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
                rowIndex++;
                xlWorkSheet.Cells[rowIndex, 1] = date;
                xlWorkSheet.Cells[rowIndex, 2] = category;
                xlWorkSheet.Cells[rowIndex, 3] = value;


                xlWorkBook.SaveAs(_myDocPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue,
                                    misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue,
                                    misValue, misValue, misValue, misValue);
                return true;
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                return false;
            }
        }

        public void OpenExcelDoc()
        {
            // Notify opening doc
            Debug.WriteLine("Opening Budget.xls...");
            //if (xlApp != null) return;
            if (xlApp == null)
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
            }
            if (xlApp == null)
            {
                Debug.WriteLine("Excel is not properly installed!!");
                return;
            }

            xlApp.DisplayAlerts = false;

            // Handles Marshal exception with unhandled COM objects
            var tmp = xlApp.Workbooks;

            misValue = System.Reflection.Missing.Value;
            //xlWorkBook = tmp.Add(misValue);

            xlWorkBook = tmp.Open(_myDocPath);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

        }

        public bool CreateExcelDoc()
        {
            // Notify checking if creating doc
            Debug.WriteLine("Checking if Budget.xls Exists...");
            if (System.IO.File.Exists(_myDocPath))
            {
                Debug.WriteLine("Confirmed...");
                return false;
            }

            
            // Notify creating doc
            Debug.WriteLine("Does not exist... Creating Budget.xls...");

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                Debug.WriteLine("Excel is not properly installed!!");
                return false;
            }

            //var tmp = xlApp.Workbooks;
            xlApp.DisplayAlerts = false;

            misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            rowIndex = 1;
            xlWorkSheet.Cells[rowIndex, 1] = "Date";
            xlWorkSheet.Cells[rowIndex, 2] = "Category";
            xlWorkSheet.Cells[rowIndex, 3] = "Value";
            
            return true;
        }

        public void Close()
        {
            try
            {
                xlWorkBook.Close(true, misValue, misValue);

                xlApp.Quit();
                //releaseObject(cell);
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                //do nothing
            }
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
                Debug.WriteLine("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        void ConnectToBudget()
        {
            if (xlAppDNE()) { KillSpecificExcelFileProcess("Budget"); }
            if (!CreateExcelDoc())
            {
                OpenExcelDoc();
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
            }
        }

        public void PrintExcelOpenError()
        {
            Debug.WriteLine("Error during Save: COM Exception\n");
            int i = 0;
            while (i++ < 15)
            {
                Debug.WriteLine("*");
            }
            Debug.WriteLine("\n\nCannot start program while Budget.xls is open...\n" +
                                "Press any key to close this app.");
            if (IsOpened(xlWorkBook, xlApp))
            {
                xlWorkBook.Close(true, misValue, misValue);
            }
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            System.Environment.Exit(0);
        }

        /*
         *  inputs: 3 strings define range of values to sum, 1 double compares progress
         *  output: messagebox.show(string) method informs user
         */
        public double calculateProg(string category, string fromDate, string toDate, 
                                    double estimate)
        {
            double sum = calculateSum(category, fromDate, toDate);

            return estimate - sum;
        }

        /*
         * inputs: 3 strings define which table values to sum
         *         Dates must be format: yyyymmdd
         * output: sum
         */
        public double calculateSum(string category, string fromDate, string toDate)
        {

            int maxIndex = xlWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
            double sum = 0;
            int fromDateInt = Int32.Parse(fromDate);
            int toDateInt = Int32.Parse(toDate);

            category = category.ToLower();


            foreach (Excel.Range row in xlWorkSheet.UsedRange.Rows)
            {
                dateCell = xlWorkSheet.Cells[row.Row,1];
                catCell = xlWorkSheet.Cells[row.Row,2];
                valCell = xlWorkSheet.Cells[row.Row,3];
                
                if (row.Row == 1) continue;

                if (category == "all")
                {
                    if (dateCell.Value >= fromDateInt && dateCell.Value <= toDateInt)
                    {
                        sum += valCell.Value;
                    }
                }

                else
                {
                    if (dateCell.Value >= fromDateInt && dateCell.Value <= toDateInt
                        && catCell.Value.ToLower() == category)
                    {
                        sum += valCell.Value;
                    }
                }

                releaseObject(catCell);
                releaseObject(dateCell);
                releaseObject(valCell);
            }

            return sum;
        }

        /* 
         * TODO: fix this so it handles month to month/ year to year
         * input: 2 strings for range
         * output: length of range as int
         */
        public int calcDateRange(string fromDate, string toDate)
        {
            int fromDateInt = Int32.Parse(fromDate);
            int toDateInt = Int32.Parse(toDate);

            DateTime oldDate = new DateTime(fromDateInt / 10000,
                                            (fromDateInt / 100) % 100,
                                            fromDateInt % 100);
            DateTime newDate = new DateTime(toDateInt / 10000,
                                            (toDateInt / 100) % 100,
                                            toDateInt % 100);

            TimeSpan ts = newDate - oldDate;

            return ts.Days;
        }

        public bool isDate(string date)
        {
            try
            {
                int dateInt = Int32.Parse(date);
                DateTime dateCheck = new DateTime(dateInt / 10000,
                                            (dateInt / 100) % 100,
                                            dateInt % 100);
            }
            catch (FormatException)
            {
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            return true;
        }

        public bool IsOpened(Excel.Workbook wkBook, Excel.Application xlApp)
        {
            bool isOpened = true;
            try
            {
                xlApp.Workbooks.get_Item(wkBook);
            }
            catch (Exception)
            {
                isOpened = false;
            }
            return isOpened;
        }

        public bool xlAppDNE()
        {
            return (xlApp == null) ? true : false;
        }

        public string getDocPath()
        {
            return _myDocPath;
        }
    }
}