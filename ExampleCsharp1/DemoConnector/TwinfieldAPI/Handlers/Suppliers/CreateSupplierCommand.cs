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
            createElement.AppendNewElement("beginperiod").InnerText = Supplier.Beginperiod;
            createElement.AppendNewElement("beginyear").InnerText = Supplier.Beginyear;
            createElement.AppendNewElement("endperiod").InnerText = Supplier.Endperiod;
            createElement.AppendNewElement("endyear").InnerText = Supplier.Endyear;
            createElement.AppendNewElement("website").InnerText = Supplier.Website;
            var f1 = createElement.AppendNewElement("financials");
            f1.AppendNewElement("matchtype").InnerText = Supplier.financials.Matchtype;
            f1.AppendNewElement("accounttype").InnerText = Supplier.financials.Accounttype;
            f1.AppendNewElement("subanalyse").InnerText = Supplier.financials.Subanalyse;
            f1.AppendNewElement("duedays").InnerText = Supplier.financials.Duedays;
            f1.AppendNewElement("level").InnerText = Supplier.financials.Level;
            f1.AppendNewElement("payavailable").InnerText = Supplier.financials.Payavailable;
            f1.AppendNewElement("meansofpayment").InnerText = Supplier.financials.Meansofpayment;
            f1.AppendNewElement("paycode").InnerText = Supplier.financials.Paycode;
            f1.AppendNewElement("substitutionlevel").InnerText = Supplier.financials.Substitutionlevel;
            f1.AppendNewElement("substitutewith").InnerText = Supplier.financials.Substitutewith;
            f1.AppendNewElement("relationsreference").InnerText = Supplier.financials.Relationsreference;
            var a1 = createElement.AppendNewElement("addresses");
            for (int i = 0; i < Supplier.addresses.Address.Count; i++)
            {
                if (!Supplier.addresses.Address[i].Equals(null) || Supplier.addresses.Address[i] != null || !Supplier.addresses.Address[i].Name.Equals("") || Supplier.addresses.Address[i].Name != "")
                {
                    var address = Supplier.addresses.Address[i];
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
            for (int i = 0; i < Supplier.banks.Bank.Count; i++)
            {
                if (!Supplier.banks.Bank[i].Equals(null) || Supplier.banks.Bank[i] != null || !Supplier.banks.Bank[i].Ascription.Equals("") || Supplier.banks.Bank[i].Ascription != "")
                {
                    var bank = Supplier.banks.Bank[i];
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
            for (int i = 0; i < Supplier.postingrules.Postingrule.Count; i++)
            {
                if (!Supplier.postingrules.Postingrule[i].Equals(null) || Supplier.postingrules.Postingrule[i] != null || !Supplier.postingrules.Postingrule[i].Currency.Equals("") || Supplier.postingrules.Postingrule[i].Currency != "")
                {
                    var postingrule = Supplier.postingrules.Postingrule[i];
                    var p2 = p1.AppendNewElement("postingrule");
                    p2.SetAttribute("id", (i + 1).ToString());
                    p2.AppendNewElement("currency").InnerText = postingrule.Currency;
                    p2.AppendNewElement("amount").InnerText = postingrule.Amount;
                    p2.AppendNewElement("description").InnerText = postingrule.Description;
                    var l1 = p2.AppendNewElement("lines");
                    for (int j = 0; j < postingrule.lines.Line.Count; j++)
                    {
                        if (!postingrule.lines.Line[j].Equals(null) || postingrule.lines.Line[j] != null || !postingrule.lines.Line[j].Office.Equals("") || postingrule.lines.Line[j].Office != "")
                        {
                            var line = postingrule.lines.Line[j];
                            var l2 = l1.AppendNewElement("line");
                            l2.SetAttribute("id", j.ToString());
                            l2.AppendNewElement("office").InnerText = line.Office;
                            l2.AppendNewElement("dimension1").InnerText = line.Dimension1;
                            l2.AppendNewElement("dimension2").InnerText = line.Dimension2;
                            l2.AppendNewElement("dimension3").InnerText = line.Dimension3;
                            l2.AppendNewElement("ratio").InnerText = line.Ratio;
                            l2.AppendNewElement("vatcode").InnerText = line.Vatcode;
                            l2.AppendNewElement("description").InnerText = line.Description;
                        }
                    }
                }
            }

            var pc1 = createElement.AppendNewElement("paymentconditions");
            for (int i = 0; i < Supplier.paymentconditions.Paymentcondition.Count; i++)
            {
                if (!Supplier.paymentconditions.Paymentcondition[i].Equals(null) || Supplier.paymentconditions.Paymentcondition[i] != null || !Supplier.paymentconditions.Paymentcondition[i].Discountdays.Equals("") || Supplier.paymentconditions.Paymentcondition[i].Discountdays != "")
                {
                    var paymentcondition = Supplier.paymentconditions.Paymentcondition[i];
                    var pc2 = pc1.AppendNewElement("paymentcondition");
                    pc2.SetAttribute("id", (i + 1).ToString());
                    pc2.AppendNewElement("discountdays").InnerText = paymentcondition.Discountdays;
                    pc2.AppendNewElement("discountpercentage").InnerText = paymentcondition.Discountpercentage;
                }
            }

            return command;
        }
    }
}
