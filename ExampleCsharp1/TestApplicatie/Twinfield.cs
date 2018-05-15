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
using DemoConnector.TwinfieldAPI.Data.Customers;
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
        private readonly ICustomerInterface _customerInterface;
        private readonly ISupplierInterface _supplierInterface;
        private readonly IGeneralLedgerInterface _generalLedgerInterface;
        private readonly IArticleInterface _articleInterface;
        private readonly ISalesInvoiceInterface _salesInvoiceInterface;
        private readonly ICostCenterInterface _costCenterInterface;
        private readonly ICustomerConverter _customerConverter;
        private readonly ISupplierConverter _supplierConverter;
        private readonly IGeneralLedgerConverter _generalLedgerConverter;
        private readonly IArticleConverter _articleConverter;
        private readonly ISalesInvoiceConverter _salesInvoiceConverter;
        private readonly ICostCenterConverter _costCenterConverter;
        private readonly IMiddlewareData _middlewareData;

        public Twinfield(Session session)
        {
            _customerInterface = new CustomerOperations(session);
            _supplierInterface = new SupplierOperations(session);
            _generalLedgerInterface = new GeneralLedgerOperations(session);
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
                "General Ledgers",
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
            functie.Enabled = false;
            functie.DataSource = new List<string>();
            functieUitvoeren.Enabled = false;
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
            dataVeld.Items.Clear();
            _gegevens?.Clear();
            switch (data.Text)
            {
                case @"Customers":
                    if (!radioButton1.Checked)
                    {
                        richTextBox1.AppendText("\r\nCustomers inladen...");
                        Cursor.Current = Cursors.WaitCursor;
                        foreach (var c in _customerInterface.GetAll())
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
                        if (!dataVeld.Items.Contains(customer))
                        {
                            dataVeld.Items.Add(customer);
                        }
                        richTextBox1.AppendText("\r\nVoorbeeld customer geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string>{"Read", "Create", "Delete"};
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
                        foreach (var s in _supplierInterface.GetAll())
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
                        if (!dataVeld.Items.Contains(supplier))
                        {
                            dataVeld.Items.Add(supplier);
                        }
                        richTextBox1.AppendText("\r\nVoorbeeld supplier geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string>{"Read", "Create", "Delete"};
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
                        foreach (var a in _articleInterface.GetAll())
                        {
                            if (!dataVeld.Items.Contains(a.Header))
                            {
                                _gegevens?.Add(a.Header);
                                dataVeld.Items.Add(a.Header);
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
                        if (!dataVeld.Items.Contains(article))
                        {
                            dataVeld.Items.Add(article);
                        }
                        richTextBox1.AppendText("\r\nVoorbeeld article geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string>{"Read", "Create", "Delete"};
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
                        if (!dataVeld.Items.Contains(salesInvoice))
                        {
                            dataVeld.Items.Add(salesInvoice);
                        }
                        richTextBox1.AppendText("\r\nVoorbeeld sales invoice geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string>{"Read", "Create"};
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "InvoiceTypeAndNumber";
                    }

                    richTextBox1.ScrollToCaret();
                    break;
                case @"General Ledgers":
                    richTextBox1.AppendText("\r\nGeneral ledgers inladen...");
                    Cursor.Current = Cursors.WaitCursor;
                    if (!radioButton1.Checked)
                    {
                        foreach (var g in _generalLedgerInterface.GetAllBalanceSheet())
                        {
                            if (!dataVeld.Items.Contains(g))
                            {
                                _gegevens?.Add(g);
                                dataVeld.Items.Add(g);
                            }
                        }

                        foreach (var g in _generalLedgerInterface.GetAllProfitLoss())
                        {
                            if (!dataVeld.Items.Contains(g))
                            {
                                _gegevens?.Add(g);
                                dataVeld.Items.Add(g);
                            }
                        }

                        richTextBox1.AppendText("\r\nGeneral ledgers geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string> {"Read", "Convert"};
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "Code";
                    }
                    else
                    {
                        richTextBox1.AppendText("\r\nVoorbeeld general ledger inladen...");
                        Cursor.Current = Cursors.WaitCursor;
                        var generalLedger = _middlewareData.GetGeneralLedgerData();
                        if (!dataVeld.Items.Contains(generalLedger))
                        {
                            dataVeld.Items.Add(generalLedger);
                        }
                        richTextBox1.AppendText("\r\nVoorbeeld general ledger geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string>{"Read", "Create", "Delete"};
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "Code";
                    }

                    richTextBox1.ScrollToCaret();
                    break;
                case @"Cost centers":
                    richTextBox1.AppendText("\r\nCost centers inladen...");
                    Cursor.Current = Cursors.WaitCursor;
                    if (!radioButton1.Checked)
                    {
                        foreach (var cc in _costCenterInterface.GetAll())
                        {
                            if (!dataVeld.Items.Contains(cc))
                            {
                                _gegevens?.Add(cc);
                                dataVeld.Items.Add(cc);
                            }
                        }
                        richTextBox1.AppendText("\r\nCost centers geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string>{"Read", "Convert"};
                        functie.DataSource = functies;
                        dataVeld.SelectedIndex = 0;
                        dataVeld.DisplayMember = "Code";
                    }
                    else
                    {
                        richTextBox1.AppendText("\r\nVoorbeeld cost center inladen...");
                        Cursor.Current = Cursors.WaitCursor;
                        var costCenter = _middlewareData.GetCostCenterData();
                        if (!dataVeld.Items.Contains(costCenter))
                        {
                            dataVeld.Items.Add(costCenter);
                        }
                        richTextBox1.AppendText("\r\nVoorbeeld cost center geladen");
                        Cursor.Current = Cursors.Arrow;
                        var functies = new List<string>{"Read", "Create", "Delete"};
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
                            case @"General Ledgers":
                                Cursor.Current = Cursors.WaitCursor;
                                try
                                {
                                    var g = _generalLedgerInterface.ReadProfitLoss(
                                                dataVeld.GetItemText(dataVeld.SelectedItem)) ??
                                            _generalLedgerInterface.ReadBalanceSheet(
                                                dataVeld.GetItemText(dataVeld.SelectedItem));
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

                                break;
                            case @"General Ledgers":
                                try
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    var gl = _generalLedgerInterface.ReadProfitLoss(
                                                 dataVeld.GetItemText(dataVeld.SelectedItem)) ??
                                             _generalLedgerInterface.ReadBalanceSheet(
                                                 dataVeld.GetItemText(dataVeld.SelectedItem));
                                    var glr = _generalLedgerConverter.ConvertGeneralLedger(gl);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nGeneral ledger " + glr.Code + " created in middleware");
                                }
                                catch (Exception exception)
                                {
                                    richTextBox1.AppendText(
                                        "\r\nDe general ledger kan niet geconverteerd worden naar de middleware");
                                    richTextBox1.AppendText("\r\nError: " + exception.Message);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Red;
                                }

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
                                    richTextBox1.AppendText("\r\nCost center kan niet geconverteerd worden naar de middleware");
                                    richTextBox1.AppendText("\r\nError: " + exception.Message);
                                    Cursor.Current = Cursors.Arrow;
                                    resultBar.BackColor = Color.Red;
                                }
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
                                var customer = _middlewareData.GetCustomerData();
                                richTextBox1.AppendText("\r\n" + customer.Name);
                                Cursor.Current = Cursors.Arrow;
                                resultBar.BackColor = Color.Chartreuse;
                                break;
                            case @"Suppliers":
                                Cursor.Current = Cursors.WaitCursor;
                                var supplier = _middlewareData.GetSupplierData();
                                richTextBox1.AppendText("\r\n" + supplier.Name);
                                Cursor.Current = Cursors.Arrow;
                                resultBar.BackColor = Color.Chartreuse;
                                break;
                            case @"Articles":
                                Cursor.Current = Cursors.WaitCursor;
                                var product = _middlewareData.GetProductData();
                                richTextBox1.AppendText("\r\n" + product.Description);
                                Cursor.Current = Cursors.Arrow;
                                resultBar.BackColor = Color.Chartreuse;
                                break;
                            case @"Sales Invoices":
                                Cursor.Current = Cursors.WaitCursor;
                                var salesInvoice = _middlewareData.GetSalesInvoiceData();
                                richTextBox1.AppendText("\r\n" + salesInvoice.InvoiceTypeAndNumber);
                                Cursor.Current = Cursors.Arrow;
                                resultBar.BackColor = Color.Chartreuse;
                                break;
                            case @"General Ledgers":
                                Cursor.Current = Cursors.WaitCursor;
                                var generalLedger = _middlewareData.GetGeneralLedgerData();
                                richTextBox1.AppendText("\r\n" + generalLedger.Name);
                                Cursor.Current = Cursors.Arrow;
                                resultBar.BackColor = Color.Chartreuse;
                                break;
                            case @"Cost Centers":
                                Cursor.Current = Cursors.WaitCursor;
                                var costCenter = _middlewareData.GetCostCenterData();
                                richTextBox1.AppendText("\r\n" + costCenter.Name);
                                Cursor.Current = Cursors.Arrow;
                                resultBar.BackColor = Color.Chartreuse;
                                break;
                        }
                        break;
                    case @"Create":
                        switch (data.Text)
                        {
                            case @"Customers":
                                Cursor.Current = Cursors.WaitCursor;
                                var customers = _middlewareData.GetCustomerData();
                                var c = _customerConverter.ConvertCustomerResponse(customers, _session.Office);
                                var cr = _customerInterface.Create(c);
                                Cursor.Current = Cursors.Arrow;
                                if (cr == "Created")
                                {
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nCustomer " + c.Code + " aangemaakt in administratie");
                                }
                                else
                                {
                                    resultBar.BackColor = Color.Red;
                                    richTextBox1.AppendText("\r\nCustomer kan niet aangemaakt worden in administratie");
                                    richTextBox1.AppendText("\r\nError: " + cr);
                                }
                                break;
                            case @"Suppliers":
                                Cursor.Current = Cursors.WaitCursor;
                                var suppliers = _middlewareData.GetSupplierData();
                                var s = _supplierConverter.ConvertSupplierResponse(suppliers, _session.Office);
                                var sr = _supplierInterface.Create(s);
                                Cursor.Current = Cursors.Arrow;
                                if (sr == "Created")
                                {
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nSupplier " + s.Code + " aangemaakt in administratie");
                                }
                                else
                                {
                                    resultBar.BackColor = Color.Red;
                                    richTextBox1.AppendText("\r\nSupplier kan niet aangemaakt worden in administratie");
                                    richTextBox1.AppendText("\r\nError: " + sr);
                                }
                                break;
                            case @"Articles":
                                Cursor.Current = Cursors.WaitCursor;
                                var products = _middlewareData.GetProductData();
                                var a = _articleConverter.ConvertProduct(products, _session.Office, "IN");
                                var ar = _articleInterface.Create(a);
                                Cursor.Current = Cursors.Arrow;
                                if (ar == "Created")
                                {
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nProduct " + a.Header.Code + "aangemaakt in administratie");
                                }
                                else
                                {
                                    resultBar.BackColor = Color.Red;
                                    richTextBox1.AppendText("\r\nProduct kan niet aangemaakt worden in administratie");
                                    richTextBox1.AppendText("\r\nError: " + ar);
                                }
                                break;
                            case @"Sales Invoices":
                                Cursor.Current = Cursors.WaitCursor;
                                var salesInvoices = _middlewareData.GetSalesInvoiceData();
                                var si = _salesInvoiceConverter.ConvertSalesInvoiceResponse(salesInvoices, "IN");
                                var sir = _salesInvoiceInterface.Create(si);
                                Cursor.Current = Cursors.Arrow;
                                if (sir == "Created")
                                {
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nSales invoice " + si.Header.InvoiceTypeAndNumber + " aangemaakt in administratie");
                                }
                                else
                                {
                                    resultBar.BackColor = Color.Red;
                                    richTextBox1.AppendText("\r\nSales invoice kan niet aangemaakt worden in administratie");
                                    richTextBox1.AppendText("\r\nError: " + sir);
                                }
                                break;
                            case @"General Ledgers":
                                Cursor.Current = Cursors.WaitCursor;
                                var generalLedgers = _middlewareData.GetGeneralLedgerData();
                                var gl = _generalLedgerConverter.ConvertGeneralLedgerResponse(generalLedgers,
                                    _session.Office);
                                var glr = _generalLedgerInterface.Create(gl);
                                Cursor.Current = Cursors.Arrow;
                                if (glr == "Created")
                                {
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nGeneral ledger " + gl.Code + " aangemaakt in administratie");
                                }
                                else
                                {
                                    resultBar.BackColor = Color.Red;
                                    richTextBox1.AppendText("\r\nGeneral ledger kan niet aangemaakt worden in administratie");
                                    richTextBox1.AppendText("\r\nError: " + glr);
                                }
                                break;
                            case @"Cost Centers":
                                Cursor.Current = Cursors.WaitCursor;
                                var costCenter = _middlewareData.GetCostCenterData();
                                var cc = _costCenterConverter.ConvertCostCenterResponse(costCenter, _session.Office);
                                var ccr = _costCenterInterface.Create(cc);
                                Cursor.Current = Cursors.Arrow;
                                if (ccr == "Created")
                                {
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nCost center " + cc.Code + " aangemaakt in administratie");
                                }
                                else
                                {
                                    resultBar.BackColor = Color.Red;
                                    richTextBox1.AppendText("\r\nCost center kan niet aangemaakt worden in administratie");
                                    richTextBox1.AppendText("\r\nError: " + ccr);
                                }
                                break;
                        }
                        break;
                    case @"Delete":
                        switch (data.Text)
                        {
                            case @"Customers":
                                Cursor.Current = Cursors.WaitCursor;
                                var customers = _middlewareData.GetCustomerData();
                                var c = _customerConverter.ConvertCustomerResponse(customers, _session.Office);
                                var cr = _customerInterface.Delete(c);
                                Cursor.Current = Cursors.Arrow;
                                if (cr == "Deleted")
                                {
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nCustomer " + c.Code + " verwijderd uit administratie");
                                }
                                else
                                {
                                    resultBar.BackColor = Color.Red;
                                    richTextBox1.AppendText("\r\nCustomer kan niet verwijderd worden uit administratie");
                                    richTextBox1.AppendText("\r\nError: " + cr);
                                }
                                break;
                            case @"Suppliers":
                                Cursor.Current = Cursors.WaitCursor;
                                var suppliers = _middlewareData.GetSupplierData();
                                var s = _supplierConverter.ConvertSupplierResponse(suppliers, _session.Office);
                                var sr = _supplierInterface.Delete(s);
                                Cursor.Current = Cursors.Arrow;
                                if (sr == "Deleted")
                                {
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nSupplier " + s.Code + " verwijderd uit administratie");
                                }
                                else
                                {
                                    resultBar.BackColor = Color.Red;
                                    richTextBox1.AppendText("\r\nSupplier kan niet verwijderd worden uit administratie");
                                    richTextBox1.AppendText("\r\nError: " + sr);
                                }
                                break;
                            case @"Articles":
                                Cursor.Current = Cursors.WaitCursor;
                                var products = _middlewareData.GetProductData();
                                var a = _articleConverter.ConvertProduct(products, _session.Office, "IN");
                                var ar = _articleInterface.Delete(a);
                                Cursor.Current = Cursors.Arrow;
                                if (ar == "Deleted")
                                {
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nProduct " + a.Header.Code + "verwijderd uit administratie");
                                }
                                else
                                {
                                    resultBar.BackColor = Color.Red;
                                    richTextBox1.AppendText("\r\nProduct kan niet verwijderd worden uit administratie");
                                    richTextBox1.AppendText("\r\nError: " + ar);
                                }
                                break;
                            case @"Sales Invoices":
                                richTextBox1.AppendText("\r\nSales invoices kunnen niet verwijderd worden in Twinfield");
                                break;
                            case @"General Ledgers":
                                Cursor.Current = Cursors.WaitCursor;
                                var generalLedgers = _middlewareData.GetGeneralLedgerData();
                                var gl = _generalLedgerConverter.ConvertGeneralLedgerResponse(generalLedgers,
                                    _session.Office);
                                var glr = _generalLedgerInterface.Delete(gl);
                                Cursor.Current = Cursors.Arrow;
                                if (glr == "Deleted")
                                {
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nGeneral ledger " + gl.Code + " verwijderd uit administratie");
                                }
                                else
                                {
                                    resultBar.BackColor = Color.Red;
                                    richTextBox1.AppendText("\r\nGeneral ledger kan niet verwijderd worden uit administratie");
                                    richTextBox1.AppendText("\r\nError: " + glr);
                                }
                                break;
                            case @"Cost Centers":
                                Cursor.Current = Cursors.WaitCursor;
                                var costCenter = _middlewareData.GetCostCenterData();
                                var cc = _costCenterConverter.ConvertCostCenterResponse(costCenter, _session.Office);
                                var ccr = _costCenterInterface.Delete(cc);
                                Cursor.Current = Cursors.Arrow;
                                if (ccr == "Deleted")
                                {
                                    resultBar.BackColor = Color.Chartreuse;
                                    richTextBox1.AppendText("\r\nCost center " + cc.Code + " verwijderd uit administratie");
                                }
                                else
                                {
                                    resultBar.BackColor = Color.Red;
                                    richTextBox1.AppendText("\r\nCost center kan niet verwijderd worden uit administratie");
                                    richTextBox1.AppendText("\r\nError: " + ccr);
                                }
                                break;
                        }
                        break;
                }
            }

            richTextBox1.ScrollToCaret();
        }

        private void data_SelectedIndexChanged(object sender, EventArgs e)
        {
            createNew.Enabled = false;
            dataVeld.Enabled = false;
            functie.Enabled = false;
            functieUitvoeren.Enabled = false;
        }

        private void createNew_Click(object sender, EventArgs e)
        {
            if (functie.Text == @"Create" || functie.Text == @"Delete")
            {
                using (var customerForm = new CustomerForm())
                {
                    var result = customerForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        var val = customerForm.CustomerName;
                        richTextBox1.AppendText("\r\n" + val);
                    }
                }



//                Form customerForm = new CustomerForm();
//                DialogResult dialogResult = customerForm.ShowDialog();
//                if (dialogResult == DialogResult.OK)
//                {
//                    richTextBox1.AppendText("\r\nGeklikt op toevoegen");
//                    richTextBox1.AppendText("Customer name = " + customerForm.);
//                }
//
//                if (dialogResult == DialogResult.Cancel)
//                {
//                    richTextBox1.AppendText("\r\nGeklikt op annuleren");
//                }
//                dataVeld.Enabled = false;
            }
            else
            {
                richTextBox1.AppendText("\r\nOm een nieuw veld toe te voegen moet de functie 'Create' of 'Delete' geselecteerd zijn");
            }
        }
    }
}