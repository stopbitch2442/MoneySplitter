using Guna.UI2.WinForms;
using Microsoft.VisualBasic;

namespace MoneySplitter
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetTextBoxPlaceholders();
            this.WindowState = FormWindowState.Maximized;
            
        }
        private void SetTextBoxPlaceholders()
        {
            textBoxLogin.SetPlaceholderText<TextBox>("Введите логин");
            textBoxPassword.SetPlaceholderText<TextBox>("Введите пароль");
            textBoxRepeatPassword.SetPlaceholderText<TextBox>("Повторите пароль");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }
    }

    public static class TextBoxExtentions
    {
        public static void SetPlaceholderText<T>(this Guna2TextBox textBox, string placeholderText) where T : TextBox
        {
            textBox.Text = placeholderText;
            textBox.Enter += (sender, args) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = string.Empty;

                }
            };

            textBox.Leave += (sender, args) =>
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Text = placeholderText;
                }
            };
        }
    }
}