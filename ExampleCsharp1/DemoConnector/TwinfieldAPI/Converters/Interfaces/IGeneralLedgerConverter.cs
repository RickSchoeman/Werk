using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Data.BalanceSheet;
using DemoConnector.TwinfieldAPI.Data.GeneralLedgers;
using DemoConnector.TwinfieldAPI.Data.ProfitLoss;

namespace DemoConnector.TwinfieldAPI.Converters.Interfaces
{
    public interface IGeneralLedgerConverter
    {
        BalanceSheet ConvertGeneralLedgerResponseToBalanceSheet(GeneralLedgerResponse generalLedgerResponse, string office);
        ProfitLoss ConvertGeneralLedgerResponseToProfitLoss(GeneralLedgerResponse generalLedgerResponse, string office);
        GeneralLedgerResponse ConvertBalanceSheet(BalanceSheet generalLedger);
        GeneralLedgerResponse ConvertProfitLoss(ProfitLoss generalLedger);
    }
}
