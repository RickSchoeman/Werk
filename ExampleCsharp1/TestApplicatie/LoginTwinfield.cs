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

namespace TestApplicatie
{
    public partial class LoginTwinfield : Form
    {


        public LoginTwinfield()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var serverUrl = ServerUrl.Text;
            var gebruiker = Gebruiker.Text;
            var wachtwoord = Wachtwoord.Text;
            var organisatie = Organisatie.Text;
            var twinfield = new TwinfieldApiConnector();
            try
            {
                var session = twinfield.Login(serverUrl, gebruiker, wachtwoord, organisatie);
                if (session != null)
                {
                    Form administratieVeranderen = new AdministratieVeranderen(session);
                    Cursor.Current = Cursors.Arrow;
                    this.Hide();
                    administratieVeranderen.Show();

                }
                else
                {
                    Cursor.Current = Cursors.Arrow;
                    System.Windows.Forms.MessageBox.Show(
                        @"Kan niet inloggen \n Inloggegevens verkeerd of administratie is niet berijkbaar.");
                }
            }
            catch (Exception exception)
            {
                Cursor.Current = Cursors.Arrow;
                System.Windows.Forms.MessageBox.Show(
                    @"Kan niet inloggen \n Inloggegevens verkeerd of administratie is niet berijkbaar.");
                Console.WriteLine(exception);
            }


        }
    }
}
