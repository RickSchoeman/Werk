using System;

namespace DemoConnector.Middleware
{
    public class MailAddresses
    {
        public MailAddresses()
        {
            General = new EmailAddress();
            Offer = new EmailAddress();
            Confirmation = new EmailAddress();
            Invoice = new EmailAddress();
            InvoiceReminder = new EmailAddress();
        }

        public EmailAddress General { get; set; }
        public EmailAddress Offer { get; set; }
        public EmailAddress Confirmation { get; set; }
        public EmailAddress Invoice { get; set; }
        public EmailAddress InvoiceReminder { get; set; }
    }

    public class EmailAddress
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
