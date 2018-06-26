using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Converters;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Suppliers;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApplicatie;
using TestApplicatie.Interfaces;

namespace TwinfieldTests
{
    [TestClass]
    public class SupplierConverterTests
    {
        private IMiddlewareData _middlewareData;
        private IApiOperationsBase<Supplier> _supplierInterface;
        private ISupplierConverter _supplierConverter;
        private Session _session;

        [TestInitialize]
        public void Initialize()
        {
            _middlewareData = new MiddlewareData();
            _session = Utilities.CreateValidSession();
            _supplierConverter = new SupplierConverter();
            _supplierInterface = new SupplierOperations(_session);
        }

        [TestMethod]
        public void Should_convert_supplier_response_to_supplier()
        {
            var supplier =
                _supplierConverter.ConvertSupplierResponse(_middlewareData.GetSupplierData(), _session.Office);
            Assert.IsNotNull(supplier);
        }

        [TestMethod]
        public void Should_convert_supplier_to_supplier_response()
        {
            var supplier = _supplierInterface.GetByName("2001");
            var supplierResponse = _supplierConverter.ConvertSupplier(supplier[0]);
            Assert.IsNotNull(supplierResponse);
        }

    }
}
