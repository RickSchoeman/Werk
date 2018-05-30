using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;

namespace TwinfieldTests
{
    static class Utilities
    {
        public static Session CreateValidSession()
        {
            var factory = new ClientFactory();;
            var sessionService = new SessionService(factory);
            var session = sessionService.Logon("API000110", "SforSoftware12", "TWINAPPS");
            sessionService.SelectOffice(session, "NLA000218");
            return session;
        }
    }
}
