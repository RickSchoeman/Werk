using System.Collections.Generic;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Relations;

namespace DemoConnector.TwinfieldAPI.Data.Suppliers
{
    public class Supplier : Relation
    {
        internal static Supplier FromXml(XmlElement element)
        {
            var addresses = new List<Address>();
            XmlNodeList elemListAddresses = element.GetElementsByTagName("address");
            for (int i = 0; i < elemListAddresses.Count; i++)
            {
                if (elemListAddresses[i].SelectInnerText("name") != null)
                {
                    var address = new Address
                    {
                        Name = elemListAddresses[i].SelectInnerText("name"),
                        Country = elemListAddresses[i].SelectInnerText("country"),
                        CountryName = elemListAddresses[i].SelectSingleNode("//country/@name")?.Value,
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
                if (elemListBanks[i].SelectInnerText("ascription") != null)
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

            var postingrules = new List<Postingrule>();
            XmlNodeList elemListPostingrules = element.GetElementsByTagName("postingrule");
            for (int i = 0; i < elemListPostingrules.Count; i++)
            {
                if (elemListPostingrules[i] != null)
                {
                    var postingrule = new Postingrule
                    {
                        Currency = elemListPostingrules[i].SelectInnerText("currency"),
                        Amount = elemListPostingrules[i].SelectInnerText("amount"),
                        Description = elemListPostingrules[i].SelectInnerText("description"),
                        Lines = new Lines
                        {
                            Line = lines
                        }
                    };
                    postingrules.Add(postingrule);
                }
            }

            bool inuse = false;
            Relations.Behaviour behaviour = Behaviour.Normal;
            Subanalyse subanalyse = Subanalyse.False;
            bool payAvailable = false;
            bool ebilling = false;
            CollectionSchema collectionSchema = CollectionSchema.Core;
            bool vatObligatory = false;
            Relations.Type type = Relations.Type.Purchase;
            bool Fixed = false;
            MatchType matchType = MatchType.Notmatchable;

            if (element.SelectInnerText("inuse") == "true")
            {
                inuse = true;
            }

            if (element.SelectInnerText("behaviour") == Relations.Behaviour.System.ToString())
            {
                behaviour = Behaviour.System;
            }

            if (element.SelectInnerText("behaviour") == Relations.Behaviour.Template.ToString())
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

            if (element.SelectSingleNode("//financials/vatcode/@type")?.Value == Relations.Type.Sales.ToString().ToLower())
            {
                type = Relations.Type.Sales;
            }

            if (element.SelectSingleNode("//financials/vatcode/@fixed")?.Value == "true")
            {
                Fixed = true;
            }

            if (element.SelectInnerText("financials/matchtype") == MatchType.Matchable.ToString().ToLower())
            {
                matchType = MatchType.Matchable;
            }

            return new Supplier
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
                    Substitutewith = element.SelectInnerText("financials/substitutewtith"),
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
                    Collectionschema = collectionSchema,
                    Childvalidations = new Childvalidations
                    {
                        Childvalidation = element.SelectInnerText("financials/childvalidations/childvalidation")
                    }
                },
                Addresses = new Addresses
                {
                    Address = addresses
                },
                Groups = new Groups
                {
                    Group = element.SelectInnerText("groups/group")
                },
                Banks = new Banks
                {
                    Bank = banks
                },
                Paymentconditions = new Paymentconditions
                {
                    Paymentcondition = paymentconditions
                },
                Postingrules = new Postingrules
                {
                    Postingrule = postingrules
                }
            };
        }

        public Supplier()
        {
            Type = "CRD";       //Dimension type of customers is DEB.
            Beginperiod = 1;
            Beginyear = 1965;
            Endperiod = 1;
            Endyear = 2019;
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
                Level = 2,
                Collectionschema = CollectionSchema.Core,       //Collection schema information. Apply this information only when the customer invoices are collected by SEPA direct debit.
                Collectmandate = new Collectmandate()
            };
            Banks = new Banks();
            Postingrules = new Postingrules();
            Addresses = new Addresses();
            Paymentconditions = new Paymentconditions();
        }
        
    }
}