using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Converters;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApplicatie;
using TestApplicatie.Interfaces;

namespace TwinfieldTests
{
    [TestClass]
    public class SalesInvoiceConverterTests
    {
        private IMiddlewareData _middlewareData;
        private ISalesInvoiceInterface _salesInvoiceInterface;
        private ISalesInvoiceConverter _salesInvoiceConverter;
        private Session _session;

        [TestInitialize]
        public void Initialize()
        {
            _middlewareData = new MiddlewareData();
            _session = Utilities.CreateValidSession();
            _salesInvoiceConverter = new SalesInvoiceConverter(_session);
            _salesInvoiceInterface = new SalesInvoiceOperations(_session);
        }

        [TestMethod]
        public void Should_convert_sales_invoice_response_to_sales_invoice()
        {
            var salesinvoice =
                _salesInvoiceConverter.ConvertSalesInvoiceResponse(_middlewareData.GetSalesInvoiceData(),
                    _session.Office);
            Assert.IsNotNull(salesinvoice);
        }

        [TestMethod]
        public void Should_convert_sales_invoice_to_sales_invoice_response()
        {
            var salesinvoice = _salesInvoiceInterface.GetByNumber("1");
            var salesInvoiceResponse = _salesInvoiceConverter.ConvertSalesInvoice(salesinvoice[0]);
            Assert.IsNotNull(salesInvoiceResponse);
        }
    }
}
