using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BT_Calculator
{
    public partial class Form1 : Form
    {
        Caculation ca;
        public Form1()
        {
            InitializeComponent();
        }

        private void btcong_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            double a = int.Parse(txtSo1.Text);
            double b = int.Parse(txtSo2.Text);
            ca = new Caculation(a, b);
            double kq = ca.Execute(bt.Text);
            txtKq.Text = kq.ToString();
        }
    }
}
