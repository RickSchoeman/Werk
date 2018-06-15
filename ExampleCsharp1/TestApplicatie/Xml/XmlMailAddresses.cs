namespace TestApplicatie.Xml
{
    public class XmlMailAddresses
    {
        public XmlEmailAddress General { get; set; }
        public XmlEmailAddress Offer { get; set; }
        public XmlEmailAddress Confirmation { get; set; }
        public XmlEmailAddress Invoice { get; set; }
        public XmlEmailAddress InvoiceReminder { get; set; }
    }

    public class XmlEmailAddress
    {
        public string To { get; set; }
        public string CC { get; set; }
        public bool IsEmpty { get; set; }
    }
}
