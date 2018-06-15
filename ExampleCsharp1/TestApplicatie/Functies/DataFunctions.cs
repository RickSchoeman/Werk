using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Converters;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Articles;
using DemoConnector.TwinfieldAPI.Data.BalanceSheet;
using DemoConnector.TwinfieldAPI.Data.CostCenters;
using DemoConnector.TwinfieldAPI.Data.Customers;
using DemoConnector.TwinfieldAPI.Data.GeneralLedgers;
using DemoConnector.TwinfieldAPI.Data.ProfitLoss;
using DemoConnector.TwinfieldAPI.Data.SalesInvoice;
using DemoConnector.TwinfieldAPI.Data.Suppliers;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using TestApplicatie.InputForms;
using TestApplicatie.Interfaces;
using TestApplicatie.Xml;

namespace TestApplicatie.Functies
{
    public class DataFunctions
    {
        private readonly Twinfield _form;
        private readonly Session _session;
        private readonly IApiOperationsBase<Customer> _customerInterface;
        private readonly IApiOperationsBase<Supplier> _supplierInterface;
        private readonly IArticleInterface _articleInterface;
        private readonly IApiOperationsBase<BalanceSheet> _balanceSheetInterface;
        private readonly IApiOperationsBase<ProfitLoss> _profitLossInterface;
        private readonly ISalesInvoiceInterface _salesInvoiceInterface;
        private readonly IApiOperationsBase<CostCenter> _costCenterInterface;
        private readonly ICustomerConverter _customerConverter;
        private readonly ISupplierConverter _supplierConverter;
        private readonly IGeneralLedgerConverter _generalLedgerConverter;
        private readonly IArticleConverter _articleConverter;
        private readonly ISalesInvoiceConverter _salesInvoiceConverter;
        private readonly ICostCenterConverter _costCenterConverter;

        public DataFunctions(Twinfield form, Session session)
        {
            _customerInterface = new CustomerOperations(session);
            _supplierInterface = new SupplierOperations(session);
            _balanceSheetInterface = new BalanceSheetOperations(session);
            _profitLossInterface = new ProfitLossOperations(session);
            _articleInterface = new ArticleOperations(session);
            _salesInvoiceInterface = new SalesInvoiceOperations(session);
            _costCenterInterface = new CostCenterOperatons(session);
            _customerConverter = new CustomerConverter();
            _supplierConverter = new SupplierConverter();
            _generalLedgerConverter = new GeneralLedgerConverter();
            _articleConverter = new ArticleConverter();
            _salesInvoiceConverter = new SalesInvoiceConverter(session);
            _costCenterConverter = new CostCenterConverter();
            _form = form;
            _session = session;
        }

        public void LoadDataItems<T>(string v, string t, List<T> list)
        {
            _form.dataVeld.Items.Clear();
            _form.LogBox.AppendText("\r\n" + t + " inladen...");
            foreach (var a in list)
            {
                if (_form.dataVeld.Items.Contains(a))
                    continue;

                _form.dataVeld.Items.Add(a);
                _form.Gegevens.Add(a);
            }

            _form.dataVeld.SelectedIndex = 0;
            _form.dataVeld.DisplayMember = v;
            _form.LogBox.AppendText("\r\n" + t + " geladen");
        }

        public void LoadData<T>(T item) where T : class //todo: verplaatsen functies
        {
            var resultType = typeof(T);
            if (resultType == typeof(Customer))
            {
                var x = item as Customer;
                _form.LogBox.AppendText("\r\n" + x.Name);
            }

            if (resultType == typeof(Supplier))
            {
                var x = item as Supplier;
                _form.LogBox.AppendText("\r\n" + x.Name);
            }

            if (resultType == typeof(Article))
            {
                var x = item as Article;
                _form.LogBox.AppendText("\r\n" + x.Header.Name);
            }

            if (resultType == typeof(SalesInvoice))
            {
                var x = item as SalesInvoice;
                _form.LogBox.AppendText("\r\n" + x.Header.InvoiceTypeAndNumber);
            }

            if (resultType == typeof(BalanceSheet))
            {
                var x = item as BalanceSheet;
                _form.LogBox.AppendText("\r\n" + x.Name);
            }

            if (resultType == typeof(ProfitLoss))
            {
                var x = item as ProfitLoss;
                _form.LogBox.AppendText("\r\n" + x.Name);
            }

            if (resultType == typeof(CostCenter))
            {
                var x = item as CostCenter;
                _form.LogBox.AppendText("\r\n" + x.Name);
            }

            _form.resultBar.BackColor = Color.Chartreuse;
            _form.LogBox.ScrollToCaret();
        }

        public void ChangeData<T>(Twinfield.DataChangeTypes changeType, System.Type dataType, List<T> item) where T : class
        {
            var response = string.Empty;
            if (dataType == typeof(CustomerResponse))
            {
                foreach (var t in item)
                {
                    var x = t as CustomerResponse;
                    if (x.Code == _form.dataVeld.GetItemText(_form.dataVeld.SelectedItem))
                    {
                        var c = _customerConverter.ConvertCustomerResponse(x, _session.Office);
                        if (changeType == Twinfield.DataChangeTypes.Create)
                        {
                            response = _customerInterface.Create(c);
                        }

                        if (changeType == Twinfield.DataChangeTypes.Delete)
                        {
                            response = _customerInterface.Delete(c);
                        }
                    }
                }
            }
            if (dataType == typeof(SupplierResponse))
            {
                foreach (var t in item)
                {
                    var x = t as SupplierResponse;
                    if (x.Code == _form.dataVeld.GetItemText(_form.dataVeld.SelectedItem))
                    {
                        var s = _supplierConverter.ConvertSupplierResponse(x, _session.Office);
                        if (changeType == Twinfield.DataChangeTypes.Create)
                        {
                            response = _supplierInterface.Create(s);
                        }

                        if (changeType == Twinfield.DataChangeTypes.Delete)
                        {
                            response = _supplierInterface.Delete(s);
                        }
                    }
                }
            }
            if (dataType == typeof(Product))
            {
                foreach (var t in item)
                {
                    var x = t as Product;
                    if (x.Code == _form.dataVeld.GetItemText(_form.dataVeld.SelectedItem))
                    {
                        var a = _articleConverter.ConvertProduct(x, _session.Office, "IN");
                        if (changeType == Twinfield.DataChangeTypes.Create)
                        {
                            response = _articleInterface.Create(a);
                        }

                        if (changeType == Twinfield.DataChangeTypes.Delete)
                        {
                            response = _articleInterface.Delete(a);
                        }
                    }
                }
            }
            if (dataType == typeof(SalesInvoiceResponse))
            {
                foreach (var t in item)
                {
                    var x = t as SalesInvoiceResponse;
                    if (x.InvoiceTypeAndNumber == _form.dataVeld.GetItemText(_form.dataVeld.SelectedItem))
                    {
                        var si = _salesInvoiceConverter.ConvertSalesInvoiceResponse(x, "IN");
                        if (changeType == Twinfield.DataChangeTypes.Create)
                        {
                            response = _salesInvoiceInterface.Create(si);
                        }
                    }
                }
            }
            if (dataType == typeof(GeneralLedgerResponse))
            {
                foreach (var t in item)
                {
                    var x = t as GeneralLedgerResponse;
                    if (x.Code == _form.dataVeld.GetItemText(_form.dataVeld.SelectedItem))
                    {
                        var gl = _generalLedgerConverter.ConvertGeneralLedgerResponseToBalanceSheet(x,
                            _session.Office);
                        if (changeType == Twinfield.DataChangeTypes.Create)
                        {
                            response = _balanceSheetInterface.Create(gl);
                        }

                        if (changeType == Twinfield.DataChangeTypes.Delete)
                        {
                            response = _balanceSheetInterface.Delete(gl);
                        }
                    }
                }
            }
            if (dataType == typeof(GeneralLedgerResponse))
            {
                foreach (var t in item)
                {
                    var x = t as GeneralLedgerResponse;
                    if (x.Code == _form.dataVeld.GetItemText(_form.dataVeld.SelectedItem))
                    {
                        var gl = _generalLedgerConverter.ConvertGeneralLedgerResponseToProfitLoss(x,
                            _session.Office);
                        if (changeType == Twinfield.DataChangeTypes.Create)
                        {
                            response = _profitLossInterface.Create(gl);
                        }

                        if (changeType == Twinfield.DataChangeTypes.Delete)
                        {
                            response = _profitLossInterface.Delete(gl);
                        }
                    }
                }
            }
            if (dataType == typeof(CostCenterResponse))
            {
                foreach (var t in item)
                {
                    var x = t as CostCenterResponse;
                    if (x.Code == _form.dataVeld.GetItemText(_form.dataVeld.SelectedItem))
                    {
                        var cc = _costCenterConverter.ConvertCostCenterResponse(x, _session.Office);
                        if (changeType == Twinfield.DataChangeTypes.Create)
                        {
                            response = _costCenterInterface.Create(cc);
                        }

                        if (changeType == Twinfield.DataChangeTypes.Delete)
                        {
                            response = _costCenterInterface.Delete(cc);
                        }
                    }
                }
            }
            if (response == "Created")
            {
                _form.resultBar.BackColor = Color.Chartreuse;
                _form.LogBox.AppendText("\r\nData aangemaakt in administratie");
            }
            else if (response == "Deleted")
            {
                _form.resultBar.BackColor = Color.Chartreuse;
                _form.LogBox.AppendText("\r\nData verwijderd uit administratie");
            }
            else
            {
                _form.resultBar.BackColor = Color.Red;
                if (changeType == Twinfield.DataChangeTypes.Create)
                {
                    _form.LogBox.AppendText("\r\nData kan niet aangemaakt worden in administratie");
                }

                if (changeType == Twinfield.DataChangeTypes.Delete)
                {
                    _form.LogBox.AppendText("\r\nData kan niet verwijderd worden uit administratie");
                }
                _form.LogBox.AppendText("\r\nError: " + response);
            }
            _form.LogBox.ScrollToCaret();
            _form.Cursor = Cursors.Arrow;
        }

        public void LoadDataMiddleware<T>(System.Type dataType, List<T> item) where T : class
        {
            if (dataType == typeof(CustomerResponse))
            {
                foreach (var t in item)
                {
                    var x = t as CustomerResponse;
                    if (x.Code == _form.dataVeld.GetItemText(_form.dataVeld.SelectedItem))
                    {
                        _form.LogBox.AppendText("\r\n" + x.Name);
                    }
                }
            }
            if (dataType == typeof(SupplierResponse))
            {
                foreach (var t in item)
                {
                    var x = t as SupplierResponse;
                    if (x.Code == _form.dataVeld.GetItemText(_form.dataVeld.SelectedItem))
                    {
                        _form.LogBox.AppendText("\r\n" + x.Name);
                    }
                }
            }
            if (dataType == typeof(Product))
            {
                foreach (var t in item)
                {
                    var x = t as Product;
                    if (x.Code == _form.dataVeld.GetItemText(_form.dataVeld.SelectedItem))
                    {
                        _form.LogBox.AppendText("\r\n" + x.Description);
                    }
                }
            }
            if (dataType == typeof(SalesInvoiceResponse))
            {
                foreach (var t in item)
                {
                    var x = t as SalesInvoiceResponse;
                    if (x.InvoiceTypeAndNumber == _form.dataVeld.GetItemText(_form.dataVeld.SelectedItem))
                    {
                        _form.LogBox.AppendText("\r\n" + x.InvoiceTypeAndNumber);
                    }
                }
            }
            if (dataType == typeof(GeneralLedgerResponse))
            {
                foreach (var t in item)
                {
                    var x = t as GeneralLedgerResponse;
                    if (x.Code == _form.dataVeld.GetItemText(_form.dataVeld.SelectedItem))
                    {
                        _form.LogBox.AppendText("\r\n" + x.Name);
                    }
                }
            }
            if (dataType == typeof(CostCenterResponse))
            {
                foreach (var t in item)
                {
                    var x = t as CostCenterResponse;
                    if (x.Code == _form.dataVeld.GetItemText(_form.dataVeld.SelectedItem))
                    {
                        _form.LogBox.AppendText("\r\n" + x.Name);
                    }
                }
            }
            _form.resultBar.BackColor = Color.Chartreuse;
            _form.LogBox.ScrollToCaret();
        }

        public void ConvertData<T>(T item) where T : class
        {
            var resultType = typeof(T);
            var xml = String.Empty;
            if (resultType == typeof(Customer))
            {
                var x = item as Customer;
                var r = _customerConverter.ConvertCustomer(x);
                var customer = (new ResponseClassToXmlClass()).ConvertCustomer(r);
                var ser = new Xml.ClassToXml<XmlCustomer>();
                xml = ser.WriteXml(customer);
                _form.LogBox.AppendText("\r\nCustomer " + r.Code + " created in middleware.");

            }

            if (resultType == typeof(Supplier))
            {
                var x = item as Supplier;
                var rs = _supplierConverter.ConvertSupplier(x);
                var supplier = (new ResponseClassToXmlClass()).ConvertSupplier(rs);
                xml = (new Xml.ClassToXml<XmlSupplier>()).WriteXml(supplier);
                _form.LogBox.AppendText("\r\nSupplier " + rs.Code + " created in middleware");
            }

            if (resultType == typeof(Article))
            {
                var x = item as Article;
                var ar = _articleConverter.ConvertArticle(x);
                var product = (new ResponseClassToXmlClass()).ConvertProducts(ar);
                xml = (new Xml.ClassToXml<XmlProducts>()).WriteXml(product);
                _form.LogBox.AppendText("\r\nArticle(s) ");
                for (int i = 0; i < ar.Count; i++)
                {
                    if (i == 0)
                    {
                        _form.LogBox.AppendText(ar[i].Code);
                    }
                    else
                    {
                        _form.LogBox.AppendText(", " + ar[i].Code);
                    }
                }
                _form.LogBox.AppendText(" created in middleware");
            }

            if (resultType == typeof(SalesInvoice))
            {
                var x = item as SalesInvoice;
                var sir = _salesInvoiceConverter.ConvertSalesInvoice(x);
                var salesInvoice = (new ResponseClassToXmlClass()).ConvertSalesInvoice(sir);
                xml = (new Xml.ClassToXml<XmlSalesInvoice>()).WriteXml(salesInvoice);
                _form.LogBox.AppendText("\r\nSales invoice " + sir.OrderNummer + " created in middleware");
            }

            if (resultType == typeof(BalanceSheet))
            {
                var x = item as BalanceSheet;
                var glr = _generalLedgerConverter.ConvertBalanceSheet(x);
                var balanceSheet = (new ResponseClassToXmlClass()).ConvertGeneralLedger(glr);
                xml = (new Xml.ClassToXml<XmlGeneralLedger>()).WriteXml(balanceSheet);
                _form.LogBox.AppendText("\r\nBalance sheet " + glr.Code + " created in middleware");
            }

            if (resultType == typeof(ProfitLoss))
            {
                var x = item as ProfitLoss;
                var glr = _generalLedgerConverter.ConvertProfitLoss(x);
                var profitLoss = (new ResponseClassToXmlClass()).ConvertGeneralLedger(glr);
                xml = (new Xml.ClassToXml<XmlGeneralLedger>()).WriteXml(profitLoss);
                _form.LogBox.AppendText("\r\nProfit and loss " + glr.Code + " created in middleware");
            }

            if (resultType == typeof(CostCenter))
            {
                var x = item as CostCenter;
                var ccr = _costCenterConverter.ConvertCostCenter(x);
                var costcenter = (new ResponseClassToXmlClass()).ConvertCostCenter(ccr);
                xml = (new Xml.ClassToXml<XmlCostCenter>()).WriteXml(costcenter);
                _form.LogBox.AppendText("\r\nCost center " + ccr.Code + " created in middleware");
            }

            _form.LogBox.AppendText("\r\nXml file '" + xml + "' created with the following results:");
            var node = XElement.Load("../../Xml/Results/" + xml);
            var nd = node.FirstNode;
            while (nd != null)
            {
                var text = FormatXml(nd);
                _form.LogBox.SelectionColor = Color.Blue;
                _form.LogBox.AppendText("\r\n" + text);
                nd = nd.NextNode;
                _form.LogBox.ScrollToCaret();
            }

            _form.LogBox.SelectionColor = Color.Black;
            Cursor.Current = Cursors.Arrow;
            _form.resultBar.BackColor = Color.Chartreuse;
            _form.LogBox.ScrollToCaret();
        }

        protected string FormatXml(XNode xmlNode)
        {
            StringBuilder bob = new StringBuilder();


            // We will use stringWriter to push the formated xml into our StringBuilder bob.
            using (StringWriter stringWriter = new StringWriter(bob))
            {
                // We will use the Formatting of our xmlTextWriter to provide our indentation.
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
                {
                    xmlTextWriter.Formatting = Formatting.Indented;
                    xmlNode.WriteTo(xmlTextWriter);
                }
            }


            return bob.ToString();
        }

        public void AddData(string displayType, string objectType, Form form, System.Type dataType)
        {
            object x = null;
            if (dataType == typeof(Customer))
            {
                using (var cForm = form as CustomerForm)
                {
                    var result = cForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        x = cForm.Customer;
                    }
                }
            }

            if (dataType == typeof(Supplier))
            {
                using (var sForm = form as SupplierForm)
                {
                    var result = sForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        x = sForm.Supplier;
                    }
                }
            }

            if (dataType == typeof(Article))
            {
                using (var aForm = form as ArticleForm)
                {
                    var result = aForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        x = aForm.Product;
                    }
                }
            }

            if (dataType == typeof(SalesInvoice))
            {
                using (var sForm = form as SalesInvoiceForm)
                {
                    var result = sForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        x = sForm.SalesInvoice;
                    }
                }
            }

            if (dataType == typeof(GeneralLedger))
            {
                using (var gForm = form as GeneralLedgerForm)
                {
                    var result = gForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        x = gForm.GeneralLedger;
                    }
                }
            }

            if (dataType == typeof(CostCenter))
            {
                using (var cForm = form as CostCenterForm)
                {
                    var result = cForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        x = cForm.CostCenter;
                    }
                }
            }

            if (x != null)
            {
                _form.Gegevens.Add(x);
                _form.dataVeld.Items.Add(x);
                _form.LogBox.AppendText("\r\n" + objectType + " toegevoegd aan de lijst");
                _form.dataVeld.DisplayMember = displayType;
                _form.dataVeld.SelectedIndex = 0;
                _form.dataVeld.Enabled = true;
                _form.functieUitvoeren.Enabled = true;
            }
        }
    }
}
