using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data.SalesInvoice;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TwinfieldTests
{
    [TestClass]
    public class SalesInvoiceOperationsTests
    {
        private ISalesInvoiceInterface _salesInvoiceInterface;

        [TestInitialize]
        public void Initialize()
        {
            var session = Utilities.CreateValidSession();
            _salesInvoiceInterface = new SalesInvoiceOperations(session);
        }

        [TestMethod]
        public void Should_find_all_salesinoices()
        {
            var salesinvoices = _salesInvoiceInterface.GetAll();
            Assert.IsNotNull(salesinvoices);
        }

        [TestMethod]
        public void Should_find_all_salesinvoices_with_given_type()
        {
            var salesinvoices = _salesInvoiceInterface.GetByInvoiceType("FACTUUR");
            Assert.IsNotNull(salesinvoices);
        }

        [TestMethod]
        public void Should_find_salesinvoice_with_given_number()
        {
            var s = _salesInvoiceInterface.GetByNumber("1");
            List<SalesInvoice> salesInvoices = new List<SalesInvoice>();
            foreach (var x in s)
            {
                var salesinvoice = _salesInvoiceInterface.Read(x.Header.Invoicenumber.ToString(), x.Header.Invoicetype);
                salesInvoices.Add(salesinvoice);
            }
            Assert.IsNotNull(salesInvoices);
            Assert.AreEqual(salesInvoices[0].Header.Invoicenumber.ToString(), "1");
        }

        [TestMethod]
        public void Should_fail_to_ceate_empty_salesinvoice()
        {
            try
            {
                _salesInvoiceInterface.Create(new SalesInvoice());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(true);
            }
        }
    }
}
