using Guna.UI2.WinForms;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MoneySplitterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySplitterWinForm
{
    public class SearchGuidForLedgers<T> where T : Guna2DataGridView
    {
        public static Guid SearchGuidInDataGrid(T Guna2DataGridView)
        {
            if (Guna2DataGridView.SelectedRows != null && Guna2DataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = Guna2DataGridView.SelectedRows[0];
                var selectedLedgers = Guna2DataGridView.SelectedRows[0].DataBoundItem as Ledgers;
                if (selectedLedgers != null)
                {
                    return selectedLedgers.Id;
                }
                else
                {
                    throw new Exception("Выбранная строка не содержит корректное значение Guid.");
                }
            }
            throw new Exception("Выбранная строка не содержит корректное значение Guid.");
        }
    }
}
