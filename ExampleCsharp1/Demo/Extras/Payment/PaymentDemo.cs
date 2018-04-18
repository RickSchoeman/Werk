using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Extras.Payments;

namespace Demo.Extras.Payment
{
    public class PaymentDemo
    {
        private const string PaymentFileType = "FMT";
        private const string PaymentTypeType = "PAY";
        private readonly Session session;
        private readonly PaymentService paymentService;

        public PaymentDemo(Session session)
        {
            this.session = session;
            paymentService = new PaymentService(session);
        }

        public void Run()
        {
            if (!FindPaymentFiles())
            {
                return;
            }

            if (!FindPaymentTypes())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindPaymentFiles()
        {
            Console.WriteLine("Searching payment files");
            const int searchField = 0;
            var payments = paymentService.FindPayments("*", PaymentFileType, searchField);
            DisplayPaymentSummaries(payments);
            if (payments.Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool FindPaymentTypes()
        {
            Console.WriteLine("Searching payment types");
            const int searchField = 0;
            var payments = paymentService.FindPayments("*", PaymentTypeType, searchField);
            DisplayPaymentSummaries(payments);
            if (payments.Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void DisplayPaymentSummaries(IEnumerable<PaymentSummary> payments)
        {
            foreach (var payment in payments)
            {
                Console.WriteLine("{0,-16} {1}", payment.Code, payment.Name);
            }
            Console.WriteLine();
        }
    }
}
