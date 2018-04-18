using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TwinfieldApi.Utilities;

namespace TwinfieldApi.Dimensions
{
    class CreateDimensionCommand
    {
        public Dimension Dimension { get; set; }

        internal XmlDocument ToXml()
        {
            var command = new XmlDocument();
            var createElement = command.AppendNewElement("dimension");
            createElement.AppendNewElement("office").InnerText = Dimension.Office;
            createElement.AppendNewElement("type").InnerText = Dimension.Type;
            createElement.AppendNewElement("code").InnerText = Dimension.Code;
            createElement.AppendNewElement("name").InnerText = Dimension.Name;
            createElement.AppendNewElement("beginperiod").InnerText = Dimension.Beginperiod;
            createElement.AppendNewElement("beginyear").InnerText = Dimension.Beginyear;
            createElement.AppendNewElement("endperiod").InnerText = Dimension.Endyear;
            createElement.AppendNewElement("endyear").InnerText = Dimension.Endyear;
            createElement.AppendNewElement("website").InnerText = Dimension.Website;
            createElement.AppendNewElement("cocnumber").InnerText = Dimension.Cocnumber;
            createElement.AppendNewElement("vatnumber").InnerText = Dimension.Vatnumber;
            createElement.AppendNewElement("editdimenionname").InnerText = Dimension.Editdimensionname;
            var f = createElement.AppendNewElement("financials");
            f.AppendNewElement("matchtype").InnerText = Dimension.financials.Matchtype;
            f.AppendNewElement("accounttype").InnerText = Dimension.financials.Accounttype;
            f.AppendNewElement("subanalyse").InnerText = Dimension.financials.Subanalyse;
            f.AppendNewElement("duedays").InnerText = Dimension.financials.Duedays;
            f.AppendNewElement("level").InnerText = Dimension.financials.Level;
            f.AppendNewElement("payavailable").InnerText = Dimension.financials.Payavailable;
            f.AppendNewElement("meansofpayment").InnerText = Dimension.financials.Meansofpayment;
            f.AppendNewElement("paycode").InnerText = Dimension.financials.Paycode;
            f.AppendNewElement("ebilling").InnerText = Dimension.financials.Ebilling;
            f.AppendNewElement("ebillmail").InnerText = Dimension.financials.Ebillmail;
            f.AppendNewElement("substitutionlevel").InnerText = Dimension.financials.Substitutionlevel;
            f.AppendNewElement("substitutewith").InnerText = Dimension.financials.Substitutewith;
            f.AppendNewElement("relationreference").InnerText = Dimension.financials.Relationsreference;
            f.AppendNewElement("vattype").InnerText = Dimension.financials.Vattype;
            f.AppendNewElement("vatcode").InnerText = Dimension.financials.Vatcode;
            f.AppendNewElement("vatobligatory").InnerText = Dimension.financials.Vatobligatory;
            f.AppendNewElement("performancetype").InnerText = Dimension.financials.Performancetype;
            var col = f.AppendNewElement("collectmandate");
            col.AppendNewElement("id").InnerText = Dimension.financials.Collectmandate.Id;
            col.AppendNewElement("signaturedate").InnerText = Dimension.financials.Collectmandate.Signaturedate;
            col.AppendNewElement("firstrundate").InnerText = Dimension.financials.Collectmandate.Firstrundate;
            f.AppendNewElement("collectionschema").InnerText = Dimension.financials.Collectionschema;
            var cred = createElement.AppendNewElement("creditmanagement");
            cred.AppendNewElement("responsibleuser").InnerText = Dimension.creditmanagement.Responsibleuser;
            cred.AppendNewElement("basecreditlimit").InnerText = Dimension.creditmanagement.Basecreditlimit;
            cred.AppendNewElement("sendreminder").InnerText = Dimension.creditmanagement.Sendreminder;
            cred.AppendNewElement("remindermails").InnerText = Dimension.creditmanagement.Reminderemail;
            cred.AppendNewElement("blocked").InnerText = Dimension.creditmanagement.Blocked;
            cred.AppendNewElement("freetext1").InnerText = Dimension.creditmanagement.Freetext1;
            cred.AppendNewElement("freetext2").InnerText = Dimension.creditmanagement.Freetext2;
            cred.AppendNewElement("freetext3").InnerText = Dimension.creditmanagement.Freetext3;
            cred.AppendNewElement("comment").InnerText = Dimension.creditmanagement.Comment;
            var rem = createElement.AppendNewElement("remittanceadvice");
            rem.AppendNewElement("sendtype").InnerText = Dimension.remittanceadvice.Sendtype;
            rem.AppendNewElement("sendmail").InnerText = Dimension.remittanceadvice.Sendmail;
            var a1 = createElement.AppendNewElement("addresses");
            for (int i = 0; i < Dimension.addresses.Address.Count; i++)
            {
                if (!Dimension.addresses.Address[i].Equals(null) || Dimension.addresses.Address[i] != null || !Dimension.addresses.Address[i].Name.Equals("") || Dimension.addresses.Address[i].Name != "")
                {
                    var address = Dimension.addresses.Address[i];
                    
                    var a2 = a1.AppendNewElement("address");
                    a2.SetAttribute("id", (i + 1).ToString());
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
            for (int i = 0; i < Dimension.banks.Bank.Count; i++)
            {
                if (!Dimension.banks.Bank[i].Equals(null) || Dimension.banks.Bank[i] != null || !Dimension.banks.Bank[i].Ascription.Equals("") || Dimension.banks.Bank[i].Ascription != "")
                {
                    var bank = Dimension.banks.Bank[i];
                    
                    var b2 = b1.AppendNewElement("bank");
                    b2.SetAttribute("id", (i + 1).ToString());
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
            var post1 = createElement.AppendNewElement("postingrules");
            for (int i = 0; i < Dimension.Postingrules.Postingrule.Count; i++)
            {
                if (!Dimension.Postingrules.Postingrule[i].Equals(null) || Dimension.Postingrules.Postingrule[i] != null || !Dimension.Postingrules.Postingrule[i].Currency.Equals("") || Dimension.Postingrules.Postingrule[i].Currency != "")
                {
                    var postingrule = Dimension.Postingrules.Postingrule[i];
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
            var p1 = createElement.AppendNewElement("paymentconditions");
            for (int i = 0; i < Dimension.paymentconditions.Paymentcondition.Count; i++)
            {
                if (!Dimension.paymentconditions.Paymentcondition[i].Equals(null) || Dimension.paymentconditions.Paymentcondition[i] != null || !Dimension.paymentconditions.Paymentcondition[i].Discountdays.Equals("") || Dimension.paymentconditions.Paymentcondition[i].Discountdays != "")
                {
                    var paymentcondition = Dimension.paymentconditions.Paymentcondition[i];
                    
                    var p2 = p1.AppendNewElement("paymentcondition");
                    p2.SetAttribute("id", (i + 1).ToString());
                    p2.AppendNewElement("discountdays").InnerText = paymentcondition.Discountdays;
                    p2.AppendNewElement("discountpercentage").InnerText = paymentcondition.Discountpercentage;
                }
            }

            return command;
        }
    }
}
