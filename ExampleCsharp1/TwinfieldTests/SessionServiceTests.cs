using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TwinfieldTests
{
    [TestClass]
    public class SessionServiceTests
    {
        SessionService sessionService;

        [TestInitialize]
        public void Initialize()
        {
            var factory = new ClientFactory();
            sessionService = new SessionService(factory);
        }

        [TestMethod]
        public void Logon_with_valid_credentials_should_create_session()
        {
            var session = sessionService.Logon("API000110", "SforSoftware12", "TWINAPPS");
            Assert.IsNotNull(session);
            Assert.IsTrue(session.LoggedOn);
        }

        [TestMethod]
        public void Logon_with_invalid_credentials_should_not_create_session()
        {
            var session = sessionService.Logon("TESTUSER", "PASSWORD", "TESTORG");

            Assert.IsNull(session);
        }

        [TestMethod]
        public void Selecting_an_office_should_set_the_sessions_office()
        {
            var session = Utilities.CreateValidSession();
            sessionService.SelectOffice(session, "NLA000218");
            Assert.AreEqual("NLA000218", session.Office);
        }

        [TestMethod]
        public void Abandoning_a_session_should_clear_it()
        {
            var session = Utilities.CreateValidSession();
            sessionService.Abandon(session);

            Assert.IsFalse(session.LoggedOn);
        }

       
    }
}
