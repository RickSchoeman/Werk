using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.TwinfieldCashBookService;

namespace TwinfieldApi.CashBooks
{
    public class CashBook
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string GeneralLedgerAccount { get; set; }

        public static CashBook FromQueryResult(string cashCode, QueryResult queryResult)
        {
            var result = queryResult as GetCashBookResult;
            if (result == null)
            {
                return null;
            }
            return new CashBook
            {
                Name = result.Name,
                ShortName = result.ShortName,
                GeneralLedgerAccount = result.GeneralLedgerAccount
            };
        }
    }
}
