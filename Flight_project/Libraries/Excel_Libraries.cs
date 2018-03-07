using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Flight_project.Libraries
{
    class Excel_Libraries
    {
        private static int rowCount;

        public static string CollectExcelSheet(string File_name, string Attribute_value, int Number)
        {

            Excel.Application x1app = new Excel.Application();
            Excel.Workbook x1workbook = x1app.Workbooks.Open(@File_name);
            Excel.Worksheet x1sheet = x1workbook.Sheets[1];
            Excel.Range xlRange = x1sheet.UsedRange;
            for (int i = 1; i <= xlRange.Columns.Count; i++)
            {
                string value = xlRange.Cells[i][1].Value2;
                if (value == Attribute_value)
                {
                    string data = xlRange.Cells[i][1 + Number].Value2;

                    x1workbook.Close(false, Type.Missing, Type.Missing);
                    x1app.Workbooks.Close();
                    Marshal.ReleaseComObject(x1workbook);

                    x1app.Quit();
                    GC.Collect();
                    Marshal.ReleaseComObject(x1app);
                    return data;
                }
            }      
            return null;
        }

        public static string ReadDataFromExcelSheet(string File_name, string Attribute_value)
        {
            Excel.Application x1app = new Excel.Application();
            Excel.Workbook x1workbook = x1app.Workbooks.Open(@File_name);
            Excel.Worksheet x1sheet = x1workbook.Sheets[1];
            Excel.Range xlRange = x1sheet.UsedRange;
                for (int i = 1; i <= xlRange.Columns.Count; i++)
                {
                    string value = xlRange.Cells[i][1].Value2;
                        if (value == Attribute_value)
                        {
                            string data = xlRange.Cells[i][1 + 1].Value2;

                            x1workbook.Close(false, Type.Missing, Type.Missing);
                            x1app.Workbooks.Close();
                            Marshal.ReleaseComObject(x1workbook);

                            x1app.Quit();
                            GC.Collect();
                            Marshal.ReleaseComObject(x1app);
                            return data;
                        }
                }
            
            
            return null;
        }

        public static void CreateExcel(string Description, string Expected, string Status, string Date_Time)
        {
            try
            {
                Excel.Application x1app = new Excel.Application();
                Excel.Workbook x1workbook = x1app.Workbooks.Open(@"E:\Sourabh_C#\repo\Flight_project\Flight_project\TestResults\Excel_Reporter.xlsx");
                Excel.Worksheet x1sheet = x1workbook.Sheets[1];
                Excel.Range xlRange = x1sheet.UsedRange;
                

                string[] Attribute = new string[] {"Description", "Expected", "Status", "Date_Time" };
                    for (int i = 0; i <= Attribute.Count() - 1; i++)
                    {
                        xlRange.Cells.set_Item(1, i + 1, Attribute[i]);
                    }
                rowCount = xlRange.Rows.Count;
                string[] Attribute_value = new string[] { Description, Expected, Status, Date_Time };
                    for (int i = 0; i <= Attribute_value.Count() - 1; i++)
                    {
                        xlRange.Cells.set_Item(rowCount+1, i + 1, Attribute_value[i]);
                    }

                x1workbook.Save();
                x1workbook.Close();
                x1app.Quit();
                Marshal.ReleaseComObject(x1sheet);
                Marshal.ReleaseComObject(x1workbook);
                Marshal.ReleaseComObject(x1app);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
