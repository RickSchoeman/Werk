using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Data.DimensionTypes;

namespace DemoConnector.TwinfieldAPI.Handlers.Interfaces
{
    public interface IDimensionTypeInterface
    {
        List<DimensionType> GetByName(string name);
        List<DimensionType> GetAll();
        string Update(DimensionType dimensionType);
    }
}
