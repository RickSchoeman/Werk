using System.Globalization;
using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Customers;

namespace DemoConnector.TwinfieldAPI.Handlers.Customers
{
    public class CreateCustomerCommand
    {
        public Customer Customer { get; set; }

        internal XmlDocument ToXml()
        {
            var type = string.Empty;
            if (Customer.Financials.Vatcode.Type != null)
            {
                type = Customer.Financials.Vatcode.Type.ToString();
            }
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
            f.AppendNewElement("payavailable").InnerText = Customer.Financials.Payavailable.ToString().ToLower();
            f.AppendNewElement("meansofpayment").InnerText = Customer.Financials.Meansofpayment.ToString().ToLower();
            f.AppendNewElement("paycode").InnerText = Customer.Financials.Paycode;
            f.AppendNewElement("ebilling").InnerText = Customer.Financials.Ebilling.ToString().ToLower();
            f.AppendNewElement("ebillmail").InnerText = Customer.Financials.Ebillmail;
           f.AppendNewElement("substitutionlevel").InnerText = Customer.Financials.Substitutionlevel.ToString().ToLower();
           f.AppendNewElement("substitutewith").InnerText = Customer.Financials.Substitutewith;
           var v = f.AppendNewElement("vatcode");
            v.SetAttribute("name", Customer.Financials.Vatcode.Name);
            v.SetAttribute("shortname", Customer.Financials.Vatcode.Shortname);
            v.SetAttribute("type", type);
            v.SetAttribute("fixed", Customer.Financials.Vatcode.Fixed.ToString().ToLower());
            var col = f.AppendNewElement("collectmandate");
            col.AppendNewElement("id").InnerText = Customer.Financials.Collectmandate.Id;
            col.AppendNewElement("signaturedate").InnerText = Customer.Financials.Collectmandate.Signaturedate;
            col.AppendNewElement("firstrundate").InnerText = Customer.Financials.Collectmandate.Firstrundate;
            f.AppendNewElement("collectionschema").InnerText = Customer.Financials.Collectionschema.ToString().ToLower();
            var cred = createElement.AppendNewElement("creditmanagement");
            cred.AppendNewElement("responsibleuser").InnerText = Customer.Creditmanagement.Responsibleuser;
            cred.AppendNewElement("basecreditlimit").InnerText = Customer.Creditmanagement.Basecreditlimit.ToString(CultureInfo.InvariantCulture).ToLower();
            cred.AppendNewElement("sendreminder").InnerText = Customer.Creditmanagement.Sendreminder.ToString().ToLower();
            cred.AppendNewElement("reminderemail").InnerText = Customer.Creditmanagement.Reminderemail;
            cred.AppendNewElement("blocked").InnerText = Customer.Creditmanagement.Blocked.ToString().ToLower();
            cred.AppendNewElement("freetext1").InnerText = Customer.Creditmanagement.Freetext1.ToString().ToLower();
            cred.AppendNewElement("freetext2").InnerText = Customer.Creditmanagement.Freetext2;
            cred.AppendNewElement("freetext3").InnerText = Customer.Creditmanagement.Freetext3;
            cred.AppendNewElement("comment").InnerText = Customer.Creditmanagement.Comment;
            var a1 = createElement.AppendNewElement("addresses");
            for (int i = 0; i < Customer.Addresses.Address.Count; i++)
            {
                if (Customer.Addresses.Address[i] != null)
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
                if (Customer.Banks.Bank[i] != null)
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

            for (int i = 0; i < Customer.Paymentconditions.Paymentcondition.Count; i++)
            {
                if (Customer.Paymentconditions.Paymentcondition[i] != null)
                {
                    var paymentcondition = Customer.Paymentconditions.Paymentcondition[i];
                    var p2 = p1.AppendNewElement("paymentcondition");
                    p2.SetAttribute("id", (i + 1).ToString());
                    p2.AppendNewElement("discountdays").InnerText = paymentcondition.Discountdays.ToString().ToLower();
                    p2.AppendNewElement("discountpercentage").InnerText = paymentcondition.Discountpercentage.ToString(CultureInfo.InvariantCulture).ToLower();
                }
            }
            var post1 = createElement.AppendNewElement("postingrules");
            for (int i = 0; i < Customer.Postingrules.Postingrule.Count; i++)
            {
                if (Customer.Postingrules.Postingrule[i] != null)
                {
                    var postingrule = Customer.Postingrules.Postingrule[i];
                    var post2 = post1.AppendNewElement("postingrule");
                    post2.SetAttribute("id", (i + 1).ToString());
                    post2.AppendNewElement("currency").InnerText = postingrule.Currency;
                    post2.AppendNewElement("amount").InnerText = postingrule.Amount;
                    post2.AppendNewElement("description").InnerText = postingrule.Description;
                    var l1 = post2.AppendNewElement("lines");
                    for (int j = 0; j < postingrule.Lines.Line.Count; j++)
                    {
                        if (postingrule.Lines.Line[j] != null)
                        {
                            var l2 = l1.AppendNewElement("line");
                            var l = postingrule.Lines.Line[j];
                            l2.SetAttribute("id", (j + 1).ToString());
                            l2.AppendNewElement("office").InnerText = l.Office;
                            l2.AppendNewElement("dimension1").InnerText = l.Dimension1;
                            l2.AppendNewElement("dimension2").InnerText = l.Dimension2;
                            l2.AppendNewElement("dimension3").InnerText = l.Dimension3;
                            l2.AppendNewElement("ratio").InnerText = l.Ratio.ToString();
                            l2.AppendNewElement("vatcode").InnerText = l.Vatcode;
                            l2.AppendNewElement("description").InnerText = l.Description;
                        }
                    }
                }
            }

            return command;
        }
    }
}