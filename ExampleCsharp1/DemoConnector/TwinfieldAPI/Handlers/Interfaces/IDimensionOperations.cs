using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Data.Dimensions;

namespace DemoConnector.TwinfieldAPI.Handlers.Interfaces
{
    public interface IDimensionOperations<T> where T : class
    {
        List<T> GetByName(string name, string type);
        List<DimensionSummary> GetSummaries(string type);
        List<T> GetAll(string type);
        T Read(string type, string code);
        string Create(T obj);
        string Delete(T obj);
        string Activate(T obj);
    }
}
