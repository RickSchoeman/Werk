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
using DemoConnector.TwinfieldAPI.Data.Customers;
using DemoConnector.TwinfieldAPI.Data.Relations;

namespace TestApplicatie.InputForms
{
    public partial class CustomerForm : Form
    {
        public CustomerResponse Customer { get; set; }


        public CustomerForm()
        {
            InitializeComponent();
        }

        private void toevoegen_Click(object sender, EventArgs e)
        {
            this.Customer = new CustomerResponse
            {
                Code = codeBox.Text,
                Name = nameBox.Text
            };
            this.Customer.Addresses.General = new PostalAddress
            {
                Address1 = addressBox.Text,
                City = cityBox.Text,
                Country = { },
                ZipCode = zipBox.Text
            };
            this.Customer.Bank.Name = bankNameBox.Text;
            this.Customer.Bank.AccountHolder = accountholderBox.Text;
            this.Customer.Bank.AccountNumber = accountnumberBox.Text;
            this.Close();
        }

        private void annuleren_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
