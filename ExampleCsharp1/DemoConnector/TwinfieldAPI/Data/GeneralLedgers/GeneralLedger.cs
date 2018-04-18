using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Data.GeneralLedgers
{
    public class GeneralLedger
    {
        internal static GeneralLedger FromXml(XmlElement element)
        {
            return new GeneralLedger
            {
                Office = element.SelectInnerText("office"),
                Type = element.SelectInnerText("type"),
                Code = element.SelectInnerText("code"),
                Uid = element.SelectInnerText("uid"),
                Name = element.SelectInnerText("name"),
                Shortname = element.SelectInnerText("shortname"),
                Inuse = element.SelectInnerText("inuse"),
                Behaviour = element.SelectInnerText("behaviour"),
                Touched = element.SelectInnerText("touched"),
                Beginperiod = element.SelectInnerText("beginperiod"),
                Beginyear = element.SelectInnerText("beginyear"),
                Endperiod = element.SelectInnerText("endperiod"),
                Endyear = element.SelectInnerText("endyear"),
                Website = element.SelectInnerText("website"),
                Cocnumber = element.SelectInnerText("cocnumber"),
                Vatnumber = element.SelectInnerText("vatnumber"),
                Editdimensionname = element.SelectInnerText("editdimensionname"),
                financials = new Financials
                {
                    Matchtype = element.SelectInnerText("financials/matchtype"),
                    Accounttype = element.SelectInnerText("financials/accounttype"),
                    Subanalyse = element.SelectInnerText("financials/subanalyse"),
                    Duedays = element.SelectInnerText("financials/duedays"),
                    Level = element.SelectInnerText("financials/level"),
                    Payavailable = element.SelectInnerText("financials/payavailable"),
                    Meansofpayment = element.SelectInnerText("financials/meansofpayment"),
                    Paycode = element.SelectInnerText("financials/paycode"),
                    Ebilling = element.SelectInnerText("financials/ebilling"),
                    Ebillmail = element.SelectInnerText("financials/ebillmail"),
                    Substitutionlevel = element.SelectInnerText("financials/substitutionleven"),
                    Substitutewith = element.SelectInnerText("financials/substitutewtith"),
                    Relationsreference = element.SelectInnerText("financials/relationsreference"),
                    Vattype = element.SelectInnerText("financials/vattype"),
                    Vatcode = element.SelectInnerText("financials/vatcode"),
                    Vatobligatory = element.SelectInnerText("financials/vatobligatory"),
                    Performancetype = element.SelectInnerText("financials/performancetype"),
                    Collectmandate = new Collectmandate
                    {
                        Id = element.SelectInnerText("financials/collectmandate/id"),
                        Signaturedate = element.SelectInnerText("financials/collectmandate/signaturedate"),
                        Firstrundate = element.SelectInnerText("financials/collectmandate/firstrundate")
                    },
                    Collectionschema = element.SelectInnerText("financials/collectionschema"),
                    Childvalidations = new Childvalidations
                    {
                        Childvalidation = element.SelectInnerText("financials/childvalidations/childvalidation")
                    }
                },
                groups = new Groups
                {
                    Group = element.SelectInnerText("groups/group")
                }
            };
        }

        public string Office { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Uid { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public string Inuse { get; set; }
        public string Behaviour { get; set; }
        public string Touched { get; set; }
        public string Beginperiod { get; set; }
        public string Beginyear { get; set; }
        public string Endperiod { get; set; }
        public string Endyear { get; set; }
        public string Website { get; set; }
        public string Cocnumber { get; set; }
        public string Vatnumber { get; set; }
        public string Editdimensionname { get; set; }
        public Financials financials { get; set; }
        public Groups groups { get; set; }
    }

    public class Financials
    {
        public string Matchtype { get; set; }
        public string Accounttype { get; set; }
        public string Subanalyse { get; set; }
        public string Duedays { get; set; }
        public string Level { get; set; }
        public string Payavailable { get; set; }
        public string Meansofpayment { get; set; }
        public string Paycode { get; set; }
        public string Ebilling { get; set; }
        public string Ebillmail { get; set; }
        public string Substitutionlevel { get; set; }
        public string Substitutewith { get; set; }
        public string Relationsreference { get; set; }
        public string Vattype { get; set; }
        public string Vatcode { get; set; }
        public string Vatobligatory { get; set; }
        public string Performancetype { get; set; }
        public Collectmandate Collectmandate { get; set; }
        public string Collectionschema { get; set; }
        public Childvalidations Childvalidations { get; set; }
    }

    public class Collectmandate
    {
        public string Id { get; set; }
        public string Signaturedate { get; set; }
        public string Firstrundate { get; set; }
    }

    public class Childvalidations
    {
        public string Childvalidation { get; set; }
    }

    public class Groups
    {
        public string Group { get; set; }
    }
}
