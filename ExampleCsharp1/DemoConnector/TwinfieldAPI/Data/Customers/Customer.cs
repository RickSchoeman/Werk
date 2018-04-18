using System.Collections.Generic;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Data.Customers
{
    public class Customer
    {
        internal static Customer FromXml(XmlElement element)
        {
            var addresses = new List<Address>();
            XmlNodeList listAddress = element.GetElementsByTagName("address");
            for (int i = 0; i < listAddress.Count; i++)
            {
                if (listAddress[i].FirstChild.InnerText != listAddress[i].SelectInnerText("field2"))
                {
                    if (listAddress[i].SelectInnerText("name") != null || !listAddress[i].SelectInnerText("name").Equals(null))
                    {
                    var a = listAddress[i];
                    var addres = new Address
                    {
                        Name = a.SelectInnerText("name"),
                        Country = a.SelectInnerText("country"),
                        City = a.SelectInnerText("city"),
                        Postcode = a.SelectInnerText("postcode"),
                        Telephone = a.SelectInnerText("telephone"),
                        Telefax = a.SelectInnerText("telefax"),
                        Email = a.SelectInnerText("email"),
                        Contact = a.SelectInnerText("contact"),
                        Field1 = a.SelectInnerText("field1"),
                        Field2 = a.SelectInnerText("field2"),
                        Field3 = a.SelectInnerText("field3"),
                        Field4 = a.SelectInnerText("field4"),
                        Field5 = a.SelectInnerText("field5"),
                        Field6 = a.SelectInnerText("field6")
                    };
                    addresses.Add(addres);
                    }

                }
            }

            var banks = new List<Bank>();
            XmlNodeList listBanks = element.GetElementsByTagName("bank");
            for (int i = 0; i < listBanks.Count; i++)
            {
                if (!listBanks[i].Equals(null) || listBanks[i] != null || !listBanks[i].SelectInnerText("ascription").Equals("") || listBanks[i].SelectInnerText("ascription") != "")
                {
                    var b = listBanks[i];
                    var bank = new Bank
                    {
                        Ascription = b.SelectInnerText("ascription"),
                        Accountnumber = b.SelectInnerText("accountnumber"),
                        Address = new Address
                        {
                            Field2 = b.SelectInnerText("address/field2"),
                            Field3 = b.SelectInnerText("address/field3")
                        },
                        Bankname = b.SelectInnerText("bankname"),
                        Biccode = b.SelectInnerText("biccode"),
                        City = b.SelectInnerText("city"),
                        Country = b.SelectInnerText("country"),
                        Iban = b.SelectInnerText("iban"),
                        Natbiccode = b.SelectInnerText("natbiccode"),
                        Postcode = b.SelectInnerText("postcode"),
                        State = b.SelectInnerText("state")
                    };
                    banks.Add(bank);
                }
            }

            var postingrules = new List<Postingrule>();
            XmlNodeList listPost = element.GetElementsByTagName("postingrule");
            for (int i = 0; i < listPost.Count; i++)
            {
                if (!listPost[i].Equals(null) || listPost[i] != null || !listPost[i].SelectInnerText("currency").Equals("") || listPost[i].SelectInnerText("currency") != "")
                {
                    var p = listPost[i];
                    var postingrule = new Postingrule
                    {
                        Currency = p.SelectInnerText("currency"),
                        Amount = p.SelectInnerText("amount"),
                        Description = p.SelectInnerText("description"),
                        Lines = new Lines
                        {
                            Line = new Line
                            {
                                Office = p.SelectInnerText("lines/line/office"),
                                Dimension1 = p.SelectInnerText("lines/line/dimension1"),
                                Dimension2 = p.SelectInnerText("lines/line/dimension2"),
                                Dimension3 = p.SelectInnerText("lines/line/dimension3"),
                                Ratio = p.SelectInnerText("lines/line/ratio"),
                                Vatcode = p.SelectInnerText("lines/line/vatcode"),
                                Description = p.SelectInnerText("lines/line/description")
                            }
                        }
                    };
                    postingrules.Add(postingrule);
                }
            }

            return new Customer
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
                Financials = new Financials
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
                    Substitutionlevel = element.SelectInnerText("financials/substitutionlevel"),
                    Substitutewith = element.SelectInnerText("financials/substitutewith"),
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
                Creditmanagement = new Creditmanagement
                {
                    Responsibleuser = element.SelectInnerText("creditmanagement/responsibleuser"),
                    Basecreditlimit = element.SelectInnerText("creditmanagement/basecreditlimit"),
                    Sendreminder = element.SelectInnerText("creditmanagement/sendreminder"),
                    Reminderemail = element.SelectInnerText("creditmanagement/remindermail"),
                    Blocked = element.SelectInnerText("creditmanagement/blocked"),
                    Freetext1 = element.SelectInnerText("creditmanagement/freetext1"),
                    Freetext2 = element.SelectInnerText("creditmanagement/freetext2"),
                    Freetext3 = element.SelectInnerText("creditmanagement/freetext3"),
                    Comment = element.SelectInnerText("creditmanagement/comment")
                },
                Invoicing = new Invoicing
                {
                    Discountarticle = element.SelectInnerText("invoicing/discountarticle")
                },
                Addresses = new Addresses
                {
                    Address = addresses
                },
                Banks = new Banks
                {
                    Bank = banks
                },
                Groups = new Groups
                {
                    Group = element.SelectInnerText("groups/group")
                },
                Postingrules = new Postingrules
                {
                    Postingrule = postingrules
                },
                Paymentconditions = new Paymentconditions
                {
                    Paymentcondition = new Paymentcondition
                    {
                        Discountdays = element.SelectInnerText("paymentconditions/paymentcondition/discountdays"),
                        Discountpercentage = element.SelectInnerText("paymentconditions/paymentcondition/discountpercentage")
                    }
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
        public Financials Financials { get; set; }
        public Creditmanagement Creditmanagement { get; set; }
        public  Invoicing Invoicing { get; set; }
        public Addresses Addresses { get; set; }
        public Banks Banks { get; set; }
        public Groups Groups { get; set; }
        public Postingrules Postingrules { get; set; }
        public Paymentconditions Paymentconditions { get; set; }
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

    public class Collectmandate
    {
        public string Id { get; set; }
        public string Signaturedate { get; set; }
        public string Firstrundate { get; set; }
    }

    public class Creditmanagement
    {
        public string Responsibleuser { get; set; }
        public string Basecreditlimit { get; set; }
        public string Sendreminder { get; set; }
        public string Reminderemail { get; set; }
        public string Blocked { get; set; }
        public string Freetext1 { get; set; }
        public string Freetext2 { get; set; }
        public string Freetext3 { get; set; }
        public string Comment { get; set; }
    }

    public class Invoicing
    {
        public string Discountarticle { get; set; }
    }

    public class Addresses
    {
        public List<Address> Address { get; set; }
    }

    public class Address
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Telephone { get; set; }
        public string Telefax { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
    }

    public class Banks
    {
        public List<Bank> Bank { get; set; }
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
        public Lines Lines { get; set; }
    }

    public class Lines
    {
        public Line Line { get; set; }
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

    public class Paymentconditions
    {
        public Paymentcondition Paymentcondition { get; set; }
    }

    public class Paymentcondition
    {
        public string Discountdays { get; set; }
        public string Discountpercentage { get; set; }
    }
}
