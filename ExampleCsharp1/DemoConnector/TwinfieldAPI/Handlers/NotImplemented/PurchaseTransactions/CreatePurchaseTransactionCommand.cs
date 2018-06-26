using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.PurchaseTransactions;

namespace DemoConnector.TwinfieldAPI.Handlers.NotImplemented.PurchaseTransactions
{
    public class CreatePurchaseTransactionCommand
    {
        public PurchaseTransaction PurchaseTransaction { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("transaction");
            createElement.SetAttribute("destiny", "temporary");
            createElement.SetAttribute("raisewarning", "false");
            var h1 = createElement.AppendNewElement("header");
            h1.AppendNewElement("code").InnerText = PurchaseTransaction.Header.Code;
            h1.AppendNewElement("currency").InnerText = PurchaseTransaction.Header.Currency;
            h1.AppendNewElement("date").InnerText = PurchaseTransaction.Header.Date;
            h1.AppendNewElement("period").InnerText = PurchaseTransaction.Header.Period;
            h1.AppendNewElement("invoicenumber").InnerText = PurchaseTransaction.Header.Invoicenumber;
            h1.AppendNewElement("paymentreference").InnerText = PurchaseTransaction.Header.Paymentreference;
            h1.AppendNewElement("office").InnerText = PurchaseTransaction.Header.Office;
            h1.AppendNewElement("duedays").InnerText = PurchaseTransaction.Header.Duedate;
            var l1 = createElement.AppendNewElement("lines");
            for (int i = 0; i < PurchaseTransaction.Line.Count; i++)
            {
                if (!PurchaseTransaction.Line[i].Equals(null) || PurchaseTransaction.Line[i] != null || !PurchaseTransaction.Line[i].Dim1.Equals("") || PurchaseTransaction.Line[i].Dim1 != "")
                {
                    var line = PurchaseTransaction.Line[i];
                    var l2 = l1.AppendNewElement("line");
                    l2.SetAttribute("id", (i + 1).ToString());
                    if (line.Type == "total")
                    {
                        l2.SetAttribute("type", "total");
                        l2.AppendNewElement("dim1").InnerText = line.Dim1;
                        l2.AppendNewElement("dim2").InnerText = line.Dim2;
                        l2.AppendNewElement("debitcredit").InnerText = line.Debitcredit;
                        l2.AppendNewElement("value").InnerText = line.Value;
                        l2.AppendNewElement("basevalue").InnerText = line.Basevalue;
                        l2.AppendNewElement("rate").InnerText = line.Rate;
                        l2.AppendNewElement("repvalue").InnerText = line.Repvalue;
                        l2.AppendNewElement("reprate").InnerText = line.Reprate;
                        l2.AppendNewElement("description").InnerText = line.Description;
                        l2.AppendNewElement("vattotal").InnerText = line.Vattotal;
                        l2.AppendNewElement("vatbasetotal").InnerText = line.Vatbasetotal;
                        l2.AppendNewElement("vatreptotal").InnerText = line.Vatreptotal;
                        l2.AppendNewElement("freechar").InnerText = line.Freechar;
                        l2.AppendNewElement("comment").InnerText = line.Comment;
                    }

                    if (line.Type == "detail")
                    {
                        l2.SetAttribute("type", "detail");
                        l2.AppendNewElement("dim1").InnerText = line.Dim1;
                        l2.AppendNewElement("dim2").InnerText = line.Dim2;
                        l2.AppendNewElement("dim3").InnerText = line.Dim3;
                        l2.AppendNewElement("debitcredit").InnerText = line.Debitcredit;
                        l2.AppendNewElement("value").InnerText = line.Value;
                        l2.AppendNewElement("basevalue").InnerText = line.Basevalue;
                        l2.AppendNewElement("rate").InnerText = line.Rate;
                        l2.AppendNewElement("repvalue").InnerText = line.Repvalue;
                        l2.AppendNewElement("reprate").InnerText = line.Reprate;
                        l2.AppendNewElement("description").InnerText = line.Description;
                        l2.AppendNewElement("vatcode").InnerText = line.Vatcode;
                        l2.AppendNewElement("vatbasevalue").InnerText = line.Vatbasevalue;
                        l2.AppendNewElement("vatrepvalue").InnerText = line.Vatrepvalue;
                        l2.AppendNewElement("destoffice").InnerText = line.Destoffice;
                        l2.AppendNewElement("freechar").InnerText = line.Freechar;
                        l2.AppendNewElement("comment").InnerText = line.Comment;
                    }

                    if (line.Type == "vat")
                    {
                        l2.SetAttribute("type", "vat");
                        l2.AppendNewElement("dim1").InnerText = line.Dim1;
                        l2.AppendNewElement("dim2").InnerText = line.Dim2;
                        l2.AppendNewElement("dim3").InnerText = line.Dim3;
                        l2.AppendNewElement("debitcredit").InnerText = line.Debitcredit;
                        l2.AppendNewElement("value").InnerText = line.Value;
                        l2.AppendNewElement("basevalue").InnerText = line.Basevalue;
                        l2.AppendNewElement("rate").InnerText = line.Rate;
                        l2.AppendNewElement("repvalue").InnerText = line.Repvalue;
                        l2.AppendNewElement("reprate").InnerText = line.Reprate;
                        l2.AppendNewElement("description").InnerText = line.Description;
                        l2.AppendNewElement("vatbaseturnover").InnerText = line.Vatbaseturnover;
                        l2.AppendNewElement("vatturnover").InnerText = line.Vatturnover;
                        l2.AppendNewElement("vatcode").InnerText = line.Vatcode;
                        l2.AppendNewElement("vatbasevalue").InnerText = line.Vatbasevalue;
                        l2.AppendNewElement("vatvalue").InnerText = line.Vatvalue;
                        l2.AppendNewElement("baseline").InnerText = line.Baseline;
                        l2.AppendNewElement("freechar").InnerText = line.Freechar;
                        l2.AppendNewElement("comment").InnerText = line.Comment;
                    }
                }
            }

            return command;
        }
    }
}
