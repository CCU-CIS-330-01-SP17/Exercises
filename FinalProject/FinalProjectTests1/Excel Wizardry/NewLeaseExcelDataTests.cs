using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProject.Excel_Wizardry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProject.Excel_Wizardry.Tests
{
    /// <summary>
    /// This class contains all methods for testing the <see cref="NewLeaseExcelData"/> class.
    /// </summary>
    [TestClass()]
    public class NewLeaseExcelDataTests
    {
        [TestMethod()]
        public void NewLeasesInitializeDictionaryTest()
        {
            Dictionary<int, NewLeaseBuilding> excelDictionary = new NewLeaseExcelData().NewLeasesInitializeDictionary
                (new FileInfo(@"C: \Users\Chris\Desktop\FinalProgramExcel\Rent Amount for New Leases.xlsx"));
            foreach (var entry in excelDictionary)
            {
                Console.WriteLine("Row: {0}, Data: {1}",
                    entry.Key, entry.Value);
            }
        }
    }
}