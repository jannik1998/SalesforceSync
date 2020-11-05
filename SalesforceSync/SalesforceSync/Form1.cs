using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesforceSync
{
    public partial class Form1 : Form
    {
        SalesforceConnect s = new SalesforceConnect();
        string data;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            s.GetSalesforceAccessToken();
            s.SendRequest(data);
        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            string value = Convert.ToString(textBoxPath.Text);
            //textBoxInfo.Text = value;
        }
        private void buttonCheckCsv_Click(object sender, EventArgs e)
        {
            if (textBoxPath.Text == "") 
            {
                textBoxInfo.Text += ("\n Bitte geben sie das richtige Verzeichnis an.");
            }
            else
            {
                string value = Convert.ToString(textBoxPath.Text);
                data = s.ReadCsv(value);
                btnSend.Enabled = true;
            }
        }
    }
}
