using System.Xml.Serialization;
using DemoConnector.Middleware;

namespace DemoConnector.XmlTest
{
    [XmlRoot(ElementName = "PostalAddresses")]
    public class PostalAddressesTest
    {
        public PostalAddressesTest()
        {
            General = new PostalAddressTest();
            Correspondence = new PostalAddressTest();
        }
        [XmlElement(ElementName = "General")]
        public PostalAddressTest General { get; set; }
        [XmlElement(ElementName = "Correspondence")]
        public PostalAddressTest Correspondence { get; set; }
    }
    [XmlRoot(ElementName = "Country")]
    public class CountryTest
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Code")]
        public string Code { get; set; }
    }

    [XmlRoot(ElementName = "PostalAddress")]
    public class PostalAddressTest
    {
        [XmlElement(ElementName = "Country")]
        private CountryTest _country;
        public PostalAddressTest()
        {
            _country = new CountryTest();
        }

        [XmlElement(ElementName = "ContactPersoon")]
        public string ContactPerson { get; set; }

        //TASK: Roel:        voor voegsel en dergelijke regelen.




        [XmlElement(ElementName = "StreetWithHouseNumber")]
        public string StreetWithHouseNumber { get; set; }


        [XmlElement(ElementName = "Address1")]
        public string Address1 { get; set; }
        [XmlElement(ElementName = "Address2")]
        public string Address2 { get; set; }
        [XmlElement(ElementName = "Address3")]
        public string Address3 { get; set; }
        [XmlElement(ElementName = "ZipCode")]
        public string ZipCode { get; set; }
        [XmlElement(ElementName = "City")]
        public string City { get; set; }
        /// <summary>
        /// Land
        /// </summary>
        [XmlElement(ElementName = "Country")]
        public CountryTest Country { get { return _country; } }
        [XmlElement(ElementName = "HouseNumber")]
        public string HouseNumber { get; set; }


        [XmlElement(ElementName = "IsEmpty")]
        public bool IsEmpty
        {
            get
            {
                //todo: uitbreiden

                if (!string.IsNullOrWhiteSpace(ContactPerson))
                    return false;

                if (!string.IsNullOrWhiteSpace(Address1))
                    return false;

                if (!string.IsNullOrWhiteSpace(ZipCode))
                    return false;

                if (!string.IsNullOrWhiteSpace(City))
                    return false;

                if (!string.IsNullOrWhiteSpace(HouseNumber))
                    return false;

                if (!string.IsNullOrWhiteSpace(Country.Code))
                    return false;

                return true;
            }
        }
    }
}
