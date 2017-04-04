using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinalProject
{
    /// <summary>
    /// This class contains methods for interacting with data from the Terminated Leases excel report.
    /// </summary>
    public class TerminatedLeaseExcelData
    {
        /// <summary>
        /// Extracts cell data from the Terminated Leases excel report and returns it as a dictionary object.
        /// </summary>
        /// <param name="fileLocation"></param>
        public Dictionary<int, TerminatedLeaseBuilding> TerminatedLeasesInitializeDictionary(FileInfo fileLocation)
        {
            Dictionary<int, TerminatedLeaseBuilding> excelDictionary = new Dictionary<int, TerminatedLeaseBuilding>();
            using (var pck = new ExcelPackage(fileLocation))
            {
                var worksheet = pck.Workbook.Worksheets[1];
                int row = 8;
                do
                {
                    row++;
                    var query1 = (from cell in worksheet.Cells[string.Format("A{0}:G{0}", row)] select cell);
                    int i = 0;
                    string[] columns = new string[7];
                    foreach (var cell in query1)
                    {
                        columns[i] = cell.Value.ToString();
                        i++;
                    }
                    TerminatedLeaseBuilding building = new TerminatedLeaseBuilding();
                    building.BuildingAbbreviation = columns[0];
                    building.PortfolioAbbreviation = columns[1];
                    building.PayeePayer = columns[2];
                    building.Date = Convert.ToDateTime(columns[3]);
                    building.ChargeAmount = Convert.ToDouble(columns[4]);
                    building.AccountNumber = columns[5];
                    building.AccountDescription = columns[6];
                    excelDictionary[row] = building;
                } while (excelDictionary.Last().Value.BuildingAbbreviation!= null);
                excelDictionary.Remove(row);
            }
            return excelDictionary;
        }

        /// <summary>
        /// Takes a Terminated Leases dictionary object, removes duplicate pairs, and returnes a new dictionary
        /// </summary>
        /// <param name="dictionary"></param>
        public Dictionary<int, TerminatedLeaseBuilding> TerminatedLeasesRemoveDuplicates(Dictionary<int, TerminatedLeaseBuilding> dictionary)
        {
            var uniqueValues = dictionary.
                OrderByDescending(pair => pair.Value.ChargeAmount)
                .GroupBy(pair => pair.Value.BuildingAbbreviation)
                .Select(group => group.First())
                .OrderBy(group=> group.Key)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
            return uniqueValues;
        }
    }
}