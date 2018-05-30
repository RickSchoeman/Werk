using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Data.Dimensions;
using DemoConnector.TwinfieldAPI.Data.GeneralLedgers;

namespace DemoConnector.TwinfieldAPI.Handlers.Interfaces
{
    public interface IGeneralLedgerInterface
    {
        List<GeneralLedger> GetBalanceSheetByName(string name);
        List<GeneralLedger> GetAllBalanceSheet();
        List<GeneralLedger> GetProfitLossByName(string name);
        List<GeneralLedger> GetAllProfitLoss();
        List<DimensionSummary> GetBalanceSheetSummaries();
        List<DimensionSummary> GetProfitLossSummaries();
        GeneralLedger ReadBalanceSheet(string code);
        GeneralLedger ReadProfitLoss(string code);
        string Create(GeneralLedger generalLedger);
        string Delete(GeneralLedger generalLedger);
        string Activate(GeneralLedger generalLedger);
    }
}
