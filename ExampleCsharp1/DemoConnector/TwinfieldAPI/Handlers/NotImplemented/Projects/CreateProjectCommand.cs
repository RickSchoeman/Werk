using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.Projects;

namespace DemoConnector.TwinfieldAPI.Handlers.NotImplemented.Projects
{
    public class CreateProjectCommand
    {
        public Project Project { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("dimension");
            createElement.AppendNewElement("office").InnerText = Project.Office;
            createElement.AppendNewElement("type").InnerText = "PRJ";
            createElement.AppendNewElement("code").InnerText = Project.Code;
            createElement.AppendNewElement("name").InnerText = Project.Name;
            createElement.AppendNewElement("shortname").InnerText = Project.Shortname;
            var p1 = createElement.AppendNewElement("projects");
            p1.AppendNewElement("invoicedescription").InnerText = Project.Projects.Invoicedescription;
            p1.AppendNewElement("authoriser").InnerText = Project.Projects.Authoriser;
            p1.AppendNewElement("customer").InnerText = Project.Projects.Customer;
            p1.AppendNewElement("billable").InnerText = Project.Projects.Billable;
            p1.AppendNewElement("rate").InnerText = Project.Projects.Rate;
            var q1 = p1.AppendNewElement("quantities");
            for (int i = 0; i < Project.Projects.Quantities.Quantity.Count; i++)
            {
                if (!Project.Projects.Quantities.Quantity[i].Equals(null) || Project.Projects.Quantities.Quantity[i] != null || !Project.Projects.Quantities.Quantity[i].Label.Equals("") || Project.Projects.Quantities.Quantity[i].Label != "")
                {
                    var quantity = Project.Projects.Quantities.Quantity[i];
                    var q2 = q1.AppendNewElement("quantity");
                    q2.SetAttribute("id", i.ToString());
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
