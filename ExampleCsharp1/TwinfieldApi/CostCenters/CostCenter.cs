using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.CostCenters
{
    public class CostCenter
    {
        internal static CostCenter FromXml(XmlElement element)
        {
            var addresses = new List<Address>();
            XmlNodeList elemListAddresses = element.GetElementsByTagName("address");
            for (int i = 0; i < elemListAddresses.Count; i++)
            {
                if (!elemListAddresses[i].SelectInnerText("name").Equals(null) ||
                    !elemListAddresses[i].SelectInnerText("name").Equals("") ||
                    elemListAddresses[i].SelectInnerText("name") != null ||
                    elemListAddresses[i].SelectInnerText("name") != "")
                {
                    var address = new Address
                    {
                        Field2 = elemListAddresses[i].SelectInnerText("field2"),
                        Field3 = elemListAddresses[i].SelectInnerText("field3"),
                    };
                    addresses.Add(address);
                }
            }

            var banks = new List<Bank>();
            XmlNodeList elemListBanks = element.GetElementsByTagName("bank");
            for (int i = 0; i < elemListBanks.Count; i++)
            {
                if (!elemListBanks[i].SelectInnerText("ascription").Equals(null) ||
                    !elemListBanks[i].SelectInnerText("ascription").Equals("") ||
                    elemListBanks[i].SelectInnerText("ascription") != null ||
                    elemListBanks[i].SelectInnerText("ascription") != "")
                {
                    var bank = new Bank
                    {
                        Ascription = elemListBanks[i].SelectInnerText("ascription"),
                        Accountnumber = elemListBanks[i].SelectInnerText("accountnumber"),
                        Address = new Address
                        {
                            Field2 = elemListBanks[i].SelectInnerText("address/field2"),
                            Field3 = elemListBanks[i].SelectInnerText("address/field3")
                        },
                        Bankname = elemListBanks[i].SelectInnerText("bankname"),
                        Biccode = elemListBanks[i].SelectInnerText("biccode"),
                        City = elemListBanks[i].SelectInnerText("city"),
                        Country = elemListBanks[i].SelectInnerText("country"),
                        Iban = elemListBanks[i].SelectInnerText("iban"),
                        Natbiccode = elemListBanks[i].SelectInnerText("natbiccode"),
                        Postcode = elemListBanks[i].SelectInnerText("postcode"),
                        State = elemListBanks[i].SelectInnerText("state")
                    };
                    banks.Add(bank);
                }
            }


            return new CostCenter
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
                banks = new Banks
                {
                    Bank = banks
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
        public Banks banks { get; set; }

        internal XmlDocument ToXml()
        {
            var document = new XmlDocument();
            var dimension = document.AppendNewElement("dimension");
            dimension.AppendNewElement("office").InnerText = Office;
            dimension.AppendNewElement("type").InnerText = Type;
            dimension.AppendNewElement("code").InnerText = Code;
            dimension.AppendNewElement("uid").InnerText = Uid;
            dimension.AppendNewElement("name").InnerText = Name;
            dimension.AppendNewElement("inuse").InnerText = Inuse;
            dimension.AppendNewElement("behaviour").InnerText = Behaviour;
            dimension.AppendNewElement("touched").InnerText = Touched;
            dimension.AppendNewElement("beginperiod").InnerText = Beginperiod;
            dimension.AppendNewElement("beginyear").InnerText = Beginyear;
            dimension.AppendNewElement("endperiod").InnerText = Endyear;
            dimension.AppendNewElement("endyear").InnerText = Endyear;
            dimension.AppendNewElement("website").InnerText = Website;
            dimension.AppendNewElement("cocnumber").InnerText = Cocnumber;
            dimension.AppendNewElement("vatnumber").InnerText = Vatnumber;
            dimension.AppendNewElement("editdimenionname").InnerText = Editdimensionname;
            dimension.AppendNewElement("financials/matchtype").InnerText = financials.Matchtype;
            dimension.AppendNewElement("financials/accounttype").InnerText = financials.Accounttype;
            dimension.AppendNewElement("financials/subanalyse").InnerText = financials.Subanalyse;
            dimension.AppendNewElement("financials/duedays").InnerText = financials.Duedays;
            dimension.AppendNewElement("financials/level").InnerText = financials.Level;
            dimension.AppendNewElement("financials/payavailable").InnerText = financials.Payavailable;
            dimension.AppendNewElement("financials/meansofpayment").InnerText = financials.Meansofpayment;
            dimension.AppendNewElement("financials/paycode").InnerText = financials.Paycode;
            dimension.AppendNewElement("financials/ebilling").InnerText = financials.Ebilling;
            dimension.AppendNewElement("financials/ebillmail").InnerText = financials.Ebillmail;
            dimension.AppendNewElement("financials/substitutionlevel").InnerText = financials.Substitutionlevel;
            dimension.AppendNewElement("financials/substitutewith").InnerText = financials.Substitutewith;
            dimension.AppendNewElement("financials/relationreference").InnerText = financials.Relationsreference;
            dimension.AppendNewElement("financials/vattype").InnerText = financials.Vattype;
            dimension.AppendNewElement("financials/vatcode").InnerText = financials.Vatcode;
            dimension.AppendNewElement("financials/vatobligatory").InnerText = financials.Vatobligatory;
            dimension.AppendNewElement("financials/performancetype").InnerText = financials.Performancetype;
            dimension.AppendNewElement("financials/collectmandate/id").InnerText = financials.Collectmandate.Id;
            dimension.AppendNewElement("financials/collectmandate/signaturedate").InnerText =
                financials.Collectmandate.Signaturedate;
            dimension.AppendNewElement("financials/collectmandate/firstrundate").InnerText =
                financials.Collectmandate.Firstrundate;
            dimension.AppendNewElement("financials/collectionschema").InnerText = financials.Collectionschema;
            dimension.AppendNewElement("financials/childvalidations/childvalidation").InnerText =
                financials.Childvalidations.Childvalidation;


            for (int i = 0; i < banks.Bank.Count; i++)
            {
                if (!banks.Bank[i].Equals(null) || banks.Bank[i] != null || !banks.Bank[i].Ascription.Equals("") ||
                    banks.Bank[i].Ascription != "")
                {
                    var bank = banks.Bank[i];
                    dimension.AppendNewElement("banks/bank[@id='" + i + "']/ascription").InnerText = bank.Ascription;
                    dimension.AppendNewElement("banks/bank[@id='" + i + "']/accountnumber").InnerText =
                        bank.Accountnumber;
                    dimension.AppendNewElement("banks/bank[@id='" + i + "']/address/field2").InnerText =
                        bank.Address.Field2;
                    dimension.AppendNewElement("banks/bank[@id='" + i + "']/address/field3").InnerText =
                        bank.Address.Field3;
                    dimension.AppendNewElement("banks/bank[@id='" + i + "']/bankname").InnerText = bank.Bankname;
                    dimension.AppendNewElement("banks/bank[@id='" + i + "']/biccode").InnerText = bank.Biccode;
                    dimension.AppendNewElement("banks/bank[@id='" + i + "']/city").InnerText = bank.City;
                    dimension.AppendNewElement("banks/bank[@id='" + i + "']/county").InnerText = bank.Country;
                    dimension.AppendNewElement("banks/bank[@id='" + i + "']/iban").InnerText = bank.Iban;
                    dimension.AppendNewElement("banks/bank[@id='" + i + "']/natbiccode").InnerText = bank.Natbiccode;
                    dimension.AppendNewElement("banks/bank[@id='" + i + "']/postcode").InnerText = bank.Postcode;
                    dimension.AppendNewElement("banks/bank[@id='" + i + "']/state").InnerText = bank.State;
                }
            }

            return document;
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

        public class Address
        {
            public string Field2 { get; set; }
            public string Field3 { get; set; }

        }


        public class Bank
        {
            public string Ascription { get; set; }
            public string Accountnumber { get; set; }
            public Address Address { get; set; }
            public string Bankname { get; set; }
            public string Biccode { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Iban { get; set; }
            public string Natbiccode { get; set; }
            public string Postcode { get; set; }
            public string State { get; set; }
            public string Default { get; set; }
            public string Id { get; set; }
            public string Blocked { get; set; }
            public string Destination { get; set; }
        }

        public class Banks
        {
            public List<Bank> Bank { get; set; }
        }


        public class Childvalidations
        {
            public string Childvalidation { get; set; }
        }

        public class Collectmandate
        {
            public string Id { get; set; }
            public string Signaturedate { get; set; }
            public string Firstrundate { get; set; }
        }
    }
}