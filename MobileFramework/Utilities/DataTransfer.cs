using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFramework.Utilities
{
    public class DataTransfer
    {
        public static IEnumerable<object[]> SheetToObject()
        {
            return ExcelUtils.GetSheetData(@"C:\Components\KhanData.xlsx", "InvalidCredentialTest");
        }
    }
}
