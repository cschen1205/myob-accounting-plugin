using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DacII.Util
{
    using System.Windows.Forms;
    using System.Drawing;
    class DataGridViewHelper
    {
        internal static void UpdateColumnHeaderStyles(System.Windows.Forms.DataGridView dgv)
        {
            //alternating row: 189, 210, 241
            //default highlight: 86, 126, 177
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.HeaderCell.Style.BackColor = Color.FromArgb(86, 126, 200);
                
                //if (dgv == dgvAll)
                //{
                //    col.HeaderCell.Style.BackColor = Color.DarkSlateBlue;
                //}
                //else if (dgv == dgvSold)
                //{
                //    col.HeaderCell.Style.BackColor = Color.DodgerBlue;
                //}
                //else if (dgv == dgvBought)
                //{
                //    col.HeaderCell.Style.BackColor = Color.Blue;
                //}
                //else if (dgv == dgvInventoried)
                //{
                //    col.HeaderCell.Style.BackColor = Color.MidnightBlue;
                //}
                col.HeaderCell.Style.ForeColor = Color.White;
                //col.HeaderCell.Style.Font = new Font(col.HeaderCell.Style.Font.FontFamily, 8.25f, FontStyle.Bold);
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv.EnableHeadersVisualStyles = false;
        }
    }
}
