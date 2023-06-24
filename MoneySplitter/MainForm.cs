using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneySplitterWinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btn_Debt_Click(object sender, EventArgs e)
        {
            uC_Debts1.Visible = true;
            uC_Ledger1.Visible = false;

        }

        private void btn_Ldger_Click(object sender, EventArgs e)
        {
            uC_Ledger1.Visible = true;
        }
    }
}
