using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Data.CostCenters;

namespace DemoConnector.TwinfieldAPI.Converters.Interfaces
{
    public interface ICostCenterConverter
    {
        CostCenterResponse ConvertCostCenter(CostCenter costCenter);
        CostCenter ConvertCostCenterResponse(CostCenterResponse costCenterResponse, string office);
    }
}
