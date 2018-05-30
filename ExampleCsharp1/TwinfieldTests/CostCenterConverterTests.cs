using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Converters;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.CostCenters;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApplicatie;
using TestApplicatie.Interfaces;

namespace TwinfieldTests
{
    [TestClass]
    public class CostCenterConverterTests
    {
        private ICostCenterConverter _costCenterConverter;
        private IApiOperationsBase<CostCenter> _costCenterInterface;
        private IMiddlewareData _middlewareData;
        private Session _session;

        [TestInitialize]
        public void Initialize()
        {
            _middlewareData = new MiddlewareData();
            _costCenterConverter = new CostCenterConverter();
            _session = Utilities.CreateValidSession();
            _costCenterInterface = new CostCenterOperatons(_session);
        }

        [TestMethod]
        public void Should_convert_cost_center_response_to_cost_center()
        {
            var costCenter =
                _costCenterConverter.ConvertCostCenterResponse(_middlewareData.GetCostCenterData(), _session.Office);
            Assert.IsNotNull(costCenter);
        }

        [TestMethod]
        public void Should_convert_cost_center_to_cost_center_response()
        {
            var costCenter = _costCenterInterface.GetByName("00000");
            var costCenterResponse = _costCenterConverter.ConvertCostCenter(costCenter[0]);
            Assert.IsNotNull(costCenterResponse);
        }
    }
}
