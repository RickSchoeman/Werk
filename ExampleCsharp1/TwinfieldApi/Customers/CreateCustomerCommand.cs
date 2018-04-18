using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Customers
{
    public class CreateCustomerCommand
    {
        public Customer Customer { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("dimension");
            createElement.AppendNewElement("office").InnerText = Customer.Office;
            createElement.AppendNewElement("type").InnerText = Customer.Type;
            createElement.AppendNewElement("code").InnerText = Customer.Code;
            createElement.AppendNewElement("name").InnerText = Customer.Name;
            createElement.AppendNewElement("website").InnerText = Customer.Website;
            createElement.AppendNewElement("cocnumber").InnerText = Customer.Cocnumber;
            createElement.AppendNewElement("vatnumber").InnerText = Customer.Vatnumber;
            var f = createElement.AppendNewElement("financials");
            f.AppendNewElement("payavailable").InnerText = Customer.Financials.Payavailable;
            f.AppendNewElement("meansofpayment").InnerText = Customer.Financials.Meansofpayment;
            f.AppendNewElement("paycode").InnerText = Customer.Financials.Paycode;
            f.AppendNewElement("ebilling").InnerText = Customer.Financials.Ebilling;
            f.AppendNewElement("ebillmail").InnerText = Customer.Financials.Ebillmail;
           f.AppendNewElement("substitutionlevel").InnerText = Customer.Financials.Substitutionlevel;
           f.AppendNewElement("substitutewith").InnerText = Customer.Financials.Substitutewith;
            f.AppendNewElement("relationsreference").InnerText = Customer.Financials.Relationsreference;
            f.AppendNewElement("vattype").InnerText = Customer.Financials.Vattype;
           f.AppendNewElement("vatcode").InnerText = Customer.Financials.Vatcode;
            f.AppendNewElement("vatobligatory").InnerText = Customer.Financials.Vatobligatory;
            f.AppendNewElement("performancetype").InnerText = Customer.Financials.Performancetype;
            var col = f.AppendNewElement("collectmandate");
            col.AppendNewElement("id").InnerText = Customer.Financials.Collectmandate.Id;
            col.AppendNewElement("signaturedate").InnerText = Customer.Financials.Collectmandate.Signaturedate;
            col.AppendNewElement("firstrundate").InnerText = Customer.Financials.Collectmandate.Firstrundate;
            f.AppendNewElement("collectionschema").InnerText = Customer.Financials.Collectionschema;
            var cred = createElement.AppendNewElement("creditmanagement");
            cred.AppendNewElement("responsibleuser").InnerText = Customer.Creditmanagement.Responsibleuser;
            cred.AppendNewElement("basecreditlimit").InnerText = Customer.Creditmanagement.Basecreditlimit;
            cred.AppendNewElement("sendreminder").InnerText = Customer.Creditmanagement.Sendreminder;
            cred.AppendNewElement("reminderemail").InnerText = Customer.Creditmanagement.Reminderemail;
            cred.AppendNewElement("blocked").InnerText = Customer.Creditmanagement.Blocked;
            cred.AppendNewElement("freetext1").InnerText = Customer.Creditmanagement.Freetext1;
            cred.AppendNewElement("freetext2").InnerText = Customer.Creditmanagement.Freetext2;
            cred.AppendNewElement("freetext3").InnerText = Customer.Creditmanagement.Freetext3;
            cred.AppendNewElement("comment").InnerText = Customer.Creditmanagement.Comment;
            var a1 = createElement.AppendNewElement("addresses");
            for (int i = 0; i < Customer.Addresses.Address.Count; i++)
            {
                if (!Customer.Addresses.Address[i].Equals(null) || Customer.Addresses.Address[i] != null ||
                    !Customer.Addresses.Address[i].Name.Equals("") || Customer.Addresses.Address[i].Name != "")
                {
                    var address = Customer.Addresses.Address[i];

                    var a2 = a1.AppendNewElement("address");
                    a2.SetAttribute("id", i.ToString());
                    a2.AppendNewElement("name").InnerText = address.Name;
                    a2.AppendNewElement("country").InnerText = address.Country;
                    a2.AppendNewElement("city").InnerText = address.City;
                    a2.AppendNewElement("postcode").InnerText = address.Postcode;
                    a2.AppendNewElement("telephone").InnerText = address.Telephone;
                    a2.AppendNewElement("telefax").InnerText = address.Telefax;
                    a2.AppendNewElement("email").InnerText = address.Email;
                    a2.AppendNewElement("contact").InnerText = address.Contact;
                    a2.AppendNewElement("field1").InnerText = address.Field1;
                    a2.AppendNewElement("field2").InnerText = address.Field2;
                    a2.AppendNewElement("field3").InnerText = address.Field3;
                    a2.AppendNewElement("field4").InnerText = address.Field4;
                    a2.AppendNewElement("field5").InnerText = address.Field5;
                    a2.AppendNewElement("field6").InnerText = address.Field6;
                }
            }

            var b1 = createElement.AppendNewElement("banks");
            for (int i = 0; i < Customer.Banks.Bank.Count; i++)
            {
                if (!Customer.Banks.Bank[i].Equals(null) || Customer.Banks.Bank[i] != null ||
                    !Customer.Banks.Bank[i].Ascription.Equals("") || Customer.Banks.Bank[i].Ascription != "")
                {
                    var bank = Customer.Banks.Bank[i];

                    var b2 = b1.AppendNewElement("bank");
                    b2.SetAttribute("id", i.ToString());
                    var b3 = b2.AppendNewElement("address");
                    b2.AppendNewElement("ascription").InnerText = bank.Ascription;
                    b2.AppendNewElement("accountnumber").InnerText = bank.Accountnumber;
                    b3.AppendNewElement("field2").InnerText = bank.Address.Field2;
                    b3.AppendNewElement("field3").InnerText = bank.Address.Field3;
                    b2.AppendNewElement("bankname").InnerText = bank.Bankname;
                    b2.AppendNewElement("biccode").InnerText = bank.Biccode;
                    b2.AppendNewElement("city").InnerText = bank.City;
                    b2.AppendNewElement("country").InnerText = bank.Country;
                    b2.AppendNewElement("iban").InnerText = bank.Iban;
                    b2.AppendNewElement("natbiccode").InnerText = bank.Natbiccode;
                    b2.AppendNewElement("postcode").InnerText = bank.Postcode;
                    b2.AppendNewElement("state").InnerText = bank.State;
                }
            }

            var p1 = createElement.AppendNewElement("paymentconditions");

            var paymentcondition = Customer.Paymentconditions.Paymentcondition;

            var p2 = p1.AppendNewElement("paymentcondition");
            p2.AppendNewElement("discountdays").InnerText = paymentcondition.Discountdays;
            p2.AppendNewElement("discountpercentage").InnerText = paymentcondition.Discountpercentage;
            var post1 = createElement.AppendNewElement("postingrules");
            for (int i = 0; i < Customer.Postingrules.Postingrule.Count; i++)
            {
                if (!Customer.Postingrules.Postingrule[i].Equals(null) || Customer.Postingrules.Postingrule[i] != null || !Customer.Postingrules.Postingrule[i].Currency.Equals("") || Customer.Postingrules.Postingrule[i].Currency != "")
                {
                    var postingrule = Customer.Postingrules.Postingrule[i];
                    var post2 = post1.AppendNewElement("postingrule");
                    post2.SetAttribute("id", (i + 1).ToString());
                    post2.AppendNewElement("currency").InnerText = postingrule.Currency;
                    post2.AppendNewElement("amount").InnerText = postingrule.Amount;
                    post2.AppendNewElement("description").InnerText = postingrule.Description;
                    var l1 = post2.AppendNewElement("lines");
                    var l2 = l1.AppendNewElement("line");
                    l2.AppendNewElement("office").InnerText = postingrule.Lines.Line.Office;
                    l2.AppendNewElement("dimension1").InnerText = postingrule.Lines.Line.Dimension1;
                    l2.AppendNewElement("dimension2").InnerText = postingrule.Lines.Line.Dimension2;
                    l2.AppendNewElement("dimension3").InnerText = postingrule.Lines.Line.Dimension3;
                    l2.AppendNewElement("ratio").InnerText = postingrule.Lines.Line.Ratio;
                    l2.AppendNewElement("vatcode").InnerText = postingrule.Lines.Line.Vatcode;
                    l2.AppendNewElement("description").InnerText = postingrule.Lines.Line.Description;
                }
            }

            return command;
        }
    }
}