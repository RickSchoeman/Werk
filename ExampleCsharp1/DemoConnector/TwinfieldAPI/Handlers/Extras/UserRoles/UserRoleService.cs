using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Extras.UserRoles;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Extras.UserRoles
{
    public class UserRoleService
    {
        private readonly FinderService finderService;

        public UserRoleService(Session session) : this(session, new ClientFactory())
        {
            
        }

        public UserRoleService(Session session, IClientFactory clientFactory)
        {
            finderService = new FinderService(session, clientFactory);
        }

        public List<UserRoleSummary> FindUserRoles(string pattern, string type, int field)
        {
            var query = new FinderService.Query
            {
                Type = type,
                Pattern = pattern,
                Field = field
            };
            var searchResult = finderService.Search(query);
            return SearchResultToUserRoleSummaries(searchResult);
        }

        private static List<UserRoleSummary> SearchResultToUserRoleSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<UserRoleSummary>();
            }

            return searchResult.Items.Select(item => new UserRoleSummary {Code = item[0], Name = item[1]}).ToList();
        }
    }
}
