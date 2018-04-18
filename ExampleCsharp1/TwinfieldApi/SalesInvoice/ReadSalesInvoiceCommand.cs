﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.SalesInvoice
{
    public class ReadSalesInvoiceCommand
    {
        public string Office { get; set; }
        public string SalesInvoiceType { get; set; }
        public string InvoiceNumber { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var readElement = command.AppendNewElement("read");
            readElement.AppendNewElement("type").InnerText = "salesinvoice";
            readElement.AppendNewElement("office").InnerText = Office;
            //hij haalt gegevens op die niet bestaan in de omgeving
            readElement.AppendNewElement("code").InnerText = SalesInvoiceType;
            readElement.AppendNewElement("invoicenumber").InnerText = InvoiceNumber;
            return command;
        }
    }
}