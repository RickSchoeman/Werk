using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.BankStatements;


namespace Demo
{
    class BankStatementDemo
    {
        private readonly BankStatementService bankStatementService;

        public BankStatementDemo(Session session)
        {
            bankStatementService = new BankStatementService(session);
        }

        public void Run()
        {
            Console.WriteLine("Read bank statement");
            var bankStatements = bankStatementService.FindBankBook(new DateTime(2000, 3, 15), DateTime.Now, true);
            if (bankStatements == null)
            {
                Console.WriteLine("Bank statement not found");
            }
            else
            {
                foreach (var bankStatement in bankStatements.bankStatement)
                {
                    Console.WriteLine("Bank Statement found");
                    Console.WriteLine("code = {0}", bankStatement.Code);
                    Console.WriteLine("number = {0}", bankStatement.Number);
                    Console.WriteLine("subid = {0}", bankStatement.SubId);
                    Console.WriteLine("accountnumber = {0}", bankStatement.AccountNumber);
                    Console.WriteLine("iban = {0}", bankStatement.Iban);
                    Console.WriteLine("statementdate = {0}", bankStatement.StatementDate);
                    Console.WriteLine("currency = {0}", bankStatement.Currency);
                    Console.WriteLine("openingbalance = {0}", bankStatement.OpeningBalance);
                    Console.WriteLine("closingbalance = {0}", bankStatement.ClosingBalance);
                    Console.WriteLine();
                    foreach (var line in bankStatement.Lines)
                    {
                        Console.WriteLine("line:");
                        Console.WriteLine("lineid = {0}", line.LineId);
                        Console.WriteLine("contra account number = {0}", line.ContraAccountNumber);
                        Console.WriteLine("contraiban = {0}", line.ContraIban);
                        Console.WriteLine("contra account name = {0}", line.ContraAccountName);
                        Console.WriteLine("paymentreference = {0}", line.PaymentReference);
                        Console.WriteLine("amount = {0}", line.Amount);
                        Console.WriteLine("baseamount = {0}", line.BaseAmount);
                        Console.WriteLine("description = {0}", line.Description);
                        Console.WriteLine("transactiontypeid = {0}", line.TransactionTypeId);
                        Console.WriteLine("reference = {0}", line.Reference);
                        Console.WriteLine("endtoendid = {0}", line.EndToEndId);
                        Console.WriteLine("returnreason = {0}", line.ReturnReason);
                        Console.WriteLine("recognition = {0}", line.Recognition);
                        Console.WriteLine();
                        foreach (var method in line.AllocationMethods)
                        {
                            Console.WriteLine("Allocation method:");
                            Console.WriteLine("type = {0}", method.Type);
                            Console.WriteLine("text = {0}", method.Text);
                            Console.WriteLine("amountoperator = {0}", method.AmountOperator);
                            Console.WriteLine("amount = {0}", method.Amount);
                            Console.WriteLine();
                        }

                        foreach (var allocation in line.Allocations)
                        {
                            Console.WriteLine("Allocation:");
                            Console.WriteLine("type = {0}", allocation.Type);
                            Console.WriteLine("amount = {0}", allocation.Amount);
                            Console.WriteLine("baseamount = {0}", allocation.BaseAmount);
                            Console.WriteLine("sense = {0}", allocation.Sense);
                            Console.WriteLine("dimension1 = {0}", allocation.Dimension1);
                            Console.WriteLine("dimension2 = {0}", allocation.Dimension2);
                            Console.WriteLine("dimension3 = {0}", allocation.Dimension3);
                            Console.WriteLine("dimension4 = {0}", allocation.Dimension4);
                            Console.WriteLine("dimension5 = {0}", allocation.Dimension5);
                            Console.WriteLine("dimension6 = {0}", allocation.Dimension6);
                            Console.WriteLine("descriptionformat = {0}", allocation.DescriptionFormat);
                            Console.WriteLine("savedescriptionformattoallocationrule = {0}", allocation.SaveDescriptionFormatToAllocationRule);
                            Console.WriteLine("chequenumber = {0}", allocation.ChequeNumber);
                            Console.WriteLine("payinginslipnumber = {0}", allocation.PayingInSlipNumber);
                            Console.WriteLine();
                            foreach (var vatline in allocation.VatLines)
                            {
                                Console.WriteLine("Vatline:");
                                Console.WriteLine("code = {0}", vatline.Code);
                                Console.WriteLine("turnover = {0}", vatline.Turnover);
                                Console.WriteLine("value = {0}", vatline.Value);
                                Console.WriteLine("valueoverridden = {0}", vatline.ValueOverridden);
                                Console.WriteLine();
                            }

                            foreach (var matching in allocation.Matchings)
                            {
                                Console.WriteLine("Matching:");
                                Console.WriteLine("basevalue = {0}", matching.BaseValue);
                                Console.WriteLine("lineid = {0}", matching.LineId);
                                Console.WriteLine("code = {0}", matching.Code);
                                Console.WriteLine("number = {0}", matching.Number);
                                Console.WriteLine();
                            }
                        }
                    }
                    
                    Console.WriteLine("transactionnumber = {0}", bankStatement.TransactionNumber);
                    Console.WriteLine();
                }
            }
        }
    }
}
