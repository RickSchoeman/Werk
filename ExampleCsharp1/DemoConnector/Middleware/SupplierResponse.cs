using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConnector.Middleware
{
    public class SupplierResponse
    {
        private PostalAddresses _addresses;
        private PhoneNumbers _phoneNumbers;
        private MailAddresses _eMailAddresses;
        private Bank _bank;

        public SupplierResponse()
        {
            _addresses = new PostalAddresses();
            _phoneNumbers = new PhoneNumbers();
            _eMailAddresses = new MailAddresses();
            _bank = new Bank();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public Bank Bank
        {
            get { return _bank; }
        }
        public PostalAddresses Addresses
        {
            get { return _addresses; }
        }
        public PhoneNumbers PhoneNumbers
        {
            get { return _phoneNumbers; }
        }
        public MailAddresses MailAddresses
        {
            get { return _eMailAddresses; }
        }
        public string VatNumber { get; set; }
        public string Comment { get; set; }
        public string Website { get; set; }
    }
}
