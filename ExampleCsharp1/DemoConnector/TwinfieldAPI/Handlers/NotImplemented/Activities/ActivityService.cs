using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.Activities;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.NotImplemented.Activities
{
    public class ActivityService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public ActivityService(Session session) : this(session, new ClientFactory())
        {

        }

        public ActivityService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<ActivitySummary> FindActivities(string pattern, string activityType, int field)
        {
            var query = new FinderService.Query
            {
                Type = "DIM",
                Pattern = pattern,
                Field = field,
                MaxRows = 10,
                Options = new []{new []{"dimtype", activityType}}
            };
            var searchResult = finderService.Search(query);
            return SearchResulttoActivitySummaries(searchResult);
        }

        private static List<ActivitySummary> SearchResulttoActivitySummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<ActivitySummary>();
            }

            return searchResult.Items.Select(item => new ActivitySummary {Code = item[0], Name = item[1]}).ToList();
        }

        public Activity ReadActivity(string activityType, string activityCode)
        {
            var command = new ReadActivityCommand
            {
                Office = session.Office,
                ActivityType = activityType,
                ActivityCode = activityCode
            };
            var response = processXml.Process(command.ToXml());
            return Activity.FromXml(response);
        }

        public void CreateActivity(Activity activity)
        {
            var command = new CreateActivityCommand
            {
                Activity = activity
            };
            processXml.Process(command.ToXml());
        }

        public void DeleteActivity(Activity activity)
        {
            var command = new DeleteActivityCommand
            {
                Activity = activity
            };
            processXml.Process(command.ToXml());
        }

        public void ActivateActivity(Activity activity)
        {
            var command = new ActivateActivityCommand
            {
                Activity = activity
            };
            processXml.Process(command.ToXml());
        }

        public bool WriteActivity(Activity activity)
        {
            var response = processXml.Process(activity.ToXml());
            return response.IsSuccess();
        }
    }
}
