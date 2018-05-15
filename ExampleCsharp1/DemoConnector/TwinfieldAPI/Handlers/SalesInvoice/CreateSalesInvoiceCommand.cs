using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Handlers.SalesInvoice
{
    public class CreateSalesInvoiceCommand
    {
        public DemoConnector.TwinfieldAPI.Data.SalesInvoice.SalesInvoice SalesInvoice { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("salesinvoice");
            var h1 = createElement.AppendNewElement("header");
            h1.AppendNewElement("office").InnerText = SalesInvoice.Header.Office;
            h1.AppendNewElement("invoicetype").InnerText = SalesInvoice.Header.Invoicetype;
            h1.AppendNewElement("invoicedate").InnerText = SalesInvoice.Header.Invoicedate;
            h1.AppendNewElement("duedate").InnerText = SalesInvoice.Header.Duedate;
            h1.AppendNewElement("bank").InnerText = SalesInvoice.Header.Bank;
            h1.AppendNewElement("customer").InnerText = SalesInvoice.Header.Customer;
            h1.AppendNewElement("period").InnerText = SalesInvoice.Header.Period;
            h1.AppendNewElement("currency").InnerText = SalesInvoice.Header.Currency;
            h1.AppendNewElement("status").InnerText = SalesInvoice.Header.Status.ToString();
            h1.AppendNewElement("paymentmethod").InnerText = SalesInvoice.Header.Paymentmethod.ToString();
            var l1 = createElement.AppendNewElement("lines");
            for (int i = 0; i < SalesInvoice.Lines.Line.Count; i++)
            {
                if (!SalesInvoice.Lines.Line[i].Equals(null) || SalesInvoice.Lines.Line[i] != null || !SalesInvoice.Lines.Line[i].Article.Equals("") || SalesInvoice.Lines.Line[i].Article != "")
                {
                    var line = SalesInvoice.Lines.Line[i];
                    var l2 = l1.AppendNewElement("line");
                    l2.SetAttribute("id", (i + 1).ToString());
                    l2.AppendNewElement("article").InnerText = line.Article;
                    l2.AppendNewElement("subarticle").InnerText = line.Subarticle;
                    l2.AppendNewElement("quantity").InnerText = line.Quantity.ToString();
                    l2.AppendNewElement("units").InnerText = line.Units.ToString();
                    l2.AppendNewElement("unitspriceexcl").InnerText = line.Unitspriceexcl;
                }
            }

            return command;
        }
    }
}
