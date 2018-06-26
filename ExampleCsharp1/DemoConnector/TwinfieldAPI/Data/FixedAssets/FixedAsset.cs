using System.Collections.Generic;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.NotImplemented.Relations;

namespace DemoConnector.TwinfieldAPI.Data.FixedAssets
{
    public class FixedAsset : Relation
    {
        internal static FixedAsset FromXml(XmlElement element)
        {
            var addresses = new List<Address>();
            XmlNodeList elemListAddresses = element.GetElementsByTagName("address");
            for (int i = 0; i < elemListAddresses.Count; i++)
            {
                if (elemListAddresses[i].SelectInnerText("name") != null)
                {
                    var address = new Address
                    {
                        Field2 = elemListAddresses[i].SelectInnerText("field2"),
                        Field3 = elemListAddresses[i].SelectInnerText("field3")
                    };
                    addresses.Add(address);
                }
            }

            var banks = new List<Bank>();
            XmlNodeList elemListBanks = element.GetElementsByTagName("bank");
            for (int i = 0; i < elemListBanks.Count; i++)
            {
                if (elemListBanks[i].SelectInnerText("ascription") != null)
                {
                    var bank = new Bank
                    {
                        Ascription = elemListBanks[i].SelectInnerText("ascription"),
                        Accountnumber = elemListBanks[i].SelectInnerText("accountnumber"),
                        Address = new Address
                        {
                            Field2 = elemListBanks[i].SelectInnerText("address/field2"),
                            Field3 = elemListBanks[i].SelectInnerText("address/field3")
                        },
                        Bankname = elemListBanks[i].SelectInnerText("bankname"),
                        Biccode = elemListBanks[i].SelectInnerText("biccode"),
                        City = elemListBanks[i].SelectInnerText("city"),
                        Country = elemListBanks[i].SelectInnerText("country"),
                        Iban = elemListBanks[i].SelectInnerText("iban"),
                        Natbiccode = elemListBanks[i].SelectInnerText("natbiccode"),
                        Postcode = elemListBanks[i].SelectInnerText("postcode"),
                        State = elemListBanks[i].SelectInnerText("state")
                    };
                    banks.Add(bank);
                }
            }

            var translines = new List<Transline>();
            XmlNodeList elemListTranslines = element.GetElementsByTagName("transline");
            for (int i = 0; i < elemListTranslines.Count; i++)
            {
                if (elemListTranslines[i].SelectInnerText("code") != null)
                {
                    var transline = new Transline
                    {
                        Code = elemListTranslines[i].SelectInnerText("code"),
                        Number = int.Parse(elemListTranslines[i].SelectInnerText("number")),
                        Line = int.Parse(elemListTranslines[i].SelectInnerText("line")),
                        Amount = elemListTranslines[i].SelectInnerText("amount"),
                        Period = elemListTranslines[i].SelectInnerText("period"),
                        Dim1 = elemListTranslines[i].SelectInnerText("dim1"),
                        Dim2 = elemListTranslines[i].SelectInnerText("dim2"),
                        Dim3 = elemListTranslines[i].SelectInnerText("dim3"),
                        Dim4 = elemListTranslines[i].SelectInnerText("dim4"),
                        Dim5 = elemListTranslines[i].SelectInnerText("dim5"),
                        Dim6 = elemListTranslines[i].SelectInnerText("dim6")
                    };
                    translines.Add(transline);
                }
            }

            Subanalyse subAnalyse = Subanalyse.False;
            Status status = Status.Inactive;
            bool inuse = false;
            Behaviour behaviour = Behaviour.Normal;
            Type type = NotImplemented.Relations.Type.Purchase;
            bool Fixed = false;
            MatchType matchType = MatchType.Notmatchable;

            if (element.SelectInnerText("financials/subanalyse") == Subanalyse.Maybe.ToString().ToLower())
            {
                subAnalyse = Subanalyse.Maybe;
            }

            if (element.SelectInnerText("financials/subanalyse") == Subanalyse.True.ToString().ToLower())
            {
                subAnalyse = Subanalyse.True;
            }

            if (element.SelectInnerText("fixedassets/status") == Status.Active.ToString().ToLower())
            {
                status = Status.Active;
            }

            if (element.SelectInnerText("fixedassets/status") == Status.ToBeActivated.ToString().ToLower())
            {
                status = Status.ToBeActivated;
            }

            if (element.SelectInnerText("fixedassets/status") == Status.Sold.ToString().ToLower())
            {
                status = Status.Sold;
            }

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


            return new FixedAsset
            {
                Office = element.SelectInnerText("office"),
                Type = element.SelectInnerText("type"),
                Name = element.SelectInnerText("name"),
                Financials = new Financials
                {
                    Matchtype = matchType,
                    Accounttype = element.SelectInnerText("financials/accounttype"),
                    Subanalyse = subAnalyse,
                    Level = int.Parse(element.SelectInnerText("financials/level")),
                    Substitutionlevel = int.Parse(element.SelectInnerText("financials/substitutionleven")),
                    Substitutewith = element.SelectInnerText("financials/substitutewtith"),

                    Vatcode = new VatCode
                    {
                        Name = element.SelectSingleNode("//financials/vatcode/@name")?.Value,
                        Shortname = element.SelectSingleNode("//financials/vatcode/@shortname")?.Value,
                        Type = type,
                        Fixed = Fixed,
                    },

                },
                FixedAssets = new FixedAssets
                {
                    Residualvalue = element.SelectInnerText("fixedassets/residualvalue"),
                    Stopvalue = element.SelectInnerText("fixedassets/stopvalue"),
                    Method = element.SelectInnerText("fixedassets/method"),
                    Beginperiod = element.SelectInnerText("fixedassets/beginperiod"),
                    Purchasedate = element.SelectInnerText("fixedassets/purchasedate"),
                    Freetext1 = element.SelectInnerText("fixedassets/freetext1"),
                    Nrofperiods = int.Parse(element.SelectInnerText("fixedassets/nrofperiods")),
                    Percentage = int.Parse(element.SelectInnerText("fixedassets/percentage")),
                    Status = status,
                    Lastdepreciation = element.SelectInnerText("fixedassets/lastdepreciation"),
                    Selldate = element.SelectInnerText("fixedassets/selldate"),
                    Freetext2 = element.SelectInnerText("fixedassets/freetext2"),
                    Freetext3 = element.SelectInnerText("fixedassets/freetext3"),
                    Freetext4 = element.SelectInnerText("fixedassets/freetext4"),
                    Freetext5 = element.SelectInnerText("fixedassets/freetext5"),
                    Translines = new Translines
                    {
                        Transline = translines
                    }
                },
                Groups = new Groups
                {
                    Group = element.SelectInnerText("groups/group")
                },

                Code = element.SelectInnerText("code"),
                Uid = element.SelectInnerText("uid"),
                Shortname = element.SelectInnerText("shortname"),
                Inuse = inuse,
                Behaviour = behaviour,
                Touched = int.Parse(element.SelectInnerText("touched")),
                Banks = new Banks
                {
                    Bank = banks
                }
            };
        }


        public FixedAssets FixedAssets { get; set; }
    }



        public class FixedAssets
        {
            public string Residualvalue { get; set; }
            public string Stopvalue { get; set; }
            public string Method { get; set; }
            public string Beginperiod { get; set; }
            public string Purchasedate { get; set; }
            public string Freetext1 { get; set; }
            public int Nrofperiods { get; set; }
            public int Percentage { get; set; }
            public Status Status { get; set; }
            public string Lastdepreciation { get; set; }
            public string Selldate { get; set; }
            public string Freetext2 { get; set; }
            public string Freetext3 { get; set; }
            public string Freetext4 { get; set; }
            public string Freetext5 { get; set; }
            public Translines Translines { get; set; }
        }

    public enum Status
    {
        ToBeActivated,
        Active,
        Inactive,
        Sold
    }

        public class Translines
        {
            public List<Transline> Transline { get; set; }
        }

        public class Transline
        {
            public string Code { get; set; }
            public int Number { get; set; }
            public int Line { get; set; }
            public string Amount { get; set; }
            public string Period { get; set; }
            public string Dim1 { get; set; }
            public string Dim2 { get; set; }
            public string Dim3 { get; set; }
            public string Dim4 { get; set; }
            public string Dim5 { get; set; }
            public string Dim6 { get; set; }
        }
    }
