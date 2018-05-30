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
    public partial class ConsoleLarge : Form
    {
        public ConsoleLarge(RichTextBox richTextBox)
        {
            InitializeComponent();
            foreach (var x in richTextBox.Lines)
            {
                richTextBox1.AppendText("\r\n" + x);
            }
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
