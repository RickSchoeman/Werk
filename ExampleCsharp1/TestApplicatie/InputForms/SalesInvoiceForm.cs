using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoConnector.Middleware;
using DemoConnector.TwinfieldAPI.Converters.Interfaces;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.Articles;
using DemoConnector.TwinfieldAPI.Data.Customers;
using DemoConnector.TwinfieldAPI.Data.Extras.InvoiceTypes;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;

namespace TestApplicatie.InputForms
{
    public partial class SalesInvoiceForm : Form
    {
        public SalesInvoiceResponse SalesInvoice { get; set; }
        private readonly IApiOperationsBase<Customer> _customerInterface;
        private readonly IArticleInterface _articleInterface;
        private readonly ICurrencyInterface _currencyInterface;
        private readonly IVatInterface _vatInterface;
        private readonly IApiSummaryBase _invoiceTypeInterface;
        public SalesInvoiceForm(Session session)
        {
            _customerInterface = new CustomerOperations(session);
            _articleInterface = new ArticleOperations(session);
            _currencyInterface = new CurrencyOperations(session);
            _vatInterface = new VatOperations(session);
            _invoiceTypeInterface = new InvoiceTypeOperations(session);
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            var custs = _customerInterface.GetSummaries();
            customerBox.DataSource = custs;
            customerBox.DropDownStyle = ComboBoxStyle.DropDownList;
            customerBox.DisplayMember = "Code";
            var curs = _currencyInterface.GetAll();
            currencyBox.DataSource = curs;
            currencyBox.DropDownStyle = ComboBoxStyle.DropDownList;
            currencyBox.DisplayMember = "Code";
            var arts = _articleInterface.GetSummaries();
            var articles = new List<object>();
            foreach (var a in arts)
            {
                articles.Add(a);
            }
            articleBox.DataSource = articles;
            articleBox.DropDownStyle = ComboBoxStyle.DropDownList;
            articleBox.DisplayMember = "Code";
            var vats = _vatInterface.GetSummaries();
            vatBox.DataSource = vats;
            vatBox.DropDownStyle = ComboBoxStyle.DropDownList;
            vatBox.DisplayMember = "Code";
            var types = _invoiceTypeInterface.GetAll();
            typeBox.DataSource = types;
            typeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            typeBox.DisplayMember = "Code";
            var subarts = _articleInterface.GetSubArticlesByArticle(articleBox.GetItemText(articleBox.SelectedItem));
            subarticleBox.DataSource = subarts;
            subarticleBox.DropDownStyle = ComboBoxStyle.DropDownList;
            subarticleBox.DisplayMember = "Code";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Cursor.Current = Cursors.Arrow;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var subarts = _articleInterface.GetSubArticlesByArticle(articleBox.GetItemText(articleBox.SelectedItem));
            subarticleBox.DataSource = subarts;
            subarticleBox.DropDownStyle = ComboBoxStyle.DropDownList;
            subarticleBox.DisplayMember = "Code";
        }

        private void toevoegen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(customerBox.GetItemText(customerBox.SelectedItem)) || !string.IsNullOrWhiteSpace(typeBox.GetItemText(typeBox.SelectedItem)) || !string.IsNullOrWhiteSpace(unitsBox.Text) || !string.IsNullOrWhiteSpace(currencyBox.GetItemText(currencyBox.SelectedItem)) || !string.IsNullOrWhiteSpace(quantityBox.Text) || !string.IsNullOrWhiteSpace(vatBox.GetItemText(vatBox.SelectedItem)) || !string.IsNullOrWhiteSpace(articleBox.GetItemText(articleBox.SelectedItem)) || !string.IsNullOrWhiteSpace(subarticleBox.GetItemText(subarticleBox.SelectedItem)))
            {
                this.SalesInvoice = new SalesInvoiceResponse
                {
                    CustomerId = customerBox.GetItemText(customerBox.SelectedItem),
                    CustomerReference = customerBox.GetItemText(customerBox.SelectedItem),
                    OrderType = typeBox.GetItemText(typeBox.SelectedItem)
                };
                var sl = new SalesInvoiceLine
                {
                    Amount = decimal.Parse(unitsBox.Text),
                    Currency = currencyBox.GetItemText(currencyBox.SelectedItem),
                    Quantity = decimal.Parse(quantityBox.Text),
                    VatType = vatBox.GetItemText(vatBox.SelectedItem),
                    Article = articleBox.GetItemText(articleBox.SelectedItem),
                    Subarticle = subarticleBox.GetItemText(subarticleBox.SelectedItem)
                };
                var sll = new List<SalesInvoiceLine>();
                sll.Add(sl);
                this.SalesInvoice.SalesInvoiceLines.SalesInvoiceLine = sll;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(@"Vul alle verplichte velden in");
            }
        }

        private void annuleren_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
