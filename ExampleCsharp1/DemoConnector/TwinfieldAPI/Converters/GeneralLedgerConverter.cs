using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data.GeneralLedgers;
using DemoConnector.TwinfieldAPI.Data.Relations;
using Type = DemoConnector.TwinfieldAPI.Data.Relations.Type;

namespace DemoConnector.TwinfieldAPI.Converters
{
    public class GeneralLedgerConverter : IGeneralLedgerConverter
    {
        public GeneralLedger ConvertGeneralLedgerResponse(GeneralLedgerResponse generalLedgerResponse, string office)
        {
            Type type = Type.Sales;
            if (generalLedgerResponse.VatType == Type.Purchase.ToString().ToLower())
            {
                type = Type.Purchase;
            }

            var g = new GeneralLedger
            {
                Office = office,
                Code = generalLedgerResponse.Code,
                Name = generalLedgerResponse.Name,
                Financials = new Financials
                {
                    Matchtype = MatchType.Notmatchable,
                    Accounttype = "balance",
                    Level = 1,
                    Vatcode = new VatCode
                    {
                        Name = generalLedgerResponse.VatName,
                        Type = type
                    }
                }
            };
            return g;
        }

        public GeneralLedgerResponse ConvertGeneralLedger(GeneralLedger generalLedger)
        {
            return new GeneralLedgerResponse
            {
                Code = generalLedger.Code,
                Name = generalLedger.Name,
                VatName = generalLedger.Financials.Vatcode.Name,
                VatType = generalLedger.Financials.Vatcode.Type.ToString()
            };
        }
    }
}
