using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data.BalanceSheet;
using DemoConnector.TwinfieldAPI.Data.GeneralLedgers;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.Relations;
using DemoConnector.TwinfieldAPI.Data.ProfitLoss;
using Type = DemoConnector.TwinfieldAPI.Data.NotImplemented.Relations.Type;

namespace DemoConnector.TwinfieldAPI.Converters
{
    

    public class GeneralLedgerConverter : IGeneralLedgerConverter
    {
        public BalanceSheet ConvertGeneralLedgerResponseToBalanceSheet(GeneralLedgerResponse generalLedgerResponse, string office)
        {
            Type type = Type.Sales;
            if (generalLedgerResponse.VatType == Type.Purchase.ToString().ToLower())
            {
                type = Type.Purchase;
            }

            var g = new BalanceSheet
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
            g.Type = generalLedgerResponse.Type;
            return g;
        }

        public ProfitLoss ConvertGeneralLedgerResponseToProfitLoss(GeneralLedgerResponse generalLedgerResponse, string office)
        {
            Type type = Type.Sales;
            if (generalLedgerResponse.VatType == Type.Purchase.ToString().ToLower())
            {
                type = Type.Purchase;
            }

            var g = new ProfitLoss
            {
                Office = office,
                Code = generalLedgerResponse.Code,

                Name = generalLedgerResponse.Name,
                Financials = new Financials
                {
                    Matchtype = MatchType.Notmatchable,
                    Accounttype = "balance",
                    Level = 1
                }
            };
            var fin = new VatCode();
            fin.Name = generalLedgerResponse.VatName;
            fin.Type = type;
            g.Type = generalLedgerResponse.Type;
            return g;
        }

        public GeneralLedgerResponse ConvertBalanceSheet(BalanceSheet generalLedger)
        {
            var glr = new GeneralLedgerResponse
            {
                Code = generalLedger.Code,
                Name = generalLedger.Name,
                VatName = generalLedger.Financials.Vatcode.Name,
                VatType = generalLedger.Financials.Vatcode.Type.ToString()
            };
            glr.Type = generalLedger.Type;
            return glr;
        }

        public GeneralLedgerResponse ConvertProfitLoss(ProfitLoss generalLedger)
        {
            var glr = new GeneralLedgerResponse
            {
                Code = generalLedger.Code,
                Name = generalLedger.Name,
                VatName = generalLedger.Financials.Vatcode.Name,
                VatType = generalLedger.Financials.Vatcode.Type.ToString()
            };
            glr.Type = generalLedger.Type;
            return glr;
        }
    }
}
