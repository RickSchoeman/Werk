using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.Summaries;

namespace DemoConnector.TwinfieldAPI.Handlers.Interfaces
{
    public interface IApiSummaryBase
    {
        List<Summary> GetByName(string name);
        List<Summary> GetAll();
    }
}
