using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Common
{
    public static class Searcher
    {
        public static void Search(DataGridView dataGrid, int[] columns, string filter)
        {
            try
            {
                bool valueResult = false;
                dataGrid.ClearSelection();
                int rowIndex;
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    foreach (int column in columns)
                    {
                        if (row.Cells[column].Value != null && row.Cells[column].Value.ToString().ToUpper().Contains(filter.ToUpper()))
                        {
                            rowIndex = row.Index;
                            dataGrid.Rows[rowIndex].Selected = true;

                            valueResult = true;
                            break;
                        }
                    }
                }
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)dataGrid.BindingContext[dataGrid.DataSource];
                    if (!row.Selected)
                    {
                        currencyManager1.SuspendBinding();
                        row.Visible = false;
                        currencyManager1.ResumeBinding();
                    }
                }
                if (!valueResult)
                {
                    MessageBox.Show("Результати за запитом '" + filter + "' не знайдені.", "Результати не знайдені.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
