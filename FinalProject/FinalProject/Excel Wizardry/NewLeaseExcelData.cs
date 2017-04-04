using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Excel_Wizardry
{
    /// <summary>
    /// This class contains methods for interacting with data from the New Leases excel report.
    /// </summary>
    public class NewLeaseExcelData
    {
        /// <summary>
        /// Extracts cell data from the New Leases excel report and returns it as a dictionary object.
        /// </summary>
        /// <param name="fileLocation"></param>
        public Dictionary<int, NewLeaseBuilding> NewLeasesInitializeDictionary(FileInfo fileLocation)
        {
            Dictionary<int, NewLeaseBuilding> excelDictionary = new Dictionary<int, NewLeaseBuilding>();
            using (var pck = new ExcelPackage(fileLocation))
            {
                var worksheet = pck.Workbook.Worksheets[1];
                int row = 3;
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
                    NewLeaseBuilding building = new NewLeaseBuilding();
                    building.BuildingAbbreviation = columns[0];
                    building.PortfolioName = columns[1];
                    building.Status = columns[2];
                    building.AdvertisingStartDate = columns[3];
                    building.PropertyLeasedDate = columns[4];
                    building.RentAmountOnLease = columns[5];
                    building.ManagementBeginDate = Convert.ToDateTime(columns[6]);
                    excelDictionary[row] = building;
                } while (excelDictionary.Last().Value.BuildingAbbreviation != null);
                excelDictionary.Remove(row);
            }
            return excelDictionary;
        }
    }
}
