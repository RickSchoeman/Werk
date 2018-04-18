using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Currencies
{
    public class CurrenciesService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public CurrenciesService(Session session) : this(session, new ClientFactory())
        {

        }

        public CurrenciesService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<CurrenciesSummary> FindCurrencies(string pattern, string currenciesType, int field)
        {
            var query = new FinderService.Query
            {
                Type = "CUR",
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToCurrenciesSummaries(searchResult);
        }

        private static List<CurrenciesSummary> SearchResultToCurrenciesSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<CurrenciesSummary>();
            }

            return searchResult.Items.Select(item => new CurrenciesSummary {Code = item[0], Name = item[1]}).ToList();
        }

        public Currency ReadCurrencies(string currenciesType, string currenciesCode)
        {
            var command = new ReadCurrenciesCommand
            {
                Office = session.Office,
                CurrenciesType = currenciesType,
                CurrenciesCode = currenciesCode
            };
            var response = processXml.Process(command.ToXml());
            return Currency.FromXml(response);
        }

        public void CreateCurrency(Currency currency)
        {
            var command = new CreateCurrencyCommand
            {
                Currency = currency
            };
            processXml.Process(command.ToXml());
        }

        public void DeleteCurrency(Currency currency)
        {
            var command = new DeleteCurrencyCommand
            {
                Currency = currency
            };
            processXml.Process(command.ToXml());
        }

        public void DeleteCurrencyRate(Currency currency)
        {
            var command = new DeleteCurrencyRateCommand
            {
                Currency = currency
            };
            processXml.Process(command.ToXml());
        }

        public bool WriteCurrencies(Currency currencies)
        {
            var response = processXml.Process(currencies.ToXml());
            return response.IsSuccess();
        }
    }
}
