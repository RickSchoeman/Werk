using System;
using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Activities;
using DemoConnector.TwinfieldAPI.Data.Articles;
using DemoConnector.TwinfieldAPI.Data.AssetMethods;
using DemoConnector.TwinfieldAPI.Data.BalanceSheet;
using DemoConnector.TwinfieldAPI.Data.BankBooks;
using DemoConnector.TwinfieldAPI.Data.BankTransactions;
using DemoConnector.TwinfieldAPI.Data.CashBooks;
using DemoConnector.TwinfieldAPI.Data.CostCenters;
using DemoConnector.TwinfieldAPI.Data.Currencies;
using DemoConnector.TwinfieldAPI.Data.Customers;
using DemoConnector.TwinfieldAPI.Data.DimensionGroups;
using DemoConnector.TwinfieldAPI.Data.Dimensions;
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
using DemoConnector.TwinfieldAPI.Data.ProfitLoss;
using DemoConnector.TwinfieldAPI.Data.Projects;
using DemoConnector.TwinfieldAPI.Data.PurchaseTransactions;
using DemoConnector.TwinfieldAPI.Data.SalesTransactions;
using DemoConnector.TwinfieldAPI.Data.Summaries;
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
using DemoConnector.TwinfieldAPI.Handlers.Dimension;
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
        private readonly ApiOperationsBase<Article> _apiOperations;
        private const int SearchField = 0;

        public ArticleOperations(Session session)
        {
            _articleService = new ArticleService(session);
            _subArticleService = new SubArticleService(session);
            _apiOperations = new ApiOperationsBase<Article>(session, "ART");
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

        public List<ArticleSummary> GetSummaries()
        {
            return _articleService.FindHeaders("*", "ART", SearchField);
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
            return _apiOperations.Create(article);
        }

        public string Delete(Article article)
        {
            return _apiOperations.Delete(article);
        }

        public string Activate(Article article)
        {
            return _apiOperations.Activate(article);
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

        public List<SubArticleSummary> GetSubArticlesByArticle(string article)
        {
            var subArticles = _subArticleService.FindSubArticles("*", article, SearchField);
            return subArticles;
        }
    }

    public class ApiOperationsBase<T> : IApiOperationsBase<T> where T : class
    {
        private readonly DimensionOperations<T> _dimensionOperations;
        private readonly string _apiCode;
        public ApiOperationsBase(Session session, string apiObjectCode)
        {
            _apiCode = apiObjectCode;
            _dimensionOperations = new DimensionOperations<T>(session);
        }
        
        public List<T> GetByName(string name)
        {
            return _dimensionOperations.GetByName(name, _apiCode);

        }

        public List<T> GetAll()
        {
            return _dimensionOperations.GetAll(_apiCode);
        }

        public T Read(string code)
        {
            return _dimensionOperations.Read(_apiCode, code);
        }

        public List<DimensionSummary> GetSummaries()
        {
            return _dimensionOperations.GetSummaries(_apiCode);
        }

        public string Create(T obj)
        {
            return _dimensionOperations.Create(obj);
        }

        public string Delete(T obj)
        {
            return _dimensionOperations.Delete(obj);
        }

        public string Activate(T obj)
        {
            return _dimensionOperations.Activate(obj);
        }
    }
    
    public class ApiSummaryBase : IApiSummaryBase
    {
        private readonly SummaryOperations _summaryOperations;
        private readonly string _apiCode;

        public ApiSummaryBase(Session session, string apiObjectCode)
        {
            _apiCode = apiObjectCode;
            _summaryOperations = new SummaryOperations(session);
        }

        public List<Summary> GetByName(string name)
        {
            return _summaryOperations.GetByName(name, _apiCode);
        }

        public List<Summary> GetAll()
        {
            return _summaryOperations.GetAll(_apiCode);
        }
    }

    public class CustomerOperations : ApiOperationsBase<Customer>
    {

        public CustomerOperations(Session session) : base(session, "DEB")
        {
        }

    }

    public class SupplierOperations : ApiOperationsBase<Supplier>
    {
        public SupplierOperations(Session session) : base(session, "CRD")
        {
        }
    }

    public class BalanceSheetOperations : ApiOperationsBase<BalanceSheet>
    {
        public BalanceSheetOperations(Session session) : base(session, "BAS")
        {
        }
    }

    public class ProfitLossOperations : ApiOperationsBase<ProfitLoss>
    {
        public ProfitLossOperations(Session session) : base(session, "PNL")
        {
        }
    }

    public class SalesInvoiceOperations : ISalesInvoiceInterface
    {
        private readonly SalesInvoiceService _salesInvoiceService;
        private readonly InvoiceTypeService _invoiceTypeService;
        private readonly ApiOperationsBase<Data.SalesInvoice.SalesInvoice> _apiOperations;
        private const int SearchField = 0;

        public SalesInvoiceOperations(Session session)
        {
            _salesInvoiceService = new SalesInvoiceService(session);
            _invoiceTypeService = new InvoiceTypeService(session);
            _apiOperations = new ApiOperationsBase<Data.SalesInvoice.SalesInvoice>(session, "INV");
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
            return _apiOperations.Create(salesInvoice);
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

    public class CostCenterOperatons : ApiOperationsBase<CostCenter>
    {
        public CostCenterOperatons(Session session) : base(session, "KPL")
        {
        }
        

    }

    public class VatOperations : IVatInterface
    {
        private readonly VatService _vatService;
        private readonly ApiOperationsBase<Vat> _apiOperations;
        private const int SearchField = 0;

        public VatOperations(Session session)
        {
            _vatService = new VatService(session);
            _apiOperations = new ApiOperationsBase<Vat>(session, "VAT");
        }

        private readonly List<Vat> _vatList = new List<Vat>();

        public List<Vat> GetByName(string name)
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

        public List<Vat> GetAll()
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

        public List<VatSummary> GetSummaries()
        {
            return _vatService.FindVats("*", "VAT", SearchField);
        }

        public string Create(Vat vat)
        {
            return _apiOperations.Create(vat);
        }

        public string Delete(Vat vat)
        {
            return _apiOperations.Delete(vat);
        }

//        public List<VatCountrySummary> GetVatCountriesByName(string name)
//        {
//            var vatCountries = _vatCountryService.FindVatCountries(name, "VGM", SearchField);
//            return vatCountries;
//        }
//
//        public List<VatCountrySummary> GetAllVatCountries()
//        {
//            var vatCountries = _vatCountryService.FindVatCountries("*", "VGM", SearchField);
//            return vatCountries;
//        }
//
//        public List<VatGroupSummary> GetVatGroupsByName(string name)
//        {
//            var vatGroups = _vatGroupService.FindVatGroups(name, "VTB", SearchField);
//            return vatGroups;
//        }
//
//        public List<VatGroupSummary> GetAllVatGroups()
//        {
//            var vatGroups = _vatGroupService.FindVatGroups("*", "VTB", SearchField);
//            return vatGroups;
//        }
//
//        public List<VatNrOfRelationsSummary> GetVatNrOfRelationsByName(string name)
//        {
//            var vatNrOfRelations = _vatNrOfRelationsService.FindVatNrOfRelations(name, "VATN", SearchField);
//            return vatNrOfRelations;
//        }
//
//        public List<VatNrOfRelationsSummary> GetAllVatNrOfRelations()
//        {
//            var vatNrOfRelations = _vatNrOfRelationsService.FindVatNrOfRelations("*", "VATN", SearchField);
//            return vatNrOfRelations;
//        }
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
    
    public class CountryOperations : ApiSummaryBase
    {
        public CountryOperations(Session session) : base(session, "CTR")
        {
        }
    }

    public class CurrencyOperations : ICurrencyInterface
    {
        private readonly CurrenciesService _currenciesService;
        private readonly ApiOperationsBase<Currency> _apiOperations;
        private const int SearchField = 0;

        public CurrencyOperations(Session session)
        {
            _currenciesService = new CurrenciesService(session);
            _apiOperations = new ApiOperationsBase<Currency>(session, "CUR");
        }

        private readonly List<Currency> _currencyList = new List<Currency>();

        public List<Currency> GetByName(string name)
        {
            _currencyList.Clear();
            var currencies = _currenciesService.FindCurrencies(name, "CUR", SearchField);
            foreach (var c in currencies)
            {
                var currency = _currenciesService.ReadCurrencies("CUR", c.Code);
                _currencyList.Add(currency);
            }

            return _currencyList;
        }

        public List<Currency> GetAll()
        {
            _currencyList.Clear();
            var currencies = _currenciesService.FindCurrencies("*", "CUR", SearchField);
            foreach (var c in currencies)
            {
                var currency = _currenciesService.ReadCurrencies("CUR", c.Code);
                _currencyList.Add(currency);
            }

            return _currencyList;
        }

        public string Create(Currency currency)
        {
            return _apiOperations.Create(currency);
        }

        public string Delete(Currency currency)
        {
            return _apiOperations.Delete(currency);
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
    
    public class InvoiceTypeOperations : ApiSummaryBase
    {
        public InvoiceTypeOperations(Session session) : base(session, "INV")
        {
        }
    }
    
    public class DimensionTypeOperations :IDimensionTypeInterface
    {
        private readonly DimensionTypeService _dimensionTypeService;
        private readonly ApiOperationsBase<DimensionType> _apiOperations;
        private const int SearchField = 0;

        public DimensionTypeOperations(Session session)
        {
            _dimensionTypeService = new DimensionTypeService(session);
            _apiOperations = new ApiOperationsBase<DimensionType>(session, "DMT");
        }

        private readonly List<DimensionType> _dimensionTypeList = new List<DimensionType>();

        public List<DimensionType> GetByName(string name)
        {
            _dimensionTypeList.Clear();
            var dimensionTypes = _dimensionTypeService.FindDimensionTypes(name, SearchField);
            foreach (var d in dimensionTypes)
            {
                var dimensiontype = _dimensionTypeService.ReadDimensionType(d.Code);
                _dimensionTypeList.Add(dimensiontype);
            }

            return _dimensionTypeList;
        }

        public List<DimensionType> GetAll()
        {
            _dimensionTypeList.Clear();
            var dimensionTypes = _dimensionTypeService.FindDimensionTypes("*", SearchField);
            foreach (var d in dimensionTypes)
            {
                var dimensionType = _dimensionTypeService.ReadDimensionType(d.Code);
                _dimensionTypeList.Add(dimensionType);
            }

            return _dimensionTypeList;
        }

        public string Update(DimensionType dimensionType)
        {
            return _apiOperations.Create(dimensionType);
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

    public class DistByPeriodOperations : ApiSummaryBase
    {
        public DistByPeriodOperations(Session session) : base(session, "SPM")
        {

        }
    }

    public class PaymentFilesOperations : ApiSummaryBase
    {
        public PaymentFilesOperations(Session session) : base(session, "FMT")
        {

        }
    }

    public class PaymentTypesOperations : ApiSummaryBase
    {
        public PaymentTypesOperations(Session session) : base(session, "PAY")
        {

        }
    }

    public class ReminderScenarioOperations : ApiSummaryBase
    {
        public ReminderScenarioOperations(Session session) : base(session, "RMD")
        {

        }
    }

    public class ReportOperations : ApiSummaryBase
    {
        public ReportOperations(Session session) : base(session, "REP")
        {

        } 
    }

    public class TaxGroupOperations : ApiSummaryBase
    {
        public TaxGroupOperations(Session session) : base(session, "TXG")
        {

        }
    }

    public class TimeQuantityOperations : ApiSummaryBase
    {
        public TimeQuantityOperations(Session session) : base(session, "TEQ")
        {

        }
    }

    public class TranslationOperations : ApiSummaryBase
    {
        public TranslationOperations(Session session) : base(session, "XLT")
        {

        }
    }

    public class UserRoleOperations : ApiSummaryBase
    {
        public UserRoleOperations(Session session) : base(session, "ROL")
        {

        }
    }

    public class ExtraOperations
    {
        private readonly BankStatementService _bankStatementService;
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
        
    }
    #endregion
}