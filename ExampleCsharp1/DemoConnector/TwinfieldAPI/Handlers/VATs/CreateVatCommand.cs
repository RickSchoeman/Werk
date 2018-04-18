using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.VATs;

namespace DemoConnector.TwinfieldAPI.Handlers.VATs
{
    public class CreateVatCommand
    {
        public Vat Vat { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("vat");
            createElement.AppendNewElement("code").InnerText = Vat.Code;
            createElement.AppendNewElement("name").InnerText = Vat.Name;
            createElement.AppendNewElement("shortname").InnerText = Vat.Shortname;
            createElement.AppendNewElement("type").InnerText = Vat.Type;
            var p1 = createElement.AppendNewElement("percentages");
            for (int i = 0; i < Vat.Percentages.Percentage.Count; i++)
            {
                if (!Vat.Percentages.Percentage[i].Equals(null) || Vat.Percentages.Percentage[i] != null || !Vat.Percentages.Percentage[i].Name.Equals("") || Vat.Percentages.Percentage[i].Name != "")
                {
                    var percentage = Vat.Percentages.Percentage[i];
                    var p2 = p1.AppendNewElement("percentage");
                    p2.SetAttribute("id", (i + 1).ToString());
                    p2.AppendNewElement("date").InnerText = percentage.Date;
                    p2.AppendNewElement("percentage").InnerText = percentage.percentage;
                    p2.AppendNewElement("name").InnerText = percentage.Name;
                    p2.AppendNewElement("shortname").InnerText = percentage.Shortname;
                    var a1 = p2.AppendNewElement("accounts");
                    for (int j = 0; j < percentage.Accounts.Account.Count; j++)
                    {
                        if (!percentage.Accounts.Account[j].Equals(null) || percentage.Accounts.Account[j] != null || !percentage.Accounts.Account[j].Dim1.Equals("") || percentage.Accounts.Account[j].Dim1 != "")
                        {
                            var account = percentage.Accounts.Account[j];
                            var a2 = a1.AppendNewElement("account");
                            a2.SetAttribute("id", (i + 1).ToString());
                            a2.AppendNewElement("dim1").InnerText = account.Dim1;
                            a2.AppendNewElement("groupcountry").InnerText = account.Groupcountry;
                            a2.AppendNewElement("group").InnerText = account.Group;
                            a2.AppendNewElement("percentage").InnerText = account.Percentage;
                            a2.AppendNewElement("linetype").InnerText = account.Linetype;
                        }
                    }
                }
            }
            return command;
        }
    }
}
