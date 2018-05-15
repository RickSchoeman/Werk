using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Projects;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Projects
{
    public class ProjectService
    {
        private readonly Session session;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public ProjectService(Session session) : this(session, new ClientFactory())
        {

        }

        public ProjectService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            processXml= new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<ProjectSummary> FindProjects(string pattern, string projectType, int field)
        {
            var query = new FinderService.Query
            {
                Type = projectType,
                Pattern = pattern,
                Field = field,
                MaxRows = 10,
                Options = new[] { new[] { "dimtype", "PRJ"}}
            };
            var searchResult = finderService.Search(query);
            return SearchResultToProjectSummaries(searchResult);
        }

        private static List<ProjectSummary> SearchResultToProjectSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<ProjectSummary>();
            }

            return searchResult.Items.Select(item => new ProjectSummary {Code = item[0], Name = item[1]}).ToList();
        }

        public Project ReadProject(string projectCode)
        {
            var command = new ReadProjectCommand
            {
                Office = session.Office,
                Dimtype = "PRJ",
                ProjectCode = projectCode
            };
            var response = processXml.Process(command.ToXml());
            return Project.FromXml(response);
        }

        public void CreateProject(Project project)
        {
            var command = new CreateProjectCommand
            {
                Project = project
            };
            processXml.Process(command.ToXml());
        }

        public void DeleteProject(Project project)
        {
            var command = new DeleteProjectCommand
            {
                Project = project
            };
            processXml.Process(command.ToXml());
        }

        public void ActivateProject(Project project)
        {
            var command = new ActivateProjectCommand
            {
                Project = project
            };
            processXml.Process(command.ToXml());
        }
        private bool WriteProject(Project project)
        {
            var response = processXml.Process(project.ToXml());
            return response.IsSuccess();
        }
    }
}
