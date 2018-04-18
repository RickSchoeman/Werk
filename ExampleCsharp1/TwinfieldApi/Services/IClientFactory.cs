namespace TwinfieldApi.Services
{
	public interface IClientFactory
	{
		ILoginSessionSoapClient CreateLoginSessionClient(string baseUrl);
		ISessionSoapClient CreateSessionClient(string baseUrl);
		IBankBookServiceClient CreateBankBookClient(string baseUrl);
		IFinderSoapClient CreateFinderClient(string baseUrl);
		IProcessXmlSoapClient CreateProcessXmlClient(string baseUrl);
	    IBudgetServiceClient CreateBudgetServiceClient(string baseUrl);
	    ICashBookServiceClient CreateCashBookClient(string baseUrl);
	    IBankStatementClient CreateBankStatementClient(string baseUrl);
	    IPeriodServiceClient CreatePeriodServiceClient(string baseUrl);
	    IDeletedTransactionsClient CreateDeletedTransactionsClient(string baseUrl);
	    ITransactionBlockedValueClient CreateTransactionBlockedValueClient(string baseUrl);
	    IDeclarationServiceClient CreateDeclarationServiceClient(string baseUrl);
	}


}