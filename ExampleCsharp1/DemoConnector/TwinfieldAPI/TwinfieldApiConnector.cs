using System;
using System.Collections.Generic;
using DemoConnector.Middleware;
//using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Converters;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.BalanceSheet;
using DemoConnector.TwinfieldAPI.Data.CostCenters;
using DemoConnector.TwinfieldAPI.Data.Customers;
using DemoConnector.TwinfieldAPI.Data.Extras.Countries;
using DemoConnector.TwinfieldAPI.Data.Suppliers;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using DemoConnector.Xml;

namespace DemoConnector.TwinfieldAPI
{
    public class TwinfieldApiConnector
    {
        readonly IClientFactory clientFactory = new ClientFactory();
        private Session _session;
        private IApiOperationsBase<Customer> _customerInterface;
        private IApiOperationsBase<Supplier> _supplierInterface;
        private IApiOperationsBase<BalanceSheet> _balanceSheetInterface;
        private IArticleInterface _articleInterface;
        private ISalesInvoiceInterface _salesInvoiceInterface;
        private IApiOperationsBase<CostCenter> _costCenterInterface;
        private ICostCenterConverter _costCenterConverter;
        private IGeneralLedgerConverter _generalLedgerConverter;
        private IDimensionTypeInterface _dimensionTypeInterface;
        private ICustomerConverter _customerConverter;
        private ISupplierConverter _supplierConverter;
        private IArticleConverter _articleConverter;
        private ISalesInvoiceConverter _salesInvoiceConverter;
        private ApiSummaryBase _countryOperations;

        public void TestConnection(string loginServerUrl, string user, string password, string organisation,
            string office)
        {
            if (Login(loginServerUrl, user, password, organisation).Equals(null))
            {
                return;
            }

            if (!SwitchToOffice(office, _session))
            {
                return;
            }
            //            foreach (var a in (new OfficeOperations(_session)).GetAllOffices())
            //            {
            //                Console.WriteLine("code = {0}", a.Code);
            //                Console.WriteLine("name = {0}", a.Name);
            //                Console.WriteLine();
            //            }
            //            
            //                        if (!SwitchToOffice(Console.ReadLine()))
            //                        {
            //                            return;
            //                        }


            //            (new OfficeDemo(_session)).Run();
            //            (new CustomerDemo(_session)).Run();
            //            (new BankBookDemo(_session)).Run();
            //            (new BookkeepingDemo(_session)).Run();
            //            var bankBook = (new Operations(_session)).GetBankBookByCode("BNK");
            //            Console.WriteLine("name = {0}", bankBook.Name);
            //            var cashbook = (new Operations(_session)).GetCashBookByCode("CASHBOOK");
            //            Console.WriteLine("name = {0}", cashbook.Name);
            //            var deletedTransactions =
            //                (new Operations(_session)).GetDeletedTransactionsByType("BNK", new DateTime(1995, 01, 01),
            //                    new DateTime(2019, 12, 12));
            //            var periods = (new Operations(_session)).GetAllPeriodsByYear(2018);
            //            var years = (new Operations(_session)).GetAllYears();
            //
            //            (new Operations(_session)).RegisterBlockedAmountForTransaction("NLA000218", "INK", 001, 1, 2000);
            //            (new Operations(_session)).UnregisterBlockedAmountForTransaction("NLA000218", "INK", 001, 1);
            //

            //            foreach (var d in _costCenterInterface.GetAll())
            //            {
            //                Console.WriteLine("Code = {0}", d.Name);
            //            }


            #region customer

            //            var customer = (new Operations(_session)).GetCustomersByName("1002");
            //            var customerResponse = (new CustomerConverter()).ConvertCustomer(customer[0]);
            //            Console.WriteLine("code = {0}", customerResponse.Code);
            //            Console.WriteLine("name = {0}", customerResponse.Name);
            //            foreach (var a in customerResponse.Addressess.postalAddresses)
            //            {
            //                Console.WriteLine("contactpersoon = {0}", a.Contactpersoon);
            //                Console.WriteLine("streetwithhousenumber = {0}", a.StreetWithHouseNumber);
            //                Console.WriteLine("address1 = {0}", a.Address1);
            //                Console.WriteLine("address2 = {0}", a.Address2);
            //                Console.WriteLine("address3 = {0}", a.Address3);
            //                Console.WriteLine("zipcode = {0}", a.ZipCode);
            //                Console.WriteLine("city = {0}", a.City);
            //                Console.WriteLine("countrycode = {0}", a.Country.Code);
            //                Console.WriteLine("countryname = {0}", a.Country.Name);
            //                Console.WriteLine("housenumber = {0}", a.HouseNumber);
            //            }
            //            Console.WriteLine("phonenumbers:");
            //            Console.WriteLine("general = {0}", customerResponse.PhoneNumbers.General);
            //            Console.WriteLine("fax = {0}", customerResponse.PhoneNumbers.Fax);
            //            Console.WriteLine("mobile = {0}", customerResponse.PhoneNumbers.Mobile);
            //
            //            Console.WriteLine("emailaddresses:");
            //            Console.WriteLine("general:");
            //            Console.WriteLine("to = {0}", customerResponse.EMailAddresses.General.To);
            //            Console.WriteLine("cc = {0}", customerResponse.EMailAddresses.General.CC);
            //            Console.WriteLine("isempty = {0}", customerResponse.EMailAddresses.General.IsEmpty);
            //            Console.WriteLine("offer:");
            //            Console.WriteLine("to = {0}", customerResponse.EMailAddresses.Offer.To);
            //            Console.WriteLine("cc = {0}", customerResponse.EMailAddresses.Offer.CC);
            //            Console.WriteLine("isempty = {0}", customerResponse.EMailAddresses.Offer.IsEmpty);
            //            Console.WriteLine("confirmation:");
            //            Console.WriteLine("to = {0}", customerResponse.EMailAddresses.Confirmation.To);
            //            Console.WriteLine("cc = {0}", customerResponse.EMailAddresses.Confirmation.CC);
            //            Console.WriteLine("isempty = {0}", customerResponse.EMailAddresses.Confirmation.IsEmpty);
            //            Console.WriteLine("invoice:");
            //            Console.WriteLine("to = {0}", customerResponse.EMailAddresses.Invoice.To);
            //            Console.WriteLine("cc = {0}", customerResponse.EMailAddresses.Invoice.CC);
            //            Console.WriteLine("isempty = {0}", customerResponse.EMailAddresses.Invoice.IsEmpty);
            //            Console.WriteLine("invoicereminder:");
            //            Console.WriteLine("to = {0}", customerResponse.EMailAddresses.InvoiceReminder.To);
            //            Console.WriteLine("cc = {0}", customerResponse.EMailAddresses.InvoiceReminder.CC);
            //            Console.WriteLine("isempty = {0}", customerResponse.EMailAddresses.InvoiceReminder.IsEmpty);
            //            Console.WriteLine("-");
            //            Console.WriteLine("vatnumber = {0}", customerResponse.VATNumber);
            //            Console.WriteLine("comment = {0}", customerResponse.Comment);
            //            Console.WriteLine("localbusinessnumber = {0}", customerResponse.LocalBusinessNumber);
            //            Console.WriteLine("importallowed = {0}", customerResponse.ImportAllowed);
            //            Console.WriteLine("registrationnumber = {0}", customerResponse.RegistrationNumber);
            //            Console.WriteLine("website = {0}", customerResponse.Website);
            //
            //                                    var cr = new CustomerResponse
            //                                    {
            //                                        Code = "1797",
            //                                        Name = "testCust"
            //                                    };
            //                                    cr.Addresses.General = new PostalAddress
            //                                    {
            //                                        Address1 = "testaddress",
            //                                        City = "veenendaal",
            //                                        Country =
            //                                        {
            //                                            Code = "NL",
            //                                            Name = "Nederland"
            //                                        },
            //                                        ZipCode = "3905GG"
            //                                    };
            //                                    cr.Bank.Name = "testbank";
            //                                    cr.Bank.AccountHolder = "1002";
            //                                    cr.Bank.AccountNumber = "12345";
            //                        var c = (new CustomerConverter()).ConvertCustomerResponse(cr, office);
            //                        Console.WriteLine(c.Addresses.Address[0].CountryName);
            //                        Console.WriteLine(_customerInterface.Create(c));

            #endregion

            #region salesinvoice

            //            var salesinvoices = (new Operations(_session)).GetAllSalesInvoices();
            //            foreach (var s in salesinvoices)
            //            {
            //                var salesinvoiceResponse = (new SalesInvoiceConverter(_session)).ConvertSalesInvoice(s);
            //                Console.WriteLine("------");
            //                Console.WriteLine("sales invoice = {0}", salesinvoiceResponse.Name);
            //                Console.WriteLine("customerid = {0}", salesinvoiceResponse.CustomerId);
            //                Console.WriteLine("customerreference = {0}", salesinvoiceResponse.CustomerReference);
            //                Console.WriteLine("ordernummer = {0}", salesinvoiceResponse.OrderNummer);
            //                foreach (var l in salesinvoiceResponse.SalesInvoicesLines)
            //                {
            //                    Console.WriteLine("Line:");
            //                    Console.WriteLine("amount = {0}", l.Amount);
            //                    Console.WriteLine("currency = {0}", l.Currency);
            //                    Console.WriteLine("description = {0}", l.Description);
            //                    Console.WriteLine("quantity = {0}", l.Quantity);
            //                    Console.WriteLine("vatpercent = {0}", l.VatPercent);
            //                    Console.WriteLine("vattype = {0}", l.VatType);
            //                    Console.WriteLine("article = {0}", l.Article);
            //                    Console.WriteLine("subarticle = {0}", l.Subarticle);
            //                }
            //                Console.WriteLine("------");
            //                Console.WriteLine();
            //            }
            //                        var salesinvoicelines = new List<SalesInvoiceLine>();
            //                        var salesinvoiceline = new SalesInvoiceLine
            //                        {
            //                            Amount = 1,
            //                            Currency = "EUR",
            //                            Description = "test",
            //                            Quantity = 2,
            //                            VatPercent = 0,
            //                            VatType = "sales",
            //                            Article = "FRUIT",
            //                            Subarticle = "BANAAN"
            //                        };
            //                        salesinvoicelines.Add(salesinvoiceline);
            //            
            //                        var salesinvoiceresponse = new SalesInvoiceResponse
            //                        {
            //                            CustomerId = "1002",
            //                            Project = "",
            //                            CustomerReference = "1002",
            //                            Name = "test",
            //                            OrderNummer = "1"
            //                        };
            //                        salesinvoiceresponse.SalesInvoiceLines.SalesInvoiceLine = salesinvoicelines;
            //
            //            var salesInvoice = (new SalesInvoiceConverter(_session)).ConvertSalesInvoiceResponse(salesinvoiceresponse, "IN");
            //            Console.WriteLine(_salesInvoiceOperations.CreateSalesInvoice(salesInvoice));

            //                        Console.WriteLine("------");
            //                        Console.WriteLine("customer = {0}", salesInvoice.Header.Customer);
            //                        Console.WriteLine("invoicenumber = {0}", salesInvoice.Header.Invoicenumber);
            //                        Console.WriteLine("currency = {0}", salesInvoice.Header.Currency);
            //                        foreach (var l in salesInvoice.Lines.Line)
            //                        {
            //                            Console.WriteLine("Line:");
            //                            Console.WriteLine("article = {0}", l.Article);
            //                            Console.WriteLine("subarticle = {0}", l.Subarticle);
            //                            Console.WriteLine("units = {0}", l.Units);
            //                            Console.WriteLine("description = {0}", l.Description);
            //                            Console.WriteLine("quantity = {0}", l.Quantity);
            //                        }
            //                        Console.WriteLine("------");

            #endregion

            #region product

            //
            //            var articles = (new Operations(_session)).GetAllArticles();
            //            foreach (var a in articles)
            //            {
            //                var products = (new ArticleConverter()).ConvertArticle(a);
            //                foreach (var p in products)
            //                {
            //                    Console.WriteLine("------");
            //                    Console.WriteLine("product = {0}", p.Description);
            //                    Console.WriteLine("code = {0}", p.Code);
            //                    Console.WriteLine("salesprice = {0}", p.SalesPrice);
            //                    Console.WriteLine("maxdiscountrate = {0}", p.MaxDiscountRate);
            //                    Console.WriteLine("unit = {0}", p.Unit);
            //                    Console.WriteLine("suppliercode = {0}", p.SupplierCode);
            //                    for (int i = 0; i < p.ExtraFields.Count; i++)
            //                    {
            //                        Console.WriteLine("extrafield" + (i +1) + " = {0}", p.ExtraFields[i].Value.Value);
            //                    }
            //                }
            //                
            //            }
            //                                    var extrafields = new List<ExtensionData>();
            //                                    var field1 = new ExtensionData
            //                                    {
            //                                        Value = new ExtensionValue
            //                                        {
            //                                            Value = "4000"
            //                                        }
            //                                    };
            //                                    var field3 = new ExtensionData
            //                                    {
            //                                        Value = new ExtensionValue
            //                                        {
            //                                            Value = "8020"
            //                                        }
            //                                    };
            //                                    extrafields.Add(field1);
            //                                    extrafields.Add(field3);
            //                                    var product = new Product
            //                                    {
            //                                        Code = "9999",
            //                                        Description = "testproduct",
            //                                        MaxDiscountRate = "",
            //                                        SupplierCode = "00006",
            //                                        SalesPrice = "100",
            //                                        ExtraFields = extrafields,
            //                                        BestelEenheid = 1,
            //                                        
            //                                        
            //                                    };
            //                                    var article = (new ArticleConverter()).ConvertProduct(product, office, "IN");
            //                        Console.WriteLine(_articleOperations.CreateArticle(article));

            #endregion

            #region supplier

            //            var suppliers = (new Operations(_session)).GetAllSuppliers();
            //            foreach (var s in suppliers)
            //            {
            //                var x = (new SupplierConverter()).ConvertSupplier(s);
            //                Console.WriteLine("------");
            //                Console.WriteLine("supplier = {0}", x.Name);
            //                Console.WriteLine("code = {0}", x.Code);
            //                Console.WriteLine("vatnumber = {0}", x.VatNumber);
            //                Console.WriteLine("comment = {0}", x.Comment);
            //                Console.WriteLine("website = {0}", x.Website);
            //                Console.WriteLine("Bank:");
            //                Console.WriteLine("accountholder = {0}", x.Bank.AccountHolder);
            //                Console.WriteLine("accountnumber = {0}", x.Bank.AccountNumber);
            //                Console.WriteLine("name = {0}", x.Bank.Name);
            //                Console.WriteLine("biccode = {0}", x.Bank.BicCode);
            //                Console.WriteLine("iban = {0}", x.Bank.Iban);
            //                Console.WriteLine("Postal addresses:");
            //                foreach (var a in x.Addresses.postalAddresses)
            //                {
            //                    Console.WriteLine("address = {0}", a.Address1);
            //                    Console.WriteLine("contactpersoon = {0}", a.Contactpersoon);
            //                    Console.WriteLine("city = {0}", a.City);
            //                    Console.WriteLine("countrycode = {0}", a.Country.Code);
            //                    Console.WriteLine("countryname = {0}", a.Country.Name);
            //                    Console.WriteLine("zipcode = {0}", a.ZipCode);
            //                }
            //                Console.WriteLine("Phonenumbers:");
            //                Console.WriteLine("general = {0}", x.PhoneNumbers.General);
            //                Console.WriteLine("fax = {0}", x.PhoneNumbers.Fax);
            //                Console.WriteLine("mobile = {0}", x.PhoneNumbers.Mobile);
            //                Console.WriteLine("Mailadresses:");
            //                Console.WriteLine("General:");
            //                Console.WriteLine("to = {0}", x.MailAddresses.General.To);
            //                Console.WriteLine("cc = {0}", x.MailAddresses.General.CC);
            //                Console.WriteLine("isempty = {0}", x.MailAddresses.General.IsEmpty);
            //                Console.WriteLine("Offer:");
            //                Console.WriteLine("to = {0}", x.MailAddresses.Offer.To);
            //                Console.WriteLine("cc = {0}", x.MailAddresses.Offer.CC);
            //                Console.WriteLine("isempty = {0}", x.MailAddresses.Offer.IsEmpty);
            //                Console.WriteLine("Confirmation:");
            //                Console.WriteLine("to = {0}", x.MailAddresses.Confirmation.To);
            //                Console.WriteLine("cc = {0}", x.MailAddresses.Confirmation.CC);
            //                Console.WriteLine("isempty = {0}", x.MailAddresses.Confirmation.IsEmpty);
            //                Console.WriteLine("Invoice:");
            //                Console.WriteLine("to = {0}", x.MailAddresses.Invoice.To);
            //                Console.WriteLine("cc = {0}", x.MailAddresses.Invoice.CC);
            //                Console.WriteLine("isempty = {0}", x.MailAddresses.Invoice.IsEmpty);
            //                Console.WriteLine("Invoicereminder:");
            //                Console.WriteLine("to = {0}", x.MailAddresses.InvoiceReminder.To);
            //                Console.WriteLine("cc = {0}", x.MailAddresses.InvoiceReminder.CC);
            //                Console.WriteLine("isempty = {0}", x.MailAddresses.InvoiceReminder.IsEmpty);
            //                Console.WriteLine("------");
            //                Console.WriteLine();
            //            }

            //                        var addresses = new List<PostalAddress>();
            //                        var address = new PostalAddress
            //                        {
            //                            Address1 = "testbedrijf",
            //                            City = "Veenendaal",
            //                            ContactPerson = "testsupplier",
            //                            ZipCode = "3903AA"
            //                        };
            //                        address.Country.Code = "NL";
            //                        address.Country.Name = "Nederland";
            //                        addresses.Add(address);
            //                        var supplierresponse = new SupplierResponse
            //                        {
            //                            Name = "testsupplier",
            //                            Code = "2790",
            //                            Comment = "test",
            //                            VatNumber = "1",
            //                            Website = "test.nl"
            //                        };
            //                        supplierresponse.Bank.Name = "Bank";
            //                        supplierresponse.Bank.AccountNumber = "12345";
            //                        supplierresponse.Bank.AccountHolder = "testsupplier";
            //                        supplierresponse.Bank.Iban = "NL32INGB0000012345";
            //                        supplierresponse.Addresses.General = address;
            //                        supplierresponse.PhoneNumbers.General = "03181111111";
            //                        supplierresponse.PhoneNumbers.Mobile = "0611111111";
            //            var supplier = (new SupplierConverter()).ConvertSupplierResponse(supplierresponse, office);
            //            Console.WriteLine(_supplierOperations.CreateSupplier(supplier));

            #endregion

            #region costcenter

            //                        foreach (var a in _costCenterInterface.GetAll())
            //                        {
            //                            var costcenter = _costCenterConverter.ConvertCostCenter(a);
            //                            Console.WriteLine("------");
            //                            Console.WriteLine("cost center:");
            //                            Console.WriteLine("name = {0}", costcenter.Name);
            //                            Console.WriteLine("code = {0}", costcenter.Code);
            //                            Console.WriteLine("comment = {0}", costcenter.Comment);
            //                            Console.WriteLine("website = {0}", costcenter.Website);
            //                            Console.WriteLine("------");
            //                            Console.WriteLine();
            //                        }

            //                        var costCenterResponse = new CostCenterResponse
            //                        {
            //                            Code = "09998",
            //                            Name = "Test Cost Center",
            //                            Website = "test.nl"
            //                        };
            //
            //            var costCenter = (new CostCenterConverter()).ConvertCostCenterResponse(costCenterResponse, office);
            //
            //            Console.WriteLine((new Operations(_session)).CreateCostCenter(costCenter));
            //

            #endregion

            #region general ledger

            //            foreach (var gl in (new GeneralLedgerOperations(_session)).GetAllGeneralLedgersBas())
            //            {
            //                var g = (new GeneralLedgerConverter()).ConvertGeneralLedger(gl);
            //                Console.WriteLine("name = {0}", g.Name);
            //                Console.WriteLine("code = {0}", g.Code);
            //                Console.WriteLine("vatname = {0}", g.VatName);
            //                Console.WriteLine("vattype = {0}", g.VatType);
            //                Console.WriteLine();
            //            }

            //                        var gl = new GeneralLedgerResponse
            //                        {
            //                            Name = "Test",
            //                            Type = "PNL",
            //                            Code = "4999",
            //                            VatType = "",
            //                            VatName = ""
            //                        };
            //            
            //                        Console.WriteLine(_generalLedgerInterface.Create(_generalLedgerConverter.ConvertGeneralLedgerResponse(gl, _session.Office)));

            #endregion

            #region xmltest
            //            foreach (var x in _dimensionTypeInterface.GetByName("BAS"))
            //            {
            //                Console.WriteLine("code = {0}", x.Mask);
            //            }

            //            var company = new Company
            //            {
            //                Id = "1",
            //                Name = "albert heijn",
            //                Stores = new List<Store> { new Store
            //                {
            //                    Id = "1",
            //                    Name = "albert heijn xxl",
            //                    Address = new Address
            //                    {
            //                        City = "ede",
            //                        Country = "nederland",
            //                        HouseNumber = "72",
            //                        Street = "hoofdstraat",
            //                        ZipCode = "3402zz"
            //                    },
            //                    Klanten = new List<Klant>{new Klant
            //                    {
            //                        Id = "1",
            //                        Name = "roy",
            //                        Email = "roydonders@mail.nl",
            //                        Address = new Address
            //                        {
            //                            City = "nijkerk",
            //                            Country = "nederland",
            //                            HouseNumber = "7",
            //                            Street = "grote weg",
            //                            ZipCode = "4201ti"
            //                        }
            //                    } }
            //                } }
            //            };
            //
            //            var ser = new ClassToXml<Company>();
            //            ser.WriteXml(company);
            #endregion
//            var x = _salesInvoiceConverter.ConvertSalesInvoice(_salesInvoiceInterface.GetByInvoiceType("FACTUUR")[0]);
//            var convertX = (new ResponseClassToXmlClass()).ConvertSalesInvoice(x);

            var s = _supplierInterface.GetAll();
            var sr = _supplierConverter.ConvertSupplier(s[0]);
            var ser = new ClassToXml<SupplierResponse>();
            ser.WriteXml(sr);

            LogOff();
        }
        
        public Session Login(string loginServerUrl, string user, string password, string organisation)
        {
            Console.WriteLine("Log in");
            var sessionService = new SessionService(clientFactory);
            _session = sessionService.Logon(loginServerUrl, user, password, organisation);
            if (_session == null)
            {
                Console.WriteLine("Failed to log in to organisation {0} with user {1} on {2}.", organisation, user,
                    loginServerUrl);
                return null;
            }

            Console.WriteLine("Logged in to organisation {0} with user {1} on {2}.", organisation, user,
                loginServerUrl);
            Console.WriteLine();
            _customerInterface = new CustomerOperations(_session);
            _supplierInterface = new SupplierOperations(_session);
//            _generalLedgerInterface = new GeneralLedgerOperations(_session);
            _articleInterface = new ArticleOperations(_session);
            _salesInvoiceInterface = new SalesInvoiceOperations(_session);
            _costCenterInterface = new CostCenterOperatons(_session);
            _costCenterConverter = new CostCenterConverter();
            _generalLedgerConverter = new GeneralLedgerConverter();
            _dimensionTypeInterface = new DimensionTypeOperations(_session);
            _balanceSheetInterface = new BalanceSheetOperations(_session);
            _countryOperations = new CountryOperations(_session);
            _customerConverter = new CustomerConverter();
            _supplierConverter = new SupplierConverter();
            _articleConverter = new ArticleConverter();
            _salesInvoiceConverter = new SalesInvoiceConverter(_session);
            return _session;
        }

        public bool SwitchToOffice(string office, Session s)
        {
            var sessionService = new SessionService(clientFactory);
            if (!sessionService.SelectOffice(s, office))
            {
                Console.WriteLine("Office {0} does not exist or you don't have sufficient rights to access it.");
                return false;
            }

            Console.WriteLine("Switched to office {0}", office);
            Console.WriteLine();
            return true;
        }

        public void LogOff()
        {
            var sessionService = new SessionService(clientFactory);
            sessionService.Abandon(_session);
            Console.WriteLine("Logged off.");
            Console.WriteLine();
        }

    }

    public interface ITwinfieldApiSettings
    {
    }
}