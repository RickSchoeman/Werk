using System.Xml;
using DemoConnector.TwinfieldAPI.Controllers;
using DemoConnector.TwinfieldAPI.Controllers.Utilities;
using DemoConnector.TwinfieldAPI.Data.Suppliers;

namespace DemoConnector.TwinfieldAPI.Handlers.Suppliers
{
    public class CreateSupplierCommand
    {
        public Supplier Supplier { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("dimension");
            createElement.AppendNewElement("office").InnerText = Supplier.Office;
            createElement.AppendNewElement("type").InnerText = "CRD";
            createElement.AppendNewElement("code").InnerText = Supplier.Code;
            createElement.AppendNewElement("name").InnerText = Supplier.Name;
            createElement.AppendNewElement("shortname").InnerText = Supplier.Shortname;
            createElement.AppendNewElement("beginperiod").InnerText = Supplier.Beginperiod.ToString();
            createElement.AppendNewElement("beginyear").InnerText = Supplier.Beginyear.ToString();
            createElement.AppendNewElement("endperiod").InnerText = Supplier.Endperiod.ToString();
            createElement.AppendNewElement("endyear").InnerText = Supplier.Endyear.ToString();
            createElement.AppendNewElement("website").InnerText = Supplier.Website;
            var f1 = createElement.AppendNewElement("financials");
            f1.AppendNewElement("matchtype").InnerText = Supplier.Financials.Matchtype.ToString();
            f1.AppendNewElement("accounttype").InnerText = Supplier.Financials.Accounttype;
            f1.AppendNewElement("subanalyse").InnerText = Supplier.Financials.Subanalyse.ToString();
            f1.AppendNewElement("duedays").InnerText = Supplier.Financials.Duedays.ToString();
            f1.AppendNewElement("level").InnerText = Supplier.Financials.Level.ToString();
            f1.AppendNewElement("payavailable").InnerText = Supplier.Financials.Payavailable.ToString();
            f1.AppendNewElement("meansofpayment").InnerText = Supplier.Financials.Meansofpayment.ToString();
            f1.AppendNewElement("paycode").InnerText = Supplier.Financials.Paycode;
            f1.AppendNewElement("substitutionlevel").InnerText = Supplier.Financials.Substitutionlevel.ToString();
            f1.AppendNewElement("substitutewith").InnerText = Supplier.Financials.Substitutewith;
            f1.AppendNewElement("relationsreference").InnerText = Supplier.Financials.Relationsreference;
            var a1 = createElement.AppendNewElement("addresses");
            for (int i = 0; i < Supplier.Addresses.Address.Count; i++)
            {
                if (Supplier.Addresses.Address[i] != null)
                {
                    var address = Supplier.Addresses.Address[i];
                    var a2 = a1.AppendNewElement("address");
                    a2.SetAttribute("id", i.ToString());
                    a2.AppendNewElement("name").InnerText = address.Name;
                    a2.AppendNewElement("country").InnerText = address.Country;
                    a2.AppendNewElement("city").InnerText = address.City;
                    a2.AppendNewElement("postcode").InnerText = address.Postcode;
                    a2.AppendNewElement("telephone").InnerText = address.Telephone;
                    a2.AppendNewElement("telefax").InnerText = address.Telefax;
                    a2.AppendNewElement("email").InnerText = address.Email;
                    a2.AppendNewElement("field1").InnerText = address.Field1;
                    a2.AppendNewElement("field2").InnerText = address.Field2;
                    a2.AppendNewElement("field3").InnerText = address.Field3;
                    a2.AppendNewElement("field4").InnerText = address.Field4;
                    a2.AppendNewElement("field5").InnerText = address.Field5;
                    a2.AppendNewElement("field6").InnerText = address.Field6;
                }
            }

            var b1 = createElement.AppendNewElement("banks");
            for (int i = 0; i < Supplier.Banks.Bank.Count; i++)
            {
                if (Supplier.Banks.Bank[i] != null)
                {
                    var bank = Supplier.Banks.Bank[i];
                    var b2 = b1.AppendNewElement("bank");
                    b2.SetAttribute("id", i.ToString());
                    b2.AppendNewElement("ascription").InnerText = bank.Ascription;
                    b2.AppendNewElement("accountnumber").InnerText = bank.Accountnumber;
                    var b3 = b2.AppendNewElement("address");
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

//            var g1 = createElement.AppendNewElement("groups");
//            g1.AppendNewElement("group").InnerText = Supplier.groups.Group;
            var p1 = createElement.AppendNewElement("postingrules");
            for (int i = 0; i < Supplier.Postingrules.Postingrule.Count; i++)
            {
                if (Supplier.Postingrules.Postingrule[i] != null)
                {
                    var postingrule = Supplier.Postingrules.Postingrule[i];
                    var p2 = p1.AppendNewElement("postingrule");
                    p2.SetAttribute("id", (i + 1).ToString());
                    p2.AppendNewElement("currency").InnerText = postingrule.Currency;
                    p2.AppendNewElement("amount").InnerText = postingrule.Amount;
                    p2.AppendNewElement("description").InnerText = postingrule.Description;
                    var l1 = p2.AppendNewElement("lines");
                    for (int j = 0; j < postingrule.Lines.Line.Count; j++)
                    {
                        if (postingrule.Lines.Line[j] != null)
                        {
                            var line = postingrule.Lines.Line[j];
                            var l2 = l1.AppendNewElement("line");
                            l2.SetAttribute("id", j.ToString());
                            l2.AppendNewElement("office").InnerText = line.Office;
                            l2.AppendNewElement("dimension1").InnerText = line.Dimension1;
                            l2.AppendNewElement("dimension2").InnerText = line.Dimension2;
                            l2.AppendNewElement("dimension3").InnerText = line.Dimension3;
                            l2.AppendNewElement("ratio").InnerText = line.Ratio.ToString();
                            l2.AppendNewElement("vatcode").InnerText = line.Vatcode;
                            l2.AppendNewElement("description").InnerText = line.Description;
                        }
                    }
                }
            }

            var pc1 = createElement.AppendNewElement("paymentconditions");
            for (int i = 0; i < Supplier.Paymentconditions.Paymentcondition.Count; i++)
            {
                if (Supplier.Paymentconditions.Paymentcondition[i] != null)
                {
                    var paymentcondition = Supplier.Paymentconditions.Paymentcondition[i];
                    var pc2 = pc1.AppendNewElement("paymentcondition");
                    pc2.SetAttribute("id", (i + 1).ToString());
                    pc2.AppendNewElement("discountdays").InnerText = paymentcondition.Discountdays.ToString();
                    pc2.AppendNewElement("discountpercentage").InnerText = paymentcondition.Discountpercentage.ToString();
                }
            }

            return command;
        }
    }
}
