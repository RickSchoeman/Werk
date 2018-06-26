using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoConnector.TwinfieldAPI;
using DemoConnector.TwinfieldAPI.Data;
using DemoConnector.TwinfieldAPI.Handlers;

namespace TestApplicatie
{
    public partial class AdministratieVeranderen : Form
    {
        private readonly Session _session;
        public AdministratieVeranderen(Session session)
        {
            _session = session;
            InitializeComponent();
            var offices = (new OfficeOperations(_session)).GetAllOffices();
            comboBox1.DataSource = offices;
            comboBox1.DisplayMember = "Code";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var twinfield = new TwinfieldApiConnector();
            twinfield.SwitchToOffice(comboBox1.Text, _session);
            
            Form twinfieldForm = new Twinfield(_session);
            Cursor.Current = Cursors.Arrow;
            this.Close();
            twinfieldForm.Show();
        }
    }
}
