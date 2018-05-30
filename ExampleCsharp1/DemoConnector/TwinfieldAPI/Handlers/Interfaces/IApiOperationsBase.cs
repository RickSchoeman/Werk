using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Data.Dimensions;

namespace DemoConnector.TwinfieldAPI.Handlers.Interfaces
{
    public interface IApiOperationsBase<T> where T : class
    {
        List<T> GetByName(string name);
        List<T> GetAll();
        T Read(string code);
        List<DimensionSummary> GetSummaries();
        string Create(T obj);
        string Delete(T obj);
        string Activate(T obj);
    }
}
