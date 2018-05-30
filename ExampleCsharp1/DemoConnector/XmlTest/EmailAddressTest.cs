using System;
using DemoConnector.Middleware;

namespace DemoConnector.XmlTest
{
    public class MailAddressesTest
    {
        public MailAddressesTest()
        {
            General = new EmailAddressTest();
            Offer = new EmailAddressTest();
            Confirmation = new EmailAddressTest();
            Invoice = new EmailAddressTest();
            InvoiceReminder = new EmailAddressTest();
        }

        public EmailAddressTest General { get; set; }
        public EmailAddressTest Offer { get; set; }
        public EmailAddressTest Confirmation { get; set; }
        public EmailAddressTest Invoice { get; set; }
        public EmailAddressTest InvoiceReminder { get; set; }
    }

    public class EmailAddressTest
    {
        public String To { get; set; }
        public String CC { get; set; }
        //BCC lijkt mij niet aanwezig in boekhuoud systemen
        //Meerdere adressen scheiden met ';'

        public bool IsEmpty
        {
            get
            {
                if (string.IsNullOrWhiteSpace(To))
                {
                    if (string.IsNullOrWhiteSpace(CC))
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
        }
    }
}
