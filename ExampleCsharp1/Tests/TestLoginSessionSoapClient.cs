using System;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldLoginSessionService;

namespace Tests
{
	internal class TestLoginSessionSoapClient : ILoginSessionSoapClient
	{
		private const string TestCluster = "https://c1.twinfield.com";
		private const string TestUser = "API000110";
		private const string TestPassword = "SforSoftware12";
		private const string TestOrganisation = "TWINAPPS";
//	    private const string TestUser = "TESTUSER";
//	    private const string TestPassword = "password";
//	    private const string TestOrganisation = "TESTORG";
        private const string TestSessionId = "1234567890";

		public Header Logon(string user, string password, string organisation, out LogonResult LogonResult, out LogonAction nextAction,
				out string cluster)
		{
			if (LogonIsValid(user, password, organisation))
			{
				LogonResult = LogonResult.Ok;
				nextAction = LogonAction.None;
				cluster = TestCluster;
				return new Header { SessionID = TestSessionId };
			}

			LogonResult = LogonResult.Invalid;
			nextAction = LogonAction.None;
			cluster = string.Empty;
			return null;
		}

		public Header OAuthLogon(string clientToken, string clientSecret, string accessToken, string accessSecret,
				out LogonResult OAuthLogonResult, out LogonAction nextAction, out string cluster)
		{
			throw new NotImplementedException();
		}

		private static bool LogonIsValid(string user, string password, string organisation)
		{
			return user == TestUser && password == TestPassword && organisation == TestOrganisation;
		}
	}
}