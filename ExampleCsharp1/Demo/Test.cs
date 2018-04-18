using System;
using System.Linq;
using Demo.Extras.Articles;
using Demo.Extras.Countries;
using Demo.Customer;
using Demo.Extras.DistByPeriod;
using Demo.Extras.InvoiceType;
using Demo.GeneralLedgers;
using Demo.Extras.Payment;
using Demo.Extras.ReminderScenario;
using Demo.Extras.Report;
using Demo.Extras.TaxGroup;
using Demo.Extras.TimeQuantity;
using Demo.Extras.TransactionType;
using Demo.Extras.Translation;
using Demo.Extras.UserRole;
using Demo.Extras.VAT;
using TwinfieldApi.BankBooks;
using TwinfieldApi.Organization;
using TwinfieldApi.Services;

namespace Demo
{
    internal class Test
    {
        private static void Main(string[] args)
        {
            var clientFactory = new ClientFactory();
            var sessionService = new SessionService(clientFactory);
            var session = sessionService.Logon("API000110", "SforSoftware12", "TWINAPPS");
            session.Office = "NLA000218";
//            var session = sessionService.Logon("TESTUSER", "password", "TESTORG");

//            var bankBook = new BankBookDemo(session);
//            bankBook.Run();
//
//            var organisation = new OrganizationDemo(session);
//            organisation.Run();
//
//            var bookkeeping = new BookkeepingDemo(session);
//            bookkeeping.Run();
//
            //\\Vervangen door Customers//\\
//            var dimension = new DimensionDemo(session);
//            dimension.Run();

//            var article = new ArticleDemo(session);
//            article.Run();

//            var invoiceType = new InvoiceTypeDemo(session);
//            invoiceType.Run();

//            var salesInvoice = new SalesInvoiceDemo(session);
//            salesInvoice.Run();

//
//            var project = new ProjectDemo(session);
//            project.Run();
//
//            var user = new UserDemo(session);
//            user.Run();
//
//            var supplier = new SupplierDemo(session);
//            supplier.Run();

//            var costCenter = new CostCenterDemo(session);
//            costCenter.Run();

//            var fixedAsset = new FixedAssetDemo(session);
//            fixedAsset.Run();

//            var activity = new ActivityDemo(session);
//            activity.Run();

//            var dimensionGroup = new DimensionGroupDemo(session);
//            dimensionGroup.Run();

//            var dimensionTypes = new DimensionTypeDemo(session);
//            dimensionTypes.Run();

//            var assetMethod = new AssetMethodDemo(session);
//            assetMethod.Run();

//            var currencies = new CurrenciesDemo(session);
//            currencies.Run();

//            var rate = new RateDemo(session);
//            rate.Run();

//            var vat = new VatDemo(session);
//            vat.Run();

//            var banktransaction = new BankTransactionDemo(session);
//            banktransaction.Run();

//            var salesTransaction = new SalesTransactionDemo(session);
//            salesTransaction.Run();

//            var budget = new BudgetDemo(session);
//            budget.Run();

//            var cashBook = new CashBookDemo(session);
//            cashBook.Run();
//
//            var bankStatement = new BankStatementDemo(session);
//            bankStatement.Run();

//            var purchaseTransaction = new PurchaseTransactionDemo(session);
//            purchaseTransaction.Run();

//            var period = new PeriodDemo(session);
//            period.Run();

//            var deletedTransaction = new DeletedTransactionDemo(session);
//            deletedTransaction.Run();

//            var transactionBlockedValue = new TransactionBlockedValueDemo(session);
//            transactionBlockedValue.Run();

//            var office =new OfficeDemo(session);
//            office.Run();

//            var customer = new CustomerDemo(session);
//            customer.Run();

//            var generalLedger = new GeneralLedgerDemo(session);
//            generalLedger.Run();

//            var country = new CountryDemo(session);
//            country.Run();

//            var subArticle = new SubArticleDemo(session);
//            subArticle.Run();

//            var taxGroup = new TaxGroupDemo(session);
//            taxGroup.Run();

//            var payment = new PaymentDemo(session);
//            payment.Run();

//            var report = new ReportDemo(session);
//            report.Run();

//            var reminderScenario = new ReminderScenarioDemo(session);
//            reminderScenario.Run();

//            var userRole = new UserRoleDemo(session);
//            userRole.Run();

//            var distByPeriods = new DistByPeriodDemo(session);
//            distByPeriods.Run();

//            var timeQuantity = new TimeQuantityDemo(session);
//            timeQuantity.Run();

//            var transactionTypes = new TransactionTypeDemo(session);
//            transactionTypes.Run();

//            var vatNrOfRelations = new VatNrOfRelationsDemo(session);
//            vatNrOfRelations.Run();

//            var vatGroup = new VatGroupDemo(session);
//            vatGroup.Run();

//            var vatCountry = new VatCountryDemo(session);
//            vatCountry.Run();

//            var translation = new TranslationDemo(session);
//            translation.Run();

            var apiDemo = new ApiDemo();
            apiDemo.Run("https://login.twinfield.com", "API000110", "SforSoftware12", "TWINAPPS", "NLA000218");






            //            var bankBookService = new BankBookService(session);
            //
            //            Console.WriteLine("Read bank book");
            //
            //            var bankBook = bankBookService.FindBankBook("BNK");
            //            if (bankBook == null)
            //            {
            //                Console.WriteLine("Bank book not found.");
            //            }
            //            else
            //            {
            //                Console.WriteLine("Bank book found");
            //                Console.WriteLine("\tcode = {0}", bankBook.Code);
            //                Console.WriteLine("\tname = {0}", bankBook.Name);
            //                Console.WriteLine("\taccount number = {0}", bankBook.AccountNumber);
            //                Console.WriteLine("\tIBAN = {0}", bankBook.Iban);
            //            }
            //
            //            Console.WriteLine();
            //
            //            var organizationService = new OrganizationService(session);
            //            Console.WriteLine("List offices");
            //
            //            var offices = organizationService.GetOffices();
            //            Console.WriteLine("Found {0} offices:", offices.Count);
            //
            //            Console.WriteLine("{0,-16} {1}", "Code", "Name");
            //            foreach (var office in offices.Take(10))
            //                Console.WriteLine("{0,-16} {1}", office.Code, office.Name);
            //            Console.WriteLine();
            WaitForUser();
        }

        private static void WaitForUser()
        {
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}