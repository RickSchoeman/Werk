using System;
using System.Collections.Generic;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Activities;
using DemoConnector.TwinfieldAPI.Data.Articles;
using DemoConnector.TwinfieldAPI.Data.AssetMethods;
using DemoConnector.TwinfieldAPI.Data.BankBooks;
using DemoConnector.TwinfieldAPI.Data.BankTransactions;
using DemoConnector.TwinfieldAPI.Data.CashBooks;
using DemoConnector.TwinfieldAPI.Data.CostCenters;
using DemoConnector.TwinfieldAPI.Data.Currencies;
using DemoConnector.TwinfieldAPI.Data.Customers;
using DemoConnector.TwinfieldAPI.Data.DimensionGroups;
using DemoConnector.TwinfieldAPI.Data.DimensionTypes;
using DemoConnector.TwinfieldAPI.Data.Extras.Countries;
using DemoConnector.TwinfieldAPI.Data.Extras.DistByPeriods;
using DemoConnector.TwinfieldAPI.Data.Extras.InvoiceTypes;
using DemoConnector.TwinfieldAPI.Data.Extras.Payments;
using DemoConnector.TwinfieldAPI.Data.Extras.ReminderScenarios;
using DemoConnector.TwinfieldAPI.Data.Extras.Reports;
using DemoConnector.TwinfieldAPI.Data.Extras.SubArticles;
using DemoConnector.TwinfieldAPI.Data.Extras.TaxGroups;
using DemoConnector.TwinfieldAPI.Data.Extras.TimeQuantities;
using DemoConnector.TwinfieldAPI.Data.Extras.TransactionTypes;
using DemoConnector.TwinfieldAPI.Data.Extras.Translations;
using DemoConnector.TwinfieldAPI.Data.Extras.UserRoles;
using DemoConnector.TwinfieldAPI.Data.Extras.VAT;
using DemoConnector.TwinfieldAPI.Data.FixedAssets;
using DemoConnector.TwinfieldAPI.Data.GeneralLedgers;
using DemoConnector.TwinfieldAPI.Data.Period;
using DemoConnector.TwinfieldAPI.Data.Projects;
using DemoConnector.TwinfieldAPI.Data.PurchaseTransactions;
using DemoConnector.TwinfieldAPI.Data.SalesTransactions;
using DemoConnector.TwinfieldAPI.Data.Suppliers;
using DemoConnector.TwinfieldAPI.Data.Users;
using DemoConnector.TwinfieldAPI.Data.VATs;
using DemoConnector.TwinfieldAPI.Handlers.Activities;
using DemoConnector.TwinfieldAPI.Handlers.Articles;
using DemoConnector.TwinfieldAPI.Handlers.AssetMethods;
using DemoConnector.TwinfieldAPI.Handlers.BankStatements;
using DemoConnector.TwinfieldAPI.Handlers.BankTransactions;
using DemoConnector.TwinfieldAPI.Handlers.CashBooks;
using DemoConnector.TwinfieldAPI.Handlers.CostCenters;
using DemoConnector.TwinfieldAPI.Handlers.Currencies;
using DemoConnector.TwinfieldAPI.Handlers.Customers;
using DemoConnector.TwinfieldAPI.Handlers.DeletedTransactions;
using DemoConnector.TwinfieldAPI.Handlers.DimensionGroups;
using DemoConnector.TwinfieldAPI.Handlers.DimensionTypes;
using DemoConnector.TwinfieldAPI.Handlers.Extras.Countries;
using DemoConnector.TwinfieldAPI.Handlers.Extras.DistByPeriods;
using DemoConnector.TwinfieldAPI.Handlers.Extras.InvoiceTypes;
using DemoConnector.TwinfieldAPI.Handlers.Extras.Payments;
using DemoConnector.TwinfieldAPI.Handlers.Extras.ReminderScenarios;
using DemoConnector.TwinfieldAPI.Handlers.Extras.Reports;
using DemoConnector.TwinfieldAPI.Handlers.Extras.SubArticles;
using DemoConnector.TwinfieldAPI.Handlers.Extras.TaxGroups;
using DemoConnector.TwinfieldAPI.Handlers.Extras.TimeQuantities;
using DemoConnector.TwinfieldAPI.Handlers.Extras.TransactionTypes;
using DemoConnector.TwinfieldAPI.Handlers.Extras.Translations;
using DemoConnector.TwinfieldAPI.Handlers.Extras.UserRoles;
using DemoConnector.TwinfieldAPI.Handlers.Extras.VAT;
using DemoConnector.TwinfieldAPI.Handlers.FixedAssets;
using DemoConnector.TwinfieldAPI.Handlers.GeneralLedgers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using DemoConnector.TwinfieldAPI.Handlers.Offices;
using DemoConnector.TwinfieldAPI.Handlers.Period;
using DemoConnector.TwinfieldAPI.Handlers.Projects;
using DemoConnector.TwinfieldAPI.Handlers.PurchaseTransactions;
using DemoConnector.TwinfieldAPI.Handlers.Rates;
using DemoConnector.TwinfieldAPI.Handlers.SalesInvoice;
using DemoConnector.TwinfieldAPI.Handlers.SalesTransactions;
using DemoConnector.TwinfieldAPI.Handlers.Suppliers;
using DemoConnector.TwinfieldAPI.Handlers.TransactionBlockedValue;
using DemoConnector.TwinfieldAPI.Handlers.Users;
using DemoConnector.TwinfieldAPI.Handlers.VATs;
using DemoConnector.TwinfieldBankBookService;
using BankBookService = DemoConnector.TwinfieldAPI.Handlers.BankBooks.BankBookService;
using Office = DemoConnector.TwinfieldAPI.Data.Offices.Office;

namespace DemoConnector.TwinfieldAPI.Handlers
{
    public class ArticleOperations : IArticleInterface
    {
        private readonly ArticleService _articleService;
        private readonly SubArticleService _subArticleService;
        private const int SearchField = 0;

        public ArticleOperations(Session session)
        {
            _articleService = new ArticleService(session);
            _subArticleService = new SubArticleService(session);
        }

        private readonly List<Article> _articleList = new List<Article>();

        public List<Article> GetByName(string name)
        {
            _articleList.Clear();
            var articles = _articleService.FindHeaders(name, "ART", SearchField);
            foreach (var a in articles)
            {
                var article = _articleService.ReadHeader(a.Code);
                _articleList.Add(article);
            }

            return _articleList;
        }

        public List<Article> GetAll()
        {
            _articleList.Clear();
            var articles = _articleService.FindHeaders("*", "ART", SearchField);
            foreach (var a in articles)
            {
                var article = _articleService.ReadHeader(a.Code);
                _articleList.Add(article);
            }

            return _articleList;
        }

        public Article Read(string code)
        {
            try
            {
                return _articleService.ReadHeader(code);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public string Create(Article article)
        {
            try
            {
                _articleService.CreateArticle(article);
                return "Created";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
        }

        public string Delete(Article article)
        {
            try
            {
                _articleService.DeleteArticle(article);
                return "Deleted";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
        }

        public string Activate(Article article)
        {
            try
            {
                _articleService.ActivateArticle(article);
                return "Activated";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
        }

        public string DeleteSubArticle(Article article)
        {
            try
            {
                _articleService.DeleteSubArticle(article);
                return "Deleted";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
        }

        public List<SubArticleSummary> GetSubArticlesByArticle(string name, string article)
        {
            var subArticles = _subArticleService.FindSubArticles(name, article, SearchField);
            return subArticles;
        }
    }

    public class CustomerOperations : ICustomerInterface
    {
        private readonly IDimensionOperations _dimensionOperations;
        private readonly List<Customer> _customers = new List<Customer>();

        public CustomerOperations(Session session)
        {
            _dimensionOperations = new DimensionOperations(session);
        }

        public List<Customer> GetByName(string name)
        {
            _customers.Clear();
            var customers = _dimensionOperations.GetByName(name, "DEB");
            foreach (var c in customers)
            {
                _customers.Add(c as Customer);
            }

            return _customers;
        }

        public List<Customer> GetAll()
        {
            _customers.Clear();
            var customers = _dimensionOperations.GetAll("DEB");
            foreach (var c in customers)
            {
                _customers.Add(c as Customer);
            }

            return _customers;
        }

        public Customer Read(string code)
        {
            try
            {
                return _dimensionOperations.Read("DEB", code) as Customer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public string Create(Customer customer)
        {
            return _dimensionOperations.Create(customer);
        }

        public string Delete(Customer customer)
        {
            return _dimensionOperations.Delete(customer);
        }

        public string Activate(Customer customer)
        {
            return _dimensionOperations.Activate(customer);
        }
    }

    public class SupplierOperations : ISupplierInterface
    {
        private readonly IDimensionOperations _dimensionOperations;
        private readonly List<Supplier> _suppliers = new List<Supplier>();

        public SupplierOperations(Session session)
        {
            _dimensionOperations = new DimensionOperations(session);
        }

        public List<Supplier> GetByName(string name)
        {
            _suppliers.Clear();
            var suppliers = _dimensionOperations.GetByName(name, "CRD");
            foreach (var s in suppliers)
            {
                _suppliers.Add(s as Supplier);
            }

            return _suppliers;
        }

        public List<Supplier> GetAll()
        {
            _suppliers.Clear();
            var suppliers = _dimensionOperations.GetAll("CRD");
            foreach (var s in suppliers)
            {
                _suppliers.Add(s as Supplier);
            }

            return _suppliers;
        }

        public Supplier Read(string code)
        {
            try
            {
                return _dimensionOperations.Read("CRD", code) as Supplier;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public string Create(Supplier supplier)
        {
            return _dimensionOperations.Create(supplier);
        }

        public string Delete(Supplier supplier)
        {
            return _dimensionOperations.Delete(supplier);
        }

        public string Activate(Supplier supplier)
        {
            return _dimensionOperations.Activate(supplier);
        }

    }

    public class GeneralLedgerOperations : IGeneralLedgerInterface
    {
        private readonly IDimensionOperations _dimensionOperations;
        private readonly List<GeneralLedger> _generalLedgers = new List<GeneralLedger>();

        public GeneralLedgerOperations(Session session)
        {
            _dimensionOperations = new DimensionOperations(session);
        }

        public List<GeneralLedger> GetBalanceSheetByName(string name)
        {
            _generalLedgers.Clear();
            var generalLedgers = _dimensionOperations.GetByName(name, "BAS");
            foreach (var g in generalLedgers)
            {
                _generalLedgers.Add(g as GeneralLedger);
            }

            return _generalLedgers;
        }

        public List<GeneralLedger> GetAllBalanceSheet()
        {
            _generalLedgers.Clear();
            var generalLedgers = _dimensionOperations.GetAll("BAS");
            foreach (var g in generalLedgers)
            {
                _generalLedgers.Add(g as GeneralLedger);
            }

            return _generalLedgers;
        }

        public GeneralLedger ReadBalanceSheet(string code)
        {
            try
            {
                return _dimensionOperations.Read("BAS", code) as GeneralLedger;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<GeneralLedger> GetProfitLossByName(string name)
        {
            var generalLedgers = _dimensionOperations.GetByName(name, "PNL");
            foreach (var g in generalLedgers)
            {
                _generalLedgers.Add(g as GeneralLedger);
            }

            return _generalLedgers;
        }

        public List<GeneralLedger> GetAllProfitLoss()
        {
            var generalLedgers = _dimensionOperations.GetAll("PNL");
            foreach (var g in generalLedgers)
            {
                _generalLedgers.Add(g as GeneralLedger);
            }

            return _generalLedgers;
        }

        public GeneralLedger ReadProfitLoss(string code)
        {
            try
            {
                return _dimensionOperations.Read("PNL", code) as GeneralLedger;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public string Create(GeneralLedger generalLedger)
        {
            return _dimensionOperations.Create(generalLedger);
        }

        public string Delete(GeneralLedger generalLedger)
        {
            return _dimensionOperations.Delete(generalLedger);
        }

        public string Activate(GeneralLedger generalLedger)
        {
            return _dimensionOperations.Activate(generalLedger);
        }
    }
    
    public class SalesInvoiceOperations : ISalesInvoiceInterface
    {
        private readonly SalesInvoiceService _salesInvoiceService;
        private readonly InvoiceTypeService _invoiceTypeService;
        private const int SearchField = 0;

        public SalesInvoiceOperations(Session session)
        {
            _salesInvoiceService = new SalesInvoiceService(session);
            _invoiceTypeService = new InvoiceTypeService(session);
        }

        private readonly List<Data.SalesInvoice.SalesInvoice> _salesInvoiceList =
            new List<Data.SalesInvoice.SalesInvoice>();

        public List<Data.SalesInvoice.SalesInvoice> GetByInvoiceType(string invoiceType)
        {
            _salesInvoiceList.Clear();
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    var salesInvoices = _salesInvoiceService.ReadSalesInvoice((i + 1).ToString(), invoiceType);
                    _salesInvoiceList.Add(salesInvoices);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
            }

            return _salesInvoiceList;
        }

        public List<Data.SalesInvoice.SalesInvoice> GetByNumber(string number)
        {
            _salesInvoiceList.Clear();
            var invoiceTypes = _invoiceTypeService.FindInvoiceTypes("*", "INV", SearchField);
            for (int i = 0; i < invoiceTypes.Count; i++)
            {
                try
                {
                    var salesInvoice = _salesInvoiceService.ReadSalesInvoice(number, invoiceTypes[i].Code);
                    _salesInvoiceList.Add(salesInvoice);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return _salesInvoiceList;
        }

        public List<Data.SalesInvoice.SalesInvoice> GetAll()
        {
            _salesInvoiceList.Clear();
            var invoiceTypes = _invoiceTypeService.FindInvoiceTypes("*", "INV", SearchField);
            for (int i = 0; i < invoiceTypes.Count; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    try
                    {
                        var salesInvoices =
                            _salesInvoiceService.ReadSalesInvoice((j + 1).ToString(), invoiceTypes[i].Code);
                        _salesInvoiceList.Add(salesInvoices);
                    }
                    catch (Exception e)
                    {
//                        Console.WriteLine(e.Message);
                        break;
                    }
                }
            }

            return _salesInvoiceList;
        }

        public Data.SalesInvoice.SalesInvoice Read(string number, string type)
        {
            try
            {
                return _salesInvoiceService.ReadSalesInvoice(number, type);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public string Create(Data.SalesInvoice.SalesInvoice salesInvoice)
        {
            try
            {
                _salesInvoiceService.CreateSalesInvoice(salesInvoice);
                return "Created";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return e.Message;
            }
        }
    }

    public class CostCenterOperatons : ICostCenterInterface
    {
        private readonly IDimensionOperations _dimensionOperations;
        private readonly List<CostCenter> _costCenterList = new List<CostCenter>();
        public CostCenterOperatons(Session session)
        {
            _dimensionOperations = new DimensionOperations(session);
        }

        

        public List<CostCenter> GetByName(string name)
        {
            _costCenterList.Clear();
            var costCenters = _dimensionOperations.GetByName(name, "KPL");
            foreach (var c in costCenters)
            {
                _costCenterList.Add(c as CostCenter);
            }

            return _costCenterList;
        }

        public List<CostCenter> GetAll()
        {
            _costCenterList.Clear();
            var costCenters = _dimensionOperations.GetAll("KPL");
            foreach (var c in costCenters)
            {
                _costCenterList.Add(c as CostCenter);
            }

            return _costCenterList;
        }

        public CostCenter Read(string code)
        {
            try
            {
                return _dimensionOperations.Read("KPL", code) as CostCenter;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public string Create(CostCenter costCenter)
        {
            return _dimensionOperations.Create(costCenter);
        }

        public string Delete(CostCenter costCenter)
        {
            return _dimensionOperations.Delete(costCenter);
        }

        public string Activate(CostCenter costCenter)
        {
            return _dimensionOperations.Activate(costCenter);
        }
    }

    public class VatOperations
    {
        private readonly VatService _vatService;
        private readonly VatCountryService _vatCountryService;
        private readonly VatGroupService _vatGroupService;
        private readonly VatNrOfRelationsService _vatNrOfRelationsService;
        private const int SearchField = 0;

        public VatOperations(Session session)
        {
            _vatService = new VatService(session);
            _vatCountryService = new VatCountryService(session);
            _vatGroupService = new VatGroupService(session);
            _vatNrOfRelationsService = new VatNrOfRelationsService(session);
        }

        private readonly List<Vat> _vatList = new List<Vat>();

        public List<Vat> GetVatsByName(string name)
        {
            _vatList.Clear();
            var vats = _vatService.FindVats(name, "VAT", SearchField);
            foreach (var v in vats)
            {
                var vat = _vatService.ReadVat(v.Code);
                _vatList.Add(vat);
            }

            return _vatList;
        }

        public List<Vat> GetAllVats()
        {
            _vatList.Clear();
            var vats = _vatService.FindVats("*", "VAT", SearchField);
            foreach (var v in vats)
            {
                var vat = _vatService.ReadVat(v.Code);
                _vatList.Add(vat);
            }

            return _vatList;
        }

        public bool CreateVat(Vat vat)
        {
            try
            {
                _vatService.CreateVat(vat);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteVat(Vat vat)
        {
            try
            {
                _vatService.CreateVat(vat);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<VatCountrySummary> GetVatCountriesByName(string name)
        {
            var vatCountries = _vatCountryService.FindVatCountries(name, "VGM", SearchField);
            return vatCountries;
        }

        public List<VatCountrySummary> GetAllVatCountries()
        {
            var vatCountries = _vatCountryService.FindVatCountries("*", "VGM", SearchField);
            return vatCountries;
        }

        public List<VatGroupSummary> GetVatGroupsByName(string name)
        {
            var vatGroups = _vatGroupService.FindVatGroups(name, "VTB", SearchField);
            return vatGroups;
        }

        public List<VatGroupSummary> GetAllVatGroups()
        {
            var vatGroups = _vatGroupService.FindVatGroups("*", "VTB", SearchField);
            return vatGroups;
        }

        public List<VatNrOfRelationsSummary> GetVatNrOfRelationsByName(string name)
        {
            var vatNrOfRelations = _vatNrOfRelationsService.FindVatNrOfRelations(name, "VATN", SearchField);
            return vatNrOfRelations;
        }

        public List<VatNrOfRelationsSummary> GetAllVatNrOfRelations()
        {
            var vatNrOfRelations = _vatNrOfRelationsService.FindVatNrOfRelations("*", "VATN", SearchField);
            return vatNrOfRelations;
        }
    }

    public class OfficeOperations
    {
        private readonly OfficeService _officeService;
        private const int SearchField = 0;

        public OfficeOperations(Session session)
        {
            _officeService = new OfficeService(session);
        }

        private readonly List<Office> _officeList = new List<Office>();

        public List<Office> GetOfficesByName(string name)
        {
            _officeList.Clear();
            var offices = _officeService.FindOffices(name, "OFF", SearchField);
            foreach (var o in offices)
            {
                var office = _officeService.ReadOffice(o.Code);
                _officeList.Add(office);
            }

            return _officeList;
        }

        public List<Office> GetAllOffices()
        {
            _officeList.Clear();
            var offices = _officeService.FindOffices("*", "OFF", SearchField);
            foreach (var o in offices)
            {
                var office = _officeService.ReadOffice(o.Code);
                _officeList.Add(office);
            }

            return _officeList;
        }
    }

    //zijn niet in gebruik
    #region niet in gebruik
    public class ActivityOperations
    {
        private readonly ActivityService _activityService;
        private const int SearchField = 0;

        public ActivityOperations(Session session)
        {
            _activityService = new ActivityService(session);
        }

        private readonly List<Activity> _activityList = new List<Activity>();

        public List<Activity> GetActivitiesByName(string name)
        {
            var activities = _activityService.FindActivities(name, "ACT", SearchField);
            foreach (var a in activities)
            {
                var activity = _activityService.ReadActivity("ACT", a.Code);
                _activityList.Add(activity);
            }

            return _activityList;
        }

        public List<Activity> GetAllActivities()
        {
            var activities = _activityService.FindActivities("*", "ACT", SearchField);
            foreach (var a in activities)
            {
                var activity = _activityService.ReadActivity("ACT", a.Code);
                _activityList.Add(activity);
            }

            return _activityList;
        }

        public bool CreateActivity(Activity activity)
        {
            try
            {
                _activityService.CreateActivity(activity);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteActivity(Activity activity)
        {
            try
            {
                _activityService.DeleteActivity(activity);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ActivateActivity(Activity activity)
        {
            try
            {
                _activityService.ActivateActivity(activity);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }

    public class AssetMethodOperations
    {
        private readonly AssetMethodService _assetMethodService;
        private const int SearchField = 0;

        public AssetMethodOperations(Session session)
        {
            _assetMethodService = new AssetMethodService(session);
        }

        private readonly List<AssetMethod> _assetMethodList = new List<AssetMethod>();

        public List<AssetMethod> GetAssetMethodsByName(string name)
        {
            var assetMethods = _assetMethodService.FindAssetMethods(name, "ASM", SearchField);
            foreach (var a in assetMethods)
            {
                var assetMethod = _assetMethodService.ReadAssetMethod("ASM", a.Code);
                _assetMethodList.Add(assetMethod);
            }

            return _assetMethodList;
        }

        public List<AssetMethod> GetAllAssetMethods()
        {
            var assetMethods = _assetMethodService.FindAssetMethods("*", "ASM", SearchField);
            foreach (var a in assetMethods)
            {
                var assetMethod = _assetMethodService.ReadAssetMethod("ASM", a.Code);
                _assetMethodList.Add(assetMethod);
            }

            return _assetMethodList;
        }

        public bool CreateAssetMethod(AssetMethod assetMethod)
        {
            try
            {
                _assetMethodService.CreateAssetMethod(assetMethod);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteAssetMethod(AssetMethod assetMethod)
        {
            try
            {
                _assetMethodService.DeleteAssetMethod(assetMethod);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ActivateAssetMethod(AssetMethod assetMethod)
        {
            try
            {
                _assetMethodService.ActivateAssetMethod(assetMethod);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }

    public class BankBookOperations
    {
        private readonly BankBookService _bankBookService;

        public BankBookOperations(Session session)
        {
            _bankBookService = new BankBookService(session);
        }

        public BankBook GetBankBookByCode(string code)
        {
            var bankbook = _bankBookService.FindBankBook(code);
            return bankbook;
        }

        public bool CreateBankBook(string code, string name, BankAccount bankAccount, string generalLedgerAccount)
        {
            try
            {
                _bankBookService.CreateBankBook(code, name, bankAccount, generalLedgerAccount);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ChangeBankBookBankAccount(string code, BankAccount bankAccount)
        {
            try
            {
                _bankBookService.ChangeBankBookBankAccount(code, bankAccount);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ChangeBankBookGeneralLedgerAccount(string code, string generalLedgerAccount)
        {
            try
            {
                _bankBookService.ChangeBankBookGeneralLedgerAccount(code, generalLedgerAccount);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ChangeBonkBookName(string code, string name)
        {
            try
            {
                _bankBookService.ChangeBankBookName(code, name);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ChangeBankBookShortname(string code, string shortname)
        {
            try
            {
                _bankBookService.ChangeBankBookShortName(code, shortname);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }

    public class CashBookOperations
    {
        private readonly CashBookService _cashBookService;

        public CashBookOperations(Session session)
        {
            _cashBookService = new CashBookService(session);
        }

        public CashBook GetCashBookByCode(string code)
        {
            var cashBook = _cashBookService.FindCashBook(code);
            return cashBook;
        }

        public bool CreateCashBook(string code, string name, string generalLedgerAccount)
        {
            try
            {
                _cashBookService.CreateCashBook(code, name, generalLedgerAccount);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ChangeCashBookName(string code, string name)
        {
            try
            {
                _cashBookService.ChangeCashBookName(code, name);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ChangeCashBookShortname(string code, string shortname)
        {
            try
            {
                _cashBookService.ChangeCashBookShortName(code, shortname);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ChangeCashBookGeneralLedgerAccount(string code, string generalLedgerAccount)
        {
            try
            {
                _cashBookService.ChangeCashBookGeneralLedgerAccount(code, generalLedgerAccount);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }

    public class CurrencyOperations
    {
        private readonly CurrenciesService _currenciesService;
        private const int SearchField = 0;

        public CurrencyOperations(Session session)
        {
            _currenciesService = new CurrenciesService(session);
        }

        private readonly List<Currency> _currencyList = new List<Currency>();

        public List<Currency> GetCurrenciesByName(string name)
        {
            var currencies = _currenciesService.FindCurrencies(name, "CUR", SearchField);
            foreach (var c in currencies)
            {
                var currency = _currenciesService.ReadCurrencies("CUR", c.Code);
                _currencyList.Add(currency);
            }

            return _currencyList;
        }

        public List<Currency> GetAllCurrencies()
        {
            var currencies = _currenciesService.FindCurrencies("*", "CUR", SearchField);
            foreach (var c in currencies)
            {
                var currency = _currenciesService.ReadCurrencies("CUR", c.Code);
                _currencyList.Add(currency);
            }

            return _currencyList;
        }

        public bool CreateCurrency(Currency currency)
        {
            try
            {
                _currenciesService.CreateCurrency(currency);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteCurrency(Currency currency)
        {
            try
            {
                _currenciesService.DeleteCurrency(currency);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteCurrencyRate(Currency currency)
        {
            try
            {
                _currenciesService.DeleteCurrencyRate(currency);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }

    public class DimensionGroupOperations
    {
        private readonly DimensionGroupService _dimensionGroupService;
        private const int SearchField = 0;

        public DimensionGroupOperations(Session session)
        {
            _dimensionGroupService = new DimensionGroupService(session);
        }

        private readonly List<DimensionGroup> _dimensionGroupList = new List<DimensionGroup>();

        public List<DimensionGroup> GetDimensionGroupsByName(string name)
        {
            var dimensionGroups = _dimensionGroupService.FindDimensionGroups(name, "GRP", SearchField);
            foreach (var d in dimensionGroups)
            {
                var dimensionGroup = _dimensionGroupService.ReadDimensiongroup(d.Code);
                _dimensionGroupList.Add(dimensionGroup);
            }

            return _dimensionGroupList;
        }

        public List<DimensionGroup> GetAllDimensionGroups()
        {
            var dimensionGroups = _dimensionGroupService.FindDimensionGroups("*", "GRP", SearchField);
            foreach (var d in dimensionGroups)
            {
                var dimensionGroup = _dimensionGroupService.ReadDimensiongroup(d.Code);
                _dimensionGroupList.Add(dimensionGroup);
            }

            return _dimensionGroupList;
        }

        public bool CreateDimensionGroup(DimensionGroup dimensionGroup)
        {
            try
            {
                _dimensionGroupService.CreateDimensionGroup(dimensionGroup);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteDimenionGroup(DimensionGroup dimensionGroup)
        {
            try
            {
                _dimensionGroupService.DeleteDimensionGroup(dimensionGroup);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }

    public class DimensionTypeOperations
    {
        private readonly DimensionTypeService _dimensionTypeService;
        private const int SearchField = 0;

        public DimensionTypeOperations(Session session)
        {
            _dimensionTypeService = new DimensionTypeService(session);
        }

        private readonly List<DimensionType> _dimensionTypeList = new List<DimensionType>();

        public List<DimensionType> GetDimensionTypesByName(string name)
        {
            var dimensionTypes = _dimensionTypeService.FindDimensionTypes(name, SearchField);
            foreach (var d in dimensionTypes)
            {
                var dimensiontype = _dimensionTypeService.ReadDimensionType(d.Code);
                _dimensionTypeList.Add(dimensiontype);
            }

            return _dimensionTypeList;
        }

        public List<DimensionType> GetAllDimensionTypes()
        {
            var dimensionTypes = _dimensionTypeService.FindDimensionTypes("*", SearchField);
            foreach (var d in dimensionTypes)
            {
                var dimensionType = _dimensionTypeService.ReadDimensionType(d.Code);
                _dimensionTypeList.Add(dimensionType);
            }

            return _dimensionTypeList;
        }

        public bool UpdateDimensionType(DimensionType dimensionType)
        {
            try
            {
                _dimensionTypeService.UpdateDimensionType(dimensionType);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }

    public class FixedAssetOperations
    {
        private readonly FixedAssetService _fixedAssetService;
        private const int SearchField = 0;

        public FixedAssetOperations(Session session)
        {
            _fixedAssetService = new FixedAssetService(session);
        }

        private readonly List<FixedAsset> _fixedAssetList = new List<FixedAsset>();

        public List<FixedAsset> GetFixedAssetsByName(string name)
        {
            var fixedAssets = _fixedAssetService.FindFixedAssets(name, "AST", SearchField);
            foreach (var f in fixedAssets)
            {
                var fixedAsset = _fixedAssetService.ReadFixedAsset("AST", f.Code);
                _fixedAssetList.Add(fixedAsset);
            }

            return _fixedAssetList;
        }

        public List<FixedAsset> GetAllFixedAssets()
        {
            var fixedAssets = _fixedAssetService.FindFixedAssets("*", "AST", SearchField);
            foreach (var f in fixedAssets)
            {
                var fixedAsset = _fixedAssetService.ReadFixedAsset("AST", f.Code);
                _fixedAssetList.Add(fixedAsset);
            }

            return _fixedAssetList;
        }

        public bool CreateFixedAsset(FixedAsset fixedAsset)
        {
            try
            {
                _fixedAssetService.CreateFixedAsset(fixedAsset);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteFixedAsset(FixedAsset fixedAsset)
        {
            try
            {
                _fixedAssetService.DeleteFixedAsset(fixedAsset);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ActivateFixedAsset(FixedAsset fixedAsset)
        {
            try
            {
                _fixedAssetService.ActivateFixedAsset(fixedAsset);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }

    public class PeriodOperations
    {
        private readonly PeriodService _periodService;

        public PeriodOperations(Session session)
        {
            _periodService = new PeriodService(session);
        }

        public Periods GetAllPeriodsByYear(int year)
        {
            var periods = _periodService.FindPeriods(year);
            return periods;
        }

        public Years GetAllYears()
        {
            var years = _periodService.FindYears();
            return years;
        }

        public bool CreateYear(int nrOfPeriods)
        {
            try
            {
                _periodService.CreateYear(nrOfPeriods);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ChangePeriodEndDate(int year, int periodNumber, DateTime endDate)
        {
            try
            {
                _periodService.ChangeEndDate(year, periodNumber, endDate);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ChangePeriodName(int year, int periodNumber, string name)
        {
            try
            {
                _periodService.ChangeName(year, periodNumber, name);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool OpenPeriod(int year, int periodNumber)
        {
            try
            {
                _periodService.OpenPeriod(year, periodNumber);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ClosePeriod(int year, int periodNumber)
        {
            try
            {
                _periodService.ClosePeriod(year, periodNumber);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ResetYears(int newYear, int nrOfPeriods)
        {
            try
            {
                _periodService.ResetYears(newYear, nrOfPeriods);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteYear(int year)
        {
            try
            {
                _periodService.DeleteYear(year);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }

    public class ProjectOperations
    {
        private readonly ProjectService _projectService;
        private const int SearchField = 0;

        public ProjectOperations(Session session)
        {
            _projectService = new ProjectService(session);
        }

        private readonly List<Project> _projectList = new List<Project>();

        public List<Project> GetProjectsByName(string name)
        {
            var projects = _projectService.FindProjects(name, "DIM", SearchField);
            foreach (var p in projects)
            {
                var project = _projectService.ReadProject(p.Code);
                _projectList.Add(project);
            }

            return _projectList;
        }

        public List<Project> GetAllProjects()
        {
            var projects = _projectService.FindProjects("*", "DIM", SearchField);
            foreach (var p in projects)
            {
                var project = _projectService.ReadProject(p.Code);
                _projectList.Add(project);
            }

            return _projectList;
        }

        public bool CreateProject(Project project)
        {
            try
            {
                _projectService.CreateProject(project);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteProject(Project project)
        {
            try
            {
                _projectService.DeleteProject(project);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ActivateProject(Project project)
        {
            try
            {
                _projectService.ActivateProject(project);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }

    public class RateOperations
    {
        private readonly RateService _rateService;
        private const int SearchField = 0;

        public RateOperations(Session session)
        {
            _rateService = new RateService(session);
        }

        private readonly List<Data.Rates.Rate> _rateList = new List<Data.Rates.Rate>();

        public List<Data.Rates.Rate> GetRatesByName(string name)
        {
            var rates = _rateService.FindRates(name, "TRT", SearchField);
            foreach (var r in rates)
            {
                var rate = _rateService.ReadRate(r.Code);
                _rateList.Add(rate);
            }

            return _rateList;
        }

        public List<Data.Rates.Rate> GetAllRates()
        {
            var rates = _rateService.FindRates("*", "TRT", SearchField);
            foreach (var r in rates)
            {
                var rate = _rateService.ReadRate(r.Code);
                _rateList.Add(rate);
            }

            return _rateList;
        }

        public bool CreateRate(Data.Rates.Rate rate)
        {
            try
            {
                _rateService.CreateRate(rate);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteRate(Data.Rates.Rate rate)
        {
            try
            {
                _rateService.DeleteRate(rate);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ActivateRate(Data.Rates.Rate rate)
        {
            try
            {
                _rateService.ActivateRate(rate);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteRateChange(Data.Rates.Rate rate)
        {
            try
            {
                _rateService.DeleteRateChange(rate);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }

    public class UserOperations
    {
        private readonly UserService _userService;
        private const int SearchField = 0;

        public UserOperations(Session session)
        {
            _userService = new UserService(session);
        }

        private readonly List<User> _userList = new List<User>();

        public List<User> GetUsersByName(string name)
        {
            var users = _userService.FindUsers(name, "USR", SearchField);
            foreach (var u in users)
            {
                var user = _userService.ReadUser(u.Code);
                _userList.Add(user);
            }

            return _userList;
        }

        public List<User> GetAllUsers()
        {
            var users = _userService.FindUsers("*", "USR", SearchField);
            foreach (var u in users)
            {
                var user = _userService.ReadUser(u.Code);
                _userList.Add(user);
            }

            return _userList;
        }

        public bool CreateUser(User user)
        {
            try
            {
                _userService.CreateUser(user);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteUser(User user)
        {
            try
            {
                _userService.DeleteUser(user);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ActivateUser(User user)
        {
            try
            {
                _userService.ActivateUser(user);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }

    public class TransactionOperations
    {
        private readonly BankTransactionService _bankTransactionService;
        private readonly DeletedTransactionService _deletedTransactionService;
        private readonly PurchaseTransactionService _purchaseTransactionService;
        private readonly SalesTransactionService _salesTransactionService;
        private readonly TransactionBlockedValueService _transactionBlockedValueService;
        private readonly TransactionTypeService _transactionTypeService;
        private readonly Session _session;
        private const int SearchField = 0;

        public TransactionOperations(Session session)
        {
            _bankTransactionService = new BankTransactionService(session);
            _deletedTransactionService = new DeletedTransactionService(session);
            _purchaseTransactionService = new PurchaseTransactionService(session);
            _salesTransactionService = new SalesTransactionService(session);
            _transactionBlockedValueService = new TransactionBlockedValueService(session);
            _transactionTypeService = new TransactionTypeService(session);
            _session = session;
        }

        private readonly List<BankTransaction> _bankTransactionList = new List<BankTransaction>();

        public List<BankTransaction> GetBankTransactionsByNameAndNumber(string name, string number)
        {
            var bankTransactions = _bankTransactionService.FindBankTransactions(name, "BNK", SearchField);
            foreach (var b in bankTransactions)
            {
                try
                {
                    var bankTransaction = _bankTransactionService.ReadBankTransaction(number, b.Code);
                    _bankTransactionList.Add(bankTransaction);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return _bankTransactionList;
        }

        public bool CreateBankTransaction(BankTransaction bankTransaction)
        {
            try
            {
                _bankTransactionService.CreateBankTransaction(bankTransaction);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public Data.DeletedTransactions.DeletedTransactions GetDeletedTransactionsByType(string type, DateTime dateFrom,
            DateTime dateTo)
        {
            var deletedTransactions =
                _deletedTransactionService.FindDeletedTransactions(_session.Office, type, dateFrom, dateTo);
            return deletedTransactions;
        }

        private readonly List<PurchaseTransaction> _purchaseTransactionList = new List<PurchaseTransaction>();

        public List<PurchaseTransaction> GetPurchaseTransactionsByName(string name)
        {
            var purchaseTransactions = _purchaseTransactionService.FindPurchaseTransactions(name, "IVT", SearchField);
            foreach (var p in purchaseTransactions)
            {
                var purchaseTransaction = _purchaseTransactionService.ReadPurchaseTransaction(p.Code);
                _purchaseTransactionList.Add(purchaseTransaction);
            }

            return _purchaseTransactionList;
        }

        public List<PurchaseTransaction> GetAllPurchaseTransactions()
        {
            var purchasedTransactions = _purchaseTransactionService.FindPurchaseTransactions("*", "IVT", SearchField);
            foreach (var p in purchasedTransactions)
            {
                var purchasedTransaction = _purchaseTransactionService.ReadPurchaseTransaction(p.Code);
                _purchaseTransactionList.Add(purchasedTransaction);
            }

            return _purchaseTransactionList;
        }

        public bool CreatePurchaseTransaction(PurchaseTransaction purchaseTransaction)
        {
            try
            {
                _purchaseTransactionService.CreatePurchaseTransaction(purchaseTransaction);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private readonly List<SalesTransaction> _salesTransactionList = new List<SalesTransaction>();

        public List<SalesTransaction> GetSalesTransactionsByName(string name)
        {
            var salesTransactions = _salesTransactionService.FindSalesTransactions(name, "IVT", SearchField);
            foreach (var s in salesTransactions)
            {
                try
                {
                    var salesTransaction = _salesTransactionService.ReadSalesTransaction("IVT", s.Code);
                    _salesTransactionList.Add(salesTransaction);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return _salesTransactionList;
        }

        public List<SalesTransaction> GetAllSalesTransactions()
        {
            var salesTransactions = _salesTransactionService.FindSalesTransactions("*", "IVT", SearchField);
            foreach (var s in salesTransactions)
            {
                try
                {
                    var salesTransaction = _salesTransactionService.ReadSalesTransaction("IVT", s.Code);
                    _salesTransactionList.Add(salesTransaction);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return _salesTransactionList;
        }

        public bool CreateSalesTransaction(SalesTransaction salesTransaction)
        {
            try
            {
                _salesTransactionService.CreateSalesTransaction(salesTransaction);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool RegisterBlockedAmountForTransaction(string companyCode, string transactionCode,
            decimal transactionNumber, int transactionLineId, decimal blockedValue)
        {
            try
            {
                _transactionBlockedValueService.RegisterBlockedAmountForTransaction(companyCode, transactionCode,
                    transactionNumber, transactionLineId, blockedValue);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool UnregisterBlockedAmountForTransaction(string companyCode, string transactionCode,
            decimal transactionNumber, int transactionLineId)
        {
            try
            {
                _transactionBlockedValueService.UnregisterBlockedAmountForTransaction(companyCode, transactionCode,
                    transactionNumber, transactionLineId);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<TransactionTypeSummary> GetTransactionTypesByName(string name)
        {
            var transactionTypes = _transactionTypeService.FindTransactionTypes(name, "TRS", SearchField);
            return transactionTypes;
        }

        public List<TransactionTypeSummary> GetAllTransactionTypes()
        {
            var transactionTypes = _transactionTypeService.FindTransactionTypes("*", "TRS", SearchField);
            return transactionTypes;
        }
    }

    public class ExtraOperations
    {
        private readonly BankStatementService _bankStatementService;
        private readonly CountryService _countryService;
        private readonly DistByPeriodService _distByPeriodService;
        private readonly InvoiceTypeService _invoiceTypeService;
        private readonly PaymentService _paymentService;
        private readonly ReminderScenarioService _reminderScenarioService;
        private readonly ReportService _reportService;
        private readonly SubArticleService _subArticleService;
        private readonly TaxGroupService _taxGroupService;
        private readonly TimeQuantityService _timeQuantityService;
        private readonly TranslationService _translationService;
        private readonly UserRoleService _userRoleService;
        private const int SearchField = 0;

        public ExtraOperations(Session session)
        {
            _bankStatementService = new BankStatementService(session);
            _countryService = new CountryService(session);
            _distByPeriodService = new DistByPeriodService(session);
            _invoiceTypeService = new InvoiceTypeService(session);
            _paymentService = new PaymentService(session);
            _reminderScenarioService = new ReminderScenarioService(session);
            _reportService = new ReportService(session);
            _subArticleService = new SubArticleService(session);
            _taxGroupService = new TaxGroupService(session);
            _timeQuantityService = new TimeQuantityService(session);
            _translationService = new TranslationService(session);
            _userRoleService = new UserRoleService(session);
        }

        #region bank statement

        public Data.BankStatements.BankStatements GetBankStatements(DateTime statementDateFrom,
            DateTime statementDateTo, Boolean includePostedStatements)
        {
            var bankStatement =
                _bankStatementService.FindBankStatements(statementDateFrom, statementDateTo, includePostedStatements);
            return bankStatement;
        }

        #endregion

        #region country

        public List<CountrySummary> GetCountriesByName(string name)
        {
            var countries = _countryService.FindCountries(name, "CTR", SearchField);
            return countries;
        }

        public List<CountrySummary> GetAllCountries()
        {
            var countries = _countryService.FindCountries("*", "CTR", SearchField);
            return countries;
        }

        #endregion

        #region dist by period

        public List<DistByPeriodSummary> GetDistByPeriodByName(string name)
        {
            var distByPeriods = _distByPeriodService.FindDistByPeriods(name, "SPM", SearchField);
            return distByPeriods;
        }

        public List<DistByPeriodSummary> GetAllDistByPeriods()
        {
            var distByPeriods = _distByPeriodService.FindDistByPeriods("*", "SPM", SearchField);
            return distByPeriods;
        }

        public List<InvoiceTypeSummary> GetInvoiceTypesByName(string name)
        {
            var invoiceTypes = _invoiceTypeService.FindInvoiceTypes(name, "INV", SearchField);
            return invoiceTypes;
        }

        #endregion

        #region invoicetype

        public List<InvoiceTypeSummary> GetAllInvoiceTypes()
        {
            var invoiceTypes = _invoiceTypeService.FindInvoiceTypes("*", "INV", SearchField);
            return invoiceTypes;
        }

        #endregion

        #region payment

        public List<PaymentSummary> GetPaymentFilesByName(string name)
        {
            var payments = _paymentService.FindPayments(name, "FMT", SearchField);
            return payments;
        }

        public List<PaymentSummary> GetAllPaymentFiles()
        {
            var payments = _paymentService.FindPayments("*", "FMT", SearchField);
            return payments;
        }

        public List<PaymentSummary> GetPaymentTypesByName(string name)
        {
            var payments = _paymentService.FindPayments(name, "PAY", SearchField);
            return payments;
        }

        public List<PaymentSummary> GetAllPaymentTypes()
        {
            var payments = _paymentService.FindPayments("*", "PAY", SearchField);
            return payments;
        }

        #endregion

        #region reminder scenario

        public List<ReminderScenarioSummary> GetReminderScenariosByName(string name)
        {
            var reminderScenarios = _reminderScenarioService.FindReminderScenarios(name, "RMD", SearchField);
            return reminderScenarios;
        }

        public List<ReminderScenarioSummary> GetAllReminderScenarios()
        {
            var reminderScenarios = _reminderScenarioService.FindReminderScenarios("*", "RMD", SearchField);
            return reminderScenarios;
        }

        #endregion

        #region report

        public List<ReportSummary> GetReportsByName(string name)
        {
            var reports = _reportService.FindReports(name, "REP", SearchField);
            return reports;
        }

        public List<ReportSummary> GetAllReports()
        {
            var reports = _reportService.FindReports("*", "REP", SearchField);
            return reports;
        }

        #endregion

        #region subarticle

        public List<SubArticleSummary> GetSubarticleByNameFromArticle(string name, string article)
        {
            var subArticles = _subArticleService.FindSubArticles(name, article, SearchField);
            return subArticles;
        }

        public List<SubArticleSummary> GetAllSubArticlesFromArticle(string article)
        {
            var subArticles = _subArticleService.FindSubArticles("*", article, SearchField);
            return subArticles;
        }

        #endregion

        #region tax group

        public List<TaxGroupSummary> GetTaxGroupsByName(string name)
        {
            var taxGroups = _taxGroupService.FindTaxGroups(name, "TXG", SearchField);
            return taxGroups;
        }

        public List<TaxGroupSummary> GetAllTaxGroups()
        {
            var taxGroups = _taxGroupService.FindTaxGroups("*", "TXG", SearchField);
            return taxGroups;
        }

        #endregion

        #region time quantity

        public List<TimeQuantitySummary> GetTimeQuantitiesByName(string name)
        {
            var timeQuantities = _timeQuantityService.FindTimeQuantities(name, "TEQ", SearchField);
            return timeQuantities;
        }

        public List<TimeQuantitySummary> GetAllTimeQuantities()
        {
            var timeQuantities = _timeQuantityService.FindTimeQuantities("*", "TEQ", SearchField);
            return timeQuantities;
        }

        #endregion

        #region translation

        public List<TranslationSummary> GetTranslationsByName(string name)
        {
            var translations = _translationService.FindTranslations(name, "XLT", SearchField);
            return translations;
        }

        public List<TranslationSummary> GetAllTranslations()
        {
            var translations = _translationService.FindTranslations("*", "XLT", SearchField);
            return translations;
        }

        #endregion

        #region user role

        public List<UserRoleSummary> GetUserRolesByName(string name)
        {
            var userRoles = _userRoleService.FindUserRoles(name, "ROL", SearchField);
            return userRoles;
        }

        public List<UserRoleSummary> GetAllUserRoles()
        {
            var userRoles = _userRoleService.FindUserRoles("*", "ROL", SearchField);
            return userRoles;
        }

        #endregion
    }
    #endregion
}