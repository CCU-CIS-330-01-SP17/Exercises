using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProject.Excel_Wizardry.Tests
{
    /// <summary>
    /// This class contains all methods for testing the <see cref="TerminatedLeaseExcelData"/> class.
    /// </summary>
    [TestClass()]
    public class TerminatedLeasesExcelDataTests
    {
        [TestMethod()]
        public void TerminatedLeasesInitalizeDictionaryTest()
        {
            Dictionary<int, TerminatedLeaseBuilding> excelDictionary = new TerminatedLeaseExcelData().TerminatedLeasesInitializeDictionary
                (new FileInfo(@"C: \Users\Chris\Desktop\FinalProgramExcel\Rent_for_Terminated_Leases_2.xlsx"));
            foreach (var entry in excelDictionary)
            {
                Console.WriteLine("Row: {0}, Data: {1}",
                    entry.Key, entry.Value);
            }
        }

        [TestMethod()]
        public void TerminatedLeasesRemoveDuplicatesTest()
        {
            Dictionary<int, TerminatedLeaseBuilding> excelDictionary = new TerminatedLeaseExcelData().TerminatedLeasesInitializeDictionary
                (new FileInfo(@"C: \Users\Chris\Desktop\FinalProgramExcel\Rent_for_Terminated_Leases_2.xlsx"));
            Dictionary<int, TerminatedLeaseBuilding> excelDictionaryNoDuplicates = new TerminatedLeaseExcelData().TerminatedLeasesRemoveDuplicates(excelDictionary);
            foreach (var entry in excelDictionaryNoDuplicates)
            {
                Console.WriteLine("Row: {0}, Data: {1}",
                    entry.Key, entry.Value);
            }

        }
    }
}