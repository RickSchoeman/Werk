using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Extras.InvoiceTypes;

namespace Demo.Extras.InvoiceType
{
    class InvoiceTypeDemo
    {
        private const string InvoiceTypeType = "INV";
        private readonly InvoiceTypeService invoiceTypeService;

        public InvoiceTypeDemo(Session session)
        {
            invoiceTypeService = new InvoiceTypeService(session);
        }

        public void Run()
        {
            if (!FindInvoiceTypes())
            {
                return;
            }
            Console.WriteLine();
        }

        public List<InvoiceTypeSummary> GetInvoiceTypeSummaries()
        {
            const int searchField = 0;
            var invoiceTypes = invoiceTypeService.FindInvoiceTypes("*", InvoiceTypeType, searchField);
            return invoiceTypes;
        }

        private bool FindInvoiceTypes()
        {
            Console.WriteLine("Searching invoice types");
            const int searchField = 0;
            var invoiceTypes = invoiceTypeService.FindInvoiceTypes("*", InvoiceTypeType, searchField);
            DisplayInvoiceTypeSummaries(invoiceTypes);
            if (invoiceTypes.Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void DisplayInvoiceTypeSummaries(IEnumerable<InvoiceTypeSummary> invoiceTypes)
        {
            foreach (var i in invoiceTypes)
            {
                Console.WriteLine("{0,-16} {1}", i.Code, i.Name);
            }
            Console.WriteLine();
        }
    }
}
