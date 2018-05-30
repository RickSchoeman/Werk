using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data.CostCenters;

namespace DemoConnector.TwinfieldAPI.Converters
{
    public class CostCenterConverter : ICostCenterConverter
    {
        public CostCenterResponse ConvertCostCenter(CostCenter costCenter)
        {
            return new CostCenterResponse
            { 
                Code = costCenter.Code,
                Name = costCenter.Name,
                Website = costCenter.Website,
            };
        }

        public CostCenter ConvertCostCenterResponse(CostCenterResponse costCenterResponse, string office)
        {
            return new CostCenter
            {
                Office = office,
                Code = costCenterResponse.Code,
                Name = costCenterResponse.Name,
                Website = costCenterResponse.Website,
            };
        }
    }
}
