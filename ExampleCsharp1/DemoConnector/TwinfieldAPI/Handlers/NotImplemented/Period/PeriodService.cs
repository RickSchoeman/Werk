using System;
using System.ServiceModel;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.Period;
using DemoConnector.TwinfieldPeriodService;

namespace DemoConnector.TwinfieldAPI.Handlers.NotImplemented.Period
{
    public class PeriodService
    {
        private readonly Session session;
        private readonly IClientFactory clientFactory;

        public PeriodService(Session session) : this(session, new ClientFactory())
        {

        }

        public PeriodService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            this.clientFactory = clientFactory;
        }

        public Periods FindPeriods(int year)
        {
            var queryResult = QueryP(new GetPeriods {Year = year});
            return Periods.FromQueryResult(queryResult);
        }

        private QueryResult QueryP(GetPeriods query)
        {
            var periodsClient = clientFactory.CreatePeriodServiceClient(session.ClusterUrl);
            return periodsClient.Query(session.SessionId, query);
        }

        public Years FindYears()
        {
            var queryResult = QueryY(new GetYears());
            return Years.FromQueryResult(queryResult);
        }

        private QueryResult QueryY(GetYears query)
        {
            var periodsClient = clientFactory.CreatePeriodServiceClient(session.ClusterUrl);
            return periodsClient.Query(session.SessionId, query);
        }

        public void CreateYear(int numberOfPeriods)
        {
            try
            {
                var cmd = new CommandRequest()
                {
                    SessionId = session.SessionId,
                    Command = new CreateYear
                    {
                        NumberOfPeriods = numberOfPeriods
                    }
                };
                var periodClient = clientFactory.CreatePeriodServiceClient(session.ClusterUrl);
                periodClient.Process(session.SessionId, cmd.Command);
            }
            catch (FaultException<PeriodServiceFault> e)
            {
                Console.WriteLine("Failed to create year:");
                Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        public void ChangeEndDate(int year, int periodNumber, DateTime endDate)
        {
            try
            {
                var cmd = new CommandRequest()
                {
                    SessionId = session.SessionId,
                    Command = new ChangeEndDate
                    {
                        Year = year,
                        PeriodNumber = periodNumber,
                        EndDate = endDate
                    }
                };
                var periodClient = clientFactory.CreatePeriodServiceClient(session.ClusterUrl);
                periodClient.Process(session.SessionId, cmd.Command);
            }
            catch (FaultException<PeriodServiceFault> e)
            {
                Console.WriteLine("Failed to update period enddate:");
                Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        public void ChangeName(int year, int periodNumber, string name)
        {
            try
            {
                var cmd = new CommandRequest()
                {
                    SessionId = session.SessionId,
                    Command = new ChangeName
                    {
                        Year = year,
                        PeriodNumber = periodNumber,
                        Name = name
                    }
                };
                var periodClient = clientFactory.CreatePeriodServiceClient(session.ClusterUrl);
                periodClient.Process(session.SessionId, cmd.Command);
            }
            catch (FaultException<PeriodServiceFault> e)
            {
                Console.WriteLine("Failed to updatte period name:");
                Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        public void OpenPeriod(int year, int periodNumber)
        {
            try
            {
                var cmd = new CommandRequest()
                {
                    SessionId = session.SessionId,
                    Command = new OpenPeriod
                    {
                        Year = year,
                        PeriodNumber = periodNumber
                    }
                };
                var periodClient = clientFactory.CreatePeriodServiceClient(session.ClusterUrl);
                periodClient.Process(session.SessionId, cmd.Command);
            }
            catch (FaultException<PeriodServiceFault> e)
            {
                Console.WriteLine("Failed to open period:");
                Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        public void ClosePeriod(int year, int periodNumber)
        {
            try
            {
                var cmd = new CommandRequest()
                {
                    SessionId = session.SessionId,
                    Command = new ClosePeriod
                    {
                        Year = year,
                        PeriodNumber = periodNumber
                    }
                };
                var periodClient = clientFactory.CreatePeriodServiceClient(session.ClusterUrl);
                periodClient.Process(session.SessionId, cmd.Command);
            }
            catch (FaultException<PeriodServiceFault> e)
            {
                Console.WriteLine("Failed to close period:");
                Console.WriteLine("Code: {0}");
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        public void ResetYears(int newYear, int newNumberOfPeriods)
        {
            try
            {
                var cmd = new CommandRequest()
                {
                    SessionId = session.SessionId,
                    Command = new ResetYears
                    {
                        NewYear = newYear,
                        NewNumberOfPeriods = newNumberOfPeriods
                    }
                };
                var periodClient = clientFactory.CreatePeriodServiceClient(session.ClusterUrl);
                periodClient.Process(session.SessionId, cmd.Command);
            }
            catch (FaultException<PeriodServiceFault> e)
            {
                Console.WriteLine("Failed to reset years:");
                Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        public void DeleteYear(int year)
        {
            try
            {
                var cmd = new CommandRequest()
                {
                    SessionId = session.SessionId,
                    Command = new DeleteYear
                    {
                        Year = year
                    }
                };
                var periodClient = clientFactory.CreatePeriodServiceClient(session.ClusterUrl);
                periodClient.Process(session.SessionId, cmd.Command);
            }
            catch (FaultException<PeriodServiceFault> e)
            {
                Console.WriteLine("Failed to delete year:");
                Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
            }
        }
    }
}
