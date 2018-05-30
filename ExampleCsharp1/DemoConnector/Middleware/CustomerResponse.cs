using System;
using System.Xml.Serialization;

namespace DemoConnector.Middleware
{
    public class CustomerResponse
    {
        private PostalAddresses _addresses;
        private PhoneNumbers _phoneNumbers;
        private MailAddresses _eMailAddresses;
        private Bank _bank;

        public CustomerResponse()
        {
            _addresses = new PostalAddresses();
            _phoneNumbers = new PhoneNumbers();
            _eMailAddresses = new MailAddresses();
            _bank = new Bank();
        }

        public virtual String Code { get; set; }
        public String Name { get; set; }
        public Bank Bank { get { return _bank;} }
        public PostalAddresses Addresses { get { return _addresses; } } //sold never be null. boxin values
        public PhoneNumbers PhoneNumbers { get { return _phoneNumbers; } } //sold never be null. boxin values
        public MailAddresses EMailAddresses { get { return _eMailAddresses; } } //sold never be null. boxin values
        public String VATNumber { get; set; }
        public String Comment { get; set; }
        public String LocalBusinessNumber { get; set; }
        public Boolean ImportAllowed { get; set; }
        public String RegistrationNumber { get; set; }
        public String Website { get; set; }


    }

}
