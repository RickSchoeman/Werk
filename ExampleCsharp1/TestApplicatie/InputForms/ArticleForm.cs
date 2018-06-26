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
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Data.BalanceSheet;
using DemoConnector.TwinfieldAPI.Data.CostCenters;
using DemoConnector.TwinfieldAPI.Data.ProfitLoss;
using DemoConnector.TwinfieldAPI.Data.Suppliers;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;

namespace TestApplicatie.InputForms
{
    public partial class ArticleForm : Form
    {
        public Product Product { get; set; }
        private readonly IApiOperationsBase<Supplier> _supplierInterface;
        private readonly IApiOperationsBase<BalanceSheet> _balanceSheetInterface;
        private readonly IApiOperationsBase<ProfitLoss> _profitLossInterface;
        private readonly IApiOperationsBase<CostCenter> _costCenterInterface;
        private readonly IVatInterface _vatInterface;

        public ArticleForm(Session session)
        {
            _supplierInterface = new SupplierOperations(session);
            _balanceSheetInterface = new BalanceSheetOperations(session);
            _profitLossInterface = new ProfitLossOperations(session);
            _costCenterInterface = new CostCenterOperatons(session);
            _vatInterface = new VatOperations(session);
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            var sups = _supplierInterface.GetSummaries();
            supplierBox.DataSource = sups;
            supplierBox.DropDownStyle = ComboBoxStyle.DropDownList;
            supplierBox.DisplayMember = "Code";

            foreach (var g in _profitLossInterface.GetSummaries())
            {
                if (!ledgerBox.Items.Contains(g))
                {
                    ledgerBox.Items.Add(g);
                }
            }

            ledgerBox.DisplayMember = "Code";
            ledgerBox.SelectedIndex = 0;
            ledgerBox.DropDownStyle = ComboBoxStyle.DropDownList;
            var ccs = _costCenterInterface.GetSummaries();
            centerBox.DataSource = ccs;
            centerBox.DropDownStyle = ComboBoxStyle.DropDownList;
            centerBox.DisplayMember = "Code";
            var vats = _vatInterface.GetSummaries();
            vatBox.DataSource = vats;
            vatBox.DropDownStyle = ComboBoxStyle.DropDownList;
            vatBox.DisplayMember = "Code";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Cursor.Current = Cursors.Arrow;
        }

        private void toevoegen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(codeBox.Text) || !string.IsNullOrWhiteSpace(nameBox.Text) || !string.IsNullOrWhiteSpace(priceBox.Text) || !string.IsNullOrWhiteSpace(unitBox.Text) || string.IsNullOrWhiteSpace(supplierBox.GetItemText(supplierBox.SelectedItem)))
            {
                this.Product = new Product
                {
                    Code = codeBox.Text,
                    Description = nameBox.Text,
                    SalesPrice = priceBox.Text,
                    BestelEenheid = decimal.Parse(unitBox.Text),
                    SupplierCode = supplierBox.GetItemText(supplierBox.SelectedItem),
                    Grootboek = ledgerBox.Text
                };
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
