using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Activities;

namespace DemoConnector.TwinfieldAPI.Handlers.Activities
{
    public class CreateActivityCommand
    {
        public Activity Activity { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("dimension");
            createElement.AppendNewElement("office").InnerText = Activity.Office;
            createElement.AppendNewElement("type").InnerText = "ACT";
            createElement.AppendNewElement("code").InnerText = Activity.Code;
            createElement.AppendNewElement("name").InnerText = Activity.Name;
            createElement.AppendNewElement("shortname").InnerText = Activity.Shortname;
            createElement.AppendNewElement("behaviour").InnerText = Activity.Behaviour;
            var f1 = createElement.AppendNewElement("financials");
            f1.AppendNewElement("vatcode").InnerText = Activity.Financials.Vatcode;
            var p1 = createElement.AppendNewElement("projects");
            p1.AppendNewElement("validfrom").InnerText = Activity.Projects.Validfrom;
            p1.AppendNewElement("validtill").InnerText = Activity.Projects.Validtill;
            p1.AppendNewElement("invoicedescription").InnerText = Activity.Projects.Invoicedescription;
            p1.AppendNewElement("authoriser").InnerText = Activity.Projects.Authoriser;
            p1.AppendNewElement("customer").InnerText = Activity.Projects.Customer;
            p1.AppendNewElement("billable").InnerText = Activity.Projects.Billable;
            p1.AppendNewElement("rate").InnerText = Activity.Projects.Rate;
            var q1 = p1.AppendNewElement("quantities");
            for (int i = 0; i < Activity.Projects.Quantities.Quantity.Count; i++)
            {
                if (!Activity.Projects.Quantities.Quantity[i].Equals(null) || Activity.Projects.Quantities.Quantity[i] != null || !Activity.Projects.Quantities.Quantity[i].Label.Equals("") || Activity.Projects.Quantities.Quantity[i].Label != "")
                {
                    var quantity = Activity.Projects.Quantities.Quantity[i];
                    var q2 = q1.AppendNewElement("quantity");
                    q2.SetAttribute("id", (i + 1).ToString());
                    q2.AppendNewElement("label").InnerText = quantity.Label;
                    q2.AppendNewElement("rate").InnerText = quantity.Rate;
                    q2.AppendNewElement("billable").InnerText = quantity.Billable;
                    q2.AppendNewElement("mandatory").InnerText = quantity.Mandatory;
                }
            }

            return command;
        }
    }
}
