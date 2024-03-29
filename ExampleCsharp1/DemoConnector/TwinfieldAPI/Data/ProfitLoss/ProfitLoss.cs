﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.GeneralLedgers;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.Relations;
using Type = DemoConnector.TwinfieldAPI.Data.NotImplemented.Relations.Type;

namespace DemoConnector.TwinfieldAPI.Data.ProfitLoss
{
    public class ProfitLoss : GeneralLedger
    {
        internal static ProfitLoss FromXml(XmlElement element)
        {
            bool inuse = false;
            Behaviour behaviour = Behaviour.Normal;
            Subanalyse subanalyse = Subanalyse.Maybe;
            Type? type = NotImplemented.Relations.Type.Purchase;
            bool Fixed = false;
            MatchType matchType = MatchType.Notmatchable;

            if (element.SelectInnerText("inuse") == "true")
            {
                inuse = true;
            }

            if (element.SelectInnerText("behaviour") == Behaviour.System.ToString().ToLower())
            {
                behaviour = Behaviour.System;
            }

            if (element.SelectInnerText("behaviour") == Behaviour.Template.ToString().ToLower())
            {
                behaviour = Behaviour.Template;
            }

            if (element.SelectInnerText("financials/subanalyse") == Subanalyse.False.ToString().ToLower())
            {
                subanalyse = Subanalyse.False;
            }

            if (element.SelectInnerText("financials/subanalyse") == Subanalyse.True.ToString().ToLower())
            {
                subanalyse = Subanalyse.True;
            }

            if (element.SelectSingleNode("//financials/vatcode/@type")?.Value == NotImplemented.Relations.Type.Sales.ToString().ToLower())
            {
                type = NotImplemented.Relations.Type.Sales;
            }

            if (element.SelectSingleNode("//financials/vatcode/@fixed")?.Value == "true")
            {
                Fixed = true;
            }

            if (element.SelectInnerText("financials/matchtype") == MatchType.Matchable.ToString().ToLower())
            {
                matchType = MatchType.Matchable;
            }

            if (element.SelectSingleNode("//financials/vatcode/@type")?.Value == null)
            {
                type = null;
            }

            return new ProfitLoss
            {
                Office = element.SelectInnerText("office"),
                Type = element.SelectInnerText("type"),
                Code = element.SelectInnerText("code"),
                Uid = element.SelectInnerText("uid"),
                Name = element.SelectInnerText("name"),
                Shortname = element.SelectInnerText("shortname"),
                Inuse = inuse,
                Behaviour = behaviour,
                Touched = int.Parse(element.SelectInnerText("touched")),
                Beginperiod = int.Parse(element.SelectInnerText("beginperiod")),
                Beginyear = int.Parse(element.SelectInnerText("beginyear")),
                Endperiod = int.Parse(element.SelectInnerText("endperiod")),
                Endyear = int.Parse(element.SelectInnerText("endyear")),
                Financials = new Financials
                {
                    Matchtype = matchType,
                    Accounttype = element.SelectInnerText("financials/accounttype"),
                    Subanalyse = subanalyse,
                    Level = int.Parse(element.SelectInnerText("financials/level")),
                    Vatcode = new VatCode
                    {
                        Name = element.SelectSingleNode("//financials/vatcode/@name")?.Value,
                        Shortname = element.SelectSingleNode("//financials/vatcode/@shortname")?.Value,
                        Type = type,
                        Fixed = Fixed,
                    },
                    Childvalidations = new Childvalidations
                    {
                        Childvalidation = element.SelectInnerText("financials/childvalidations/childvalidation")
                    }
                },
                Groups = new Groups
                {
                    Group = element.SelectInnerText("groups/group")
                },

            };
        }
    }
}
