using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MDI_StudentApp
{
    public class FormProduct : Form
    {
        private readonly DataGridView productGrid;
        private readonly BindingSource bindingSource;
        private readonly DataTable productTable;

        public event Action<string> StatusChanged;

        public FormProduct()
        {
            Text = "Quản lý Sản phẩm";
            Width = 900;
            Height = 500;
            StartPosition = FormStartPosition.CenterParent;

            productTable = CreateProductTable();
            bindingSource = new BindingSource { DataSource = productTable };
            productGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                DataSource = bindingSource,
                ContextMenuStrip = CreateContextMenu()
            };
            productGrid.MouseDown += ProductGridMouseDown;

            Panel header = new Panel { Dock = DockStyle.Top, Height = 48, Padding = new Padding(8) };
            Button addButton = new Button { Text = "Thêm sản phẩm", AutoSize = true, Dock = DockStyle.Left };
            addButton.Click += AddProductClick;
            Button deleteButton = new Button { Text = "Xóa dòng", AutoSize = true, Dock = DockStyle.Left };
            deleteButton.Click += DeleteProductClick;
            Button refreshButton = new Button { Text = "Làm mới", AutoSize = true, Dock = DockStyle.Left };
            refreshButton.Click += RefreshProductsClick;
            header.Controls.Add(refreshButton);
            header.Controls.Add(deleteButton);
            header.Controls.Add(addButton);

            Controls.Add(productGrid);
            Controls.Add(header);
        }

        private DataTable CreateProductTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã SP");
            table.Columns.Add("Tên sản phẩm");
            table.Columns.Add("Loại");
            table.Columns.Add("Đơn giá");
            table.Columns.Add("Tồn kho");
            table.Rows.Add("SP001", "Laptop Dell Inspiron", "Laptop", "18500000", "12");
            table.Rows.Add("SP002", "Chuột không dây Logitech", "Phụ kiện", "450000", "35");
            table.Rows.Add("SP003", "Bàn phím cơ Keychron", "Phụ kiện", "2200000", "18");
            return table;
        }

        private ContextMenuStrip CreateContextMenu()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("Xóa dòng", null, DeleteProductClick);
            menu.Items.Add("Làm mới dữ liệu", null, RefreshProductsClick);
            menu.Items.Add("Xem chi tiết", null, ViewProductClick);
            return menu;
        }

        private void ProductGridMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            DataGridView.HitTestInfo hit = productGrid.HitTest(e.X, e.Y);
            if (hit.RowIndex >= 0)
            {
                productGrid.ClearSelection();
                productGrid.Rows[hit.RowIndex].Selected = true;
            }
        }

        private void AddProductClick(object sender, EventArgs e)
        {
            int nextNumber = productTable.Rows.Count + 1;
            productTable.Rows.Add("SP" + nextNumber.ToString("000"), "Sản phẩm mới", "Chưa phân loại", "0", "0");
            RaiseStatus("Đã thêm sản phẩm thành công.");
        }

        private void DeleteProductClick(object sender, EventArgs e)
        {
            if (productGrid.SelectedRows.Count == 0)
            {
                RaiseStatus("Vui lòng chọn một sản phẩm để xóa.");
                return;
            }

            int rowIndex = productGrid.SelectedRows[0].Index;
            if (rowIndex >= 0 && rowIndex < productTable.Rows.Count)
            {
                productTable.Rows.RemoveAt(rowIndex);
                RaiseStatus("Đã xóa sản phẩm thành công.");
            }
        }

        private void RefreshProductsClick(object sender, EventArgs e)
        {
            bindingSource.ResetBindings(false);
            RaiseStatus("Đã làm mới dữ liệu sản phẩm.");
        }

        private void ViewProductClick(object sender, EventArgs e)
        {
            if (productGrid.SelectedRows.Count == 0)
            {
                RaiseStatus("Vui lòng chọn một sản phẩm để xem chi tiết.");
                return;
            }

            DataGridViewRow row = productGrid.SelectedRows[0];
            MessageBox.Show(
                "Mã SP: " + row.Cells[0].Value + Environment.NewLine +
                "Tên sản phẩm: " + row.Cells[1].Value + Environment.NewLine +
                "Loại: " + row.Cells[2].Value + Environment.NewLine +
                "Đơn giá: " + row.Cells[3].Value + " VNĐ" + Environment.NewLine +
                "Tồn kho: " + row.Cells[4].Value,
                "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RaiseStatus("Đã xem chi tiết sản phẩm.");
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
