using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Users
{
    class CreateUserCommand
    {
        public User User { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("user");
            createElement.AppendNewElement("code").InnerText = User.Code;
            createElement.AppendNewElement("name").InnerText = User.Name;
            createElement.AppendNewElement("shortname").InnerText = User.Shortname;
            createElement.AppendNewElement("nameview").InnerText = User.Nameview;
            createElement.AppendNewElement("type").InnerText = User.Type;
            createElement.AppendNewElement("acceptextracost").InnerText = User.Acceptextracost;
            createElement.AppendNewElement("demo").InnerText = User.Demo;
            createElement.AppendNewElement("password").InnerText = User.Password;
            createElement.AppendNewElement("culture").InnerText = User.Culture;
            createElement.AppendNewElement("email").InnerText = User.Email;
            createElement.AppendNewElement("role").InnerText = User.Role;
            createElement.AppendNewElement("support").InnerText = User.Support;
            createElement.AppendNewElement("exchangequota").InnerText = User.Exchangequota;
            createElement.AppendNewElement("filemanagerquota").InnerText = User.Filemanagerquota;
            createElement.AppendNewElement("freetext1").InnerText = User.Freetext1;
            createElement.AppendNewElement("freetext2").InnerText = User.Freetext2;
            createElement.AppendNewElement("freetext3").InnerText = User.Freetext3;
            var s1 = createElement.AppendNewElement("smslogin");
            s1.AppendNewElement("phonenumber").InnerText = User.Smslogin.Phonenumber;
            s1.AppendNewElement("service").InnerText = User.Smslogin.Service;
            s1.AppendNewElement("services").InnerText = User.Smslogin.Services;
            var o1 = createElement.AppendNewElement("office");
            o1.AppendNewElement("default").InnerText = User.Office.Default;
            o1.AppendNewElement("template").InnerText = User.Office.Template;
            o1.AppendNewElement("offices").InnerText = User.Office.Offices;
            var a1 = createElement.AppendNewElement("account");
            a1.AppendNewElement("sso").InnerText = User.Account.Sso;
            a1.AppendNewElement("expire").InnerText = User.Account.Expire;
            var d1 = a1.AppendNewElement("disable");
            d1.AppendNewElement("from").InnerText = User.Account.Disable.From;
            d1.AppendNewElement("to").InnerText = User.Account.Disable.To;
            var t1 = createElement.AppendNewElement("time");
            t1.AppendNewElement("authoriser").InnerText = User.Time.Authoriser;
            t1.AppendNewElement("weekhours").InnerText = User.Time.Weekhours;
            var e1 = createElement.AppendNewElement("expenses");
            e1.AppendNewElement("dimension1").InnerText = User.Expenses.Dimension1;
            e1.AppendNewElement("dimension2").InnerText = User.Expenses.Dimension2;
            e1.AppendNewElement("dimension3").InnerText = User.Expenses.Dimension3;
            e1.AppendNewElement("dimension4").InnerText = User.Expenses.Dimension4;
            return command;
        }
    }
}
