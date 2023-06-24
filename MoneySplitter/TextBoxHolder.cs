using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;

namespace MoneySplitterWinForm
{
    public class TextBoxHolder<T> where T : Guna2TextBox
    {
        private readonly T _textBox;
        private readonly string _textHolder;

        public TextBoxHolder(T Guna2TextBox, string textHolder)
        {
            _textBox = Guna2TextBox;
            _textHolder = textHolder;

            _textBox.TextChanged += Textbox_TextChanged;
            _textBox.Leave += Textbox_Leave;
            _textBox.Enter += Textbox_Enter;

            SetTextHolder();
        }

        private void SetTextHolder()
        {
            if (string.IsNullOrWhiteSpace(_textBox.Text))
            {
                _textBox.Text = _textHolder;
            }
        }

        private void Textbox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_textBox.Text))
            {
                _textBox.Text = _textBox.Text.Trim();
            }
        }

        private void Textbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_textBox.Text))
            {
                SetTextHolder();
            }
        }
        private void Textbox_Enter(object sender, EventArgs e)
        {
            if (_textBox.Text == _textHolder)
            {
                _textBox.Text = "";
            }
        }
    }
}