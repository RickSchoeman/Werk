using System;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Demo;

namespace DemoConnector.TwinfieldAPI
{
    public class TwinfieldApiConnector
    {
        readonly IClientFactory clientFactory = new ClientFactory();
        private Session session;

        public void TestConnection(string loginServerUrl, string user, string password, string organisation,
            string office)
        {
            if (!Login(loginServerUrl, user, password, organisation))
            {
                return;
            }

            if (!SwitchToOffice(office))
            {
                return;
            }
            (new OfficeDemo(session)).Run();
            (new CustomerDemo(session)).Run();
            (new BankBookDemo(session)).Run();
            (new BookkeepingDemo(session)).Run();
            LogOff();
        }

        private bool Login(string loginServerUrl, string user, string password, string organisation)
        {
            Console.WriteLine("Log in");
            var sessionService = new SessionService(clientFactory);
            session = sessionService.Logon(loginServerUrl, user, password, organisation);
            if (session == null)
            {
                Console.WriteLine("Failed to log in to organisation {0} with user {1} on {2}.", organisation, user, loginServerUrl);
                return false;
            }
            Console.WriteLine("Logged in to organisation {0} with user {1} on {2}.", organisation, user, loginServerUrl);
            Console.WriteLine();
            return true;
        }

        private bool SwitchToOffice(string office)
        {
            var sessionService = new SessionService(clientFactory);
            if (!sessionService.SelectOffice(session, office))
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
            sessionService.Abandon(session);
            Console.WriteLine("Logged off.");
            Console.WriteLine();
        }
    }

    public interface ITwinfieldApiSettings
    {

    }
}
