using System;
using System.ServiceModel;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldTransactionBlockedValueService;

namespace DemoConnector.TwinfieldAPI.Handlers.TransactionBlockedValue
{
    public class TransactionBlockedValueService
    {
        private readonly Session session;
        private readonly IClientFactory clientFactory;

        public TransactionBlockedValueService(Session session) : this(session, new ClientFactory())
        {

        }

        public TransactionBlockedValueService(Session session, IClientFactory clientFactory)
        {
            this.session = session;
            this.clientFactory = clientFactory;
        }

        public void RegisterBlockedAmountForTransAction(string companyCode, string transactionCode,
            decimal transactionNumber, int transactionLineId, decimal blockedValue)
        {
            try
            {
                var cmd = new CommandRequest
                {
                    SessionId = session.SessionId,
                    Command = new RegisterBlockedAmountForTransaction
                    {
                        CompanyCode = companyCode,
                        TransactionCode = transactionCode,
                        TransactionNumber = transactionNumber,
                        TransactionLineId = transactionLineId,
                        BlockedValue = blockedValue
                    }
                };
                var transactionBlockedValueClient =
                    clientFactory.CreateTransactionBlockedValueClient(session.ClusterUrl);
                transactionBlockedValueClient.Process(session.SessionId, cmd.Command);
                Console.WriteLine("Blocked value successfully registered.");
            }
            catch (FaultException<TransactionBlockedValueServiceFault> e)
            {
                Console.WriteLine("Failed to register blocked value:");
                Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        public void UnregisterBlockedAmountForTransaction(string companyCode, string transactionCode,
            decimal transactionNumber, int transactionLineId)
        {
            try
            {
                var cmd = new CommandRequest
                {
                    SessionId = session.SessionId,
                    Command = new UnregisterBlockedAmountForTransaction
                    {
                        CompanyCode = companyCode,
                        TransactionCode = transactionCode,
                        TransactionNumber = transactionNumber,
                        TransactionLineId = transactionLineId
                    }
                };
                var transactionBlockedValueClient =
                    clientFactory.CreateTransactionBlockedValueClient(session.ClusterUrl);
                transactionBlockedValueClient.Process(session.SessionId, cmd.Command);
                Console.WriteLine("Blocked value successfully unregistered.");
            }
            catch (FaultException<TransactionBlockedValueServiceFault> e)
            {
                Console.WriteLine("Failed to unregister blocked value:");
                Console.WriteLine("Code: {0}", e.Code);
                Console.WriteLine("Message: {0}", e.Message);
            }
        }
    }
}
