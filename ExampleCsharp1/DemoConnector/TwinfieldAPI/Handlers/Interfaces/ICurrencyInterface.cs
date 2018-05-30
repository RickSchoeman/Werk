using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI.Data.Currencies;

namespace DemoConnector.TwinfieldAPI.Handlers.Interfaces
{
    public interface ICurrencyInterface
    {
        List<Currency> GetByName(string name);
        List<Currency> GetAll();
        bool Create(Currency currency);
        bool Delete(Currency currency);
        bool DeleteCurrencyRate(Currency currency);
    }
}
