using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.TwinfieldBudgetService;

namespace TwinfieldApi.Budget
{
    public class Budget
    {
        public int Year { get; set; }
        public int Period { get; set; }
        public string Dim1 { get; set; }
        public string Group1 { get; set; }
        public string Group2 { get; set; }
        public string Group3 { get; set; }
        public string Dim2 { get; set; }
        public string Dim3 { get; set; }
        public decimal ActualDebit { get; set; }
        public decimal ActualCredit { get; set; }
        public decimal ActualTotal { get; set; }
        public decimal BudgetDebit { get; set; }
        public decimal BudgetCredit { get; set; }
        public decimal BudgetTotal { get; set; }

        public static Budget FromQueryResult(QueryResult queryResult)
        {
            var result = queryResult as GetBudgetTotalResult;
            if (result == null)
            {
                return null;
            }
            return new Budget
            {
                Year = result.Year,
                Period = result.Period,
                Dim1 = result.Dim1,
                Group1 = result.Group1,
                Group2 = result.Group2,
                Group3 = result.Group3,
                Dim2 = result.Dim2,
                Dim3 = result.Dim3,
                ActualDebit = result.ActualDebit,
                ActualCredit = result.ActualCredit,
                ActualTotal = result.ActualTotal,
                BudgetDebit = result.BudgetDebit,
                BudgetCredit = result.BudgetCredit,
                BudgetTotal = result.BudgetTotal
            };
        }
    }
    
}
