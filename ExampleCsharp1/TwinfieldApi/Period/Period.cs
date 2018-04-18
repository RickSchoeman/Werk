using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi.TwinfieldPeriodService;

namespace TwinfieldApi.Period
{
    public class Periods
    {
        public TwinfieldPeriodService.Period[] periods { get; set; }

        public static Periods FromQueryResult(QueryResult queryResult)
        {
            var result = queryResult as GetPeriodsResult;
            if (result == null)
            {
                return null;
            }

            return new Periods
            {
                periods = result.Periods
            };
        }
    }

    public class Years
    {
        public int[] years { get; set; }

        public static Years FromQueryResult(QueryResult queryResult)
        {
            var result = queryResult as GetYearsResult;
            if (result == null)
            {
                return null;
            }
            return new Years
            {
                years = result.Years
            };
        }
    }

}
