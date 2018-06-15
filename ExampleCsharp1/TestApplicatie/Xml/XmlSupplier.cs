﻿namespace TestApplicatie.Xml
{
    public class XmlSupplier
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public XmlBank Bank { get; set; }
        public XmlPostalAddresses Addresses { get; set; }
        public XmlPhoneNumbers PhoneNumbers { get; set; }
        public XmlMailAddresses MailAddresses { get; set; }
        public string VatNumber { get; set; }
        public string Comment { get; set; }
        public string Website { get; set; }
    }
}