using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.TransactionBlockedValue;

namespace Demo
{
    class TransactionBlockedValueDemo
    {
        private readonly TransactionBlockedValueService transactionBlockedValueService;

        public TransactionBlockedValueDemo(Session session)
        {
            transactionBlockedValueService = new TransactionBlockedValueService(session);
        }

        public void Run()
        {
            transactionBlockedValueService.RegisterBlockedAmountForTransAction("NLA000218", "INK", 001, 1, 2000);
            transactionBlockedValueService.UnregisterBlockedAmountForTransaction("NLA000218", "INK", 001, 1);
        }
    }
}
