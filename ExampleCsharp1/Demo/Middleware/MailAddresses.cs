using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Middleware
{
    class MailAddresses
    {
        public EmailAddress General { get; set; }
        public EmailAddress Offer { get; set; }
        public EmailAddress Confirmation { get; set; }
        public EmailAddress Invoice { get; set; }
        public EmailAddress InvoiceReminder { get; set; }

        public MailAddresses()
        {
            General = new EmailAddress();
            Offer = new EmailAddress();
            Confirmation = new EmailAddress();
            Invoice = new EmailAddress();
            InvoiceReminder = new EmailAddress();
        }
    }

    public class EmailAddress
    {
        public String To { get; set; }
        public String CC { get; set; }
        public Boolean IsEmpty { get; set; }
    }
}
