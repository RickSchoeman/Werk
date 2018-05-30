using System;
using System.Xml.Serialization;
using DemoConnector.Middleware;

namespace DemoConnector.XmlTest
{
    [XmlRoot(ElementName = "CustomerResponse")]
    public class CustomerResponseTest
    {
        [XmlElement(ElementName = "Addresses")]
        private PostalAddressesTest _addresses;
        [XmlElement(ElementName = "PhoneNumbers")]
        private PhoneNumbersTest _phoneNumbers;
        [XmlElement(ElementName = "EmailAddresses")]
        private MailAddressesTest _eMailAddresses;
        [XmlElement(ElementName = "Bank")]
        private BankTest _bank;

        public CustomerResponseTest()
        {
            _addresses = new PostalAddressesTest();
            _phoneNumbers = new PhoneNumbersTest();
            _eMailAddresses = new MailAddressesTest();
            _bank = new BankTest();
        }
        [XmlElement(ElementName = "Code")]
        public virtual String Code { get; set; }
        [XmlElement(ElementName = "Name")]
        public String Name { get; set; }
        [XmlElement(ElementName = "Bank")]
        public BankTest Bank { get { return _bank;} }
        [XmlElement(ElementName = "Addresses")]
        public PostalAddressesTest Addresses { get { return _addresses; } } //sold never be null. boxin values
        [XmlElement(ElementName = "PhoneNumbers")]
        public PhoneNumbersTest PhoneNumbers { get { return _phoneNumbers; } } //sold never be null. boxin values
        [XmlElement(ElementName = "EmailAddresses")]
        public MailAddressesTest EMailAddresses { get { return _eMailAddresses; } } //sold never be null. boxin values
        [XmlElement(ElementName = "VatNumber")]
        public String VATNumber { get; set; }
        [XmlElement(ElementName = "Comment")]
        public String Comment { get; set; }
        [XmlElement(ElementName = "LocalBusinessNumber")]
        public String LocalBusinessNumber { get; set; }
        [XmlElement(ElementName = "ImportAllowed")]
        public Boolean ImportAllowed { get; set; }
        [XmlElement(ElementName = "RegistrationNumber")]
        public String RegistrationNumber { get; set; }
        [XmlElement(ElementName = "Website")]
        public String Website { get; set; }


    }


}
