using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.FixedAssets
{
    public class FixedAsset
    {
        internal static FixedAsset FromXml(XmlElement element)
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
                        Field3 = elemListAddresses[i].SelectInnerText("field3")
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

            var translines = new List<Transline>();
            XmlNodeList elemListTranslines = element.GetElementsByTagName("transline");
            for (int i = 0; i < elemListTranslines.Count; i++)
            {
                if (!elemListTranslines[i].SelectInnerText("code").Equals(null) ||
                    elemListTranslines[i].SelectInnerText("code") != null ||
                    !elemListTranslines[i].SelectInnerText("code").Equals("") ||
                    elemListTranslines[i].SelectInnerText("code") != "")
                {
                    var transline = new Transline
                    {
                        Code = elemListTranslines[i].SelectInnerText("code"),
                        Number = elemListTranslines[i].SelectInnerText("number"),
                        Line = elemListTranslines[i].SelectInnerText("line"),
                        Amount = elemListTranslines[i].SelectInnerText("amount"),
                        Period = elemListTranslines[i].SelectInnerText("period"),
                        Dim1 = elemListTranslines[i].SelectInnerText("dim1"),
                        Dim2 = elemListTranslines[i].SelectInnerText("dim2"),
                        Dim3 = elemListTranslines[i].SelectInnerText("dim3"),
                        Dim4 = elemListTranslines[i].SelectInnerText("dim4"),
                        Dim5 = elemListTranslines[i].SelectInnerText("dim5"),
                        Dim6 = elemListTranslines[i].SelectInnerText("dim6")
                    };
                    translines.Add(transline);
                }
            }


            return new FixedAsset
            {
                Office = element.SelectInnerText("office"),
                Type = element.SelectInnerText("type"),
                Name = element.SelectInnerText("name"),
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
                    Collectionschema = element.SelectInnerText("financials/collectionschema")
                },
                fixedAssets = new FixedAssets
                {
                    Residualvalue = element.SelectInnerText("fixedassets/residualvalue"),
                    Stopvalue = element.SelectInnerText("fixedassets/stopvalue"),
                    Method = element.SelectInnerText("fixedassets/method"),
                    Beginperiod = element.SelectInnerText("fixedassets/beginperiod"),
                    Purchasedate = element.SelectInnerText("fixedassets/purchasedate"),
                    Freetext1 = element.SelectInnerText("fixedassets/freetext1"),
                    Nrofperiods = element.SelectInnerText("fixedassets/nrofperiods"),
                    Percentage = element.SelectInnerText("fixedassets/percentage"),
                    Status = element.SelectInnerText("fixedassets/status"),
                    Lastdepreciation = element.SelectInnerText("fixedassets/lastdepreciation"),
                    Selldate = element.SelectInnerText("fixedassets/selldate"),
                    Freetext2 = element.SelectInnerText("fixedassets/freetext2"),
                    Freetext3 = element.SelectInnerText("fixedassets/freetext3"),
                    Freetext4 = element.SelectInnerText("fixedassets/freetext4"),
                    Freetext5 = element.SelectInnerText("fixedassets/freetext5"),
                    Translines = new Translines
                    {
                        Transline = translines
                    }
                },
                groups = new Groups
                {
                    Group = element.SelectInnerText("groups/group")
                },

                Code = element.SelectInnerText("code"),
                Uid = element.SelectInnerText("uid"),
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
                banks = new Banks
                {
                    Bank = banks
                }
            };
        }

        public string Office { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public Financials financials { get; set; }
        public FixedAssets fixedAssets { get; set; }
        public Groups groups { get; set; }
        public string Code { get; set; }
        public string Uid { get; set; }
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
        public Banks banks { get; set; }


        internal XmlDocument ToXml()
        {
            var document = new XmlDocument();
            var fixedAsset = document.AppendNewElement("dimension");
            fixedAsset.AppendNewElement("office").InnerText = Office;
            fixedAsset.AppendNewElement("type").InnerText = Type;
            fixedAsset.AppendNewElement("name").InnerText = Name;
            fixedAsset.AppendNewElement("financials/matchtype").InnerText = financials.Matchtype;
            fixedAsset.AppendNewElement("financials/accounttype").InnerText = financials.Accounttype;
            fixedAsset.AppendNewElement("financials/subanalyse").InnerText = financials.Subanalyse;
            fixedAsset.AppendNewElement("financials/duedays").InnerText = financials.Duedays;
            fixedAsset.AppendNewElement("financials/level").InnerText = financials.Level;
            fixedAsset.AppendNewElement("financials/payavailable").InnerText = financials.Payavailable;
            fixedAsset.AppendNewElement("financials/meansofpayment").InnerText = financials.Meansofpayment;
            fixedAsset.AppendNewElement("financials/paycode").InnerText = financials.Paycode;
            fixedAsset.AppendNewElement("financials/ebilling").InnerText = financials.Ebilling;
            fixedAsset.AppendNewElement("financials/ebillmail").InnerText = financials.Ebillmail;
            fixedAsset.AppendNewElement("financials/substitutionlevel").InnerText = financials.Substitutionlevel;
            fixedAsset.AppendNewElement("financials/substitutewith").InnerText = financials.Substitutewith;
            fixedAsset.AppendNewElement("financials/relationreference").InnerText = financials.Relationsreference;
            fixedAsset.AppendNewElement("financials/vattype").InnerText = financials.Vattype;
            fixedAsset.AppendNewElement("financials/vatcode").InnerText = financials.Vatcode;
            fixedAsset.AppendNewElement("financials/vatobligatory").InnerText = financials.Vatobligatory;
            fixedAsset.AppendNewElement("financials/performancetype").InnerText = financials.Performancetype;
            fixedAsset.AppendNewElement("financials/collectmandate/id").InnerText = financials.Collectmandate.Id;
            fixedAsset.AppendNewElement("financials/collectmandate/signaturedate").InnerText =
                financials.Collectmandate.Signaturedate;
            fixedAsset.AppendNewElement("financials/collectmandate/firstrundate").InnerText =
                financials.Collectmandate.Firstrundate;
            fixedAsset.AppendNewElement("financials/collectionschema").InnerText = financials.Collectionschema;

            fixedAsset.AppendNewElement("fixedassets/residualvalue").InnerText = fixedAssets.Residualvalue;
            fixedAsset.AppendNewElement("fixedassets/stopvalue").InnerText = fixedAssets.Stopvalue;
            fixedAsset.AppendNewElement("fixedassets/method").InnerText = fixedAssets.Method;
            fixedAsset.AppendNewElement("fixedassets/beginperiod").InnerText = fixedAssets.Beginperiod;
            fixedAsset.AppendNewElement("fixedassets/purchasedate").InnerText = fixedAssets.Purchasedate;
            fixedAsset.AppendNewElement("fixedassets/freetext1").InnerText = fixedAssets.Freetext1;
            fixedAsset.AppendNewElement("fixedassets/nrofperiods").InnerText = fixedAssets.Nrofperiods;
            fixedAsset.AppendNewElement("fixedassets/percentage").InnerText = fixedAssets.Percentage;
            fixedAsset.AppendNewElement("fixedassets/status").InnerText = fixedAssets.Status;
            fixedAsset.AppendNewElement("fixedassets/lastdepreciation").InnerText = fixedAssets.Lastdepreciation;
            fixedAsset.AppendNewElement("fixedassets/selldate").InnerText = fixedAssets.Selldate;
            fixedAsset.AppendNewElement("fixedassets/freetext2").InnerText = fixedAssets.Freetext2;
            fixedAsset.AppendNewElement("fixedassets/freetext3").InnerText = fixedAssets.Freetext3;
            fixedAsset.AppendNewElement("fixedassets/freetext4").InnerText = fixedAssets.Freetext4;
            fixedAsset.AppendNewElement("fixedassets/freetext5").InnerText = fixedAssets.Freetext5;
            for (int i = 0; i < fixedAssets.Translines.Transline.Count; i++)
            {
                if (!fixedAssets.Translines.Transline[i].Equals(null) || fixedAssets.Translines.Transline[i] != null || !fixedAssets.Translines.Transline[i].Code.Equals("") || fixedAssets.Translines.Transline[i].Code != "")
                {
                    var transLine = fixedAssets.Translines.Transline[i];
                    fixedAsset.AppendNewElement("fixedassets/translines/transline[@id='" + i + "']/code").InnerText =
                        transLine.Code;
                    fixedAsset.AppendNewElement("fixedassets/translines/transline[@id='" + i + "']/number").InnerText =
                        transLine.Number;
                    fixedAsset.AppendNewElement("fixedassets/translines/transline[@id='" + i + "']/line").InnerText =
                        transLine.Line;
                    fixedAsset.AppendNewElement("fixedassets/translines/transline[@id='" + i + "']/amount").InnerText =
                        transLine.Amount;
                    fixedAsset.AppendNewElement("fixedassets/translines/transline[@id='" + i + "']/period").InnerText =
                        transLine.Period;
                    fixedAsset.AppendNewElement("fixedassets/translines/transline[@id='" + i + "']/dim1").InnerText =
                        transLine.Dim1;
                    fixedAsset.AppendNewElement("fixedassets/translines/transline[@id='" + i + "']/dim2").InnerText =
                        transLine.Dim2;
                    fixedAsset.AppendNewElement("fixedassets/translines/transline[@id='" + i + "']/dim3").InnerText =
                        transLine.Dim3;
                    fixedAsset.AppendNewElement("fixedassets/translines/transline[@id='" + i + "']/dim4").InnerText =
                        transLine.Dim4;
                    fixedAsset.AppendNewElement("fixedassets/translines/transline[@id='" + i + "']/dim5").InnerText =
                        transLine.Dim5;
                    fixedAsset.AppendNewElement("fixedassets/translines/transline[@id='" + i + "']/dim6").InnerText =
                        transLine.Dim6;
                }
            }
            fixedAsset.AppendNewElement("groups/group").InnerText = groups.Group;
            fixedAsset.AppendNewElement("code").InnerText = Code;
            fixedAsset.AppendNewElement("uid").InnerText = Uid;
            fixedAsset.AppendNewElement("inuse").InnerText = Inuse;
            fixedAsset.AppendNewElement("behaviour").InnerText = Behaviour;
            fixedAsset.AppendNewElement("touched").InnerText = Touched;
            fixedAsset.AppendNewElement("beginperiod").InnerText = Beginperiod;
            fixedAsset.AppendNewElement("beginyear").InnerText = Beginyear;
            fixedAsset.AppendNewElement("endperiod").InnerText = Endyear;
            fixedAsset.AppendNewElement("endyear").InnerText = Endyear;
            fixedAsset.AppendNewElement("website").InnerText = Website;
            fixedAsset.AppendNewElement("cocnumber").InnerText = Cocnumber;
            fixedAsset.AppendNewElement("vatnumber").InnerText = Vatnumber;
            fixedAsset.AppendNewElement("editdimenionname").InnerText = Editdimensionname;
            for (int i = 0; i < banks.Bank.Count; i++)
            {
                if (!banks.Bank[i].Equals(null) || banks.Bank[i] != null || !banks.Bank[i].Ascription.Equals("") ||
                    banks.Bank[i].Ascription != "")
                {
                    var bank = banks.Bank[i];
                    fixedAsset.AppendNewElement("banks/bank[@id='" + i + "']/ascription").InnerText = bank.Ascription;
                    fixedAsset.AppendNewElement("banks/bank[@id='" + i + "']/accountnumber").InnerText =
                        bank.Accountnumber;
                    fixedAsset.AppendNewElement("banks/bank[@id='" + i + "']/address/field2").InnerText =
                        bank.Address.Field2;
                    fixedAsset.AppendNewElement("banks/bank[@id='" + i + "']/address/field3").InnerText =
                        bank.Address.Field3;
                    fixedAsset.AppendNewElement("banks/bank[@id='" + i + "']/bankname").InnerText = bank.Bankname;
                    fixedAsset.AppendNewElement("banks/bank[@id='" + i + "']/biccode").InnerText = bank.Biccode;
                    fixedAsset.AppendNewElement("banks/bank[@id='" + i + "']/city").InnerText = bank.City;
                    fixedAsset.AppendNewElement("banks/bank[@id='" + i + "']/county").InnerText = bank.Country;
                    fixedAsset.AppendNewElement("banks/bank[@id='" + i + "']/iban").InnerText = bank.Iban;
                    fixedAsset.AppendNewElement("banks/bank[@id='" + i + "']/natbiccode").InnerText = bank.Natbiccode;
                    fixedAsset.AppendNewElement("banks/bank[@id='" + i + "']/postcode").InnerText = bank.Postcode;
                    fixedAsset.AppendNewElement("banks/bank[@id='" + i + "']/state").InnerText = bank.State;
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
        }

        public class Address
        {
            public string Field2 { get; set; }
            public string Field3 { get; set; }

        }

        public class Addresses
        {
            public List<Address> Address { get; set; }
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

        public class Collectmandate
        {
            public string Id { get; set; }
            public string Signaturedate { get; set; }
            public string Firstrundate { get; set; }
        }

        public class Groups
        {
            public string Group { get; set; }
        }

        public class FixedAssets
        {
            public string Residualvalue { get; set; }
            public string Stopvalue { get; set; }
            public string Method { get; set; }
            public string Beginperiod { get; set; }
            public string Purchasedate { get; set; }
            public string Freetext1 { get; set; }
            public string Nrofperiods { get; set; }
            public string Percentage { get; set; }
            public string Status { get; set; }
            public string Lastdepreciation { get; set; }
            public string Selldate { get; set; }
            public string Freetext2 { get; set; }
            public string Freetext3 { get; set; }
            public string Freetext4 { get; set; }
            public string Freetext5 { get; set; }
            public Translines Translines { get; set; }
        }

        public class Translines
        {
            public List<Transline> Transline { get; set; }
        }

        public class Transline
        {
            public string Code { get; set; }
            public string Number { get; set; }
            public string Line { get; set; }
            public string Amount { get; set; }
            public string Period { get; set; }
            public string Dim1 { get; set; }
            public string Dim2 { get; set; }
            public string Dim3 { get; set; }
            public string Dim4 { get; set; }
            public string Dim5 { get; set; }
            public string Dim6 { get; set; }
        }
    }
}