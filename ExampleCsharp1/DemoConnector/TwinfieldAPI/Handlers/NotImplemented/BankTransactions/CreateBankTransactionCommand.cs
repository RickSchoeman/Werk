using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.BankTransactions;

namespace DemoConnector.TwinfieldAPI.Handlers.NotImplemented.BankTransactions
{
    public class CreateBankTransactionCommand
    {
        public BankTransaction BankTransaction { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("transaction");
            createElement.SetAttribute("destiny", "temporary");
            var h1 = createElement.AppendNewElement("header");
            h1.AppendNewElement("office").InnerText = BankTransaction.Header.Office;
            h1.AppendNewElement("code").InnerText = BankTransaction.Header.Code;
            h1.AppendNewElement("currency").InnerText = BankTransaction.Header.Currency;
            h1.AppendNewElement("date").InnerText = BankTransaction.Header.Date;
            h1.AppendNewElement("statementnumber").InnerText = BankTransaction.Header.Statementnumber;
            h1.AppendNewElement("startvalue").InnerText = BankTransaction.Header.Startvalue;
            h1.AppendNewElement("closevalue").InnerText = BankTransaction.Header.Closevalue;
            var l1 = createElement.AppendNewElement("lines");
            for (int i = 0; i < BankTransaction.Lines.Line.Count; i++)
            {
                if (!BankTransaction.Lines.Line[i].Equals(null) || BankTransaction.Lines.Line[i] != null || !BankTransaction.Lines.Line[i].Dim1.Equals("") || BankTransaction.Lines.Line[i].Dim1 != "")
                {
                    var line = BankTransaction.Lines.Line[i];
                    var l2 = l1.AppendNewElement("line");
                    l2.SetAttribute("id", (i + 1).ToString());
                    if (line.Type == "total")
                    {
                        l2.SetAttribute("type", "total");
                        l2.AppendNewElement("dim1").InnerText = line.Dim1;
                        l2.AppendNewElement("debitcredit").InnerText = line.Debitcredit;
                        l2.AppendNewElement("basevalue").InnerText = line.Basevalue;
                        l2.AppendNewElement("rate").InnerText = line.Rate;
                        l2.AppendNewElement("value").InnerText = line.Value;
                        l2.AppendNewElement("reprate").InnerText = line.Reprate;
                        l2.AppendNewElement("repvalue").InnerText = line.Repvalue;
                        l2.AppendNewElement("description").InnerText = line.Description;
                        l2.AppendNewElement("vatbasetotal").InnerText = line.Vatbasetotal;
                        l2.AppendNewElement("freechar").InnerText = line.Freechar;
                        l2.AppendNewElement("comment").InnerText = line.Comment;
                    }

                    if (line.Type == "detail")
                    {
                        l2.SetAttribute("type", "detail");
                        l2.AppendNewElement("dim1").InnerText = line.Dim1;
                        l2.AppendNewElement("dim2").InnerText = line.Dim2;
                        l2.AppendNewElement("debitcredit").InnerText = line.Debitcredit;
                        l2.AppendNewElement("basevalue").InnerText = line.Basevalue;
                        l2.AppendNewElement("rate").InnerText = line.Rate;
                        l2.AppendNewElement("value").InnerText = line.Value;
                        l2.AppendNewElement("reprate").InnerText = line.Reprate;
                        l2.AppendNewElement("repvalue").InnerText = line.Repvalue;
                        l2.AppendNewElement("currencydate").InnerText = line.Currencydate;
                        l2.AppendNewElement("description").InnerText = line.Description;
                        l2.AppendNewElement("freechar").InnerText = line.Freechar;
                        l2.AppendNewElement("comment").InnerText = line.Comment;
                    }

                    if (line.Type == "vat")
                    {
                        l2.SetAttribute("type", "vat");
                        l2.AppendNewElement("dim1").InnerText = line.Dim1;
                        l2.AppendNewElement("debitcredit").InnerText = line.Debitcredit;
                        l2.AppendNewElement("basevalue").InnerText = line.Basevalue;
                        l2.AppendNewElement("rate").InnerText = line.Rate;
                        l2.AppendNewElement("value").InnerText = line.Value;
                        l2.AppendNewElement("reprate").InnerText = line.Reprate;
                        l2.AppendNewElement("repvalue").InnerText = line.Repvalue;
                        l2.AppendNewElement("vatbaseturnover").InnerText = line.Vatbaseturnover;
                        l2.AppendNewElement("vatturnover").InnerText = line.Vatturnover;
                        l2.AppendNewElement("vatcode").InnerText = line.Vatcode;
                        l2.AppendNewElement("vatbasevalue").InnerText = line.Vatbasevalue;
                        l2.AppendNewElement("freechar").InnerText = line.Freechar;
                        l2.AppendNewElement("comment").InnerText = line.Comment;
                    }
                }
            }

            return command;
        }
    }
}
