using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;

namespace DemoConnector.TwinfieldAPI.Data.Users
{
    public class User
    {

        internal static User FromXml(XmlElement element)
        {
            return new User
            {
                Code = element.SelectInnerText("code"),
                Touched = element.SelectInnerText("touched"),
                Created = element.SelectInnerText("created"),
                Modified = element.SelectInnerText("modified"),
                Name = element.SelectInnerText("name"),
                Shortname = element.SelectInnerText("shortname"),
                Nameview = element.SelectInnerText("nameview"),
                Type = element.SelectInnerText("type"),
                Acceptextracost = element.SelectInnerText("acceptextracost"),
                Demo = element.SelectInnerText("demo"),
                Password = element.SelectInnerText("password"),
                Culture = element.SelectInnerText("culture"),
                Email = element.SelectInnerText("email"),
                Role = element.SelectInnerText("role"),
                Support = element.SelectInnerText("support"),
                Exchangequota = element.SelectInnerText("exchangequota"),
                Filemanagerquota = element.SelectInnerText("filemanagerquota"),
                Freetext1 = element.SelectInnerText("freetext1"),
                Freetext2 = element.SelectInnerText("freetext2"),
                Freetext3 = element.SelectInnerText("freetext3"),
                Smslogin = new Smslogin
                {
                    Phonenumber = element.SelectInnerText("smslogin/phonenumber"),
                    Service = element.SelectInnerText("smslogin/service"),
                    Services = element.SelectInnerText("smslogin/services")
                    
                },
                Office = new Office
                {
                    Default = element.SelectInnerText("office/default"),
                    Template = element.SelectInnerText("template"),
                    Offices = element.SelectInnerText("office/offices"),
                    Restricted = element.SelectInnerText("restricted")
                },
                Account = new Account
                {
                    Sso = element.SelectInnerText("account/sso"),
                    Expire = element.SelectInnerText("account/expire"),
                    Disable = new Disable
                    {
                        From = element.SelectInnerText("account/disable/from"),
                        To = element.SelectInnerText("account/disable/to")
                    }
                },
                Time = new Time
                {
                    Authoriser = element.SelectInnerText("time/authoriser"),
                    Weekhours = element.SelectInnerText("time/weekhours")
                },
                Expenses = new Expenses
                {
                    Dimension1 = element.SelectInnerText("expenses/dimension1"),
                    Dimension2 = element.SelectInnerText("expenses/dimension2"),
                    Dimension3 = element.SelectInnerText("expenses/dimension3"),
                    Dimension4 = element.SelectInnerText("expenses/dimension4")
                },
                Performance = element.SelectInnerText("performance")
            };
        }

        public string Code { get; set; }
        public string Touched { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }
        public string Name { get; set; }
        public string Shortname { get; set; }
        public string Nameview { get; set; }
        public string Type { get; set; }
        public string Acceptextracost { get; set; }
        public string Demo { get; set; }
        public string Password { get; set; }
        public string Culture { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Support { get; set; }
        public string Exchangequota { get; set; }
        public string Filemanagerquota { get; set; }
        public string Freetext1 { get; set; }
        public string Freetext2 { get; set; }
        public string Freetext3 { get; set; }
        public Smslogin Smslogin { get; set; }
        public Office Office { get; set; }
        public Account Account { get; set; }
        public Time Time { get; set; }
        public Expenses Expenses { get; set; }
        public string Performance { get; set; }
        public Deletereason Deletereason { get; set; }

        internal XmlDocument ToXml()
        {
            var document = new XmlDocument();
            var user = document.AppendNewElement("user");
            user.AppendNewElement("code").InnerText = Code;
            user.AppendNewElement("touched").InnerText = Touched;
            user.AppendNewElement("created").InnerText = Created;
            user.AppendNewElement("modified").InnerText = Modified;
            user.AppendNewElement("name").InnerText = Name;
            user.AppendNewElement("shortname").InnerText = Shortname;
            user.AppendNewElement("nameview").InnerText = Nameview;
            user.AppendNewElement("type").InnerText = Type;
            user.AppendNewElement("acceptextracost").InnerText = Acceptextracost;
            user.AppendNewElement("demo").InnerText = Demo;
            user.AppendNewElement("password").InnerText = Password;
            user.AppendNewElement("culture").InnerText = Culture;
            user.AppendNewElement("email").InnerText = Email;
            user.AppendNewElement("role").InnerText = Role;
            user.AppendNewElement("support").InnerText = Support;
            user.AppendNewElement("exchangequota").InnerText = Exchangequota;
            user.AppendNewElement("filemanagerquota").InnerText = Filemanagerquota;
            user.AppendNewElement("freetext1").InnerText = Freetext1;
            user.AppendNewElement("freetext2").InnerText = Freetext2;
            user.AppendNewElement("freetext3").InnerText = Freetext3;
            user.AppendNewElement("smslogin/phonenumber").InnerText = Smslogin.Phonenumber;
            user.AppendNewElement("smslogin/service").InnerText = Smslogin.Service;
            user.AppendNewElement("smslogin/services").InnerText = Smslogin.Services;
            user.AppendNewElement("office/default").InnerText = Office.Default;
            user.AppendNewElement("office/template").InnerText = Office.Template;
            user.AppendNewElement("office/offices").InnerText = Office.Offices;
            user.AppendNewElement("office/restricted").InnerText = Office.Restricted;
            user.AppendNewElement("account/sso").InnerText = Account.Sso;
            user.AppendNewElement("account/expire").InnerText = Account.Expire;
            user.AppendNewElement("account/disable/from").InnerText = Account.Disable.From;
            user.AppendNewElement("account/disable/to").InnerText = Account.Disable.To;
            user.AppendNewElement("time/authoriser").InnerText = Time.Authoriser;
            user.AppendNewElement("time/weekhours").InnerText = Time.Weekhours;
            user.AppendNewElement("expenses/dimension1").InnerText = Expenses.Dimension1;
            user.AppendNewElement("expenses/dimension2").InnerText = Expenses.Dimension2;
            user.AppendNewElement("expenses/dimension3").InnerText = Expenses.Dimension3;
            user.AppendNewElement("expenses/dimension4").InnerText = Expenses.Dimension4;
            user.AppendNewElement("performance").InnerText = Performance;
            return document;
        }
    }

    public class Smslogin
    {
        public string Phonenumber { get; set; }
        public string Service { get; set; }
        public string Services { get; set; }
    }


    public class Office
    {
        public string Default { get; set; }
        public string Template { get; set; }
        public string Offices { get; set; }
        public string Restricted { get; set; }
    }



    public class Account
    {
        public string Sso { get; set; }
        public string Expire { get; set; }
        public Disable Disable { get; set; }
    }

    public class Disable
    {
        public string From { get; set; }
        public string To { get; set; }
    }

    public class Time
    {
        public string Authoriser { get; set; }
        public string Weekhours { get; set; }
    }

    public class Expenses
    {
        public string Dimension1 { get; set; }
        public string Dimension2 { get; set; }
        public string Dimension3 { get; set; }
        public string Dimension4 { get; set; }
    }

    public class Deletereason
    {
        public string Code { get; set; }
        public string Comment { get; set; }
    }

}
