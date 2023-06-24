using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySplitterWinForm
{
    public class ReturnRightType
    {
        public decimal ReturnDecimalValue(string stringAmount)
        {
            if (string.IsNullOrWhiteSpace(stringAmount))
            {
                // Обработка случая, когда строка пустая или содержит только пробельные символы
                MessageBox.Show("Введите значение");
                return 0;
            }

            stringAmount = stringAmount.Replace(',', '.'); // Заменяем запятые на точки, чтобы правильно распознавались десятичные числа

            if (!decimal.TryParse(stringAmount, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal result))
            {
                // Обработка случая, когда строка не может быть приведена к типу decimal
                MessageBox.Show("Введенное значение не является числом типа decimal");
                return 0;
            }

            return result;
        }

        public bool ReturnBooleanValue(string stringAmount)
        {
            if (stringAmount == "+")
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

    }
}
