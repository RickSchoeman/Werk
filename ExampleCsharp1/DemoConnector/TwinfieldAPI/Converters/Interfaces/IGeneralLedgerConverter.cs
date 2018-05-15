using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Data.GeneralLedgers;

namespace DemoConnector.TwinfieldAPI.Converters.Interfaces
{
    public interface IGeneralLedgerConverter
    {
        GeneralLedger ConvertGeneralLedgerResponse(GeneralLedgerResponse generalLedgerResponse, string office);
        GeneralLedgerResponse ConvertGeneralLedger(GeneralLedger generalLedger);
    }
}
