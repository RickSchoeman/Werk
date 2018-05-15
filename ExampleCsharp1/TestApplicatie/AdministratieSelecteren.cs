using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApplicatie
{
    public partial class AdministratieSelecteren : Form
    {
        private Form loginTwinfield = new LoginTwinfield();

        public AdministratieSelecteren()
        {
            InitializeComponent();
            var administratiesystemen = new List<string>();
            administratiesystemen.Add("Twinfield");
            administratiesystemen.Add("SnelStart");
            administratiesystemen.Add("Voorbeeld");
            comboBox2.DataSource = administratiesystemen;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (comboBox2.Text == @"Twinfield")
            {
                Cursor.Current = Cursors.Arrow;
                this.Hide();
                loginTwinfield.Show();
            }
            else if (comboBox2.Text == @"SnelStart")
            {
                Cursor.Current = Cursors.Arrow;
                System.Windows.Forms.MessageBox.Show(@"Dit administratiesysteem is nog niet geïmplementeerd");
            }
            else if (comboBox2.Text == @"Voorbeeld")
            {
                Cursor.Current = Cursors.Arrow;
                System.Windows.Forms.MessageBox.Show(@"Dit administratiesysteem is nog niet geïmplementeerd");
            }
        }
        
    }
}
