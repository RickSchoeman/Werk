using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;

namespace TwinfieldApi.Extras.VAT
{
    public class VatNrOfRelationsService
    {
        private readonly FinderService finderService;

        public VatNrOfRelationsService(Session session) : this(session, new ClientFactory())
        {

        }

        public VatNrOfRelationsService(Session session, IClientFactory clientFactory)
        {
            finderService = new FinderService(session);
        }

        public List<VatNrOfRelationsSummary> FindVatNrOfRelations(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = type,
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToNrOfRelationsSummaries(searchResult);
        }

        private static List<VatNrOfRelationsSummary> SearchResultToNrOfRelationsSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<VatNrOfRelationsSummary>();
            }

            return searchResult.Items.Select(item => new VatNrOfRelationsSummary
            {
                Code = item[0],
                Name = item[1],
                Country = item[2],
                VatNumber = item[3],
                RelationCompany = item[4],
                City = item[5]
            }).ToList();
        }
    }
}
