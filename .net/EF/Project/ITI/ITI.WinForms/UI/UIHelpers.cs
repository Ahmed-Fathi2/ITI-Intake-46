using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ITI.WinForms.UI
{
    internal static class UIHelpers
    {
        public static void ApplyModernStyle(Form form)
        {
            if (form == null) return;

            // Basic form styling
            form.BackColor = Color.White;
            form.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);

            // Apply to all controls recursively
            foreach (Control c in form.Controls.Cast<Control>().ToList())
            {
                ApplyControlStyle(c);
            }
        }

        private static void ApplyControlStyle(Control c)
        {
            switch (c)
            {
                case Button b:
                    b.FlatStyle = FlatStyle.Flat;
                    try { b.FlatAppearance.BorderSize = 0; } catch { }
                    b.BackColor = Color.FromArgb(33, 150, 243);
                    b.ForeColor = Color.White;
                    b.Cursor = Cursors.Hand;
                    break;
                case DataGridView dgv:
                    dgv.BackgroundColor = Color.White;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.GridColor = Color.FromArgb(230, 230, 230);
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgv.RowTemplate.Height = 30;
                    dgv.AllowUserToAddRows = false;
                    break;
                case TextBox tb:
                    tb.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case ComboBox cb:
                    cb.FlatStyle = FlatStyle.Flat;
                    break;
                case CheckedListBox clb:
                    clb.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case Label lbl:
                    lbl.ForeColor = Color.FromArgb(33, 33, 33);
                    break;
                case Panel p:
                    p.BackColor = Color.White;
                    break;
            }

            // Recurse into child controls
            foreach (Control child in c.Controls.Cast<Control>().ToList())
                ApplyControlStyle(child);
        }
    }
}
