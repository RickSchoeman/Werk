using DemoConnector.TwinfieldBudgetService;
using DemoConnector.TwinfieldDeclarationsService;
using DemoConnector.TwinfieldFinderService;
using DemoConnector.TwinfieldSessionService;
using Command = DemoConnector.TwinfieldBankBookService.Command;
using LogonAction = DemoConnector.TwinfieldLoginSessionService.LogonAction;
using LogonResult = DemoConnector.TwinfieldLoginSessionService.LogonResult;
using Query = DemoConnector.TwinfieldBankBookService.Query;
using QueryResult = DemoConnector.TwinfieldBankBookService.QueryResult;

namespace DemoConnector.TwinfieldAPI.Controllers.Services
{
    public interface ILoginSessionSoapClient
	{
		TwinfieldLoginSessionService.Header Logon(string user, string password, string organisation, out LogonResult LogonResult, out LogonAction nextAction, out string cluster);
		TwinfieldLoginSessionService.Header OAuthLogon(string clientToken, string clientSecret, string accessToken, string accessSecret, out LogonResult OAuthLogonResult, out LogonAction nextAction, out string cluster);
	}

	public interface ISessionSoapClient
	{
		SMSLogonResult SmsLogon(TwinfieldSessionService.Header Header, string smsCode, out TwinfieldSessionService.LogonAction nextAction);
		int SmsSendCode(TwinfieldSessionService.Header Header);
		ChangePasswordResult ChangePassword(TwinfieldSessionService.Header Header, string currentPassword, string newPassword, out TwinfieldSessionService.LogonAction nextAction);
		SelectCompanyResult SelectCompany(TwinfieldSessionService.Header Header, string company);
		void KeepAlive(TwinfieldSessionService.Header Header);
		void Abandon(TwinfieldSessionService.Header Header);
		string GetRole(TwinfieldSessionService.Header Header);
	}

	public interface IBankBookServiceClient
	{
		void Process(string SessionId, Command Command);
		QueryResult Query(string SessionId, Query Query1);
	}

	public interface IFinderSoapClient
	{
		MessageOfErrorCodes[] Search(TwinfieldFinderService.Header Header, string type, string pattern, int field, int firstRow, int maxRows, string[][] options, out FinderData data);
	}

	public interface IProcessXmlSoapClient
	{
		string ProcessXmlString(TwinfieldProcessXmlService.Header Header, string xmlRequest);
		System.Xml.XmlNode ProcessXmlDocument(TwinfieldProcessXmlService.Header Header, System.Xml.XmlNode xmlRequest);
		byte[] ProcessXmlCompressed(TwinfieldProcessXmlService.Header Header, byte[] xmlRequest);
	}

    public interface IBudgetServiceClient
    {
        void Process(string SessionId, TwinfieldBudgetService.Command Command);
        TwinfieldBudgetService.QueryResult Query(string SessionId, BudgetQuery Query1);
    }

    public interface ICashBookServiceClient
    {
        void Process(string SessionId, DemoConnector.TwinfieldCashBookService.Command Command);
        TwinfieldCashBookService.QueryResult Query(string SessionId, TwinfieldCashBookService.Query Query);
    }

    public interface IBankStatementClient
    {
        void Process(string SessionId, DemoConnector.TwinfieldBankStatementService.Command Command);

        DemoConnector.TwinfieldBankStatementService.QueryResult Query(string SessionId,
            DemoConnector.TwinfieldBankStatementService.Query Query);
    }

    public interface IPeriodServiceClient
    {
        void Process(string SessionId, DemoConnector.TwinfieldPeriodService.Command Command);

        DemoConnector.TwinfieldPeriodService.QueryResult Query(string SessionId,
            DemoConnector.TwinfieldPeriodService.Query Query);
    }

    public interface IDeletedTransactionsClient
    {
        DemoConnector.TwinfieldDeletedTransactionService.QueryResult Query(string SessionId,
            DemoConnector.TwinfieldDeletedTransactionService.Query Query);
    }

    public interface ITransactionBlockedValueClient
    {
        void Process(string SessionId, DemoConnector.TwinfieldTransactionBlockedValueService.Command Command);
    }

    public interface IDeclarationServiceClient
    {
        MessageOfLoadMessage[] GetAllSummaries(DemoConnector.TwinfieldDeclarationsService.Header header,
            string companyCode);
    }

}
