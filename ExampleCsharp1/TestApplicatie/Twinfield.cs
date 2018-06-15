using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
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
using TestApplicatie.Functies;
using TestApplicatie.InputForms;
using TestApplicatie.Interfaces;
using TestApplicatie.Xml;

namespace TestApplicatie
{
    public partial class Twinfield : Form
    {
        private readonly Session _session;
        public List<object> Gegevens = new List<object>();
        private readonly IApiOperationsBase<Customer> _customerInterface;
        private readonly IApiOperationsBase<Supplier> _supplierInterface;
        private readonly IArticleInterface _articleInterface;
        private readonly IApiOperationsBase<BalanceSheet> _balanceSheetInterface;
        private readonly IApiOperationsBase<ProfitLoss> _profitLossInterface;
        private readonly ISalesInvoiceInterface _salesInvoiceInterface;
        private readonly IApiOperationsBase<CostCenter> _costCenterInterface;
        private readonly IMiddlewareData _middlewareData;
        private readonly DataFunctions _ldf;
        public class ComboxItem<T>
        {
            public ComboxItem(T value, Func<T, string> displayValue)
            {
                DisplayValue = displayValue(value);
                Value = value;
            }

            public override string ToString()
            {
                return DisplayValue;
            }

            public string DisplayValue { get; set; }

            public T Value { get; set; }
        }

        public enum DataTypeEnum
        {
            Customers,
            Suppliers,
            Articles,
            SalesInvoices,
            BalanceSheets,
            ProfitAndLoss,
            CostCenters
        }

        private const string CustomersText = "Customers";
        private const string SuppliersText = "Suppliers";
        private const string ArticlesText = "Articles";
        private const string SalesInvoicesText = "Sales Invoices";
        private const string BalanceSheetsText = "Balance Sheets";
        private const string ProfitAndLossText = "Profit and Loss";
        private const string CostCentersText = "Cost Centers";

        private static string DataTypeDisplayName(DataTypeEnum value)
        {
            switch (value)
            {
                case DataTypeEnum.Customers: return CustomersText;
                case DataTypeEnum.Suppliers: return SuppliersText;
                case DataTypeEnum.Articles: return ArticlesText;
                case DataTypeEnum.SalesInvoices: return SalesInvoicesText;
                case DataTypeEnum.BalanceSheets: return BalanceSheetsText;
                case DataTypeEnum.ProfitAndLoss: return ProfitAndLossText;
                case DataTypeEnum.CostCenters: return CostCentersText;
                default: return value.ToString();
            }
        }


        public Twinfield(Session session)
        {
            _customerInterface = new CustomerOperations(session);
            _supplierInterface = new SupplierOperations(session);
            _balanceSheetInterface = new BalanceSheetOperations(session);
            _profitLossInterface = new ProfitLossOperations(session);
            _articleInterface = new ArticleOperations(session);
            _salesInvoiceInterface = new SalesInvoiceOperations(session);
            _costCenterInterface = new CostCenterOperatons(session);
            _middlewareData = new MiddlewareData();
            _session = session;
            InitializeComponent();

            var dataList = new List<ComboxItem<DataTypeEnum>>();

            foreach (var item in Enum.GetValues(typeof(DataTypeEnum)))
            {
                dataList.Add(new ComboxItem<DataTypeEnum>((DataTypeEnum) item, DataTypeDisplayName));
            }

            var functies = new List<string> {"None"};
            dataVeld.DropDownStyle = ComboBoxStyle.DropDownList;
            DataComboBox.DataSource = dataList;
            DataComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            functie.DataSource = functies;
            functie.DropDownStyle = ComboBoxStyle.DropDownList;
            radioButton1.Checked = false;
            radioButton2.Checked = true;
            textBox1.Text = @"Middleware";
            LogBox.Text = @"Administratie " + _session.Office + @" geladen";
            functieUitvoeren.Enabled = false;
            dataVeld.Enabled = false;
            functie.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            _ldf = new DataFunctions(this, _session);
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
            SetFunctions(FunctionEnum.Read, FunctionEnum.Create, FunctionEnum.Delete);
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
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dataVeld.Items.Clear();
                Gegevens?.Clear();
                
                switch (DataComboBox.Text)
                {
                    case CustomersText:
                        if (!radioButton1.Checked)
                        {
                            _ldf.LoadDataItems("Code", "Customers", _customerInterface.GetSummaries());
                            SetFunctions(FunctionEnum.Read, FunctionEnum.Convert);
                        }
                        else
                        {
                            _ldf.LoadDataItems("Code", "Voorbeeld customers", _middlewareData.GetCustomerData());
                            SetFunctions(FunctionEnum.Read, FunctionEnum.Create, FunctionEnum.Delete);
                        }

                        LogBox.ScrollToCaret();
                        break;
                    case SuppliersText:
                        if (!radioButton1.Checked)
                        {
                            _ldf.LoadDataItems("Code", "Suppliers", _supplierInterface.GetSummaries());
                            SetFunctions(FunctionEnum.Read, FunctionEnum.Convert);
                        }
                        else
                        {
                            _ldf.LoadDataItems("Code", "Voorbeeld suppliers", _middlewareData.GetSupplierData());
                            SetFunctions(FunctionEnum.Read, FunctionEnum.Create, FunctionEnum.Delete);
                        }

                        LogBox.ScrollToCaret();
                        break;
                    case ArticlesText:
                        if (!radioButton1.Checked)
                        {
                            _ldf.LoadDataItems("Code", "Articles", _articleInterface.GetSummaries());
                            SetFunctions(FunctionEnum.Read, FunctionEnum.Convert);
                        }
                        else
                        {
                            _ldf.LoadDataItems("Code", "Voorbeeld articles", _middlewareData.GetProductData());
                            SetFunctions(FunctionEnum.Read, FunctionEnum.Create, FunctionEnum.Delete);
                        }

                        LogBox.ScrollToCaret();
                        break;
                    case SalesInvoicesText:
                        if (!radioButton1.Checked)
                        {
                            LogBox.AppendText("\r\nSales invoices inladen...");
                            foreach (var s in _salesInvoiceInterface.GetAll())
                            {
                                if (!dataVeld.Items.Contains(s.Header))
                                {
                                    Gegevens?.Add(s.Header);
                                    dataVeld.Items.Add(s.Header);
                                }
                            }

                            dataVeld.SelectedIndex = 0;
                            dataVeld.DisplayMember = "InvoiceTypeAndNumber";
                            LogBox.AppendText("\r\nSales invoices geladen");
                            SetFunctions(FunctionEnum.Read, FunctionEnum.Convert);
                        }
                        else
                        {
                            _ldf.LoadDataItems("InvoiceTypeAndNumber", "Voorbeeld sales invoice",
                                _middlewareData.GetSalesInvoiceData());
                            SetFunctions(FunctionEnum.Read, FunctionEnum.Create);
                        }

                        LogBox.ScrollToCaret();
                        break;
                    case BalanceSheetsText:
                        if (!radioButton1.Checked)
                        {
                            _ldf.LoadDataItems("Code", "Balance sheets", _balanceSheetInterface.GetSummaries());
                            SetFunctions(FunctionEnum.Read, FunctionEnum.Convert);
                        }
                        else
                        {
                            _ldf.LoadDataItems("Code", "Voorbeels balance sheets", _middlewareData.GetBalanceSheetData());
                            SetFunctions(FunctionEnum.Read, FunctionEnum.Create, FunctionEnum.Delete);
                        }

                        LogBox.ScrollToCaret();
                        break;
                    case ProfitAndLossText:
                        if (!radioButton1.Checked)
                        {
                            _ldf.LoadDataItems("Code", "Profit and loss", _profitLossInterface.GetSummaries());
                            SetFunctions(FunctionEnum.Read, FunctionEnum.Convert);
                        }
                        else
                        {
                            _ldf.LoadDataItems("Code", "Voorbeeld profit and loss", _middlewareData.GetProfitAndLossData());
                            SetFunctions(FunctionEnum.Read, FunctionEnum.Create, FunctionEnum.Delete);
                        }

                        LogBox.ScrollToCaret();
                        break;
                    case CostCentersText:
                        if (!radioButton1.Checked)
                        {
                            _ldf.LoadDataItems("Code", "Cost centers", _costCenterInterface.GetSummaries());
                            SetFunctions(FunctionEnum.Read, FunctionEnum.Convert);
                        }
                        else
                        {
                            _ldf.LoadDataItems("Code", "Voorbeeld cost center", _middlewareData.GetCostCenterData());
                            SetFunctions(FunctionEnum.Read, FunctionEnum.Create, FunctionEnum.Delete);
                        }

                        LogBox.ScrollToCaret();
                        break;
                }

                LogBox.ScrollToCaret();
                functie.Enabled = true;
                functieUitvoeren.Enabled = true;
                dataVeld.Enabled = true;
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        public enum FunctionEnum
        {
            Read,
            Delete,
            Convert,
            Create,
        }

        private void SetFunctions(params FunctionEnum[] functions)
        {
            var functies = new List<string>(functions.Select(s => s.ToString()));
            functie.DataSource = functies;
        }

        public enum DataChangeTypes
        {
            Create,
            Delete
        }

        private void functieUitvoeren_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!radioButton1.Checked)
            {
                switch (functie.Text)
                {
                    case @"Read":

                        try
                        {
                            switch (DataComboBox.Text)
                            {
                                case CustomersText:
                                    _ldf.LoadData(_customerInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem)));
                                    break;
                                case SuppliersText:
                                    _ldf.LoadData(_supplierInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem)));
                                    break;
                                case ArticlesText:
                                    _ldf.LoadData(_articleInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem)));
                                    break;
                                case SalesInvoicesText:
                                    var data = dataVeld.GetItemText(dataVeld.SelectedItem);
                                    string[] items = data.Split(',');
                                    _ldf.LoadData(_salesInvoiceInterface.Read(items[1], items[0]));
                                    break;
                                case BalanceSheetsText:
                                    _ldf.LoadData(_balanceSheetInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem)));
                                    break;
                                case ProfitAndLossText:
                                    _ldf.LoadData(_profitLossInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem)));
                                    break;
                                case CostCentersText:
                                    _ldf.LoadData(_costCenterInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem)));
                                    break;
                            }

                            this.Cursor = Cursors.Arrow;
                            break;
                        }
                        catch (Exception ex)
                        {
                            this.Cursor = Cursors.Arrow;
                            resultBar.BackColor = Color.Red;
                            LogBox.AppendText("\r\nDe data kan niet gelezen worden");
                            LogBox.AppendText("\r\nError: " + ex.Message);
                            break;
                        }
                    case @"Convert":
                        try
                        {
                            switch (DataComboBox.Text)
                            {
                                case CustomersText:
                                    _ldf.ConvertData(_customerInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem)));
                                    break;
                                case SuppliersText:
                                    _ldf.ConvertData(_supplierInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem)));
                                    break;
                                case ArticlesText:
                                    _ldf.ConvertData(_articleInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem)));
                                    break;
                                case SalesInvoicesText:
                                    var data = dataVeld.GetItemText(dataVeld.SelectedItem);
                                    string[] items = data.Split(',');
                                    _ldf.ConvertData(_salesInvoiceInterface.Read(items[1], items[0]));
                                    break;
                                case BalanceSheetsText:
                                    _ldf.ConvertData(_balanceSheetInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem)));
                                    break;
                                case ProfitAndLossText:
                                    _ldf.ConvertData(_profitLossInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem)));
                                    break;
                                case CostCentersText:
                                    _ldf.ConvertData(_costCenterInterface.Read(dataVeld.GetItemText(dataVeld.SelectedItem)));
                                    break;
                            }
                            break;
                        }
                        catch (Exception exception)
                        {
                            LogBox.AppendText(
                                "\r\nDe data kan niet geconverteerd worden naar de middleware");
                            LogBox.AppendText("\r\nError: " + exception.Message);
                            Cursor.Current = Cursors.Arrow;
                            resultBar.BackColor = Color.Red;
                            break;
                        }
                    case @"None":
                        LogBox.AppendText("\r\nEr moet eerst data ingeladen worden.");
                        break;
                }
            }
            else
            {
                switch (functie.Text)
                {
                    case @"Read":
                        switch (DataComboBox.Text)
                        {
                            case CustomersText:

                                _ldf.LoadDataMiddleware(typeof(CustomerResponse), Gegevens);
                                break;
                            case SuppliersText:
                                _ldf.LoadDataMiddleware(typeof(SupplierResponse), Gegevens);
                                break;
                            case ArticlesText:
                                _ldf.LoadDataMiddleware(typeof(Product), Gegevens);
                                break;
                            case SalesInvoicesText:
                                _ldf.LoadDataMiddleware(typeof(SalesInvoiceResponse), Gegevens);
                                break;
                            case BalanceSheetsText:
                                _ldf.LoadDataMiddleware(typeof(GeneralLedgerResponse), Gegevens);
                                break;
                            case ProfitAndLossText:
                                _ldf.LoadDataMiddleware(typeof(GeneralLedgerResponse), Gegevens);
                                break;
                            case CostCentersText:
                                _ldf.LoadDataMiddleware(typeof(CostCenterResponse), Gegevens);
                                break;
                        }

                        break;
                    case @"Create":
                        switch (DataComboBox.Text)
                        {
                            case CustomersText:
                                _ldf.ChangeData(DataChangeTypes.Create, typeof(CustomerResponse), Gegevens);
                                break;
                            case SuppliersText:
                                _ldf.ChangeData(DataChangeTypes.Create, typeof(SupplierResponse), Gegevens);
                                break;
                            case ArticlesText:
                                _ldf.ChangeData(DataChangeTypes.Create, typeof(Product), Gegevens);
                                break;
                            case SalesInvoicesText:
                                _ldf.ChangeData(DataChangeTypes.Create, typeof(SalesInvoiceResponse), Gegevens);
                                break;
                            case BalanceSheetsText:
                                _ldf.ChangeData(DataChangeTypes.Create, typeof(GeneralLedgerResponse), Gegevens);
                                break;
                            case ProfitAndLossText:
                                _ldf.ChangeData(DataChangeTypes.Create, typeof(GeneralLedgerResponse), Gegevens);
                                break;
                            case CostCentersText:
                                _ldf.ChangeData(DataChangeTypes.Create, typeof(CostCenterResponse), Gegevens);
                                break;
                        }

                        break;
                    case @"Delete":
                        switch (DataComboBox.Text)
                        {
                            case CustomersText:
                                _ldf.ChangeData(DataChangeTypes.Delete, typeof(CustomerResponse), Gegevens);
                                break;
                            case SuppliersText:
                                _ldf.ChangeData(DataChangeTypes.Delete, typeof(SupplierResponse), Gegevens);
                                break;
                            case ArticlesText:
                                _ldf.ChangeData(DataChangeTypes.Delete, typeof(Product), Gegevens);
                                break;
                            case SalesInvoicesText:
                                LogBox.AppendText(
                                    "\r\nSales invoices kunnen niet verwijderd worden in Twinfield");
                                break;
                            case BalanceSheetsText:
                                _ldf.ChangeData(DataChangeTypes.Delete, typeof(GeneralLedgerResponse), Gegevens);
                                break;
                            case ProfitAndLossText:
                                _ldf.ChangeData(DataChangeTypes.Delete, typeof(GeneralLedgerResponse), Gegevens);
                                break;
                            case CostCentersText:
                                _ldf.ChangeData(DataChangeTypes.Delete, typeof(CostCenterResponse), Gegevens);
                                break;
                        }
                        break;
                }
            }

            LogBox.ScrollToCaret();
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
            Cursor.Current = Cursors.WaitCursor;
            switch (DataComboBox.Text)
            {
                case CustomersText:
                    _ldf.AddData("code", "Customer", new CustomerForm(_session), typeof(Customer));
                    break;
                case SuppliersText:
                    _ldf.AddData("code", "Supplier", new SupplierForm(_session), typeof(Supplier));
                    break;
                case ArticlesText:
                    _ldf.AddData("code", "Article", new ArticleForm(_session), typeof(Article));
                    break;
                case SalesInvoicesText:
                    _ldf.AddData("InvoiceTypeAndNumber", "Sales invoice", new SalesInvoiceForm(_session), typeof(SalesInvoice));
                    break;
                case BalanceSheetsText:
                    _ldf.AddData("code", "Balance sheet", new GeneralLedgerForm(_session, "BAS"), typeof(GeneralLedger));
                    break;
                case ProfitAndLossText:
                    _ldf.AddData("code", "Profit and loss", new GeneralLedgerForm(_session, "PNL"), typeof(GeneralLedger));
                    break;
                case CostCentersText:
                    _ldf.AddData("code", "Cost center", new CostCenterForm(_session), typeof(CostCenter));
                    break;
            }
        }

        private void info_Click(object sender, EventArgs e)
        {
            Form info = new ConsoleLarge(LogBox);
            info.Show();
        }

        private void results_Click(object sender, EventArgs e)
        {
            var path = Directory.GetDirectories("../../Xml");
            foreach (var p in path)
            {
                if (p.EndsWith("Results"))
                {
                    Process.Start(p);
                }
            }
        }
    }
}