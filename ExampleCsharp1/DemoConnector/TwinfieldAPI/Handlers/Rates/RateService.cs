using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Rates;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Rates
{
    public class RateService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public RateService(Session session) : this(session, new ClientFactory())
        {

        }

        public RateService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<RateSummary> FindRates(string pattern, string rateType, int field)
        {
            var query = new FinderService.Query
            {
                Type = "TRT",
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToRateSummaries(searchResult);
        }

        private static List<RateSummary> SearchResultToRateSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<RateSummary>();
            }

            return searchResult.Items.Select(item => new RateSummary {Code = item[0], Name = item[1]}).ToList();
        }

        public Rate ReadRate(string rateCode)
        {
            var command = new ReadRateCommand
            {
                Office = session.Office,
                RateCode = rateCode
            };
            var response = processXml.Process(command.ToXml());
            return Rate.FromXml(response);
        }

        public void CreateRate(Rate rate)
        {
            var command = new CreateRateCommand
            {
                Rate = rate
            };

            processXml.Process(command.ToXml());
        }

        public void DeleteRate(Rate rate)
        {
            var command = new DeleteRateCommand
            {
                Rate = rate
            };
            processXml.Process(command.ToXml());
        }

        public void ActivateRate(Rate rate)
        {
            var command = new ActivateRateCommand
            {
                Rate = rate
            };
            processXml.Process(command.ToXml());
        }

        public void DeleteRateChange(Rate rate)
        {
            var command = new DeleteRateChangeCommand
            {
                Rate = rate
            };
            processXml.Process(command.ToXml());
        }

        public bool WriteRate(Rate rate)
        {
            var response = processXml.Process(rate.ToXml());
            return response.IsSuccess();
        }
    }
}
