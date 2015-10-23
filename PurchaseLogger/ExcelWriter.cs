﻿using System;
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
        static Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        object misValue;
        int _RowIndex;
        string _currentDate = "";
        string _myDocPath = "";


        public ExcelWriter()
        {
            _currentDate = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString();
            _myDocPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Budget.xls";
        }

        public void WriteToExcel(string category, double value, string date)
        {
            // Notify adding tuple
            Debug.WriteLine("Writing \"" + _currentDate + ", " + category + ", " + value + "\" to " + _myDocPath);

            _RowIndex = xlWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
            _RowIndex++;
            xlWorkSheet.Cells[_RowIndex, 1] = date;
            xlWorkSheet.Cells[_RowIndex, 2] = category;
            xlWorkSheet.Cells[_RowIndex, 3] = value;

            try
            {
                xlWorkBook.SaveAs(_myDocPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue,
                                    misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue,
                                    misValue, misValue, misValue, misValue);
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                PrintExcelOpenError();
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
            Console.WriteLine("Does not exist... Creating Budget.xls...");

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
            _RowIndex = 1;
            xlWorkSheet.Cells[_RowIndex, 1] = "Date";
            xlWorkSheet.Cells[_RowIndex, 2] = "Category";
            xlWorkSheet.Cells[_RowIndex, 3] = "Value";

            return true;
        }

        public void Close()
        {
            xlWorkBook.Close(true, misValue, misValue);

            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
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
            Console.ReadKey();
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