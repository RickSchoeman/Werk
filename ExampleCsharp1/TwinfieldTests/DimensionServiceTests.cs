using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data.Customers;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Dimension;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TwinfieldTests
{
    [TestClass]
    public class DimensionServiceTests
    {
        private IDimensionOperations<Customer> _dimensionOperations;

        [TestInitialize]
        public void Initialize()
        {
            var session = Utilities.CreateValidSession();
            Console.WriteLine(session.SessionId);
            _dimensionOperations = new DimensionOperations<Customer>(session);
        }

        [TestMethod]
        public void Should_find_all_dimensions()
        {
            var dimensions = _dimensionOperations.GetByName("1000", "DEB");
            Console.WriteLine(dimensions.Count);
            Assert.IsNotNull(dimensions);
        }
    }
}
