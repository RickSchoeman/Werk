using System.Collections.Generic;

namespace DemoConnector.TwinfieldAPI.Data.Relations
{
    public class Relation
    {
        public string Office { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Uid { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public bool Inuse { get; set; }
        public Behaviour Behaviour { get; set; }
        public int Touched { get; set; }
        public int Beginperiod { get; set; }
        public int Beginyear { get; set; }
        public int Endperiod { get; set; }
        public int Endyear { get; set; }
        public string Website { get; set; }
        public string Cocnumber { get; set; }
        public string Vatnumber { get; set; }
        public string Editdimensionname { get; set; }
        public Financials Financials { get; set; }
        public Remittanceadvice Remittanceadvice { get; set; }
        public Addresses Addresses { get; set; }
        public Banks Banks { get; set; }
        public Groups Groups { get; set; }
        public Postingrules Postingrules { get; set; }
        public Paymentconditions Paymentconditions { get; set; }
    }

    public enum Behaviour
    {
        Normal,
        System,
        Template
    }

    public class Financials
    {
        public MatchType? Matchtype { get; set; }
        public string Accounttype { get; set; }
        public Subanalyse Subanalyse { get; set; }
        public int Duedays { get; set; }
        public int Level { get; set; }
        public bool Payavailable { get; set; }

        public MeansOfPayment Meansofpayment
        {
            get
            {
                if (Payavailable)
                {
                    return MeansOfPayment.Paymentfile;
                }

                return MeansOfPayment.None;
            }
        }

        public string Paycode { get; set; }
        public bool Ebilling { get; set; }
        public string Ebillmail { get; set; }
        public int Substitutionlevel { get; set; }
        public string Substitutewith { get; set; }
        public string Relationsreference { get; set; }
        public string Vattype { get; set; }
        public VatCode Vatcode { get; set; }
        public bool Vatobligatory { get; set; }
        public string Performancetype { get; set; }
        public Collectmandate Collectmandate { get; set; }
        public CollectionSchema Collectionschema { get; set; }
        public Childvalidations Childvalidations { get; set; }
    }

    public enum MatchType
    {
        Notmatchable,
        Matchable,
        Customersupplier
    }

    public class VatCode
    {
        public string Name { get; set; }
        public string Shortname { get; set; }
        public Type? Type { get; set; }
        public bool Fixed { get; set; }
    }

    public enum Type
    {
        Purchase,
        Sales
    }

    public enum Subanalyse
    {
        True,
        False,
        Maybe
    }

    public enum MeansOfPayment
    {
        None,
        Paymentfile
    }

    public enum CollectionSchema
    {
        Core,
        B2B
    }

    public class Address
    {
        public AddressType Type { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string CountryName { get; set; }
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

    public enum AddressType
    {
        Invoice,
        Postal,
        Contact
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
        public int Discountdays { get; set; }
        public decimal Discountpercentage { get; set; }
    }

    public class Paymentconditions
    {
        public List<Paymentcondition> Paymentcondition { get; set; }
    }

    public class Remittanceadvice
    {
        public SendType Sendtype { get; set; }
        public string Sendmail { get; set; }
    }

    public enum SendType
    {
        ToFileManager,
        ByEmail
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
        public List<Line> Line { get; set; }
    }

    public class Line
    {
        public string Office { get; set; }
        public string Dimension1 { get; set; }
        public string Dimension2 { get; set; }
        public string Dimension3 { get; set; }
        public decimal Ratio { get; set; }
        public string Vatcode { get; set; }
        public string Description { get; set; }
    }
}