using MoneySplitterApi;
using MoneySplitterApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneySplitterWinForm.UC
{
    public partial class UC_Debts : UserControl
    {
        private readonly ApiClient _apiClient;
        public UC_Debts()
        {
            InitializeComponent();
            _apiClient = new ApiClient();
            LoadDebts();

        }
        private async void LoadDebts()
        {
            var debts = await _apiClient.GetDebtsAsync();
            guna2DataGridView1.DataSource = debts;
        }

        private void UC_Debts_Load(object sender, EventArgs e)
        {
            
        }
        public async void AddDept()
        {
            var dept = new Debts
            {
                Description = "New debt",
                Amount = 100,
                DateOwed = DateTime.Now,
                DeadLine = DateTime.Now.AddDays(30),
                IsPaid = false,
                Creditor = "Creditor",
                Debtor = "Debtor"
            };

            var response = await _apiClient.CreateDebtsAsync(dept);

            if (response.IsSuccessStatusCode)
            {
                LoadDebts();
            }
            else
            {
                MessageBox.Show("Error adding debt");
            }
        }
        private async void btn_addDebt_Click(object sender, EventArgs e)
        {
            AddDept();
        }
    }
}
