using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Users;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.SalesTransactions
{
    public class SalesTransaction
    {
        internal static SalesTransaction FromXml(XmlElement element)
        {
            var lines = new List<Line>();
            XmlNodeList elemList = element.GetElementsByTagName("line");
            for (int i = 0; i < elemList.Count; i++)
            {
                if (!elemList[i].Equals(null) || elemList[i] != null || !elemList[i].SelectInnerText("dim1").Equals("") || elemList[i].SelectInnerText("dim1") != "")
                {
                    var line = new Line
                    {
                        Type = elemList[i].SelectInnerText("@type"),
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
                        Performancetype = elemList[i].SelectInnerText("performancetype"),
                        Performancecountry = elemList[i].SelectInnerText("performancecountry"),
                        Performancevatnumber = elemList[i].SelectInnerText("performancevatnumber"),
                        Performancedate = elemList[i].SelectInnerText("performancedate"),
                        Destoffice = elemList[i].SelectInnerText("destoffice"),
                        Currencydate = elemList[i].SelectInnerText("currencrydate"),
                        Freechar = elemList[i].SelectInnerText("freechar"),
                        Comment = elemList[i].SelectInnerText("comment"),
                        Matches = elemList[i].SelectInnerText("matches")
                    };
                    lines.Add(line);
                }
            }
            return new SalesTransaction
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
                    Originreference = element.SelectInnerText("header/originreference"),
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
                Lines = new Lines
                {
                    Line = lines
                }
            };
        }
        public Header Header { get; set; }
        public Lines Lines { get; set; }

        internal XmlDocument ToXml()
        {
            var document = new XmlDocument();
            var st = document.AppendNewElement("transaction");
            st.AppendNewElement("header/office").InnerText = Header.Office;
            st.AppendNewElement("header/code").InnerText = Header.Code;
            st.AppendNewElement("header/number").InnerText = Header.Number;
            st.AppendNewElement("header/period").InnerText = Header.Period;
            st.AppendNewElement("header/currency").InnerText = Header.Currency;
            st.AppendNewElement("header/date").InnerText = Header.Date;
            st.AppendNewElement("header/origin").InnerText = Header.Origin;
            st.AppendNewElement("header/originreference").InnerText = Header.Originreference;
            st.AppendNewElement("header/modificationdate").InnerText = Header.Modificationdate;
            st.AppendNewElement("header/user").InnerText = Header.User;
            st.AppendNewElement("header/inputdate").InnerText = Header.Inputdate;
            st.AppendNewElement("header/duedate").InnerText = Header.Duedate;
            st.AppendNewElement("header/invoicenumber").InnerText = Header.Invoicenumber;
            st.AppendNewElement("header/paymentreference").InnerText = Header.Paymentreference;
            st.AppendNewElement("header/freetext1").InnerText = Header.Freetext1;
            st.AppendNewElement("header/freetext2").InnerText = Header.Freetext2;
            st.AppendNewElement("header/freetext3").InnerText = Header.Freetext3;
            for (int i = 0; i < Lines.Line.Count; i++)
            {
                if (!Lines.Line[i].Equals(null) || Lines.Line[i] != null || !Lines.Line[i].Dim1.Equals("") || Lines.Line[i].Dim1 != "")
                {
                    var line = Lines.Line[i];
                    st.AppendNewElement("lines/line[@id='" + i + "']/dim1").InnerText = line.Dim1;
                    st.AppendNewElement("lines/line[@id='" + i + "']/dim2").InnerText = line.Dim2;
                    st.AppendNewElement("lines/line[@id='" + i + "']/dim3").InnerText = line.Dim3;
                    st.AppendNewElement("lines/line[@id='" + i + "']/dim4").InnerText = line.Dim4;
                    st.AppendNewElement("lines/line[@id='" + i + "']/dim5").InnerText = line.Dim5;
                    st.AppendNewElement("lines/line[@id='" + i + "']/dim6").InnerText = line.Dim6;
                    st.AppendNewElement("lines/line[@id='" + i + "']/debitcredit").InnerText = line.Debitcredit;
                    st.AppendNewElement("lines/line[@id='" + i + "']/value").InnerText = line.Value;
                    st.AppendNewElement("lines/line[@id='" + i + "']/basevalue").InnerText = line.Basevalue;
                    st.AppendNewElement("lines/line[@id='" + i + "']/rate").InnerText = line.Rate;
                    st.AppendNewElement("lines/line[@id='" + i + "']/repvalue").InnerText = line.Repvalue;
                    st.AppendNewElement("lines/line[@id='" + i + "']/reprate").InnerText = line.Reprate;
                    st.AppendNewElement("lines/line[@id='" + i + "']/description").InnerText = line.Description;
                    st.AppendNewElement("lines/line[@id='" + i + "']/vattotal").InnerText = line.Vattotal;
                    st.AppendNewElement("lines/line[@id='" + i + "']/vatbasetotal").InnerText = line.Vatbasetotal;
                    st.AppendNewElement("lines/line[@id='" + i + "']/vatreptotal").InnerText = line.Vatreptotal;
                    st.AppendNewElement("lines/line[@id='" + i + "']/matchstatus").InnerText = line.Matchstatus;
                    st.AppendNewElement("lines/line[@id='" + i + "']/matchlevel").InnerText = line.Matchlevel;
                    st.AppendNewElement("lines/line[@id='" + i + "']/relation").InnerText = line.Relation;
                    st.AppendNewElement("lines/line[@id='" + i + "']/valueopen").InnerText = line.Valueopen;
                    st.AppendNewElement("lines/line[@id='" + i + "']/basevalueopen").InnerText = line.Basevalueopen;
                    st.AppendNewElement("lines/line[@id='" + i + "']/repvalueopen").InnerText = line.Repvalueopen;
                    st.AppendNewElement("lines/line[@id='" + i + "']/vatcode").InnerText = line.Vatcode;
                    st.AppendNewElement("lines/line[@id='" + i + "']/vatvalue").InnerText = line.Vatvalue;
                    st.AppendNewElement("lines/line[@id='" + i + "']/vatbasevalue").InnerText = line.Vatbasevalue;
                    st.AppendNewElement("lines/line[@id='" + i + "']/vatrepvalue").InnerText = line.Vatrepvalue;
                    st.AppendNewElement("lines/line[@id='" + i + "']/vatturnover").InnerText = line.Vatturnover;
                    st.AppendNewElement("lines/line[@id='" + i + "']/vatbaseturnover").InnerText = line.Vatbaseturnover;
                    st.AppendNewElement("lines/line[@id='" + i + "']/vatrepturnover").InnerText = line.Vatrepturnover;
                    st.AppendNewElement("lines/line[@id='" + i + "']/baseline").InnerText = line.Baseline;
                    st.AppendNewElement("lines/line[@id='" + i + "']/performancetype").InnerText = line.Performancetype;
                    st.AppendNewElement("lines/line[@id='" + i + "']/performancecountry").InnerText =
                        line.Performancecountry;
                    st.AppendNewElement("lines/line[@id='" + i + "']/performancevatnumber").InnerText =
                        line.Performancevatnumber;
                    st.AppendNewElement("lines/line[@id='" + i + "']/performancedate").InnerText = line.Performancedate;
                    st.AppendNewElement("lines/line[@id='" + i + "']/destoffice").InnerText = line.Destoffice;
                    st.AppendNewElement("lines/line[@id='" + i + "']/currencydate").InnerText = line.Currencydate;
                    st.AppendNewElement("lines/line[@id='" + i + "']/freechar").InnerText = line.Freechar;
                    st.AppendNewElement("lines/line[@id='" + i + "']/comment").InnerText = line.Comment;
                    st.AppendNewElement("lines/line[@id='" + i + "']/matches").InnerText = line.Matches;
                }
            }

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
        public string Originreference { get; set; }
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

    public class Lines
    {
        public List<Line> Line { get; set; }
    }

    public class Line
    {
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
        public string Performancetype { get; set; }
        public string Performancecountry { get; set; }
        public string Performancevatnumber { get; set; }
        public string Performancedate { get; set; }
        public string Destoffice { get; set; }
        public string Currencydate { get; set; }
        public string Freechar { get; set; }
        public string Comment { get; set; }
        public string Matches { get; set; }
        public string Type { get; set; }
    }
}
