using System;
using System.ServiceModel;
using TwinfieldApi.TwinfieldBankBookService;
using TwinfieldApi.TwinfieldBankStatementService;
using TwinfieldApi.TwinfieldBudgetService;
using TwinfieldApi.TwinfieldCashBookService;
using TwinfieldApi.TwinfieldDeclarationsService;
using TwinfieldApi.TwinfieldDeletedTransactionService;
using TwinfieldApi.TwinfieldFinderService;
using TwinfieldApi.TwinfieldPeriodService;
using TwinfieldApi.TwinfieldProcessXmlService;
using TwinfieldApi.TwinfieldTransactionBlockedValueService;
using SessionSoapClient = TwinfieldApi.TwinfieldSessionService.SessionSoapClient;

namespace TwinfieldApi.Services
{
	public class ClientFactory : IClientFactory
	{
		private const string SessionServicePath = "/webservices/session.asmx";
		private const string FinderServicePath = "/webservices/finder.asmx";
		private const string BankBookServicePath = "/webservices/BankBookService.svc";
		private const string ProcessXmlServicePath = "/webservices/processxml.asmx";
	    private const string BudgetServicePath = "/webservices/BudgetService.svc";
	    private const string CashBookServicePath = "/webservices/CashBookService.svc";
	    private const string BankStatementsServicePath = "/webservices/BankStatementService.svc";
	    private const string PeriodServicePath = "/webservices/PeriodService.svc";
	    private const string DeletedTransactionServicePath = "/webservices/DeletedTransactionsService.svc";
	    private const string TransactionBlockedValueServicePath = "/webservices/TransactionBlockedValueService.svc";
	    private const string DeclarationServicePath = "/webservices/declarations.asmx";


        public ILoginSessionSoapClient CreateLoginSessionClient(string baseUrl)
		{
			string endpointUrl = baseUrl + SessionServicePath;
			return new TwinfieldLoginSessionService.SessionSoapClient(GetBinding(endpointUrl), new EndpointAddress(endpointUrl));
		}

		public ISessionSoapClient CreateSessionClient(string baseUrl)
		{
			string endpointUrl = baseUrl + SessionServicePath;
			return new SessionSoapClient(GetBinding(endpointUrl), new EndpointAddress(endpointUrl));
		}

		public IBankBookServiceClient CreateBankBookClient(string baseUrl)
		{
			string endpointUrl = baseUrl + BankBookServicePath;
			return new BankBookServiceClient(GetBinding(endpointUrl), new EndpointAddress(endpointUrl));
		}

		public IFinderSoapClient CreateFinderClient(string baseUrl)
		{
			string endpointUrl = baseUrl + FinderServicePath;
			return new FinderSoapClient(GetBinding(endpointUrl), new EndpointAddress(endpointUrl));
		}

		public IProcessXmlSoapClient CreateProcessXmlClient(string baseUrl)
		{
			string endpointUrl = baseUrl + ProcessXmlServicePath;
			return new ProcessXmlSoapClient(GetBinding(endpointUrl), new EndpointAddress(endpointUrl));
		}

	    public IBudgetServiceClient CreateBudgetServiceClient(string baseUrl)
	    {
	        string endpointurl = baseUrl + BudgetServicePath;
	        return new BudgetServiceClient(GetBinding(endpointurl), new EndpointAddress(endpointurl));
	    }

	    public ICashBookServiceClient CreateCashBookClient(string baseUrl)
	    {
	        string endpointurl = baseUrl + CashBookServicePath;
	        return new CashBookServiceClient(GetBinding(endpointurl), new EndpointAddress(endpointurl));
	    }

	    public IBankStatementClient CreateBankStatementClient(string baseUrl)
	    {
	        string endpointurl = baseUrl + BankStatementsServicePath;
	        return new BankStatementServiceClient(GetBinding(endpointurl), new EndpointAddress(endpointurl));
	    }

	    public IPeriodServiceClient CreatePeriodServiceClient(string baseUrl)
	    {
	        string endpointurl = baseUrl + PeriodServicePath;
	        return new PeriodServiceClient(GetBinding(endpointurl), new EndpointAddress(endpointurl));
	    }

	    public IDeletedTransactionsClient CreateDeletedTransactionsClient(string baseUrl)
	    {
	        string endpointurl = baseUrl + DeletedTransactionServicePath;
	        return new DeletedTransactionsServiceClient(GetBinding(endpointurl), new EndpointAddress(endpointurl));
	    }

	    public ITransactionBlockedValueClient CreateTransactionBlockedValueClient(string baseUrl)
	    {
	        string endpointurl = baseUrl + TransactionBlockedValueServicePath;
	        return new TransactionBlockedValueServiceClient(GetBinding(endpointurl), new EndpointAddress(endpointurl));
	    }

	    public IDeclarationServiceClient CreateDeclarationServiceClient(string baseUrl)
	    {
	        string endpointurl = baseUrl + DeclarationServicePath;
            return new DeclarationsSoapClient(GetBinding(endpointurl), new EndpointAddress(endpointurl));
	    }

		private static BasicHttpBinding GetBinding(string endpointUrl)
		{
			var uri = new Uri(endpointUrl);
			var securityMode = uri.Scheme == "https" ? BasicHttpSecurityMode.Transport : BasicHttpSecurityMode.None;
			var binding = new BasicHttpBinding(securityMode)
			{
				MaxReceivedMessageSize = 20000000, 
				SendTimeout = new TimeSpan(0, 0, 900)
			};
			return binding;
		}
	}
}
