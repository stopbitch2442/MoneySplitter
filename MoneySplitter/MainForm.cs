using Guna.UI2.WinForms;

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
           
            this.WindowState = FormWindowState.Maximized;
            
        }
        private void SetTextBoxPlaceholders()
        {
            textBoxLogin.SetPlaceholderText<TextBox>("������� �����");
            textBoxPassword.SetPlaceholderText<TextBox>("������� ������");
            textBoxRepeatPassword.SetPlaceholderText<TextBox>("��������� ������");
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