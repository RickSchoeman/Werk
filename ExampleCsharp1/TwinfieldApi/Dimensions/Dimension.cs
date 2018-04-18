using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Dimensions
{
    public class Dimension
    {
        internal static Dimension FromXml(XmlElement element)
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
                    if (elemListAddresses[i].FirstChild.InnerText != elemListAddresses[i].SelectInnerText("field2"))
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

            var paymentconditions = new List<Paymentcondition>();
            XmlNodeList elemListPaymentconditions = element.GetElementsByTagName("paymentcondition");
            for (int i = 0; i < elemListPaymentconditions.Count; i++)
            {
                if (!elemListPaymentconditions[i].SelectInnerText("discountdays").Equals(null) ||
                    !elemListPaymentconditions[i].SelectInnerText("discountdays").Equals("") ||
                    elemListPaymentconditions[i].SelectInnerText("discountdays") != null ||
                    elemListPaymentconditions[i].SelectInnerText("discountdays") != "")
                {
                    var paymentcondition = new Paymentcondition
                    {
                        Discountdays = elemListPaymentconditions[i].SelectInnerText("discountdays"),
                        Discountpercentage = elemListPaymentconditions[i].SelectInnerText("discountpercentage")
                    };
                    paymentconditions.Add(paymentcondition);
                }
            }

            return new Dimension
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
                creditmanagement = new Creditmanagement
                {
                    Responsibleuser = element.SelectInnerText("creditmanagement/responsibleuser"),
                    Basecreditlimit = element.SelectInnerText("creditmanagement/basecreditlimit"),
                    Sendreminder = element.SelectInnerText("creditmanagement/sendreminder"),
                    Reminderemail = element.SelectInnerText("creditmanagement/remindermail"),
                    Blocked = element.SelectInnerText("creditmanagement/blocked"),
                    Freetext1 = element.SelectInnerText("creditmanagement/freetext1"),
                    Freetext2 = element.SelectInnerText("creditmanagement/freetext2"),
                    Freetext3 = element.SelectInnerText("creditmanagement/freetext2"),
                    Comment = element.SelectInnerText("creditmanagement/comment")
                },
                remittanceadvice = new Remittanceadvice
                {
                    Sendtype = element.SelectInnerText("remittanceadvice/sendtype"),
                    Sendmail = element.SelectInnerText("remittanceadvice/sendmail")
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
        public Creditmanagement creditmanagement { get; set; }
        public Remittanceadvice remittanceadvice { get; set; }
        public Addresses addresses { get; set; }
        public Banks banks { get; set; }
        public Groups groups { get; set; }
        public Postingrules Postingrules { get; set; }
        public Paymentconditions paymentconditions { get; set; }

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

        public class Remittanceadvice
        {
            public string Sendtype { get; set; }
            public string Sendmail { get; set; }
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

}