using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.CostCenters;

namespace DemoConnector.TwinfieldAPI.Handlers.CostCenters
{
    public class CreateCostCenterCommand
    {
        public CostCenter CostCenter { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("dimension");
            createElement.AppendNewElement("office").InnerText = CostCenter.Office;
            createElement.AppendNewElement("type").InnerText = "KPL";
            createElement.AppendNewElement("name").InnerText = CostCenter.Name;
            createElement.AppendNewElement("code").InnerText = CostCenter.Code;
            createElement.AppendNewElement("shortname").InnerText = CostCenter.Shortname;
            createElement.AppendNewElement("website").InnerText = CostCenter.Website;
            createElement.AppendNewElement("vatnumber").InnerText = CostCenter.Vatnumber;
            createElement.AppendNewElement("cocnumber").InnerText = CostCenter.Cocnumber;
            createElement.AppendNewElement("editdimensionname").InnerText = CostCenter.Editdimensionname;
            return command;
        }
    }
}
