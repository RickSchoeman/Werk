using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConnector.Middleware
{
    public class CostCenterResponse
    {
        private Bank _bank;

        public CostCenterResponse()
        {
            _bank = new Bank();
        }

        public string Code { get; set; }
        public string Name { get; set; }

        public Bank Bank
        {
            get { return _bank; }
        }
        public string Comment { get; set; }
        public string Website { get; set; }
    }
}
