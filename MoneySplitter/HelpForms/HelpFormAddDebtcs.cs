using Guna.UI2.WinForms;
using MoneySplitterApi.Models;
using MoneySplitterApi;
using MoneySplitterWinForm.UC;

namespace MoneySplitterWinForm
{
    public partial class HelpFormAddDebtcs : Form
    {
        private readonly UC_Debts _parentForm;
        private readonly ApiClient _apiClient;

        public HelpFormAddDebtcs(UC_Debts parentForm, ApiClient apiClient)
        {
            InitializeComponent();
            _parentForm = parentForm;
            _apiClient = apiClient;
        }

        private void HelpFormAddDebtcs_Load(object sender, EventArgs e)
        {
            time_DateOwed.Value = DateTime.Now;
            time_DeadLine.Value = DateTime.Now;

            TextBoxHold();
        }

        private void TextBoxHold()
        {
            new TextBoxHolder<Guna2TextBox>(textbox_Description, "Введите описание");
            new TextBoxHolder<Guna2TextBox>(textbox_Amount, "Введите количество");
            new TextBoxHolder<Guna2TextBox>(textbox_Creditor, "Введите кредитора");
            new TextBoxHolder<Guna2TextBox>(textbox_Debitor, "Введите дебетора");
        }

        private async void btn_AddDebt_Click(object sender, EventArgs e)
        {
            ReturnRightType returnDecimal = new ReturnRightType();
            // Проверка, что все поля заполнены
            if (textbox_Description == null || string.IsNullOrEmpty(textbox_Description.Text) ||
            textbox_Amount == null || string.IsNullOrEmpty(textbox_Amount.Text) ||
            textbox_Creditor == null || string.IsNullOrEmpty(textbox_Creditor.Text) ||
            textbox_Debitor == null || string.IsNullOrEmpty(textbox_Debitor.Text))
            {
                MessageBox.Show("Заполните все поля для добавления долга");
                return;
            }

            // Создание объекта Debts
            var dept = new Debts
            {
                Id = Guid.NewGuid(),
                Description = textbox_Description.Text,
                Amount = returnDecimal.ReturnDecimalValue(textbox_Amount.Text),
                DateOwed = time_DateOwed.Value.ToUniversalTime(),
                DeadLine = time_DeadLine.Value.ToUniversalTime(),
                IsPaid = btn_IsPaid.Checked,
                Creditor = textbox_Creditor.Text,
                Debtor = textbox_Debitor.Text
            };

            // Создание долга через API
            await _apiClient.CreateDebtAsync(dept);
            this.Close();

            // Обновляем datagrid в родительской форме UC_Debts
            _parentForm.LoadDebts();
        }

    }
}