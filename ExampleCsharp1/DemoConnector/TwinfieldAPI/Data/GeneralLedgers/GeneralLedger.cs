using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Relations;

namespace DemoConnector.TwinfieldAPI.Data.GeneralLedgers
{
    public class GeneralLedger : Relation
    {
        
        public GeneralLedger()
        {
            Beginperiod = 0;
            Beginyear = 0;
            Endperiod = 0;
            Endyear = 0;
            Financials = new Financials
            {
                Matchtype = MatchType.Notmatchable,
                Subanalyse = Subanalyse.Maybe,
                Accounttype = "balance",
                Level = 1
            };
        }


    }
   
}
