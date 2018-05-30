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
using DemoConnector.TwinfieldAPI.Data.Extras.Countries;
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;

namespace TestApplicatie.InputForms
{
    public partial class SupplierForm : Form
    {
        public SupplierResponse Supplier { get; set; }
        private readonly IApiSummaryBase _countryInterface;
        private readonly IDimensionTypeInterface _dimensionTypeInterface;

        public SupplierForm(Session session)
        {
            _countryInterface = new CountryOperations(session);
            _dimensionTypeInterface = new DimensionTypeOperations(session);
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            var countries = _countryInterface.GetAll().OrderBy(o=>o.Name).ToList();
            countryBox.DataSource = countries;
            countryBox.DropDownStyle = ComboBoxStyle.DropDownList;
            countryBox.DisplayMember = "Name";
            countryBox.SelectedIndex = countryBox.FindStringExact("Nederland");
            var types = _dimensionTypeInterface.GetByName("CRD");
            maskBox.Text = @"**Code moet voldoen aan het volgende format : " + types[0].Mask;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Cursor.Current = Cursors.Arrow;
        }

        private void toevoegen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(codeBox.Text) || !string.IsNullOrWhiteSpace(nameBox.Text) ||
                !string.IsNullOrWhiteSpace(banknameBox.Text) || !string.IsNullOrWhiteSpace(holderBox.Text) ||
                !string.IsNullOrWhiteSpace(numberBox.Text)) 
            {
                var countries = _countryInterface.GetByName(countryBox.Text);
                var countryName = string.Empty;
                var countryCode = string.Empty;
                foreach (var c in countries)
                {
                    countryName = c.Name;
                    countryCode = c.Code;
                }
                this.Supplier = new SupplierResponse
                {
                    Code = codeBox.Text,
                    Name = nameBox.Text,
                };
                this.Supplier.Addresses.General = new PostalAddress
                {
                    Address1 = addressBox.Text,
                    City = cityBox.Text,
                    Country = { Name = countryName, Code = countryCode },
                    ZipCode = zipBox.Text
                };
                this.Supplier.Bank.Name = banknameBox.Text;
                this.Supplier.Bank.AccountHolder = holderBox.Text;
                this.Supplier.Bank.AccountNumber = numberBox.Text;
                this.Supplier.Bank.BicCode = bicBox.Text;
                this.Supplier.Bank.Iban = ibanBox.Text;
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
