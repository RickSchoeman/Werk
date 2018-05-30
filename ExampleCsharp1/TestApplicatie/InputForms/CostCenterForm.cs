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
using DemoConnector.TwinfieldAPI.Handlers;
using DemoConnector.TwinfieldAPI.Handlers.Interfaces;

namespace TestApplicatie.InputForms
{
    public partial class CostCenterForm : Form
    {
        public CostCenterResponse CostCenter { get; set; }
        private readonly IDimensionTypeInterface _dimensionTypeInterface;

        public CostCenterForm(Session session)
        {
            _dimensionTypeInterface = new DimensionTypeOperations(session);
            InitializeComponent();
            Cursor.Current = Cursors.Arrow;
            var types = _dimensionTypeInterface.GetByName("KPL");
            maskBox.Text = @"**Code moet voldoen aan het volgende format : " + types[0].Mask;
            Cursor.Current = Cursors.Arrow;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void toevoegen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(codeBox.Text) || !string.IsNullOrWhiteSpace(nameBox.Text))
            {
                this.CostCenter = new CostCenterResponse
                {
                    Code = codeBox.Text,
                    Name = nameBox.Text,
                    Website = websiteBox.Text
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
