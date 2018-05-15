using System.Collections.Generic;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Data.SalesInvoice
{
    public class SalesInvoice
    {
        internal static SalesInvoice FromXml(XmlElement element)
        {
            bool allowDiscountorPremium = false;
            PerformanceType? performanceTypeLine = PerformanceType.Goods;
            PerformanceType? performanceTypeVat = PerformanceType.Goods;
            Status status = Status.Default;
            PaymentMethod? paymentMethod = PaymentMethod.Bank;
            int invoiceAddressNumber;
            int deleverAddressNumber;
            int invoiceNumber;
            int quantity;
            int units;
            
            var lines = new List<Line>();
            XmlNodeList elemListLine = element.GetElementsByTagName("line");
            for (int i = 0; i < elemListLine.Count; i++)
            {
                if (elemListLine[i].SelectInnerText("article") != null)
                {
                    if (elemListLine[i].SelectInnerText("allowdiscountorpremium") == "true")
                    {
                        allowDiscountorPremium = true;
                    }

                    if (elemListLine[i].SelectInnerText("performancetype") == PerformanceType.Services.ToString().ToLower())
                    {
                        performanceTypeLine = PerformanceType.Services;
                    }

                    if (string.IsNullOrEmpty(elemListLine[i].SelectInnerText("performancetype")))
                    {
                        performanceTypeLine = null;
                    }

                    int.TryParse(elemListLine[i].SelectInnerText("quantity"), out quantity);
                    int.TryParse(elemListLine[i].SelectInnerText("units"), out units);

                    var line = new Line
                    {
                        Article = elemListLine[i].SelectInnerText("article"),
                        Subarticle = elemListLine[i].SelectInnerText("subarticle"),
                        Quantity = quantity,
                        Units = units,
                        Unitspriceexcl = elemListLine[i].SelectInnerText("unitspriceexcl"),
                        Unitspriceinc = elemListLine[i].SelectInnerText("unitspriceinc"),
                        Vatcode = elemListLine[i].SelectInnerText("vatcode"),
                        Allowdiscountorpremium = allowDiscountorPremium,
                        Description = elemListLine[i].SelectInnerText("description"),
                        Performancedate = elemListLine[i].SelectInnerText("performancedate"),
                        Performancetype = performanceTypeLine,
                        Freetext1 = elemListLine[i].SelectInnerText("freetext1"),
                        Freetext2 = elemListLine[i].SelectInnerText("freetext2"),
                        Freetext3 = elemListLine[i].SelectInnerText("freetext3"),
                        Dim1 = elemListLine[i].SelectInnerText("dim1"),
                        Valueexcl = elemListLine[i].SelectInnerText("valueexcl"),
                        Vatvalue = elemListLine[i].SelectInnerText("vatvalue"),
                        Valueinc = elemListLine[i].SelectInnerText("valueinc")
                    };
                    lines.Add(line);
                }
            }
            var vatlines = new List<Vatline>();
            XmlNodeList elemListVatLine = element.GetElementsByTagName("vatline");
            for (int i = 0; i < elemListVatLine.Count; i++)
            {
                if (elemListVatLine[i].SelectInnerText("vatcode") != null)
                {
                    if (elemListVatLine[i].SelectInnerText("performancetype") == PerformanceType.Services.ToString().ToLower())
                    {
                        performanceTypeVat = PerformanceType.Services;
                    }

                    if (string.IsNullOrEmpty(elemListVatLine[i].SelectInnerText("performancetype")))
                    {
                        performanceTypeVat = null;
                    }

                    var vatLine = new Vatline
                    {
                        Vatcode = elemListVatLine[i].SelectInnerText("vatcode"),
                        Vatvalue = elemListVatLine[i].SelectInnerText("vatvalue"),
                        Performancetype = performanceTypeVat,
                        Performancedate = elemListVatLine[i].SelectInnerText("performancedate")
                    };
                    vatlines.Add(vatLine);
                }
            }

            if (element.SelectInnerText("header/status") == Status.Concept.ToString().ToLower())
            {
                status = Status.Concept;
            }

            if (element.SelectInnerText("header/status") == Status.Final.ToString().ToLower())
            {
                status = Status.Final;
            }

            if (element.SelectInnerText("header/paymentmethod") == PaymentMethod.Cash.ToString().ToLower())
            {
                paymentMethod = PaymentMethod.Cash;
            }

            if (element.SelectInnerText("header/paymentmethod") == PaymentMethod.Cashondelivery.ToString().ToLower())
            {
                paymentMethod = PaymentMethod.Cashondelivery;
            }

            if (element.SelectInnerText("header/paymentmethod") == PaymentMethod.Cheque.ToString().ToLower())
            {
                paymentMethod = PaymentMethod.Cheque;
            }

            if (element.SelectInnerText("header/paymentmethod") == PaymentMethod.Da.ToString().ToLower())
            {
                paymentMethod = PaymentMethod.Da;
            }

            if (string.IsNullOrWhiteSpace(element.SelectInnerText("header/paymentmethod")))
            {
                paymentMethod = null;
            }

            int.TryParse(element.SelectInnerText("header/invoiceaddressnumber"), out invoiceAddressNumber);
            int.TryParse(element.SelectInnerText("header/deliveraddressnumber"), out deleverAddressNumber);
            int.TryParse(element.SelectInnerText("header/invoicenumber"), out invoiceNumber);

            var salesInvoice =  new SalesInvoice
            {
                Header = new Header
                {
                    Office = element.SelectInnerText("header/office"),
                    Invoicetype = element.SelectInnerText("header/invoicetype"),
                    Invoicedate = element.SelectInnerText("header/invoicedate"),
                    Duedate = element.SelectInnerText("header/duedate"),
                    Bank = element.SelectInnerText("header/bank"),
                    Customer = element.SelectInnerText("header/customer"),
                    Period = element.SelectInnerText("header/period"),
                    Currency = element.SelectInnerText("header/currency"),
                    Status = status,
                    Paymentmethod = paymentMethod,
                    Invoiceaddressnumber = invoiceAddressNumber,
                    Deliveraddressnumber = deleverAddressNumber,
                    Headertext = element.SelectInnerText("header/headertext"),
                    Footertext = element.SelectInnerText("header/footertext"),
                    Invoicenumber = invoiceNumber
                },
                Lines = new Lines
                {
                    Line = lines
                },
                Totals = new Totals
                {
                    Valueexcl = element.SelectInnerText("totals/valueexcl"),
                    Valueinc = element.SelectInnerText("totals/valueinc")
                },
                Vatlines = new Vatlines
                {
                    Vatline = vatlines
                }
            };
            if (element.SelectInnerText("header/status") == "final")
            {
                salesInvoice.Financials = new Financials
                {
                    Code = element.SelectInnerText("financials/code"),
                    Number = int.Parse(element.SelectInnerText("financials/number"))
                };
            }
            return salesInvoice;
        }
        public Header Header { get; set; }
        public Lines Lines { get; set; }
        public Totals Totals { get; set; }
        public Vatlines Vatlines { get; set; }
        public Financials Financials { get; set; }


        public SalesInvoice()
        {
            Header = new Header
            {
                Invoicetype = "FACTUUR",
                Status = Status.Concept,
                
            };
            Vatlines = new Vatlines
            {
                Vatline = new List<Vatline>()
            };
        }
    }

    public class Header
    {
        public string Office { get; set; }
        public string Invoicetype { get; set; }
        public string Invoicedate { get; set; }
        public string Duedate { get; set; }
        public string Bank { get; set; }
        public string Customer { get; set; }
        public string Period { get; set; }
        public string Currency { get; set; }
        public Status Status { get; set; }
        public PaymentMethod? Paymentmethod { get; set; }
        public int Invoiceaddressnumber { get; set; }
        public int Deliveraddressnumber { get; set; }
        public string Headertext { get; set; }
        public string Footertext { get; set; }
        public int Invoicenumber { get; set; }

        public string InvoiceTypeAndNumber
        {
            get { return Invoicetype + "," + Invoicenumber; }
        }
    }

    public enum Status
    {
        Default,
        Concept,
        Final
    }

    public enum PaymentMethod
    {
        Cash,
        Bank,
        Cheque,
        Cashondelivery,
        Da
    }
    
    
    public class Line
    {
        public string Article { get; set; }
        public string Subarticle { get; set; }
        public int Quantity { get; set; }
        public int Units { get; set; }
        public string Unitspriceexcl { get; set; }
        public string Unitspriceinc { get; set; }
        public string Vatcode { get; set; }
        public bool Allowdiscountorpremium { get; set; }
        public string Description { get; set; }
        public string Performancedate { get; set; }
        public PerformanceType? Performancetype { get; set; }
        public string Freetext1 { get; set; }
        public string Freetext2 { get; set; }
        public string Freetext3 { get; set; }
        public string Dim1 { get; set; }
        public string Valueexcl { get; set; }
        public string Vatvalue { get; set; }
        public string Valueinc { get; set; }
        public int Id { get; set; }
    }

    public enum PerformanceType
    {
        Services,
        Goods
    }

    public class Lines
    {
        public List<Line> Line { get; set; }
    }
    
    public class Totals
    {
        public string Valueexcl { get; set; }
        public string Valueinc { get; set; }
    }
    
    public class Vatline
    {
        public string Vatcode { get; set; }
        public string Vatvalue { get; set; }
        public PerformanceType? Performancetype { get; set; }
        public string Performancedate { get; set; }
    }
    
    public class Vatlines
    {
        public List<Vatline> Vatline { get; set; }
    }

    public class Financials
    {
        public string Code { get; set; }
        public int Number { get; set; }
    }

}
