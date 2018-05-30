using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Converters;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.BalanceSheet;
using DemoConnector.TwinfieldAPI.Data.ProfitLoss;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApplicatie;
using TestApplicatie.Interfaces;

namespace TwinfieldTests
{
    [TestClass]
    public class GeneralLedgerConverterTests
    {
        private IMiddlewareData _middlewareData;
        private IApiOperationsBase<BalanceSheet> _balanceSheetInterface;
        private IApiOperationsBase<ProfitLoss> _profitLossInterface;
        private IGeneralLedgerConverter _generalLedgerConverter;
        private Session _session;

        [TestInitialize]
        public void Initialize()
        {
            _middlewareData = new MiddlewareData();
            _generalLedgerConverter = new GeneralLedgerConverter();
            _session = Utilities.CreateValidSession();
            _balanceSheetInterface = new BalanceSheetOperations(_session);
            _profitLossInterface = new ProfitLossOperations(_session);
        }

        [TestMethod]
        public void Should_convert_general_ledger_response_to_general_ledger()
        {
            var generalLedger =
                _generalLedgerConverter.ConvertGeneralLedgerResponseToBalanceSheet(_middlewareData.GetGeneralLedgerData(),
                    _session.Office);
            Assert.IsNotNull(generalLedger);
        }

        [TestMethod]
        public void Should_convert_balance_sheet_to_general_ledger_response()
        {
            var generalLedger = _balanceSheetInterface.GetByName("0090");
            var generalLedgerResponse = _generalLedgerConverter.ConvertBalanceSheet(generalLedger[0]);
            Assert.IsNotNull(generalLedgerResponse);
        }

        [TestMethod]
        public void Should_convert_profit_loss_to_general_ledger_response()
        {
            var generalLedger = _profitLossInterface.GetByName("4000");
            var generalLedgerResponse = _generalLedgerConverter.ConvertProfitLoss(generalLedger[0]);
            Assert.IsNotNull(generalLedgerResponse);
        }
    }
}
