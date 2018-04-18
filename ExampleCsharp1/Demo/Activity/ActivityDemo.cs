using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Activities;

namespace Demo
{
    class ActivityDemo
    {
        private const string ActivityType = "ACT";
        private readonly ActivityService activityService;
        private readonly Session session;
        private ActivitySummary activitySummary;
        private Activity activity;
        private IEnumerable<ActivitySummary> activities;

        public ActivityDemo(Session session)
        {
            this.session = session;
            activityService = new ActivityService(session);
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
            var act = new Activity
            {
                Office = session.Office,
                Type = "ACT",
                Code = "A009",
                Name = "test",
                Shortname = "test",
                Behaviour = "normal",
                Financials = new Financials
                {
                    Vatcode = ""
                },
                Projects = new Projects
                {
                    Validfrom = "",
                    Validtill = "",
                    Invoicedescription = "test description",
                    Authoriser = "SUPER",
                    Customer = "1010",
                    Billable = "false",
                    Rate = "T001",
                    Quantities = new Quantities
                    {
                        Quantity = quantities
                    }
                }
            };
            activityService.CreateActivity(act);

            var delAct = new Activity
            {
                Type = "ACT",
                Code = "A009"
            };
            activityService.DeleteActivity(delAct);

            if (!FindActivities())
            {
                return;
            }

            if (!ReadActivityDetails())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindActivities()
        {
            Console.WriteLine("Searching activities");
            const int searchField = 2;
            var activities = activityService.FindActivities("*", ActivityType, searchField);
            DisplayActivitySummaries(activities);
            if (activities.Count < 1)
            {
                return false;
            }
            else
            {
                this.activities = activities;
                activitySummary = activities.First();
                return true;
            }
        }

        private bool ReadActivityDetails()
        {
            Console.WriteLine("Read activity details");
            foreach (var a in activities)
            {
                activity = activityService.ReadActivity(ActivityType, a.Code);
                if (activitySummary == null)
                {
                    Console.WriteLine("Activity {0} not found", activity.Code);
                    return false;
                }
                DisplayActivityDetails(activity);
            }

            return true;
        }

        private static void DisplayActivitySummaries(IEnumerable<ActivitySummary> activities)
        {
            foreach (var activity in activities)
            {
                Console.WriteLine("{0, -16} {1}", activity.Code, activity.Name);
            }
            Console.WriteLine();
        }

        private static void DisplayActivityDetails(Activity activity)
        {
            Console.WriteLine("------");
            Console.WriteLine("Activity details of {0}:", activity.Name);
            Console.WriteLine("office = {0}", activity.Office);
            Console.WriteLine("type = {0}", activity.Type);
            Console.WriteLine("code = {0}", activity.Code);
            Console.WriteLine("name = {0}", activity.Name);
            Console.WriteLine("shortname = {0}", activity.Shortname);
            Console.WriteLine("------");
            Console.WriteLine("Projects:");
            Console.WriteLine("invoicedescription = {0}", activity.Projects.Invoicedescription);
            Console.WriteLine("authoriser = {0}", activity.Projects.Authoriser);
            Console.WriteLine("customer = {0}", activity.Projects.Customer);
            Console.WriteLine("billable = {0}", activity.Projects.Billable);
            Console.WriteLine("rate = {0}", activity.Projects.Rate);
            Console.WriteLine("------");
            Console.WriteLine("Quantities:");
            for (int i = 0; i < activity.Projects.Quantities.Quantity.Count; i++)
            {
                if (!activity.Projects.Quantities.Quantity[i].Equals(null) || activity.Projects.Quantities.Quantity[i] != null || !activity.Projects.Quantities.Quantity[i].Label.Equals("") || activity.Projects.Quantities.Quantity[i].Label != "")
                {
                    var quantity = activity.Projects.Quantities.Quantity[i];
                    Console.WriteLine("------");
                    Console.WriteLine("Quantity: " + (i + 1));
                    Console.WriteLine("label = {0}", quantity.Label);
                    Console.WriteLine("rate = {0}", quantity.Rate);
                    Console.WriteLine("billable = {0}", quantity.Billable);
                    Console.WriteLine("mandatory = {0}", quantity.Mandatory);
                    Console.WriteLine("------");
                }
            }
            Console.WriteLine("------");
            Console.WriteLine("validfrom = {0}", activity.Projects.Validfrom);
            Console.WriteLine("validtill = {0}", activity.Projects.Validtill);
            Console.WriteLine("------");
            Console.WriteLine("uid = {0}", activity.Uid);
            Console.WriteLine("inuse = {0}", activity.Inuse);
            Console.WriteLine("behaviour = {0}", activity.Behaviour);
            Console.WriteLine("touched = {0}", activity.Touched);
            Console.WriteLine("------");
            Console.WriteLine("Financials:");
            Console.WriteLine("vatcode = {0}", activity.Financials.Vatcode);
            Console.WriteLine("------");
            Console.WriteLine();
        }
    }
}
