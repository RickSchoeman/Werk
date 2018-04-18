using System.Collections.Generic;
using TwinfieldApi.TwinfieldBudgetService;
using TwinfieldApi.TwinfieldDeclarationsService;
using TwinfieldApi.TwinfieldFinderService;
using TwinfieldApi.TwinfieldSessionService;
using Command = TwinfieldApi.TwinfieldBankBookService.Command;
using LogonAction = TwinfieldApi.TwinfieldLoginSessionService.LogonAction;
using LogonResult = TwinfieldApi.TwinfieldLoginSessionService.LogonResult;
using Query = TwinfieldApi.TwinfieldBankBookService.Query;
using QueryResult = TwinfieldApi.TwinfieldBankBookService.QueryResult;

namespace TwinfieldApi.Services
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
        void Process(string SessionId, TwinfieldApi.TwinfieldCashBookService.Command Command);
        TwinfieldCashBookService.QueryResult Query(string SessionId, TwinfieldCashBookService.Query Query);
    }

    public interface IBankStatementClient
    {
        void Process(string SessionId, TwinfieldApi.TwinfieldBankStatementService.Command Command);

        TwinfieldApi.TwinfieldBankStatementService.QueryResult Query(string SessionId,
            TwinfieldApi.TwinfieldBankStatementService.Query Query);
    }

    public interface IPeriodServiceClient
    {
        void Process(string SessionId, TwinfieldApi.TwinfieldPeriodService.Command Command);

        TwinfieldApi.TwinfieldPeriodService.QueryResult Query(string SessionId,
            TwinfieldApi.TwinfieldPeriodService.Query Query);
    }

    public interface IDeletedTransactionsClient
    {
        TwinfieldApi.TwinfieldDeletedTransactionService.QueryResult Query(string SessionId,
            TwinfieldApi.TwinfieldDeletedTransactionService.Query Query);
    }

    public interface ITransactionBlockedValueClient
    {
        void Process(string SessionId, TwinfieldApi.TwinfieldTransactionBlockedValueService.Command Command);
    }

    public interface IDeclarationServiceClient
    {
        MessageOfLoadMessage[] GetAllSummaries(TwinfieldApi.TwinfieldDeclarationsService.Header header,
            string companyCode);
    }

}
