using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Projects;

namespace Demo
{
    class ProjectDemo
    {
        private const string ProjectType = "DIM";
        private readonly ProjectService projectService;
        private readonly Session session;
        private ProjectSummary projectSummary;
        private Project project;
        private IEnumerable<ProjectSummary> projects;

        public ProjectDemo(Session session)
        {
            this.session = session;
            projectService = new ProjectService(session);
        }

        public void Run()
        {
            var quantities = new List<Quantity>();
            var quantity = new Quantity
            {
                Label = "KM",
                Rate = "KM",
                Billable = "false",
                Mandatory = "false"
            };
            quantities.Add(quantity);
            var project = new Project
            {
                Office = session.Office,
                Code = "P0100",
                Type = "PRJ",
                Name = "test",
                Shortname = "test",
                Projects = new Projects
                {
                    Invoicedescription = "test documentation",
                    Authoriser = "SUPER",
                    Customer = "1002",
                    Billable = "true",
                    Rate = "T001",
                    Quantities = new Quantities
                    {
                        Quantity = quantities
                    }

                }
            };
            projectService.CreateProject(project);

            var delProject = new Project
            {
                Office = session.Office,
                Type = "PRJ",
                Code = "P0100"
            };
            projectService.DeleteProject(delProject);

            if (!FindProjects())
            {
                return;
            }

            if (!ReadProjectDetails())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindProjects()
        {
            Console.WriteLine("Searching for projects");

            const int searchField = 0;
            var projects = projectService.FindProjects("*", ProjectType, searchField);
            DisplayProjectSummaries(projects);

            if (projects.Count < 1)
            {
                return false;
            }
            else
            {
                this.projects = projects;
                projectSummary = projects.First();
                return true;
            }
        }

        private bool ReadProjectDetails()
        {
            Console.WriteLine("Read project details");

            foreach (var p in projects)
            {
                project = projectService.ReadProject(p.Code);
                if (projectSummary == null)
                {
                    Console.WriteLine("Project {0} not found.", project.Code);
                    return false;
                }

                DisplayProjectDetails(project);
            }

            return true;
        }

        private static void DisplayProjectSummaries(IEnumerable<ProjectSummary> projects)
        {
            foreach (var project in projects)
            {
                Console.WriteLine("{0, -16} {1}", project.Code, project.Name);
            }
            Console.WriteLine();
        }

        private static void DisplayProjectDetails(Project project)
        {
            Console.WriteLine("------");
            Console.WriteLine("Project details of {0}", project.Name);
            Console.WriteLine("office = {0}", project.Office);
            Console.WriteLine("type = {0}", project.Type);
            Console.WriteLine("code = {0}", project.Code);
            Console.WriteLine("name = {0}", project.Name);
            Console.WriteLine("shortname = {0}", project.Shortname);
            Console.WriteLine("------");
            Console.WriteLine("Projects:");
            Console.WriteLine("invoicedescription = {0}", project.Projects.Invoicedescription);
            Console.WriteLine("authoriser = {0}", project.Projects.Authoriser);
            Console.WriteLine("customer = {0}", project.Projects.Customer);
            Console.WriteLine("billable = {0}", project.Projects.Billable);
            Console.WriteLine("rate = {0}", project.Projects.Rate);
            for (int i = 0; i < project.Projects.Quantities.Quantity.Count; i++)
            {
                if (!project.Projects.Quantities.Quantity[i].Equals(null) || project.Projects.Quantities.Quantity[i] != null || !project.Projects.Quantities.Quantity[i].Label.Equals("") || project.Projects.Quantities.Quantity[i].Label != "")
                {
                    var quantity = project.Projects.Quantities.Quantity[i];
                    Console.WriteLine("------");
                    Console.WriteLine("Quantity: " + (i + 1));
                    Console.WriteLine("label = {0}", quantity.Label);
                    Console.WriteLine("rate = {0}", quantity.Rate);
                    Console.WriteLine("billable = {0}", quantity.Billable);
                    Console.WriteLine("mandatory = {0}", quantity.Mandatory);
                    Console.WriteLine("------");
                }
            }
            Console.WriteLine("validfrom = {0}", project.Projects.Validfrom);
            Console.WriteLine("validtill = {0}", project.Projects.Validtill);
            Console.WriteLine("------");
            Console.WriteLine("uid = {0}", project.Uid);
            Console.WriteLine("inuse = {0}", project.Inuse);
            Console.WriteLine("behaviour = {0}", project.Behaviour);
            Console.WriteLine("touched = {0}", project.Touched);
            Console.WriteLine("------");
            Console.WriteLine("Financials:");
            Console.WriteLine("vatcode = {0}", project.Financials.Vatcode);
            Console.WriteLine("------");
            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}
