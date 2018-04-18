using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.PurchaseTransactions
{
    public class PurchaseTransaction
    {
        internal static PurchaseTransaction FromXml(XmlElement element)
        {
            var lines = new List<Line>();
            XmlNodeList elemList = element.GetElementsByTagName("line");
            for (int i = 0; i < elemList.Count; i++)
            {
                if (elemList[i].Attributes["type"].Value != null)
                {
                    if (!elemList[i].Equals(null) || elemList[i] != null ||
                        !elemList[i].SelectInnerText("dim1").Equals("") || elemList[i].SelectInnerText("dim1") != "")
                    {
                        var line = new Line
                        {
                            Type = elemList[i].Attributes["type"].Value,
                            Dim1 = elemList[i].SelectInnerText("dim1"),
                            Dim2 = elemList[i].SelectInnerText("dim2"),
                            Dim3 = elemList[i].SelectInnerText("dim3"),
                            Dim4 = elemList[i].SelectInnerText("dim4"),
                            Dim5 = elemList[i].SelectInnerText("dim5"),
                            Dim6 = elemList[i].SelectInnerText("dim6"),
                            Debitcredit = elemList[i].SelectInnerText("debitcredit"),
                            Value = elemList[i].SelectInnerText("value"),
                            Basevalue = elemList[i].SelectInnerText("basevalue"),
                            Rate = elemList[i].SelectInnerText("rate"),
                            Repvalue = elemList[i].SelectInnerText("repvalue"),
                            Reprate = elemList[i].SelectInnerText("reprate"),
                            Description = elemList[i].SelectInnerText("description"),
                            Vattotal = elemList[i].SelectInnerText("vattotal"),
                            Vatbasetotal = elemList[i].SelectInnerText("vatbasetotal"),
                            Vatreptotal = elemList[i].SelectInnerText("vatreptotal"),
                            Matchstatus = elemList[i].SelectInnerText("matchstatus"),
                            Matchlevel = elemList[i].SelectInnerText("matchlevel"),
                            Matchdate = elemList[i].SelectInnerText("matchdate"),
                            Relation = elemList[i].SelectInnerText("relation"),
                            Valueopen = elemList[i].SelectInnerText("valueopen"),
                            Basevalueopen = elemList[i].SelectInnerText("basevalueopen"),
                            Repvalueopen = elemList[i].SelectInnerText("repvalueopen"),
                            Vatcode = elemList[i].SelectInnerText("vatcode"),
                            Vatvalue = elemList[i].SelectInnerText("vatvalue"),
                            Vatbasevalue = elemList[i].SelectInnerText("vatbasevalue"),
                            Vatrepvalue = elemList[i].SelectInnerText("vatrepvalue"),
                            Vatturnover = elemList[i].SelectInnerText("vatturnover"),
                            Vatbaseturnover = elemList[i].SelectInnerText("vatbaseturnover"),
                            Vatrepturnover = elemList[i].SelectInnerText("vatrepturnover"),
                            Baseline = elemList[i].SelectInnerText("baseline"),
                            Destoffice = elemList[i].SelectInnerText("destoffice"),
                            Currencydate = elemList[i].SelectInnerText("currencydate"),
                            Freechar = elemList[i].SelectInnerText("freechar"),
                            Comment = elemList[i].SelectInnerText("comment")
                        };
                        lines.Add(line);
                    }
                }
            }
            return new PurchaseTransaction
            {
                Header = new Header
                {
                    Office = element.SelectInnerText("header/office"),
                    Code = element.SelectInnerText("header/code"),
                    Number = element.SelectInnerText("header/number"),
                    Period = element.SelectInnerText("header/period"),
                    Currency = element.SelectInnerText("header/currency"),
                    Date = element.SelectInnerText("header/date"),
                    Origin = element.SelectInnerText("header/origin"),
                    Modificationdate = element.SelectInnerText("header/modificationdate"),
                    User = element.SelectInnerText("header/user"),
                    Inputdate = element.SelectInnerText("header/inputdate"),
                    Duedate = element.SelectInnerText("header/duedate"),
                    Invoicenumber = element.SelectInnerText("header/invoicenumber"),
                    Paymentreference = element.SelectInnerText("header/paymentreference"),
                    Freetext1 = element.SelectInnerText("header/freetext1"),
                    Freetext2 = element.SelectInnerText("header/freetext2"),
                    Freetext3 = element.SelectInnerText("header/freetext3")
                },
                Line = lines
            };
        }
        public Header Header;
        public List<Line> Line;

        internal XmlDocument ToXml()
        {
            var document = new XmlDocument();
            var pt = document.AppendNewElement("transaction");
            //toevoegen
            return document;
        }
    }

    public class Header
    {
        public string Office { get; set; }
        public string Code { get; set; }
        public string Number { get; set; }
        public string Period { get; set; }
        public string Currency { get; set; }
        public string Date { get; set; }
        public string Origin { get; set; }
        public string Modificationdate { get; set; }
        public string User { get; set; }
        public string Inputdate { get; set; }
        public string Duedate { get; set; }
        public string Invoicenumber { get; set; }
        public string Paymentreference { get; set; }
        public string Freetext1 { get; set; }
        public string Freetext2 { get; set; }
        public string Freetext3 { get; set; }
    }

    public class Line
    {
        public string Type { get; set; }
        public string Dim1 { get; set; }
        public string Dim2 { get; set; }
        public string Dim3 { get; set; }
        public string Dim4 { get; set; }
        public string Dim5 { get; set; }
        public string Dim6 { get; set; }
        public string Debitcredit { get; set; }
        public string Value { get; set; }
        public string Basevalue { get; set; }
        public string Rate { get; set; }
        public string Repvalue { get; set; }
        public string Reprate { get; set; }
        public string Description { get; set; }
        public string Vattotal { get; set; }
        public string Vatbasetotal { get; set; }
        public string Vatreptotal { get; set; }
        public string Matchstatus { get; set; }
        public string Matchlevel { get; set; }
        public string Matchdate { get; set; }
        public string Relation { get; set; }
        public string Valueopen { get; set; }
        public string Basevalueopen { get; set; }
        public string Repvalueopen { get; set; }
        public string Vatcode { get; set; }
        public string Vatvalue { get; set; }
        public string Vatbasevalue { get; set; }
        public string Vatrepvalue { get; set; }
        public string Vatturnover { get; set; }
        public string Vatbaseturnover { get; set; }
        public string Vatrepturnover { get; set; }
        public string Baseline { get; set; }
        public string Destoffice { get; set; }
        public string Currencydate { get; set; }
        public string Freechar { get; set; }
        public string Comment { get; set; }
    }
}
