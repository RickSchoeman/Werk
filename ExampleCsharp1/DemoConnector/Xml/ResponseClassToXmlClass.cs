using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.Middleware;

namespace DemoConnector.Xml
{
    public class ResponseClassToXmlClass
    {
        public XmlCustomer ConvertCustomer(CustomerResponse cr)
        {
            var convertCust = new XmlCustomer
            {
                Name = cr.Name,
                Code = cr.Code,
                VATNumber = cr.VATNumber,
                Website = cr.Website,
                Bank = new XmlBank
                {
                    Name = cr.Bank.Name,
                    AccountHolder = cr.Bank.AccountHolder,
                    AccountNumber = cr.Bank.AccountNumber,
                    BicCode = cr.Bank.BicCode,
                    IBan = cr.Bank.BicCode
                },
                Addresses = new XmlPostalAddresses
                {
                    General = new XmlPostalAddress
                    {
                        Address1 = cr.Addresses.General.Address1,
                        Address2 = cr.Addresses.General.Address2,
                        City = cr.Addresses.General.City,
                        ContactPerson = cr.Addresses.General.ContactPerson,
                        Country = new XmlCountry
                        {
                            Code = cr.Addresses.General.Country.Code,
                            Name = cr.Addresses.General.Country.Name
                        },
                        ZipCode = cr.Addresses.General.ZipCode
                    }
                },
                PhoneNumbers = new XmlPhoneNumbers
                {
                    General = cr.PhoneNumbers.General,
                    Mobile = cr.PhoneNumbers.Mobile,
                    Fax = cr.PhoneNumbers.Fax
                },
                EMailAddresses = new XmlMailAddresses
                {
                    General = new XmlEmailAddres
                    {
                        To = cr.EMailAddresses.General.To
                    },
                    Invoice = new XmlEmailAddres
                    {
                        To = cr.EMailAddresses.Invoice.To
                    },
                    InvoiceReminder = new XmlEmailAddres
                    {
                        To = cr.EMailAddresses.InvoiceReminder.To
                    }
                }
            };
            return convertCust;
        }

        public XmlSupplier ConvertSupplier(SupplierResponse sr)
        {
            var convertSup = new XmlSupplier
            {
                Name = sr.Name,
                Code = sr.Code,
                VatNumber = sr.VatNumber,
                Website = sr.Website,
                Bank = new XmlBank
                {
                    Name = sr.Bank.Name,
                    AccountHolder = sr.Bank.AccountHolder,
                    AccountNumber = sr.Bank.AccountNumber,
                    BicCode = sr.Bank.BicCode,
                    IBan = sr.Bank.BicCode
                },
                Addresses = new XmlPostalAddresses
                {
                    General = new XmlPostalAddress
                    {
                        Address1 = sr.Addresses.General.Address1,
                        Address2 = sr.Addresses.General.Address2,
                        City = sr.Addresses.General.City,
                        ContactPerson = sr.Addresses.General.ContactPerson,
                        Country = new XmlCountry
                        {
                            Code = sr.Addresses.General.Country.Code,
                            Name = sr.Addresses.General.Country.Name
                        },
                        ZipCode = sr.Addresses.General.ZipCode
                    }
                },
                PhoneNumbers = new XmlPhoneNumbers
                {
                    General = sr.PhoneNumbers.General,
                    Mobile = sr.PhoneNumbers.Mobile,
                    Fax = sr.PhoneNumbers.Fax
                },
                MailAddresses = new XmlMailAddresses
                {
                    General = new XmlEmailAddres
                    {
                        To = sr.MailAddresses.General.To
                    },
                    Invoice = new XmlEmailAddres
                    {
                        To = sr.MailAddresses.Invoice.To
                    },
                    InvoiceReminder = new XmlEmailAddres
                    {
                        To = sr.MailAddresses.InvoiceReminder.To
                    }
                }
            };
            return convertSup;
        }

        public XmlProducts ConvertProducts(List<Product> products)
        {
            var prods = new XmlProducts
            {
                Products = new List<XmlProduct>()
            };
            foreach (var p in products)
            {
                var product = new XmlProduct
                {
                    Code = p.Code,
                    Description = p.Description,
                    SalesPrice = p.SalesPrice,
                    SupplierCode = p.SupplierCode,
                    BestelEenheid = p.BestelEenheid,
                    Grootboek = p.Grootboek
                };
                prods.Products.Add(product);
            }

            return prods;
        }

        public XmlCostCenter ConvertCostCenter(CostCenterResponse ccr)
        {
            var costCenter = new XmlCostCenter
            {
                Code = ccr.Code,
                Name = ccr.Name,
                Website = ccr.Website
            };
            return costCenter;
        }

        public XmlGeneralLedger ConvertGeneralLedger(GeneralLedgerResponse glr)
        {
            var generalLedger = new XmlGeneralLedger
            {
                Code = glr.Code,
                Name = glr.Name,
                VatName = glr.VatName,
                VatType = glr.VatType
            };
            return generalLedger;
        }

        public XmlSalesInvoice ConvertSalesInvoice(SalesInvoiceResponse sir)
        {
            var lines = new List<XmlSalesInvoiceLine>();
            foreach (var l in sir.SalesInvoiceLines.SalesInvoiceLine)
            {
                var line = new XmlSalesInvoiceLine
                {
                    Amount = l.Amount,
                    Currency = l.Currency,
                    Description = l.Description,
                    Quantity = l.Quantity,
                    VatPercentage = l.VatPercent,
                    VatType = l.VatType,
                    Article = l.Article,
                    Subarticle = l.Subarticle
                };
                lines.Add(line);
            }
            var salesInoice = new XmlSalesInvoice
            {
                CustomerId = sir.CustomerId,
                CustomerReference = sir.CustomerReference,
                OrderNummer = sir.OrderNummer,
                OrderType = sir.OrderType,
                SalesInvoiceLines = lines
            };
            return salesInoice;
        }
    }
}
