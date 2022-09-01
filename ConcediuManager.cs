using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcediuAngajati
{
    public partial class ConcediuManager : Form
    {
        public ConcediuManager()
        {
            InitializeComponent();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var columnIndex = 0;
            if (e.ColumnIndex == columnIndex)
            {
                // If the user checked this box, then uncheck all the other rows
                var isChecked = (bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (isChecked)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            row.Cells[columnIndex].Value = !isChecked;
                        }
                    }
                }
            }
        }
    }
}
