using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Data.CostCenters;

namespace DemoConnector.TwinfieldAPI.Handlers.Interfaces
{
    public interface ICostCenterInterface
    {
        List<CostCenter> GetByName(string name);
        List<CostCenter> GetAll();
        CostCenter Read(string code);
        string Create(CostCenter costCenter);
        string Delete(CostCenter costCenter);
        string Activate(CostCenter costCenter);
    }
}
