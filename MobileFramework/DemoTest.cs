using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace MobileFramework
{
    [TestClass]
    public class DemoTest
    {
        [TestMethod]
        public void ReadExcel()
        {
            XLWorkbook book=new XLWorkbook(@"C:\Components\KhanData.xlsx");

            var sheet= book.Worksheet("InvalidCredentialTest");
            var range= sheet.RangeUsed();

            int rowCount=range.RowCount();
            int columnCount=range.ColumnCount();
            
            for(int r = 2; r <= rowCount; r++)
            {

                string[] main = new string[columnCount];
                for (int c = 1; c <= columnCount; c++)
                {
                    string cellValue = range.Cell(r, c).GetString();
                    Console.WriteLine(cellValue);
                    main[c - 1] = cellValue;
                }
            }

            book.Dispose(); 
        }

        [TestMethod]
        public void TestM()
        {
            int a = 10;
            double b = 20.5;
            string c = "hell";

            object z = a;
            z = b;
            z = c; //boxing 
            z = a;

            int result = (int)z; //unboxing

        }
    }
}
