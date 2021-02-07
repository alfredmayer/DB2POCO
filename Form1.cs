using System;
using System.Linq;
using System.Windows.Forms;

namespace DB2POCO
{
    public partial class Form1 : Form
    {
        public Form1(Services.ConfigService configService)
        {
            InitializeComponent();

            Text=configService.List.First().Key;
            ConnString.Text = configService.List.First().Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}