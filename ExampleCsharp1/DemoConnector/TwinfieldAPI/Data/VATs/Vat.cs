using System.Collections.Generic;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Data.VATs
{
    public class Vat
    {
        internal static Vat FromXml(XmlElement element)
        {
            var accounts = new List<Account>();
            XmlNodeList elemListAccounts = element.GetElementsByTagName("account");
            for (int i = 0; i < elemListAccounts.Count; i++)
            {
                if (!elemListAccounts[i].Equals(null) || elemListAccounts[i] != null || !elemListAccounts[i].SelectInnerText("dim1").Equals("") || elemListAccounts[i].SelectInnerText("dim1") != "")
                {
                    var account = new Account
                    {
                        Dim1 = elemListAccounts[i].SelectInnerText("dim1"),
                        Groupcountry = elemListAccounts[i].SelectInnerText("groupcountry"),
                        Group = elemListAccounts[i].SelectInnerText("group"),
                        Percentage = elemListAccounts[i].SelectInnerText("percentage"),
                        Linetype = elemListAccounts[i].SelectInnerText("linetype")
                    };
                    accounts.Add(account);
                }
            }
            var percentages = new List<Percentage>();
            XmlNodeList elemListPercentages = element.GetElementsByTagName("percentage");
            for (int i = 0; i < elemListPercentages.Count; i++)
            {
                if (elemListPercentages[i].FirstChild.InnerText == elemListPercentages[i].SelectInnerText("date"))
                {
                    if (!elemListPercentages[i].Equals(null) || elemListPercentages[i] != null ||
                        !elemListPercentages[i].SelectInnerText("name").Equals("") ||
                        elemListPercentages[i].SelectInnerText("name") != "")
                    {
                        var percentage = new Percentage
                        {
                            Date = elemListPercentages[i].SelectInnerText("date"),
                            percentage = elemListPercentages[i].SelectInnerText("percentage"),
                            Name = elemListPercentages[i].SelectInnerText("name"),
                            Shortname = elemListPercentages[i].SelectInnerText("shortname"),
                            Accounts = new Accounts
                            {
                                Account = accounts
                            },
                            User = elemListPercentages[i].SelectInnerText("user")
                        };
                        percentages.Add(percentage);
                    }
                }
            }

            return new Vat
            {
                Office = element.SelectInnerText("office"),
                Code = element.SelectInnerText("code"),
                Name = element.SelectInnerText("name"),
                Shortname = element.SelectInnerText("shortname"),
                Type = element.SelectInnerText("type"),
                Uid = element.SelectInnerText("uid"),
                Created = element.SelectInnerText("created"),
                Modified = element.SelectInnerText("modified"),
                Touched = element.SelectInnerText("touched"),
                User = element.SelectInnerText("user"),
                Percentages = new Percentages
                {
                    Percentage = percentages
                }
            };
        }

        public string Office { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public string Type { get; set; }
        public string Uid { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }
        public string Touched { get; set; }
        public string User { get; set; }
        public Percentages Percentages { get; set; }

        internal XmlDocument ToXml()
        {
            var document = new XmlDocument();
            var vat = document.AppendNewElement("vat");
            vat.AppendNewElement("code").InnerText = Code;
            vat.AppendNewElement("name").InnerText = Name;
            vat.AppendNewElement("shortname").InnerText = Shortname;
            vat.AppendNewElement("type").InnerText = Type;
            for (int i = 0; i <Percentages.Percentage.Count; i++)
            {
                if (!Percentages.Percentage[i].Equals(null) || Percentages.Percentage[i] != null || !Percentages.Percentage[i].Name.Equals("") || Percentages.Percentage[i].Name != "")
                {
                    var percentage = Percentages.Percentage[i];
                    vat.AppendNewElement("percentages/percentage[@id='" + i + "']/date").InnerText = percentage.Date;
                    vat.AppendNewElement("percentages/percentage[@id='" + i + "']/percentage").InnerText =
                        percentage.percentage;
                    vat.AppendNewElement("percentages/percentage[@id='" + i + "']/name").InnerText = percentage.Name;
                    vat.AppendNewElement("percentages/percentage[@id='" + i + "']/shortname").InnerText =
                        percentage.Shortname;
                    for (int j = 0; j < percentage.Accounts.Account.Count; j++)
                    {
                        if (!percentage.Accounts.Account[j].Equals(null) || percentage.Accounts.Account[j] != null || !percentage.Accounts.Account[j].Dim1.Equals("") || percentage.Accounts.Account[j].Dim1 != "")
                        {
                            var account = percentage.Accounts.Account[j];
                            vat.AppendNewElement("percentages/percentage[@id='" + i + "']/accounts/account[@id='" + j +
                                                 "']/dim1").InnerText = account.Dim1;
                            vat.AppendNewElement("percentages/percentage[@id='" + "']/accounts/account[@id='" + j +
                                                 "']/groupcountry").InnerText = account.Groupcountry;
                            vat.AppendNewElement("percentages/percentage[@id='" + i + "']/accounts/account[@id='" + j +
                                                 "']/group").InnerText = account.Group;
                            vat.AppendNewElement("percentages/percentage[@id='" + i + "']/accounts/account[@id='" + j +
                                                 "']/percentage").InnerText = account.Percentage;
                            vat.AppendNewElement("percentages/percentage[@id='" + i + "']/accounts/account[@id='" + j +
                                                 "']/linetype").InnerText = account.Linetype;
                        }
                    }
                    vat.AppendNewElement("percentages/percentage[@id='" + i + "']/user").InnerText = percentage.User;
                }
            }

            vat.AppendNewElement("uid").InnerText = Uid;
            vat.AppendNewElement("user").InnerText = User;
            vat.AppendNewElement("touched").InnerText = Touched;
            return document;
        }
    }

    public class Percentages
    {
        public List<Percentage> Percentage { get; set; }
    }

    public class Percentage
    {
        public string Date { get; set; }
        public string percentage { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public Accounts Accounts { get; set; }
        public string User { get; set; }
    }

    public class Accounts
    {
        public List<Account> Account { get; set; }
    }

    public class Account
    {
        public string Dim1 { get; set; }
        public string Groupcountry { get; set; }
        public string Group { get; set; }
        public string Percentage { get; set; }
        public string Linetype { get; set; }
    }
}