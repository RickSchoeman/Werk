using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConnector.TwinfieldAPI;

namespace DemoConnector
{
    class Program
    {
        private static void Main(string[] args)
        {
            var apiConnector = new TwinfieldApiConnector();
            apiConnector.TestConnection("https://login.twinfield.com", "API000110", "SforSoftware12", "TWINAPPS", "NLA000218");
            WaitForUser();
        }

        private static void WaitForUser()
        {
            Console.WriteLine("Prss any key to close");
            Console.ReadKey();
        }
    }
}
