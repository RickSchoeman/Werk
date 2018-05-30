using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
using DemoConnector.TwinfieldAPI.Data.Suppliers;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;
using TestApplicatie.InputForms;
using TestApplicatie.Interfaces;

namespace TestApplicatie
{
    public partial class Twinfield : Form
    {
        private readonly Session _session;
        public List<object> _gegevens = new List<object>();
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
        private readonly IMiddlewareData _middlewareData;
        private readonly List<CustomerResponse> _customers = new List<CustomerResponse>();
        private readonly List<SupplierResponse> _suppliers = new List<SupplierResponse>();
        private readonly List<Product> _products = new List<Product>();
        private readonly List<SalesInvoiceResponse> _salesInvoices = new List<SalesInvoiceResponse>();
        private readonly List<GeneralLedgerResponse> _generalLedgers = new List<GeneralLedgerResponse>();
        private readonly List<CostCenterResponse> _costCenters = new List<CostCenterResponse>();

        public Twinfield(Session session)
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
            _middlewareData = new MiddlewareData();
            _session = session;
            InitializeComponent();
            var dataList = new List<string>
            {
                "Customers",
                "Suppliers",
                "Articles",
                "Sales Invoices",
                "Balance Sheets",
                "Profit and Loss",
                "Cost Centers"
            };
            var functies = new List<string> {"None"};
            dataVeld.DropDownStyle = ComboBoxStyle.DropDownList;
            data.DataSource = dataList;
            data.DropDownStyle = ComboBoxStyle.DropDownList;
            functie.DataSource = functies;
            functie.DropDownStyle = ComboBoxStyle.DropDownList;
            radioButton1.Checked = false;
            radioButton2.Checked = true;
            textBox1.Text = @"Middleware";
            richTextBox1.Text = @"Administratie " + _session.Office + @" geladen";
            functieUitvoeren.Enabled = false;
            dataVeld.Enabled = false;
            functie.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form wissel = new AdministratieVeranderen(_session);
            wissel.Show();
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = @"Administratie";
            createNew.Enabled = true;
            dataVeld.Enabled = false;
            functieUitvoeren.Enabled = false;
            var functies = new List<string> {"Create", "Delete"};
            functie.DataSource = functies;
            functie.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = @"Middleware";
            createNew.Enabled = false;
            dataVeld.Enabled = false;
            functie.Enabled = false;
            functie.DataSource = new List<string>();
            functieUitvoeren.Enabled = false;
        }

        private void dataInladen_Click(object sender, EventArgs e)
        {
            _customers.Clear();
            _suppliers.Clear();
            _products.Clear();
            _salesInvoices.Clear();
            _generalLedgers.Clear();
            _costCenters.Clear();
            dataVeld.Items.Clear();
            _gegevens?.Clear();
            switch (data.Text)
            {
                case @"Customers":
                    if (!radioButton1.Checked)
                    {
                        richTextBox1.AppendText("\r\nCustomers inladen...");
                        Cursor.Current = Cursors.WaitCursor;
                        foreach (var c in _customerInterface.GetSummaries())
                        {
                            if (!dataVeld.Items.Contains(c))
                            {
                                _gegevens?.Add(c);
                                dataVeld.Items.Add(c);
                            }
                        }

                        richTextBox1.AppendText("\r\nCustomers geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string> {"Read", "Convert"};
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "Code";
                    }
                    else
                    {
                        richTextBox1.AppendText("\r\nVoorbeeld customer inladen...");
                        Cursor.Current = Cursors.WaitCursor;
                        var customer = _middlewareData.GetCustomerData();
                        _customers.Add(customer);
                        if (!dataVeld.Items.Contains(customer))
                        {
                            dataVeld.Items.Add(customer);
                        }

                        richTextBox1.AppendText("\r\nVoorbeeld customer geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string> {"Read", "Create", "Delete"};
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "Code";
                    }

                    richTextBox1.ScrollToCaret();
                    break;
                case @"Suppliers":
                    richTextBox1.AppendText("\r\nSuppliers inladen...");
                    Cursor.Current = Cursors.WaitCursor;
                    if (!radioButton1.Checked)
                    {
                        foreach (var s in _supplierInterface.GetSummaries())
                        {
                            if (!dataVeld.Items.Contains(s))
                            {
                                _gegevens?.Add(s);
                                dataVeld.Items.Add(s);
                            }
                        }

                        richTextBox1.AppendText("\r\nSuppliers geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string> {"Read", "Convert"};
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "Code";
                    }
                    else
                    {
                        richTextBox1.AppendText("\r\nVoorbeeld supplier inladen...");
                        Cursor.Current = Cursors.WaitCursor;
                        var supplier = _middlewareData.GetSupplierData();
                        _suppliers.Add(supplier);
                        if (!dataVeld.Items.Contains(supplier))
                        {
                            dataVeld.Items.Add(supplier);
                        }

                        richTextBox1.AppendText("\r\nVoorbeeld supplier geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string> {"Read", "Create", "Delete"};
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "Code";
                    }

                    richTextBox1.ScrollToCaret();
                    break;
                case @"Articles":
                    richTextBox1.AppendText("\r\nArticles inladen...");
                    Cursor.Current = Cursors.WaitCursor;
                    if (!radioButton1.Checked)
                    {
                        foreach (var a in _articleInterface.GetSummaries())
                        {
                            if (!dataVeld.Items.Contains(a))
                            {
                                _gegevens?.Add(a);
                                dataVeld.Items.Add(a);
                            }
                        }

                        richTextBox1.AppendText("\r\nArticles geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string> {"Read", "Convert"};
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "Code";
                    }
                    else
                    {
                        richTextBox1.AppendText("\r\nVoorbeeld article inladen...");
                        Cursor.Current = Cursors.WaitCursor;
                        var article = _middlewareData.GetProductData();
                        _products.Add(article);
                        if (!dataVeld.Items.Contains(article))
                        {
                            dataVeld.Items.Add(article);
                        }

                        richTextBox1.AppendText("\r\nVoorbeeld article geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string> {"Read", "Create", "Delete"};
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "Code";
                    }

                    richTextBox1.ScrollToCaret();
                    break;
                case @"Sales Invoices":
                    richTextBox1.AppendText("\r\nSales invoices inladen...");
                    Cursor.Current = Cursors.WaitCursor;
                    if (!radioButton1.Checked)
                    {
                        foreach (var s in _salesInvoiceInterface.GetAll())
                        {
                            if (!dataVeld.Items.Contains(s.Header))
                            {
                                _gegevens?.Add(s.Header);
                                dataVeld.Items.Add(s.Header);
                            }
                        }

                        richTextBox1.AppendText("\r\nSales invoices geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string> {"Read", "Convert"};
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "InvoiceTypeAndNumber";
                    }
                    else
                    {
                        richTextBox1.AppendText("\r\nVoorbeeld sales invoice inladen...");
                        Cursor.Current = Cursors.WaitCursor;
                        var salesInvoice = _middlewareData.GetSalesInvoiceData();
                        _salesInvoices.Add(salesInvoice);
                        if (!dataVeld.Items.Contains(salesInvoice))
                        {
                            dataVeld.Items.Add(salesInvoice);
                        }

                        richTextBox1.AppendText("\r\nVoorbeeld sales invoice geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string> {"Read", "Create"};
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "InvoiceTypeAndNumber";
                    }

                    richTextBox1.ScrollToCaret();
                    break;
                case @"Balance Sheets":
                    richTextBox1.AppendText("\r\nBalance sheets inladen...");
                    Cursor.Current = Cursors.WaitCursor;
                    if (!radioButton1.Checked)
                    {
                        foreach (var g in _balanceSheetInterface.GetSummaries())
                        {
                            if (!dataVeld.Items.Contains(g))
                            {
                                _gegevens?.Add(g);
                                dataVeld.Items.Add(g);
                            }
                        }
                        richTextBox1.AppendText("\r\nBalance sheets geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string> { "Read", "Convert" };
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "Code";
                    }
                    else
                    {
                        richTextBox1.AppendText("\r\nVoorbeeld balance sheet inladen...");
                        Cursor.Current = Cursors.WaitCursor;
                        var generalLedger = _middlewareData.GetBalanceSheetData();
                        _generalLedgers.Add(generalLedger);
                        if (!dataVeld.Items.Contains(generalLedger))
                        {
                            dataVeld.Items.Add(generalLedger);
                        }

                        richTextBox1.AppendText("\r\nVoorbeeld balance sheet geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string> { "Read", "Create", "Delete" };
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "Code";
                    }
                    richTextBox1.ScrollToCaret();
                    break;
                case @"Profit and Loss":
                    richTextBox1.AppendText("\r\nProfit and loss inladen...");
                    Cursor.Current = Cursors.WaitCursor;
                    if (!radioButton1.Checked)
                    {
                        foreach (var g in _profitLossInterface.GetSummaries())
                        {
                            if (!dataVeld.Items.Contains(g))
                            {
                                _gegevens?.Add(g);
                                dataVeld.Items.Add(g);
                            }
                        }
                        richTextBox1.AppendText("\r\nProfit and loss geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string> { "Read", "Convert" };
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "Code";
                    }
                    else
                    {
                        richTextBox1.AppendText("\r\nVoorbeeld profit and loss inladen...");
                        Cursor.Current = Cursors.WaitCursor;
                        var generalLedger = _middlewareData.GetProfitAndLossData();
                        _generalLedgers.Add(generalLedger);
                        if (!dataVeld.Items.Contains(generalLedger))
                        {
                            dataVeld.Items.Add(generalLedger);
                        }

                        richTextBox1.AppendText("\r\nVoorbeeld profit and loss geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string> { "Read", "Create", "Delete" };
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "Code";
                    }
                    richTextBox1.ScrollToCaret();
                    break;
                case @"Cost Centers":
                    richTextBox1.AppendText("\r\nCost centers inladen...");
                    Cursor.Current = Cursors.WaitCursor;
                    if (!radioButton1.Checked)
                    {
                        foreach (var cc in _costCenterInterface.GetSummaries())
                        {
                            if (!dataVeld.Items.Contains(cc))
                            {
                                _gegevens?.Add(cc);
                                dataVeld.Items.Add(cc);
                            }
                        }

                        richTextBox1.AppendText("\r\nCost centers geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string> {"Read", "Convert"};
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "Code";
                    }
                    else
                    {
                        richTextBox1.AppendText("\r\nVoorbeeld cost center inladen...");
                        Cursor.Current = Cursors.WaitCursor;
                        var costCenter = _middlewareData.GetCostCenterData();
                        _costCenters.Add(costCenter);
                        if (!dataVeld.Items.Contains(costCenter))
                        {
                            dataVeld.Items.Add(costCenter);
                        }

                        richTextBox1.AppendText("\r\nVoorbeeld cost center geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string> {"Read", "Create", "Delete"};
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "Code";
                    }

                    richTextBox1.ScrollToCaret();
                    break;
            }


            richTextBox1.ScrollToCaret();
            functie.Enabled = true;
            functieUitvoeren.Enabled = true;
            dataVeld.Enabled = true;
        }

        private void functieUitvoeren_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            {
                switch (functie.Text)
                {
                    case @"Read":
                        switch (data.Text)
                        {
                            case @"Customers":
                                Cursor.Current = Cursors.WaitCursor;
                                try
                                {
                                    var c = _customerInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem));
                                    Cursor.Current = Cursors.Arrow;
                                    richTextBox1.AppendText("\r\n" + c.Name);
                                    resultBar.BackColor = Color.Chartreuse;
                                }
                                catch (Exception exception)
                                {
                                    richTextBox1.AppendText("\r\nDe data kan niet gelezen worden");
                                    richTextBox1.AppendText("\r\nError: " + exception.Message);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Red;
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Suppliers":
                                Cursor.Current = Cursors.WaitCursor;
                                try
                                {
                                    var s = _supplierInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem));
                                    Cursor.Current = Cursors.Arrow;
                                    richTextBox1.AppendText("\r\n" + s.Name);
                                    resultBar.BackColor = Color.Chartreuse;
                                }
                                catch (Exception exception)
                                {
                                    richTextBox1.AppendText("\r\nDe data kan niet gelezen worden");
                                    richTextBox1.AppendText("\r\nError: " + exception.Message);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Red;
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Articles":
                                Cursor.Current = Cursors.WaitCursor;
                                try
                                {
                                    var a = _articleInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem));
                                    Cursor.Current = Cursors.Arrow;
                                    richTextBox1.AppendText("\r\n" + a.Header.Name);
                                    resultBar.BackColor = Color.Chartreuse;
                                }
                                catch (Exception exception)
                                {
                                    richTextBox1.AppendText("\r\nDe data kan niet gelezen worden");
                                    richTextBox1.AppendText("\r\nError: " + exception.Message);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Red;
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Sales Invoices":
                                Cursor.Current = Cursors.WaitCursor;
                                var data = dataVeld.GetItemText(dataVeld.SelectedItem);
                                string[] items = data.Split(',');
                                try
                                {
                                    var si = _salesInvoiceInterface.Read(items[1], items[0]);
                                    Cursor.Current = Cursors.Arrow;
                                    richTextBox1.AppendText("\r\n" + si.Header.InvoiceTypeAndNumber);
                                    resultBar.BackColor = Color.Chartreuse;
                                }
                                catch (Exception exception)
                                {
                                    richTextBox1.AppendText("\r\nDe data kan niet gelezen worden");
                                    richTextBox1.AppendText("\r\nError: " + exception.Message);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Red;
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Balance Sheets":
                                Cursor.Current = Cursors.WaitCursor;
                                try
                                {
                                    var g = _balanceSheetInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem));
                                    Cursor.Current = Cursors.Arrow;
                                    richTextBox1.AppendText("\r\n" + g.Name);
                                    resultBar.BackColor = Color.Chartreuse;
                                }
                                catch (Exception exception)
                                {
                                    richTextBox1.AppendText("\r\nDe data kan niet gelezen worden");
                                    richTextBox1.AppendText("\r\nError: " + exception.Message);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Red;
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Profit and Loss":
                                Cursor.Current = Cursors.WaitCursor;
                                try
                                {
                                    var g = _profitLossInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem));
                                    Cursor.Current = Cursors.Arrow;
                                    richTextBox1.AppendText("\r\n" + g.Name);
                                    resultBar.BackColor = Color.Chartreuse;
                                }
                                catch (Exception exception)
                                {
                                    richTextBox1.AppendText("\r\nDe data kan niet gelezen worden");
                                    richTextBox1.AppendText("\r\nError: " + exception.Message);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Red;
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Cost Centers":
                                Cursor.Current = Cursors.WaitCursor;
                                try
                                {
                                    var cc = _costCenterInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem));
                                    Cursor.Current = Cursors.Arrow;
                                    richTextBox1.AppendText("\r\n" + cc.Name);
                                    resultBar.BackColor = Color.Chartreuse;
                                }
                                catch (Exception exception)
                                {
                                    richTextBox1.AppendText("\r\nDe data kan niet gelezen worden");
                                    richTextBox1.AppendText("\r\nError: " + exception.Message);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Red;
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                        }

                        break;
                    case @"Convert":
                        switch (data.Text)
                        {
                            case @"Customers":
                                try
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    var c = _customerInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem));
                                    var r = _customerConverter.ConvertCustomer(c);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nCustomer " + r.Code + " created in middleware.");
                                }
                                catch (Exception exception)
                                {
                                    richTextBox1.AppendText(
                                        "\r\nDe customer kan niet geconverteerd worden naar de middleware");
                                    richTextBox1.AppendText("\r\nError: " + exception.Message);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Red;
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Suppliers":
                                try
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    var s = _supplierInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem));
                                    var rs = _supplierConverter.ConvertSupplier(s);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nSupplier " + rs.Code + " created in middleware");
                                }
                                catch (Exception exception)
                                {
                                    richTextBox1.AppendText(
                                        "\r\nDe supplier kan niet geconverteerd worden naar de middleware");
                                    richTextBox1.AppendText("\r\nError: " + exception.Message);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Red;
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Articles":
                                try
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    var a = _articleInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem));
                                    var ar = _articleConverter.ConvertArticle(a);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nArticle(s) ");
                                    for (int i = 0; i < ar.Count; i++)
                                    {
                                        if (i == 0)
                                        {
                                            richTextBox1.AppendText(ar[i].Code);
                                        }
                                        else
                                        {
                                            richTextBox1.AppendText(", " + ar[i].Code);
                                        }
                                    }

                                    richTextBox1.AppendText(" created in middleware");
                                }
                                catch (Exception exception)
                                {
                                    richTextBox1.AppendText(
                                        "\r\nDe article(s) kunnen niet geconverteerd worden naar de middelware");
                                    richTextBox1.AppendText("\r\nError: " + exception.Message);
                                    Cursor.Current = Cursors.WaitCursor;
                                    resultBar.BackColor = Color.Red;
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Sales Invoices":
                                try
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    var data = dataVeld.GetItemText(dataVeld.SelectedItem);
                                    string[] items = data.Split(',');
                                    var si = _salesInvoiceInterface.Read(items[1], items[0]);
                                    var sir = _salesInvoiceConverter.ConvertSalesInvoice(si);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nSales invoice " + sir.OrderNummer +
                                                            " created in middleware");
                                }
                                catch (Exception exception)
                                {
                                    richTextBox1.AppendText(
                                        "\r\nDe sales invoice kan niet geconverteerd worden naar de middleware");
                                    richTextBox1.AppendText("\r\nError: " + exception.Message);
                                    Cursor.Current = Cursors.WaitCursor;
                                    resultBar.BackColor = Color.Red;
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Balance Sheets":
                                try
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    var gl = _balanceSheetInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem));
                                    var glr = _generalLedgerConverter.ConvertBalanceSheet(gl);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nBalance sheet " + glr.Code +
                                                            " created in middleware");
                                }
                                catch (Exception exception)
                                {
                                    richTextBox1.AppendText(
                                        "\r\nDe balance sheet kan niet geconverteerd worden naar de middleware");
                                    richTextBox1.AppendText("\r\nError: " + exception.Message);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Red;
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Profit and Loss":
                                try
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    var gl = _profitLossInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem));
                                    var glr = _generalLedgerConverter.ConvertProfitLoss(gl);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nProfit and loss " + glr.Code +
                                                            " created in middleware");
                                }
                                catch (Exception exception)
                                {
                                    richTextBox1.AppendText(
                                        "\r\nDe profit and loss kan niet geconverteerd worden naar de middleware");
                                    richTextBox1.AppendText("\r\nError: " + exception.Message);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Red;
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Cost Centers":
                                try
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    var cc = _costCenterInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem));
                                    var ccr = _costCenterConverter.ConvertCostCenter(cc);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nCost center " + ccr.Code + " created in middleware");
                                }
                                catch (Exception exception)
                                {
                                    richTextBox1.AppendText(
                                        "\r\nCost center kan niet geconverteerd worden naar de middleware");
                                    richTextBox1.AppendText("\r\nError: " + exception.Message);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Red;
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                        }

                        break;
                    case @"None":
                        richTextBox1.AppendText("\r\nEr moet eerst data ingeladen worden.");
                        break;
                }
            }
            else
            {
                switch (functie.Text)
                {
                    case @"Read":
                        switch (data.Text)
                        {
                            case @"Customers":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var c in _customers)
                                {
                                    if (c.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        richTextBox1.AppendText("\r\n" + c.Name);
                                        Cursor.Current = Cursors.Arrow;
                                        resultBar.BackColor = Color.Chartreuse;
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Suppliers":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var s in _suppliers)
                                {
                                    if (s.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        richTextBox1.AppendText("\r\n" + s.Name);
                                        Cursor.Current = Cursors.Arrow;
                                        resultBar.BackColor = Color.Chartreuse;
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Articles":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var p in _products)
                                {
                                    if (p.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        richTextBox1.AppendText("\r\n" + p.Description);
                                        Cursor.Current = Cursors.Arrow;
                                        resultBar.BackColor = Color.Chartreuse;
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Sales Invoices":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var s in _salesInvoices)
                                {
                                    if (s.InvoiceTypeAndNumber == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        richTextBox1.AppendText("\r\n" + s.InvoiceTypeAndNumber);
                                        Cursor.Current = Cursors.Arrow;
                                        resultBar.BackColor = Color.Chartreuse;
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Balance Sheets":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var g in _generalLedgers)
                                {
                                    if (g.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        richTextBox1.AppendText("\r\n" + g.Name);
                                        Cursor.Current = Cursors.Arrow;
                                        resultBar.BackColor = Color.Chartreuse;
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Profit and Loss":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var g in _generalLedgers)
                                {
                                    if (g.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        richTextBox1.AppendText("\r\n" + g.Name);
                                        Cursor.Current = Cursors.Arrow;
                                        resultBar.BackColor = Color.Chartreuse;
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Cost Centers":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var c in _costCenters)
                                {
                                    if (c.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        richTextBox1.AppendText("\r\n" + c.Name);
                                        Cursor.Current = Cursors.Arrow;
                                        resultBar.BackColor = Color.Chartreuse;
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                        }

                        break;
                    case @"Create":
                        switch (data.Text)
                        {
                            case @"Customers":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var x in _customers)
                                {
                                    if (x.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        var c = _customerConverter.ConvertCustomerResponse(x, _session.Office);
                                        var cr = _customerInterface.Create(c);
                                        Cursor.Current = Cursors.Arrow;
                                        if (cr == "Created")
                                        {
                                            resultBar.BackColor = Color.Chartreuse;
                                            richTextBox1.AppendText(
                                                "\r\nCustomer " + c.Code + " aangemaakt in administratie");
                                        }
                                        else
                                        {
                                            resultBar.BackColor = Color.Red;
                                            richTextBox1.AppendText(
                                                "\r\nCustomer kan niet aangemaakt worden in administratie");
                                            richTextBox1.AppendText("\r\nError: " + cr);
                                        }
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Suppliers":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var x in _suppliers)
                                {
                                    if (x.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        var s = _supplierConverter.ConvertSupplierResponse(x, _session.Office);
                                        var sr = _supplierInterface.Create(s);
                                        Cursor.Current = Cursors.Arrow;
                                        if (sr == "Created")
                                        {
                                            resultBar.BackColor = Color.Chartreuse;
                                            richTextBox1.AppendText(
                                                "\r\nSupplier " + s.Code + " aangemaakt in administratie");
                                        }
                                        else
                                        {
                                            resultBar.BackColor = Color.Red;
                                            richTextBox1.AppendText(
                                                "\r\nSupplier kan niet aangemaakt worden in administratie");
                                            richTextBox1.AppendText("\r\nError: " + sr);
                                        }
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Articles":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var x in _products)
                                {
                                    if (x.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        var a = _articleConverter.ConvertProduct(x, _session.Office, "IN");
                                        var ar = _articleInterface.Create(a);
                                        Cursor.Current = Cursors.Arrow;
                                        if (ar == "Created")
                                        {
                                            resultBar.BackColor = Color.Chartreuse;
                                            richTextBox1.AppendText(
                                                "\r\nProduct " + a.Header.Code + "aangemaakt in administratie");
                                        }
                                        else
                                        {
                                            resultBar.BackColor = Color.Red;
                                            richTextBox1.AppendText(
                                                "\r\nProduct kan niet aangemaakt worden in administratie");
                                            richTextBox1.AppendText("\r\nError: " + ar);
                                        }
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Sales Invoices":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var x in _salesInvoices)
                                {
                                    if (x.InvoiceTypeAndNumber == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        var si = _salesInvoiceConverter.ConvertSalesInvoiceResponse(x, "IN");
                                        var sir = _salesInvoiceInterface.Create(si);
                                        Cursor.Current = Cursors.Arrow;
                                        if (sir == "Created")
                                        {
                                            resultBar.BackColor = Color.Chartreuse;
                                            richTextBox1.AppendText(
                                                "\r\nSales invoice " + si.Header.InvoiceTypeAndNumber +
                                                " aangemaakt in administratie");
                                        }
                                        else
                                        {
                                            resultBar.BackColor = Color.Red;
                                            richTextBox1.AppendText(
                                                "\r\nSales invoice kan niet aangemaakt worden in administratie");
                                            richTextBox1.AppendText("\r\nError: " + sir);
                                        }
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Balance Sheets":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var x in _generalLedgers)
                                {
                                    if (x.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        var gl = _generalLedgerConverter.ConvertGeneralLedgerResponseToBalanceSheet(x, _session.Office);
                                        var glr = _balanceSheetInterface.Create(gl);
                                        Cursor.Current = Cursors.Arrow;
                                        if (glr == "Created")
                                        {
                                            resultBar.BackColor = Color.Chartreuse;
                                            richTextBox1.AppendText(
                                                "\r\nBalance sheet " + gl.Code + " aangemaakt in administratie");
                                        }
                                        else
                                        {
                                            resultBar.BackColor = Color.Red;
                                            richTextBox1.AppendText(
                                                "\r\nBalance sheet kan niet aangemaakt worden in administratie");
                                            richTextBox1.AppendText("\r\nError: " + glr);
                                        }
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Profit and Loss":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var x in _generalLedgers)
                                {
                                    if (x.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        var gl = _generalLedgerConverter.ConvertGeneralLedgerResponseToProfitLoss(x, _session.Office);
                                        var glr = _profitLossInterface.Create(gl);
                                        Cursor.Current = Cursors.Arrow;
                                        if (glr == "Created")
                                        {
                                            resultBar.BackColor = Color.Chartreuse;
                                            richTextBox1.AppendText(
                                                "\r\nProfit and loss " + gl.Code + " aangemaakt in administratie");
                                        }
                                        else
                                        {
                                            resultBar.BackColor = Color.Red;
                                            richTextBox1.AppendText(
                                                "\r\nProfit and loss kan niet aangemaakt worden in administratie");
                                            richTextBox1.AppendText("\r\nError: " + glr);
                                        }
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Cost Centers":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var x in _costCenters)
                                {
                                    if (x.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        var cc = _costCenterConverter.ConvertCostCenterResponse(x, _session.Office);
                                        var ccr = _costCenterInterface.Create(cc);
                                        Cursor.Current = Cursors.Arrow;
                                        if (ccr == "Created")
                                        {
                                            resultBar.BackColor = Color.Chartreuse;
                                            richTextBox1.AppendText(
                                                "\r\nCost center " + cc.Code + " aangemaakt in administratie");
                                        }
                                        else
                                        {
                                            resultBar.BackColor = Color.Red;
                                            richTextBox1.AppendText(
                                                "\r\nCost center kan niet aangemaakt worden in administratie");
                                            richTextBox1.AppendText("\r\nError: " + ccr);
                                        }
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                        }

                        break;
                    case @"Delete":
                        switch (data.Text)
                        {
                            case @"Customers":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var x in _customers)
                                {
                                    if (x.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        var c = _customerConverter.ConvertCustomerResponse(x, _session.Office);
                                        var cr = _customerInterface.Delete(c);
                                        Cursor.Current = Cursors.Arrow;
                                        if (cr == "Deleted")
                                        {
                                            resultBar.BackColor = Color.Chartreuse;
                                            richTextBox1.AppendText(
                                                "\r\nCustomer " + c.Code + " verwijderd uit administratie");
                                        }
                                        else
                                        {
                                            resultBar.BackColor = Color.Red;
                                            richTextBox1.AppendText(
                                                "\r\nCustomer kan niet verwijderd worden uit administratie");
                                            richTextBox1.AppendText("\r\nError: " + cr);
                                        }
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Suppliers":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var x in _suppliers)
                                {
                                    if (x.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        var s = _supplierConverter.ConvertSupplierResponse(x, _session.Office);
                                        var sr = _supplierInterface.Delete(s);
                                        Cursor.Current = Cursors.Arrow;
                                        if (sr == "Deleted")
                                        {
                                            resultBar.BackColor = Color.Chartreuse;
                                            richTextBox1.AppendText(
                                                "\r\nSupplier " + s.Code + " verwijderd uit administratie");
                                        }
                                        else
                                        {
                                            resultBar.BackColor = Color.Red;
                                            richTextBox1.AppendText(
                                                "\r\nSupplier kan niet verwijderd worden uit administratie");
                                            richTextBox1.AppendText("\r\nError: " + sr);
                                        }
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Articles":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var x in _products)
                                {
                                    if (x.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        var a = _articleConverter.ConvertProduct(x, _session.Office, "IN");
                                        var ar = _articleInterface.Delete(a);
                                        Cursor.Current = Cursors.Arrow;
                                        if (ar == "Deleted")
                                        {
                                            resultBar.BackColor = Color.Chartreuse;
                                            richTextBox1.AppendText(
                                                "\r\nProduct " + a.Header.Code + "verwijderd uit administratie");
                                        }
                                        else
                                        {
                                            resultBar.BackColor = Color.Red;
                                            richTextBox1.AppendText(
                                                "\r\nProduct kan niet verwijderd worden uit administratie");
                                            richTextBox1.AppendText("\r\nError: " + ar);
                                        }
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Sales Invoices":
                                richTextBox1.AppendText(
                                    "\r\nSales invoices kunnen niet verwijderd worden in Twinfield");
                                break;
                            case @"Balance Sheets":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var x in _generalLedgers)
                                {
                                    if (x.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        var gl = _generalLedgerConverter.ConvertGeneralLedgerResponseToBalanceSheet(x, _session.Office);
                                        var glr = _balanceSheetInterface.Delete(gl);
                                        Cursor.Current = Cursors.Arrow;
                                        if (glr == "Deleted")
                                        {
                                            resultBar.BackColor = Color.Chartreuse;
                                            richTextBox1.AppendText(
                                                "\r\nBalance sheet " + gl.Code + " verwijderd uit administratie");
                                        }
                                        else
                                        {
                                            resultBar.BackColor = Color.Red;
                                            richTextBox1.AppendText(
                                                "\r\nBalance sheet kan niet verwijderd worden uit administratie");
                                            richTextBox1.AppendText("\r\nError: " + glr);
                                        }
                                    }
                                }

                                richTextBox1.ScrollToCaret();

                                break;
                            case @"Profit and Loss":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var x in _generalLedgers)
                                {
                                    if (x.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        var gl = _generalLedgerConverter.ConvertGeneralLedgerResponseToProfitLoss(x, _session.Office);
                                        var glr = _profitLossInterface.Delete(gl);
                                        Cursor.Current = Cursors.Arrow;
                                        if (glr == "Deleted")
                                        {
                                            resultBar.BackColor = Color.Chartreuse;
                                            richTextBox1.AppendText(
                                                "\r\nProfit and loss " + gl.Code + " verwijderd uit administratie");
                                        }
                                        else
                                        {
                                            resultBar.BackColor = Color.Red;
                                            richTextBox1.AppendText(
                                                "\r\nProfit and loss kan niet verwijderd worden uit administratie");
                                            richTextBox1.AppendText("\r\nError: " + glr);
                                        }
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                            case @"Cost Centers":
                                Cursor.Current = Cursors.WaitCursor;
                                foreach (var x in _costCenters)
                                {
                                    if (x.Code == dataVeld.GetItemText(dataVeld.SelectedItem))
                                    {
                                        var cc = _costCenterConverter.ConvertCostCenterResponse(x, _session.Office);
                                        var ccr = _costCenterInterface.Delete(cc);
                                        Cursor.Current = Cursors.Arrow;
                                        if (ccr == "Deleted")
                                        {
                                            resultBar.BackColor = Color.Chartreuse;
                                            richTextBox1.AppendText(
                                                "\r\nCost center " + cc.Code + " verwijderd uit administratie");
                                        }
                                        else
                                        {
                                            resultBar.BackColor = Color.Red;
                                            richTextBox1.AppendText(
                                                "\r\nCost center kan niet verwijderd worden uit administratie");
                                            richTextBox1.AppendText("\r\nError: " + ccr);
                                        }
                                    }
                                }

                                richTextBox1.ScrollToCaret();
                                break;
                        }

                        break;
                }
            }

            richTextBox1.ScrollToCaret();
        }

        private void data_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            {
                createNew.Enabled = false;
            }

            dataVeld.Enabled = false;
            functieUitvoeren.Enabled = false;
        }

        private void createNew_Click(object sender, EventArgs e)
        {
            switch (data.Text)
            {
                case @"Customers":
                    using (var customerForm = new CustomerForm(_session))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        var result = customerForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            var cust = customerForm.Customer;
                            _customers.Add(cust);
                            richTextBox1.AppendText("\r\nCustomer " + cust.Code + " toegevoegd aan de lijst");
                            dataVeld.Enabled = true;
                            dataVeld.Items.Add(cust);
                            dataVeld.DisplayMember = "Code";
                            dataVeld.SelectedIndex = 0;
                            functieUitvoeren.Enabled = true;
                        }
                    }

                    richTextBox1.ScrollToCaret();
                    break;
                case @"Suppliers":
                    using (var supplierForm = new SupplierForm(_session))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        var result = supplierForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            var sup = supplierForm.Supplier;
                            _suppliers.Add(sup);
                            richTextBox1.AppendText("\r\nSupplier " + sup.Code + " toegevoegd aan de lijst");
                            dataVeld.Enabled = true;
                            dataVeld.Items.Add(sup);
                            dataVeld.DisplayMember = "Code";
                            dataVeld.SelectedIndex = 0;
                            functieUitvoeren.Enabled = true;
                        }
                    }

                    richTextBox1.ScrollToCaret();
                    break;
                case @"Articles":
                    using (var articleForm = new ArticleForm(_session))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        var result = articleForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            var art = articleForm.Product;
                            _products.Add(art);
                            richTextBox1.AppendText("\r\nArticle " + art.Code + " toegevoegd aan de lijst");
                            dataVeld.Enabled = true;
                            dataVeld.Items.Add(art);
                            dataVeld.DisplayMember = "Code";
                            dataVeld.SelectedIndex = 0;
                            functieUitvoeren.Enabled = true;
                        }
                    }

                    richTextBox1.ScrollToCaret();
                    break;
                case @"Sales Invoices":
                    using (var salesInvoiceForm = new SalesInvoiceForm(_session))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        var result = salesInvoiceForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            var si = salesInvoiceForm.SalesInvoice;
                            _salesInvoices.Add(si);
                            richTextBox1.AppendText("\r\nSales invoice " + si.InvoiceTypeAndNumber +
                                                    " toegevoegd aan de lijst");
                            dataVeld.Enabled = true;
                            dataVeld.Items.Add(si);
                            dataVeld.DisplayMember = "InvoiceTypeAndNumber";
                            dataVeld.SelectedIndex = 0;
                            functieUitvoeren.Enabled = true;
                        }
                    }

                    richTextBox1.ScrollToCaret();
                    break;
                case @"Balance Sheets":
                    using (var generalLedgerForm = new GeneralLedgerForm(_session, "BAS"))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        var result = generalLedgerForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            var gl = generalLedgerForm.GeneralLedger;
                            _generalLedgers.Add(gl);
                            richTextBox1.AppendText("\r\nBalance sheet " + gl.Code + " toegevoegd aan de lijst");
                            dataVeld.Enabled = true;
                            dataVeld.Items.Add(gl);
                            dataVeld.DisplayMember = "Code";
                            dataVeld.SelectedIndex = 0;
                            functieUitvoeren.Enabled = true;
                        }
                    }

                    richTextBox1.ScrollToCaret();
                    break;
                case @"Profit and Loss":
                    using (var generalLedgerForm = new GeneralLedgerForm(_session, "PNL"))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        var result = generalLedgerForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            var gl = generalLedgerForm.GeneralLedger;
                            _generalLedgers.Add(gl);
                            richTextBox1.AppendText("\r\nProit and loss " + gl.Code + " toegevoegd aan de lijst");
                            dataVeld.Enabled = true;
                            dataVeld.Items.Add(gl);
                            dataVeld.DisplayMember = "Code";
                            dataVeld.SelectedIndex = 0;
                            functieUitvoeren.Enabled = true;
                        }
                    }

                    richTextBox1.ScrollToCaret();
                    break;
                case @"Cost Centers":
                    using (var costCenterForm = new CostCenterForm(_session))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        var result = costCenterForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            var cc = costCenterForm.CostCenter;
                            _costCenters.Add(cc);
                            richTextBox1.AppendText("\r\nCost center " + cc.Code + " toegevoegd aan de lijst");
                            dataVeld.Enabled = true;
                            dataVeld.Items.Add(cc);
                            dataVeld.DisplayMember = "Code";
                            dataVeld.SelectedIndex = 0;
                            functieUitvoeren.Enabled = true;
                        }
                    }

                    richTextBox1.ScrollToCaret();
                    break;
            }
        }

        private void info_Click(object sender, EventArgs e)
        {
            Form info = new ConsoleLarge(richTextBox1);
            info.Show();
        }
    }
}