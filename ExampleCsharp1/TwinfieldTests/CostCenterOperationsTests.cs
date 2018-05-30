using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data.CostCenters;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TwinfieldTests
{
    [TestClass]
    public class CostCenterOperationsTests
    {
        private IApiOperationsBase<CostCenter> _costCenterInterface;

        [TestInitialize]
        public void Initialize()
        {
            var session = Utilities.CreateValidSession();
            _costCenterInterface = new CostCenterOperatons(session);
        }

        [TestMethod]
        public void Should_find_all_cost_centers()
        {
            var cc = _costCenterInterface.GetAll();
            Assert.IsNotNull(cc);
        }

        [TestMethod]
        public void Should_find_all_cost_center_summaries()
        {
            var cc = _costCenterInterface.GetSummaries();
            Assert.IsNotNull(cc);
        }

        [TestMethod]
        public void Should_read_given_cost_center()
        {
            var cc = _costCenterInterface.GetByName("00000");
            List<CostCenter> costCenters = new List<CostCenter>();
            foreach (var x in cc)
            {
                var costCenter = _costCenterInterface.Read(x.Code);
                costCenters.Add(costCenter);
            }
            Assert.IsNotNull(costCenters);
            Assert.AreEqual(costCenters[0].Code, "00000");
        }

        [TestMethod]
        public void Should_fail_to_create_empty_cost_center()
        {
            try
            {
                _costCenterInterface.Create(new CostCenter());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Should_fail_to_delete_with_empty_cost_center()
        {
            try
            {
                _costCenterInterface.Delete(new CostCenter());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Should_fail_to_activate_with_empty_cost_center()
        {
            try
            {
                _costCenterInterface.Activate(new CostCenter());
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
