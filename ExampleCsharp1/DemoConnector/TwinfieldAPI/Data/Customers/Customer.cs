using System.Collections.Generic;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.Relations;

namespace DemoConnector.TwinfieldAPI.Data.Customers
{
    public class Customer : Relation
    {
        internal static Customer FromXml(XmlElement element)
        {
            var paymentconditions = new List<Paymentcondition>();
            XmlNodeList elemListPaymentconditions = element.GetElementsByTagName("paymentcondition");
            for (int i = 0; i < elemListPaymentconditions.Count; i++)
            {
                if (elemListPaymentconditions[i].SelectInnerText("discountdays") != null)
                {
                    var paymentcondition = new Paymentcondition
                    {
                        Discountdays = int.Parse(elemListPaymentconditions[i].SelectInnerText("discountdays")),
                        Discountpercentage = decimal.Parse(elemListPaymentconditions[i].SelectInnerText("discountpercentage"))
                    };
                    paymentconditions.Add(paymentcondition);
                }
            }

            var lines = new List<Line>();
            XmlNodeList elemListLine = element.GetElementsByTagName("line");
            for (int i = 0; i < elemListLine.Count; i++)
            {
                if (elemListLine[i] != null)
                {
                    var line = new Line
                    {
                        Office = elemListLine[i].SelectInnerText("office"),
                        Dimension1 = elemListLine[i].SelectInnerText("dimension1"),
                        Dimension2 = elemListLine[i].SelectInnerText("dimension2"),
                        Dimension3 = elemListLine[i].SelectInnerText("dimension3"),
                        Ratio = decimal.Parse(elemListLine[i].SelectInnerText("ratio")),
                        Vatcode = elemListLine[i].SelectInnerText("vatcode"),
                        Description = elemListLine[i].SelectInnerText("description")
                    };
                    lines.Add(line);
                }
            }

            var addresses = new List<Address>();
            XmlNodeList listAddress = element.GetElementsByTagName("address");
            for (int i = 0; i < listAddress.Count; i++)
            {
                if (listAddress[i].FirstChild.InnerText != listAddress[i].SelectInnerText("field2"))
                {
                    if (listAddress[i].SelectInnerText("name") != null)
                    {
                        var a = listAddress[i];
                        var addres = new Address
                        {
                            Name = a.SelectInnerText("name"),
                            Country = a.SelectInnerText("country"),
                            CountryName = a.SelectSingleNode("//country/@name")?.Value,
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
                if (listBanks[i] != null)
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
                if (listPost[i] != null)
                {
                    var p = listPost[i];
                    var postingrule = new Postingrule
                    {
                        Currency = p.SelectInnerText("currency"),
                        Amount = p.SelectInnerText("amount"),
                        Description = p.SelectInnerText("description"),
                        Lines = new Lines
                        {
                            Line = lines
                        }
                    };
                    postingrules.Add(postingrule);
                }
            }

            bool inuse = false;
            Behaviour behaviour = Behaviour.Normal;
            Subanalyse subanalyse = Subanalyse.False;
            bool payAvailable = false;
            bool ebilling = false;
            CollectionSchema collectionSchema = CollectionSchema.Core;
            bool vatObligatory = false;
            SendReminder sendReminder = SendReminder.False;
            bool blocked = false;
            bool freetext1 = false;
            Type type = NotImplemented.Relations.Type.Purchase;
            bool Fixed = false;
            MatchType matchType = MatchType.Notmatchable;

            if (element.SelectInnerText("inuse") == "true")
            {
                inuse = true;
            }

            if (element.SelectInnerText("behaviour") == Behaviour.System.ToString())
            {
                behaviour = Behaviour.System;
            }

            if (element.SelectInnerText("behaviour") == Behaviour.Template.ToString())
            {
                behaviour = Behaviour.Template;
            }

            if (element.SelectInnerText("financials/subanalyse") == Subanalyse.Maybe.ToString())
            {
                subanalyse = Subanalyse.Maybe;
            }

            if (element.SelectInnerText("financials/subanalyse") == Subanalyse.True.ToString())
            {
                subanalyse = Subanalyse.True;
            }

            if (element.SelectInnerText("financials/payavailable") == "true")
            {
                payAvailable = true;
            }

            if (element.SelectInnerText("financials/ebilling") == "true")
            {
                ebilling = true;
            }

            if (element.SelectInnerText("financials/collectionschema") == CollectionSchema.B2B.ToString())
            {
                collectionSchema = CollectionSchema.B2B;
            }

            if (element.SelectInnerText("financials/vatobligatory") == "true")
            {
                vatObligatory = true;
            }

            if (element.SelectInnerText("creditmanagement/sendreminder") == SendReminder.True.ToString())
            {
                sendReminder = SendReminder.True;
            }

            if (element.SelectInnerText("creditmanagement/sendreminder") == SendReminder.Email.ToString())
            {
                sendReminder = SendReminder.Email;
            }

            if (element.SelectInnerText("creditmanagement/blocked") == "true")
            {
                blocked = true;
            }

            if (element.SelectInnerText("creditmanagement/freetext1") == "true")
            {
                freetext1 = true;
            }

            if (element.SelectSingleNode("//financials/vatcode/@type")?.Value == NotImplemented.Relations.Type.Sales.ToString().ToLower())
            {
                type = NotImplemented.Relations.Type.Sales;
            }

            if (element.SelectSingleNode("//financials/vatcode/@fixed")?.Value == "true")
            {
                Fixed = true;
            }

            if (element.SelectInnerText("financials/matchtype") == MatchType.Matchable.ToString().ToLower())
            {
                matchType = MatchType.Matchable;
            }

            return new Customer
            {
                Office = element.SelectInnerText("office"),
                Type = element.SelectInnerText("type"),
                Code = element.SelectInnerText("code"),
                Uid = element.SelectInnerText("uid"),
                Name = element.SelectInnerText("name"),
                Shortname = element.SelectInnerText("shortname"),
                Inuse = inuse,
                Behaviour = behaviour,
                Touched = int.Parse(element.SelectInnerText("touched")),
                Beginperiod = int.Parse(element.SelectInnerText("beginperiod")),
                Beginyear = int.Parse(element.SelectInnerText("beginyear")),
                Endperiod = int.Parse(element.SelectInnerText("endperiod")),
                Endyear = int.Parse(element.SelectInnerText("endyear")),
                Website = element.SelectInnerText("website"),
                Cocnumber = element.SelectInnerText("cocnumber"),
                Vatnumber = element.SelectInnerText("vatnumber"),
                Editdimensionname = element.SelectInnerText("editdimensionname"),
                Financials = new Financials
                {
                    Matchtype = matchType,
                    Accounttype = element.SelectInnerText("financials/accounttype"),
                    Subanalyse = subanalyse,
                    Duedays = int.Parse(element.SelectInnerText("financials/duedays")),
                    Level = int.Parse(element.SelectInnerText("financials/level")),
                    Payavailable = payAvailable,
                    Paycode = element.SelectInnerText("financials/paycode"),
                    Ebilling = ebilling,
                    Ebillmail = element.SelectInnerText("financials/ebillmail"),
                    Substitutionlevel = int.Parse(element.SelectInnerText("financials/substitutionlevel")),
                    Substitutewith = element.SelectInnerText("financials/substitutewith"),
                    Relationsreference = element.SelectInnerText("financials/relationsreference"),
                    Vattype = element.SelectInnerText("financials/vattype"),
                    Vatcode = new VatCode
                    {
                        Name = element.SelectSingleNode("//financials/vatcode/@name")?.Value,
                        Shortname = element.SelectSingleNode("//financials/vatcode/@shortname")?.Value,
                        Type = type,
                        Fixed = Fixed,
                    },
                    Vatobligatory = vatObligatory,
                    Performancetype = element.SelectInnerText("financials/performancetype"),
                    Collectmandate = new Collectmandate
                    {
                        Id = element.SelectInnerText("financials/collectmandate/id"),
                        Signaturedate = element.SelectInnerText("financials/collectmandate/signaturedate"),
                        Firstrundate = element.SelectInnerText("financials/collectmandate/firstrundate")
                    },
                    Collectionschema = collectionSchema
                },
                Creditmanagement = new Creditmanagement
                {
                    Responsibleuser = element.SelectInnerText("creditmanagement/responsibleuser"),
                    Basecreditlimit = float.Parse(element.SelectInnerText("creditmanagement/basecreditlimit")),
                    Sendreminder = sendReminder,
                    Reminderemail = element.SelectInnerText("creditmanagement/remindermail"),
                    Blocked = blocked,
                    Freetext1 = freetext1,
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
                    Paymentcondition = paymentconditions
                }
            };
        }

        public Creditmanagement Creditmanagement { get; set; }
        public Invoicing Invoicing { get; set; } 

        public Customer()
        {
            Type = "DEB";       //Dimension type of customers is DEB.
            Beginperiod = 1;
            Beginyear = 1;
            Endperiod = 1;
            Endyear = 1;
            Financials = new Financials
            {
                Matchtype = MatchType.Customersupplier,     //Fixed value customersupplier.
                Accounttype = "inherit",            //Fixed value inherit.
                Subanalyse = Subanalyse.False,      //Fixed value false
                Duedays = 100,
                Substitutionlevel = 1,              //Level of the balancesheet account. Fixed value 1.
                Payavailable = false,               //Determines if direct debit is possible.
                Ebilling = false,                   //Determines if the sales invoices will be sent electronically to the customer.
                Vatobligatory = false,              
                Collectionschema = CollectionSchema.Core,       //Collection schema information. Apply this information only when the customer invoices are collected by SEPA direct debit.
                Collectmandate = new Collectmandate
                {
                    Id = "1"
                },
                Vatcode = new VatCode()
            };
            Creditmanagement = new Creditmanagement
            {
                Sendreminder = SendReminder.False,      //Determines if and how a customer will be reminded.
                Blocked = false,            //Indicates if related projects for this customer are blocked in time & expenses.
                Freetext1 = true,           //Right of use
                Basecreditlimit = 500,      //The credit limit amount.

            };
            Banks = new Banks();
            Postingrules = new Postingrules();
            Addresses = new Addresses();
            Paymentconditions = new Paymentconditions();
        }


    }

    public class Creditmanagement
        {
            public string Responsibleuser { get; set; }
            public float Basecreditlimit { get; set; }
            public SendReminder Sendreminder { get; set; }
            public string Reminderemail { get; set; }
            public bool Blocked { get; set; }
            public bool Freetext1 { get; set; }
            public string Freetext2 { get; set; }
            public string Freetext3 { get; set; }
            public string Comment { get; set; }
        }

    public enum SendReminder
    {
        True,
        Email,
        False
    }

        public class Invoicing
        {
            public string Discountarticle { get; set; }
        }

    
}
