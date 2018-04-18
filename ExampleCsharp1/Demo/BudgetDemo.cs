using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Budget;

namespace Demo
{
    class BudgetDemo
    {
        private readonly BudgetService budgetService;

        public BudgetDemo(Session session)
        {
            budgetService = new BudgetService(session);
        }

        public void Run()
        {
            Console.WriteLine("Read budget");
            var budget = budgetService.FindBudgetByCostCenter("001", 2018, 1);
            if (budget == null)
            {
                Console.WriteLine("Budget not found.");
            }
            else
            {
                Console.WriteLine("Budget found");
                Console.WriteLine("\tyear = {0}", budget.Year);
                Console.WriteLine("\tperiod = {0}", budget.Period);
                Console.WriteLine("\tdm1 = {0}", budget.Dim1);
                Console.WriteLine("\tgroup1 = {0}", budget.Group1);
                Console.WriteLine("\tgroup2 = {0}", budget.Group2);
                Console.WriteLine("\tgroup3 = {0}", budget.Group3);
                Console.WriteLine("\tdim2 = {0}", budget.Dim2);
                Console.WriteLine("\tdim3 = {0}", budget.Dim3);
                Console.WriteLine("\tactualdebit = {0}", budget.ActualDebit);
                Console.WriteLine("\tactualcredit = {0}", budget.ActualCredit);
                Console.WriteLine("\tactualtotal = {0}", budget.ActualTotal);
                Console.WriteLine("\tbudgetdebit = {0}", budget.BudgetDebit);
                Console.WriteLine("\tbudgetcredit = {0}",budget.BudgetCredit);
                Console.WriteLine("\tbudgettotal = {0}", budget.BudgetTotal);
            }
            Console.WriteLine();
        }
    }
}
