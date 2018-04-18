using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.Services;
using TwinfieldApi.TwinfieldFinderService;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Users
{
    public class UserService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public UserService(Session session) : this(session, new ClientFactory())
        {

        }

        public UserService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<UserSummary> FindUsers(string pattern, string userType, int field)
        {
            var query = new FinderService.Query
            {
                Type = "USR",
                Pattern = pattern,
                Field = field,
                MaxRows = 10
            };
            var searchResult = finderService.Search(query);
            return SearchResultToUserSummaries(searchResult);
        }

        private static List<UserSummary> SearchResultToUserSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<UserSummary>();
            }

            return searchResult.Items.Select(item => new UserSummary {Code = item[0], Name = item[1]}).ToList();
        }

        public User ReadUser(string userCode)
        {
            var command = new ReadUserCommand
            {
                UserCode = userCode
            };
            var response = processXml.Process(command.ToXml());
            return User.FromXml(response);
        }

        public void CreateUser(User user)
        {
            var command = new CreateUserCommand
            {
                User = user
            };
            processXml.Process(command.ToXml());
        }

        public void DeleteUser(User user)
        {
            var command = new DeleteUserCommand
            {
                User = user
            };
            processXml.Process(command.ToXml());
        }

        public void ActivateUser(User user)
        {
            var command = new ActivateUserCommand
            {
                User = user
            };
            processXml.Process(command.ToXml());
        }

        public bool WriteUser(User user)
        {
            var response = processXml.Process(user.ToXml());
            return response.IsSuccess();
        }
    }
}
