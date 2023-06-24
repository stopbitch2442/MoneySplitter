    using Guna.UI2.WinForms;
    using MoneySplitterApi.Models;
    using MoneySplitterApi;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Guna.UI2.WinForms.Suite;
    using System.Numerics;
    using MoneySplitterWinForm.UC;
    using NuGet.Protocol.Plugins;
    using System.Net.Http;

    namespace MoneySplitterWinForm.UC
    {
        public partial class UC_Debts : UserControl
        {
            private readonly ApiClient _apiClient = new ApiClient();
            private HelpFormAddDebtcs helpForm;

            public UC_Debts()
            {
                InitializeComponent();
                LoadDebts();
            }

            public async void LoadDebts()
            {
                var debts = await _apiClient.GetDebtsAsync();
                guna2DataGridView1.DataSource = debts;
            }

            private void btn_addDebt_Click(object sender, EventArgs e)
            {
                helpForm = new HelpFormAddDebtcs(this, _apiClient);
                helpForm.Show();
            }

            private Guid SearchGuidInDataGrid()
            {
                if (guna2DataGridView1.SelectedRows != null && guna2DataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];
                    var selectedDebt = guna2DataGridView1.SelectedRows[0].DataBoundItem as Debts;
                    if (selectedDebt != null)
                    {
                        return selectedDebt.Id;
                    }
                    else
                    {
                        throw new Exception("Выбранная строка не содержит корректное значение Guid.");
                    }
                }
                throw new Exception("Выбранная строка не содержит корректное значение Guid.");
            }

            private async void btn_deleteDebt_Click(object sender, EventArgs e)
            {
                if (guna2DataGridView1.SelectedRows != null && guna2DataGridView1.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Удалить данный долг?", "Внимание", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            Guid guid = SearchGuidInDataGrid();
                            var response = await _apiClient.DeleteDebtAsync(guid);
                            if (response.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Долг успешно удалён");
                            }
                            else
                            {
                                string errorMessage = await response.Content.ReadAsStringAsync();
                                throw new Exception(errorMessage);
                            }
                            LoadDebts();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Необходимо выбрать какой долг удалить");
                }
            }

            private void btn_editDebt_Click(object sender, EventArgs e)
            {

            }

        private void UC_Debts_Load(object sender, EventArgs e)
        {

        }
    }
    }