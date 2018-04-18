using System.Collections.Generic;
using System.Linq;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Services;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Customers;
using DemoConnector.TwinfieldFinderService;

namespace DemoConnector.TwinfieldAPI.Handlers.Customers
{
    public class CustomerService
    {
        private readonly Session sesion;
        private readonly ProcessXmlService processXml;
        private readonly FinderService finderService;

        public CustomerService(Session session) : this(session, new ClientFactory())
        {

        }

        public CustomerService(Session session, IClientFactory clientFactory)
        {
            this.sesion = session;
            processXml = new ProcessXmlService(session, clientFactory);
            finderService = new FinderService(session, clientFactory);
        }

        public List<CustomerSummary> FindCustomers(string pattern, string customerType, int field)
        {
            var query = new FinderService.Query
            {
                Type = "DIM",
                Pattern = pattern,
                Field = field,
                Options = new []{new []{"dimtype", customerType}}
            };
            var searchResult = finderService.Search(query);
            return SearchResultToCustomerSummaries(searchResult);
        }

        private static List<CustomerSummary> SearchResultToCustomerSummaries(FinderData searchResult)
        {
            if (searchResult.Items == null)
            {
                return new List<CustomerSummary>();
            }

            return searchResult.Items.Select(item => new CustomerSummary {Code = item[0], Name = item[1]}).ToList();
        }

        public Customer ReadCustomer(string customerType, string customerCode)
        {
            var command = new ReadCustomerCommandcs
            {
                Office = sesion.Office,
                CustomerType = customerType,
                CustomerCode = customerCode
            };
            var response = processXml.Process(command.ToXml());
            return Customer.FromXml(response);
        }

        public void CreateCustomer(Customer customer)
        {
            var command = new CreateCustomerCommand
            {
                Customer = customer
            };
            processXml.Process(command.ToXml());
        }

        public void DeleteCustomer(Customer customer)
        {
            var command = new DeleteCustomerCommand
            {
                Customer = customer
            };
            processXml.Process(command.ToXml());
        }

        public void DeletePostingRule(Customer customer)
        {
            var command = new DeletePostingRuleCommand
            {
                Customer = customer
            };
            processXml.Process(command.ToXml());
        }

        public void ActivateCustomer(Customer customer)
        {
            var command = new ActivateCustomerCommand
            {
                Customer = customer
            };
            processXml.Process(command.ToXml());
        }
    }
}
