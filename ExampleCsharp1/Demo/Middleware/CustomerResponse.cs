using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Middleware
{
    class CustomerResponse
    {
        private PostalAddresses _addresses;
        private PhoneNumbers _phoneNumbers;
        private MailAddresses _eMailAddresses;

        public CustomerResponse()
        {
            _addresses = new PostalAddresses();
            _phoneNumbers = new PhoneNumbers();
            _eMailAddresses = new MailAddresses();
        }

        public virtual String Code { get; set; }
        public String Name { get; set; }
        public PostalAddresses Addressess
        {
            get { return _addresses; }
        }
        public PhoneNumbers PhoneNumbers
        {
            get { return _phoneNumbers; }
        }
        public MailAddresses EMailAddresses
        {
            get { return _eMailAddresses; }
        }
        public String VATNumber { get; set; }
        public String Comment { get; set; }
        public String LocalBusinessNumber { get; set; }
        public Boolean ImportAllowed { get; set; }
        public String RegistrationNumber { get; set; }
        public String Website { get; set; }


    }

}
