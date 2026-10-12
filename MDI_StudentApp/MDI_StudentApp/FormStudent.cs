using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MDI_StudentApp
{
    public class FormStudent : Form
    {
        private readonly DataGridView studentGrid;
        private readonly ContextMenuStrip gridContextMenu;
        private readonly BindingSource bindingSource;
        private readonly DataTable studentTable;

        public event Action<string> StatusChanged;

        public FormStudent()
        {
            Text = "Quản lý Sinh viên";
            Width = 900;
            Height = 550;
            StartPosition = FormStartPosition.CenterParent;

            studentTable = CreateStudentTable();
            bindingSource = new BindingSource { DataSource = studentTable };
            studentGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                DataSource = bindingSource
            };

            gridContextMenu = CreateGridContextMenu();
            studentGrid.ContextMenuStrip = gridContextMenu;
            studentGrid.MouseDown += StudentGridMouseDown;

            Panel header = new Panel { Dock = DockStyle.Top, Height = 48, Padding = new Padding(8) };
            Button addButton = new Button { Text = "Thêm sinh viên", AutoSize = true, Dock = DockStyle.Left };
            addButton.Click += AddStudentClick;
            Button deleteButton = new Button { Text = "Xóa dòng", AutoSize = true, Dock = DockStyle.Left };
            deleteButton.Click += DeleteStudentClick;
            header.Controls.Add(deleteButton);
            header.Controls.Add(addButton);
            Controls.Add(studentGrid);
            Controls.Add(header);
        }

        private DataTable CreateStudentTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã SV");
            table.Columns.Add("Họ tên");
            table.Columns.Add("Lớp");
            table.Columns.Add("Email");
            table.Rows.Add("SV001", "Nguyễn Văn An", "CNTT01", "an@example.com");
            table.Rows.Add("SV002", "Trần Thị Bình", "CNTT02", "binh@example.com");
            return table;
        }

        private ContextMenuStrip CreateGridContextMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("Xóa dòng", null, DeleteStudentClick);
            menu.Items.Add("Làm mới dữ liệu", null, RefreshStudentsClick);
            menu.Items.Add("Xem chi tiết", null, ViewStudentClick);
            return menu;
        }

        private void StudentGridMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            DataGridView.HitTestInfo hit = studentGrid.HitTest(e.X, e.Y);
            if (hit.RowIndex >= 0)
            {
                studentGrid.ClearSelection();
                studentGrid.Rows[hit.RowIndex].Selected = true;
            }
        }

        private void AddStudentClick(object sender, EventArgs e)
        {
            int nextNumber = studentTable.Rows.Count + 1;
            studentTable.Rows.Add("SV" + nextNumber.ToString("000"), "Sinh viên mới", "Chưa xếp lớp", "");
            RaiseStatus("Đã thêm sinh viên thành công.");
        }

        private void DeleteStudentClick(object sender, EventArgs e)
        {
            if (studentGrid.SelectedRows.Count == 0)
            {
                RaiseStatus("Vui lòng chọn một dòng để xóa.");
                return;
            }

            int rowIndex = studentGrid.SelectedRows[0].Index;
            if (rowIndex >= 0 && rowIndex < studentTable.Rows.Count)
            {
                studentTable.Rows.RemoveAt(rowIndex);
                RaiseStatus("Đã xóa sinh viên thành công.");
            }
        }

        private void RefreshStudentsClick(object sender, EventArgs e)
        {
            bindingSource.ResetBindings(false);
            RaiseStatus("Đã làm mới dữ liệu sinh viên.");
        }

        private void ViewStudentClick(object sender, EventArgs e)
        {
            if (studentGrid.SelectedRows.Count == 0)
            {
                RaiseStatus("Vui lòng chọn một sinh viên để xem chi tiết.");
                return;
            }

            DataGridViewRow row = studentGrid.SelectedRows[0];
            MessageBox.Show("Mã SV: " + row.Cells[0].Value + Environment.NewLine + "Họ tên: " + row.Cells[1].Value + Environment.NewLine + "Lớp: " + row.Cells[2].Value, "Chi tiết sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RaiseStatus("Đã xem chi tiết sinh viên.");
        }

        private void RaiseStatus(string message)
        {
            Action<string> handler = StatusChanged;
            if (handler != null)
            {
                handler(message);
            }
        }
    }
}
