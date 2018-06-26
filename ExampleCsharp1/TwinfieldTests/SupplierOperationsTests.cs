using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data.Suppliers;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TwinfieldTests
{
    [TestClass]
    public class SupplierOperationsTests
    {
        private IApiOperationsBase<Supplier> _supplierInterface;

        [TestInitialize]
        public void Initialize()
        {
            var session = Utilities.CreateValidSession();
            _supplierInterface = new SupplierOperations(session);
        }

        [TestMethod]
        public void Should_find_all_suppliers()
        {
            var suppliers = _supplierInterface.GetAll();
            Assert.IsNotNull(suppliers);
        }

        [TestMethod]
        public void Should_find_all_supplier_summaries()
        {
            var suppliers = _supplierInterface.GetSummaries();
            Assert.IsNotNull(suppliers);
        }

        [TestMethod]
        public void Should_read_given_supplier()
        {
            var s = _supplierInterface.GetByName("2001");
            List<Supplier> suppliers = new List<Supplier>();
            foreach (var x in s)
            {
                var supplier = _supplierInterface.Read(x.Code);
                suppliers.Add(supplier);
            }
            Assert.IsNotNull(suppliers);
            Assert.AreEqual(suppliers[0].Code, "2001");
        }

        [TestMethod]
        public void Should_fail_to_create_empty_supplier()
        {
            try
            {
                _supplierInterface.Create(new Supplier());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Should_fail_to_delete_with_empty_supplier()
        {
            try
            {
                _supplierInterface.Delete(new Supplier());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Should_fail_to_activate_with_empty_supplier()
        {
            try
            {
                _supplierInterface.Activate(new Supplier());
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
