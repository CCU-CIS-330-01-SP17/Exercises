using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// Represents a building in the Terminated Leases Excel Report
    /// </summary>
    public class TerminatedLeaseBuilding
    {
        public string BuildingAbbreviation { get; set; }

        public string PortfolioAbbreviation { get; set; }

        public string PayeePayer { get; set; }

        public DateTime Date { get; set; }

        public double ChargeAmount { get; set; }

        public string AccountNumber { get; set; }

        public string AccountDescription { get; set; }

        public override string ToString()
        {
            return "BuildingAbbreviation: " + BuildingAbbreviation + "   PortfolioAbbreviation: " + PortfolioAbbreviation + "   Payee/Payer: " + PayeePayer +
                "   Date: " + Date + "   ChargeAmount: " + ChargeAmount + "   AccountNumber: " + AccountNumber + "   AccountDescription: " + AccountDescription;
        }
    }
}
