using System;
using System.Collections.Generic;
using DemoConnector.TwinfieldBankStatementService;

namespace DemoConnector.TwinfieldAPI.Data.NotImplemented.BankStatements
{
    public class BankStatements
    {
        public List<BankStatement> bankStatement { get; set; }
        public static BankStatements FromQueryResult(QueryResult queryResult)
        {
            var result = queryResult as GetBankStatementsResult;
            if (result == null)
            {
                return null;
            }
            else
            {
                var bankStatements = new List<BankStatement>();
                foreach (var r in result.BankStatements)
                {
                    var bankStatement = new BankStatement
                    {
                        Code = r.Code,
                        Number = r.Number,
                        SubId = r.SubId,
                        AccountNumber = r.AccountNumber,
                        Iban = r.Iban,
                        StatementDate = r.StatementDate,
                        Currency = r.Currency,
                        OpeningBalance = r.OpeningBalance,
                        ClosingBalance = r.ClosingBalance,
                        Lines = r.Lines,
                        TransactionNumber = r.TransactionNumber
                    };
                    bankStatements.Add(bankStatement);
                }

                return new BankStatements
                {
                    bankStatement = bankStatements
                };
            }
        }

    public class BankStatement
    {
        public string Code { get; set; }
        public int Number { get; set; }
        public int SubId { get; set; }
        public string AccountNumber { get; set; }
        public string Iban { get; set; }
        public DateTime StatementDate { get; set; }
        public string Currency { get; set; }
        public Decimal OpeningBalance { get; set; }
        public Decimal ClosingBalance { get; set; }
        public BankStatementLine[] Lines { get; set; }
        public Decimal? TransactionNumber { get; set; }

        
        }
    }

    

}
