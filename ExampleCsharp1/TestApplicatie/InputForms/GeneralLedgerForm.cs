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
    public partial class GeneralLedgerForm : Form
    {
        public GeneralLedgerResponse GeneralLedger { get; set; }
        private readonly IVatInterface _vatInterface;
        private readonly IDimensionTypeInterface _dimensionTypeInterface;
        public string Type { get; set; }
        public GeneralLedgerForm(Session session, string type)
        {
            _vatInterface = new VatOperations(session);
            _dimensionTypeInterface = new DimensionTypeOperations(session);
            InitializeComponent();
            Cursor.Current = Cursors.WaitCursor;
            var vats = _vatInterface.GetSummaries();
            vatBox.DataSource = vats;
            vatBox.DropDownStyle = ComboBoxStyle.DropDownList;
            vatBox.DisplayMember = "Code";
            var ty = _dimensionTypeInterface.GetByName(type);
            maskBox.Text = @"**Code moet bij type " + type + @" voldoen aan het volgende format: " + ty[0].Mask;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Cursor.Current = Cursors.Arrow;
            Type = type;
        }

        private void toevoegen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(vatBox.GetItemText(vatBox.SelectedItem)) || !string.IsNullOrWhiteSpace(codeBox.Text) || !string.IsNullOrWhiteSpace(nameBox.Text))
            {
                var vats = _vatInterface.GetByName(vatBox.GetItemText(vatBox.SelectedItem));
                var vatName = "";
                var vatType = "";
                foreach (var v in vats)
                {
                    vatName = v.Code;
                    vatType = v.Type;
                }
                this.GeneralLedger = new GeneralLedgerResponse
                {
                    Code = codeBox.Text,
                    Name = nameBox.Text,
                    VatName = vatName,
                    VatType = vatType,
                    Type = Type
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
