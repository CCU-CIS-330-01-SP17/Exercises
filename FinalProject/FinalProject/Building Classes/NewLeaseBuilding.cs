using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Represents a building in the New Leases Excel Report
    /// </summary>
    public class NewLeaseBuilding
    {
        public string BuildingAbbreviation { get; set; }

        public string PortfolioName { get; set; }

        public string Status { get; set; }

        public string AdvertisingStartDate { get; set; }

        public string PropertyLeasedDate { get; set; }

        public string RentAmountOnLease { get; set; }

        public DateTime ManagementBeginDate { get; set; }

        public override string ToString()
        {
            return "BuildingAbbreviation " + BuildingAbbreviation + "   PortfolioName " + PortfolioName + "   Status" + Status +
                "   AdvertisingStartDate" + AdvertisingStartDate + "   PropertyLeasedDate" + PropertyLeasedDate +
                "   RentAmountOnLease" + RentAmountOnLease + "   ManagementBeginDate" + ManagementBeginDate;
        }
    }
}
