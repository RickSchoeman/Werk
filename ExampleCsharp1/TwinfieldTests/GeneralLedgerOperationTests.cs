using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data.BalanceSheet;
using DemoConnector.TwinfieldAPI.Data.GeneralLedgers;
using DemoConnector.TwinfieldAPI.Data.ProfitLoss;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TwinfieldTests
{
    [TestClass]
    public class GeneralLedgerOperationTests
    {
        private IApiOperationsBase<BalanceSheet> _balanceSheetInterface;
        private IApiOperationsBase<ProfitLoss> _profitLossInterface;

        [TestInitialize]
        public void Initialize()
        {
            var session = Utilities.CreateValidSession();
            _balanceSheetInterface = new BalanceSheetOperations(session);
            _profitLossInterface = new ProfitLossOperations(session);
        }

        [TestMethod]
        public void Should_find_all_balance_sheet()
        {
            var gen = _balanceSheetInterface.GetAll();
            Assert.IsNotNull(gen);
        }

        [TestMethod]
        public void Should_find_all_profit_loss()
        {
            var gen = _profitLossInterface.GetAll();
            Assert.IsNotNull(gen);
        }

        [TestMethod]
        public void Should_read_given_balance_sheet()
        {
            var g = _balanceSheetInterface.GetByName("0090");
            List<GeneralLedger> generalLedgers = new List<GeneralLedger>();
            foreach (var x in g)
            {
                var generalLedger = _balanceSheetInterface.Read(x.Code);
                generalLedgers.Add(generalLedger);
            }
            Assert.IsNotNull(generalLedgers);
            Assert.AreEqual(generalLedgers[0].Code, "0090");
        }

        [TestMethod]
        public void Should_read_given_profit_loss()
        {
            var g = _profitLossInterface.GetByName("4000");
            List<GeneralLedger> generalLedgers = new List<GeneralLedger>();
            foreach (var x in g)
            {
                var generalLedger = _profitLossInterface.Read(x.Code);
                generalLedgers.Add(generalLedger);
            }
            Assert.IsNotNull(generalLedgers);
            Assert.AreEqual(generalLedgers[0].Code, "4000");
        }

        [TestMethod]
        public void Should_find_all_balance_sheet_summaries()
        {
            var gen = _balanceSheetInterface.GetSummaries();
            Assert.IsNotNull(gen);
        }

        [TestMethod]
        public void Should_find_all_profit_loss_summaries()
        {
            var gen = _profitLossInterface.GetSummaries();
            Assert.IsNotNull(gen);
        }

        [TestMethod]
        public void Should_fail_to_create_empty_general_ledger()
        {
            try
            {
                _balanceSheetInterface.Create(new BalanceSheet());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Should_fail_to_delete_with_empty_general_ledger()
        {
            try
            {
                _balanceSheetInterface.Delete(new BalanceSheet());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Should_fail_to_activate_with_empty_general_ledger()
        {
            try
            {
                _balanceSheetInterface.Activate(new BalanceSheet());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.IsTrue(true);
            }
        }
    }
}
