using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
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
    public partial class UC_Ledger : UserControl
    {
        private readonly ApiClient _apiClient = new ApiClient();
        public UC_Ledger()
        {
            InitializeComponent();
            LoadLedger();
        }
        public async void LoadLedger()
        {
            var ledgers = await _apiClient.GetLedgersAsync();
            guna2DataGridView1.DataSource = ledgers;
        }
        private void UC_Ledger_Load(object sender, EventArgs e)
        {
            TextBoxHold();
            DataGridFilter(guna2DataGridView1, true);
            DataGridFilter(guna2DataGridView2, false);
        }

        private void TextBoxHold()
        {
            new TextBoxHolder<Guna2TextBox>(textbox_Description, "Введите описание");
            new TextBoxHolder<Guna2TextBox>(textbox_Amount, "Введите количество");
        }

        private async void btn_submit_Click(object sender, EventArgs e)
        {
            ReturnRightType returnDecimal = new ReturnRightType();

            if (string.IsNullOrEmpty(textbox_Description.Text) ||
                string.IsNullOrEmpty(textbox_Amount.Text) ||
                string.IsNullOrEmpty(comboBox_Sign.Text))
            {
                MessageBox.Show("Заполните все поля для добавления");
                return;
            }

            decimal amount;
            if (!decimal.TryParse(textbox_Amount.Text, out amount))
            {
                MessageBox.Show("Неверный формат количества");
                return;
            }

            bool sign;
            if (comboBox_Sign.Text.Trim() == "+")
            {
                sign = true;
            }
            else if (comboBox_Sign.Text.Trim() == "-")
            {
                sign = false;
            }
            else
            {
                MessageBox.Show("Неверный формат знака (+ или -)");
                return;
            }

            var ledgers = new Ledgers
            {
                Id = Guid.NewGuid(),
                Description = textbox_Description.Text,
                Amount = amount,
                Sign = sign
            };

            var response = await _apiClient.CreateLedgersAsync(ledgers);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Расчёт успешно добавлен");
            }
            else
            {
                MessageBox.Show("Расчёт не добавлен");
            }
            LoadLedger();
        }

        private Guid GuidIntoDataGrid()
        {
            if (guna2DataGridView1.SelectedRows != null)
            {
                Guid guid = SearchGuidForLedgers<Guna2DataGridView>.SearchGuidInDataGrid(guna2DataGridView1);
                return guid;
            }
            else
            {
                Guid guid = SearchGuidForLedgers<Guna2DataGridView>.SearchGuidInDataGrid(guna2DataGridView2);
                return guid;
            }
            
        }

        private void DataGridFilter(Guna2DataGridView guna2DataGridView, bool filterValue)
        {
        }

        private async void btn_DeleteLedgers_Click(object sender, EventArgs e)
        {
            
            DialogResult dialogResult = MessageBox.Show("Удалить данный расчёт?", "Внимание", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Guid guid = GuidIntoDataGrid();
                    var response = await _apiClient.DeleteLedgersAsync(guid);
                    if (response.IsSuccessStatusCode)   
                    {
                        MessageBox.Show("Расчёт успешно удалён");
                    }
                    else
                    {
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        throw new Exception(errorMessage);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать какой расчёт удалить");
            }
            LoadLedger();
        }
    }
}
