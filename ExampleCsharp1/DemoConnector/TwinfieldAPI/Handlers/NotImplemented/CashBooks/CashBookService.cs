using System;
using System.ServiceModel;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.CashBooks;
using DemoConnector.TwinfieldCashBookService;

namespace DemoConnector.TwinfieldAPI.Handlers.NotImplemented.CashBooks
{
    public class CashBookService
    {
        private readonly Session session;
        private readonly IClientFactory clientFactory;

        public CashBookService(Session session) : this(session, new ClientFactory())
        {

        }

        public CashBookService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            this.clientFactory = clientFactory;
        }

        public CashBook FindCashBook(string code)
        {
            var queryResult = Query(new GetCashBook {Code = code});
            return CashBook.FromQueryResult(code, queryResult);
        }

        private QueryResult Query(GetCashBook query)
        {
            var cashBookClient = clientFactory.CreateCashBookClient(session.ClusterUrl);
            return cashBookClient.Query(session.SessionId, query);
        }

        public void CreateCashBook(string code, string name, string generalLedgerAccount)
        {
            try
            {
                var req = new CommandRequest()
                            {
                                SessionId = session.SessionId,
                                Command = new CreateCashBook
                                {
                                    Code = code,
                                    Name = name,
                                    GeneralLedgerAccount = generalLedgerAccount
                                }
                            };
                var cashBookClient = clientFactory.CreateCashBookClient(session.ClusterUrl);
                cashBookClient.Process(session.SessionId, req.Command);
            }
            catch (FaultException<CashBookServiceFault> e)
            {
                Console.WriteLine("Failed to create the cash book:");
                Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
            }
            
        }

        public void ChangeCashBookName(string code, string name)
        {
            try
            {
                var cmd = new CommandRequest()
                {
                    SessionId = session.SessionId,
                    Command = new ChangeCashBookName
                    {
                        Code = code,
                        Name = name
                    }
                };
                var cashBookClient = clientFactory.CreateCashBookClient(session.ClusterUrl);
                cashBookClient.Process(session.SessionId, cmd.Command);
            }
            catch (FaultException<CashBookServiceFault> e)
            {
                Console.WriteLine("Failed to update cash book name:");
                Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        public void ChangeCashBookShortName(string code, string shortname)
        {
            try
            {
                var cmd = new CommandRequest()
                {
                    SessionId = session.SessionId,
                    Command = new ChangeCashBookShortName
                    {
                        Code = code,
                        ShortName = shortname
                    }
                };
                var cashBookClient = clientFactory.CreateCashBookClient(session.ClusterUrl);
                cashBookClient.Process(session.SessionId, cmd.Command);
            }
            catch (FaultException<CashBookServiceFault> e)
            {
                Console.WriteLine("Failed to update cash book shortname:");
                Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        public void ChangeCashBookGeneralLedgerAccount(string code, string generalLedgerAccount)
        {
            try
            {
                var cmd = new CommandRequest()
                {
                    SessionId = session.SessionId,
                    Command = new ChangeCashBookGeneralLedgerAccount
                    {
                        Code = code,
                        GeneralLedgerAccount = generalLedgerAccount
                    }
                };
                var cashBookClient = clientFactory.CreateCashBookClient(session.ClusterUrl);
                cashBookClient.Process(session.SessionId, cmd.Command);
            }
            catch (FaultException<CashBookServiceFault> e)
            {
                Console.WriteLine("Failed to update cash book general ledger account:");
                Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
            }
        }



    }
}
