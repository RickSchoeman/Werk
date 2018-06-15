namespace TestApplicatie.Xml
{
    public class XmlPostalAddresses
    {
        public XmlPostalAddress General { get; set; }
        public XmlPostalAddress Correspondence { get; set; }
    }

    public class XmlPostalAddress
    {
        public string ContactPerson { get; set; }
        public string StreetWithHouseNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public XmlCountry Country { get; set; }
        public string HouseNumber { get; set; }
        public bool IsEmpty { get; set; }
    }

    public class XmlCountry
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
