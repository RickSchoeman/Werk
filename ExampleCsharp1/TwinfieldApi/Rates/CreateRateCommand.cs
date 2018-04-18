using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Rates
{
    public class CreateRateCommand
    {
        public Rate Rate { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("projectrate");
            createElement.AppendNewElement("office").InnerText = Rate.Office;
            createElement.AppendNewElement("code").InnerText = Rate.Code;
            createElement.AppendNewElement("name").InnerText = Rate.Name;
            createElement.AppendNewElement("shortname").InnerText = Rate.Shortname;
            createElement.AppendNewElement("type").InnerText = Rate.Type;
            createElement.AppendNewElement("unit").InnerText = Rate.Unit;
            createElement.AppendNewElement("currency").InnerText = Rate.Currency;
            var r1 = createElement.AppendNewElement("ratechanges");
            for (int i = 0; i < Rate.Ratechanges.Ratechange.Count; i++)
            {
                if (!Rate.Ratechanges.Ratechange[i].Equals(null) || Rate.Ratechanges.Ratechange[i] != null || !Rate.Ratechanges.Ratechange[i].Begindate.Equals("") || Rate.Ratechanges.Ratechange[i].Begindate != "")
                {
                    var ratechange = Rate.Ratechanges.Ratechange[i];
                    var r2 = r1.AppendNewElement("ratechange");
                    r2.SetAttribute("id", (i + 1).ToString());
                    r2.AppendNewElement("begindate").InnerText = ratechange.Begindate;
                    r2.AppendNewElement("enddate").InnerText = ratechange.Enddate;
                    r2.AppendNewElement("internalrate").InnerText = ratechange.Internalrate;
                    r2.AppendNewElement("externalrate").InnerText = ratechange.Externalrate;
                }
            }
            return command;
        }
    }
}
