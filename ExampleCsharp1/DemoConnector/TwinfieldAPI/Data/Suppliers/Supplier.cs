using System.Collections.Generic;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Data.Suppliers
{
    public class Supplier
    {
        internal static Supplier FromXml(XmlElement element)
        {
            var addresses = new List<Address>();
            XmlNodeList elemListAddresses = element.GetElementsByTagName("address");
            for (int i = 0; i < elemListAddresses.Count; i++)
            {
                if (!elemListAddresses[i].SelectInnerText("name").Equals(null) || !elemListAddresses[i].SelectInnerText("name").Equals("") || elemListAddresses[i].SelectInnerText("name") != null || elemListAddresses[i].SelectInnerText("name") != "")
                {
                    var address = new Address
                    {
                        Name = elemListAddresses[i].SelectInnerText("name"),
                        Country = elemListAddresses[i].SelectInnerText("country"),
                        City = elemListAddresses[i].SelectInnerText("city"),
                        Postcode = elemListAddresses[i].SelectInnerText("postcode"),
                        Telephone = elemListAddresses[i].SelectInnerText("telephone"),
                        Telefax = elemListAddresses[i].SelectInnerText("telefax"),
                        Email = elemListAddresses[i].SelectInnerText("email"),
                        Contact = elemListAddresses[i].SelectInnerText("contact"),
                        Field1 = elemListAddresses[i].SelectInnerText("field1"),
                        Field2 = elemListAddresses[i].SelectInnerText("field2"),
                        Field3 = elemListAddresses[i].SelectInnerText("field3"),
                        Field4 = elemListAddresses[i].SelectInnerText("field4"),
                        Field5 = elemListAddresses[i].SelectInnerText("field5"),
                        Field6 = elemListAddresses[i].SelectInnerText("field6"),
                    };
                    addresses.Add(address);
                }
            }
            var banks = new List<Bank>();
            XmlNodeList elemListBanks = element.GetElementsByTagName("bank");
            for (int i = 0; i < elemListBanks.Count; i++)
            {
                if (!elemListBanks[i].SelectInnerText("ascription").Equals(null) || !elemListBanks[i].SelectInnerText("ascription").Equals("") || elemListBanks[i].SelectInnerText("ascription") != null || elemListBanks[i].SelectInnerText("ascription") != "")
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
            var paymentconditions = new List<Paymentcondition>();
            XmlNodeList elemListPaymentconditions = element.GetElementsByTagName("paymentcondition");
            for (int i = 0; i < elemListPaymentconditions.Count; i++)
            {
                if (!elemListPaymentconditions[i].SelectInnerText("discountdays").Equals(null) || !elemListPaymentconditions[i].SelectInnerText("discountdays").Equals("") || elemListPaymentconditions[i].SelectInnerText("discountdays") != null || elemListPaymentconditions[i].SelectInnerText("discountdays") != "")
                {
                    var paymentcondition = new Paymentcondition
                    {
                        Discountdays = elemListPaymentconditions[i].SelectInnerText("discountdays"),
                        Discountpercentage = elemListPaymentconditions[i].SelectInnerText("discountpercentage")
                    };
                    paymentconditions.Add(paymentcondition);
                }
            }

            var lines = new List<Line>();
            XmlNodeList elemListLine = element.GetElementsByTagName("line");
            for (int i = 0; i < elemListLine.Count; i++)
            {
                if (!elemListLine[i].Equals(null) || elemListLine[i] != null ||
                    !elemListLine[i].SelectInnerText("office").Equals("") ||
                    elemListLine[i].SelectInnerText("office") != "")
                {
                    var line = new Line
                    {
                        Office = elemListLine[i].SelectInnerText("office"),
                        Dimension1 = elemListLine[i].SelectInnerText("dimension1"),
                        Dimension2 = elemListLine[i].SelectInnerText("dimension2"),
                        Dimension3 = elemListLine[i].SelectInnerText("dimension3"),
                        Ratio = elemListLine[i].SelectInnerText("ratio"),
                        Vatcode = elemListLine[i].SelectInnerText("vatcode"),
                        Description = elemListLine[i].SelectInnerText("description")
                    };
                    lines.Add(line);
                }
            }

            var postingrules = new List<Postingrule>();
            XmlNodeList elemListPostingrules = element.GetElementsByTagName("postingrule");
            for (int i = 0; i < elemListPostingrules.Count; i++)
            {
                if (!elemListPostingrules[i].Equals(null) || elemListPostingrules[i] != null ||
                    !elemListPostingrules[i].SelectInnerText("currency").Equals("") ||
                    elemListPostingrules[i].SelectInnerText("currency") != "")
                {
                    var postingrule = new Postingrule
                    {
                        Currency = elemListPostingrules[i].SelectInnerText("currency"),
                        Amount = elemListPostingrules[i].SelectInnerText("amount"),
                        Description = elemListPostingrules[i].SelectInnerText("description"),
                        lines = new Lines
                        {
                            Line = lines
                        }
                    };
                    postingrules.Add(postingrule);
                }
            }

            return new Supplier
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
                addresses = new Addresses
                {
                    Address = addresses
                },
                groups = new Groups
                {
                    Group = element.SelectInnerText("groups/group")
                },
                banks = new Banks
                {
                    Bank = banks
                },
                paymentconditions = new Paymentconditions
                {
                    Paymentcondition = paymentconditions
                },
                postingrules = new Postingrules
                {
                    Postingrule = postingrules
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
        public Addresses addresses { get; set; }
        public Banks banks { get; set; }
        public Groups groups { get; set; }
        public Postingrules postingrules { get; set; }
        public Paymentconditions paymentconditions { get; set; }


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
            dimension.AppendNewElement("financials/collectmandate/signaturedate").InnerText = financials.Collectmandate.Signaturedate;
            dimension.AppendNewElement("financials/collectmandate/firstrundate").InnerText = financials.Collectmandate.Firstrundate;
            dimension.AppendNewElement("financials/collectionschema").InnerText = financials.Collectionschema;
            dimension.AppendNewElement("financials/childvalidations/childvalidation").InnerText = financials.Childvalidations.Childvalidation;
            for (int i = 0; i < addresses.Address.Count; i++)
            {
                if (!addresses.Address[i].Equals(null) || addresses.Address[i] != null || !addresses.Address[i].Name.Equals("") || addresses.Address[i].Name != "")
                {
                    var address = addresses.Address[i];
                    dimension.AppendNewElement("addresses/address[@id='" + i + "']/name").InnerText = address.Name;
                    dimension.AppendNewElement("addresses/address[@id='" + i + "']/country").InnerText = address.Country;
                    dimension.AppendNewElement("addresses/address[@id='" + i + "']/city").InnerText = address.City;
                    dimension.AppendNewElement("addresses/address[@id='" + i + "']/postcode").InnerText = address.Postcode;
                    dimension.AppendNewElement("addresses/address[@id='" + i + "']/telephone").InnerText = address.Telephone;
                    dimension.AppendNewElement("addresses/address[@id='" + i + "']/telefax").InnerText = address.Telefax;
                    dimension.AppendNewElement("addresses/address[@id='" + i + "']/email").InnerText = address.Email;
                    dimension.AppendNewElement("addresses/address[@id='" + i + "']/contact").InnerText = address.Contact;
                    dimension.AppendNewElement("addresses/address[@id='" + i + "']/field1").InnerText = address.Field1;
                    dimension.AppendNewElement("addresses/address[@id='" + i + "']/field2").InnerText = address.Field2;
                    dimension.AppendNewElement("addresses/address[@id='" + i + "']/field3").InnerText = address.Field3;
                    dimension.AppendNewElement("addresses/address[@id='" + i + "']/field4").InnerText = address.Field4;
                    dimension.AppendNewElement("addresses/address[@id='" + i + "']/field5").InnerText = address.Field5;
                    dimension.AppendNewElement("addresses/address[@id='" + i + "']/field6").InnerText = address.Field6;
                }
            }

            for (int i = 0; i < banks.Bank.Count; i++)
            {
                if (!banks.Bank[i].Equals(null) || banks.Bank[i] != null || !banks.Bank[i].Ascription.Equals("") || banks.Bank[i].Ascription != "")
                {
                    var bank = banks.Bank[i];
                    dimension.AppendNewElement("banks/bank[@id='" + i + "']/ascription").InnerText = bank.Ascription;
                    dimension.AppendNewElement("banks/bank[@id='" + i + "']/accountnumber").InnerText = bank.Accountnumber;
                    dimension.AppendNewElement("banks/bank[@id='" + i + "']/address/field2").InnerText = bank.Address.Field2;
                    dimension.AppendNewElement("banks/bank[@id='" + i + "']/address/field3").InnerText = bank.Address.Field3;
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

            dimension.AppendNewElement("groups/group").InnerText = groups.Group;
            for (int i = 0; i < paymentconditions.Paymentcondition.Count; i++)
            {
                if (!paymentconditions.Paymentcondition[i].Equals(null) || paymentconditions.Paymentcondition[i] != null || !paymentconditions.Paymentcondition[i].Discountdays.Equals("") || paymentconditions.Paymentcondition[i].Discountdays != "")
                {
                    var paymentcondition = paymentconditions.Paymentcondition[i];
                    dimension.AppendNewElement("paymentconditions/paymentcondition[@id='" + i + "']/discountdays").InnerText = paymentcondition.Discountdays;
                    dimension.AppendNewElement("paymentconditions/paymentcondition[@id='" + i + "']/discountpercentage").InnerText = paymentcondition.Discountpercentage;
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
            public string Name { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public string Postcode { get; set; }
            public string Telephone { get; set; }
            public string Telefax { get; set; }
            public string Email { get; set; }
            public string Contact { get; set; }
            public string Field1 { get; set; }
            public string Field2 { get; set; }
            public string Field3 { get; set; }
            public string Field4 { get; set; }
            public string Field5 { get; set; }
            public string Field6 { get; set; }
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

        public class Paymentcondition
        {
            public string Discountdays { get; set; }
            public string Discountpercentage { get; set; }
        }

        public class Paymentconditions
        {
            public List<Paymentcondition> Paymentcondition { get; set; }
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

        public class Groups
        {
            public string Group { get; set; }
        }

        public class Postingrules
        {
            public List<Postingrule> Postingrule { get; set; }
        }

        public class Postingrule
        {
            public string Id { get; set; }
            public string Currency { get; set; }
            public string Amount { get; set; }
            public string Description { get; set; }
            public Lines lines { get; set; }
        }

        public class Lines
        {
            public List<Line> Line { get; set; }
        }

        public class Line
        {
            public string Office { get; set; }
            public string Dimension1 { get; set; }
            public string Dimension2 { get; set; }
            public string Dimension3 { get; set; }
            public string Ratio { get; set; }
            public string Vatcode { get; set; }
            public string Description { get; set; }
        }
    }
}
