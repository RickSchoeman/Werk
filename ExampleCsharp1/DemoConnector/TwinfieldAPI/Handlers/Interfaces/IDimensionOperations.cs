using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConnector.TwinfieldAPI.Handlers.Interfaces
{
    public interface IDimensionOperations
    {
        List<object> GetByName(string name, string type);
        List<object> GetAll(string type);
        object Read(string type, string code);
        string Create(object obj);
        string Delete(object obj);
        string Activate(object obj);
    }
}
