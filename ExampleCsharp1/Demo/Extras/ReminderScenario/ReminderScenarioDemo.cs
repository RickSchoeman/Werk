using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Extras.ReminderScenarios;

namespace Demo.Extras.ReminderScenario
{
    class ReminderScenarioDemo
    {
        private const string ReminderScenarioType = "RMD";
        private readonly ReminderScenarioService reminderScenarioService;

        public ReminderScenarioDemo(Session session)
        {
            reminderScenarioService = new ReminderScenarioService(session);
        }

        public void Run()
        {
            if (!FindReminderScenarios())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindReminderScenarios()
        {
            Console.WriteLine("Searching reminder scenarios");
            const int searchField = 0;
            var reminderScenarios =
                reminderScenarioService.FinReminderScenarios("*", ReminderScenarioType, searchField);
            DisplayReminderScenarioSummaries(reminderScenarios);
            if (reminderScenarios.Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void DisplayReminderScenarioSummaries(IEnumerable<ReminderScenarioSummary> reminderScenarios)
        {
            foreach (var r in reminderScenarios)
            {
                Console.WriteLine("{0,-16} {1}", r.Code, r.Name);
            }
            Console.WriteLine();
        }
    }
}
