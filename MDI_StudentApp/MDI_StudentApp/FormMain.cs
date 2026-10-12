using System;
using System.Drawing;
using System.Windows.Forms;

namespace MDI_StudentApp
{
    public class FormMain : Form
    {
        private readonly MenuStrip menuStrip;
        private readonly ToolStrip toolStrip;
        private readonly StatusStrip statusStrip;
        private readonly ContextMenuStrip contextMenuStrip;
        private readonly ToolStripStatusLabel userStatusLabel;
        private readonly ToolStripStatusLabel messageStatusLabel;
        private readonly ToolStripStatusLabel timeStatusLabel;
        private readonly Timer clockTimer;

        public FormMain()
        {
            Text = "Hệ thống quản lý - MDI StudentApp";
            IsMdiContainer = true;
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;

            menuStrip = CreateMenuStrip();
            toolStrip = CreateToolStrip();
            statusStrip = CreateStatusStrip(out userStatusLabel, out messageStatusLabel, out timeStatusLabel);
            contextMenuStrip = CreateContextMenuStrip();

            MainMenuStrip = menuStrip;
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            MdiClientContextMenu();

            clockTimer = new Timer { Interval = 1000 };
            clockTimer.Tick += delegate { timeStatusLabel.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); };
            clockTimer.Start();
            FormClosed += delegate { clockTimer.Stop(); };
        }

        private MenuStrip CreateMenuStrip()
        {
            MenuStrip menu = new MenuStrip();
            ToolStripMenuItem systemMenu = new ToolStripMenuItem("Hệ thống");
            systemMenu.DropDownItems.Add("Đăng xuất", null, LogoutClick);
            systemMenu.DropDownItems.Add("Thoát", null, ExitClick);

            ToolStripMenuItem catalogMenu = new ToolStripMenuItem("Danh mục");
            catalogMenu.DropDownItems.Add("Quản lý Sinh viên", null, OpenStudentClick);
            catalogMenu.DropDownItems.Add("Quản lý Sản phẩm", null, OpenProductClick);

            ToolStripMenuItem windowMenu = new ToolStripMenuItem("Cửa sổ");
            windowMenu.DropDownItems.Add("Cascade", null, delegate { LayoutMdi(MdiLayout.Cascade); });
            windowMenu.DropDownItems.Add("Tile Horizontal", null, delegate { LayoutMdi(MdiLayout.TileHorizontal); });
            windowMenu.DropDownItems.Add("Tile Vertical", null, delegate { LayoutMdi(MdiLayout.TileVertical); });
            windowMenu.DropDownItems.Add("Đóng cửa sổ hiện tại", null, CloseActiveChildClick);

            menu.Items.Add(systemMenu);
            menu.Items.Add(catalogMenu);
            menu.Items.Add(windowMenu);
            return menu;
        }

        private ToolStrip CreateToolStrip()
        {
            ToolStrip tool = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden };
            ToolStripButton studentButton = new ToolStripButton("Sinh viên") { DisplayStyle = ToolStripItemDisplayStyle.Text, ToolTipText = "Mở quản lý sinh viên" };
            studentButton.Click += OpenStudentClick;
            ToolStripButton productButton = new ToolStripButton("Sản phẩm") { DisplayStyle = ToolStripItemDisplayStyle.Text, ToolTipText = "Mở quản lý sản phẩm" };
            productButton.Click += OpenProductClick;
            tool.Items.Add(studentButton);
            tool.Items.Add(productButton);
            tool.Items.Add(new ToolStripSeparator());
            ToolStripButton cascadeButton = new ToolStripButton("Cascade") { DisplayStyle = ToolStripItemDisplayStyle.Text };
            cascadeButton.Click += delegate { LayoutMdi(MdiLayout.Cascade); };
            tool.Items.Add(cascadeButton);
            return tool;
        }

        private StatusStrip CreateStatusStrip(out ToolStripStatusLabel userLabel, out ToolStripStatusLabel messageLabel, out ToolStripStatusLabel timeLabel)
        {
            StatusStrip status = new StatusStrip();
            userLabel = new ToolStripStatusLabel("Người dùng: Admin");
            messageLabel = new ToolStripStatusLabel("Sẵn sàng") { Spring = true, TextAlign = ContentAlignment.MiddleLeft };
            timeLabel = new ToolStripStatusLabel(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            status.Items.Add(userLabel);
            status.Items.Add(new ToolStripSeparator());
            status.Items.Add(messageLabel);
            status.Items.Add(timeLabel);
            return status;
        }

        private ContextMenuStrip CreateContextMenuStrip()
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("Mở quản lý Sinh viên", null, OpenStudentClick);
            menu.Items.Add("Mở quản lý Sản phẩm", null, OpenProductClick);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("Đóng cửa sổ hiện tại", null, CloseActiveChildClick);
            return menu;
        }

        private void MdiClientContextMenu()
        {
            foreach (Control control in Controls)
            {
                MdiClient client = control as MdiClient;
                if (client != null)
                {
                    client.ContextMenuStrip = contextMenuStrip;
                    break;
                }
            }
        }

        private void OpenStudentClick(object sender, EventArgs e)
        {
            OpenChild<FormStudent>();
        }

        private void OpenProductClick(object sender, EventArgs e)
        {
            OpenChild<FormProduct>();
        }

        private void OpenChild<T>() where T : Form, new()
        {
            foreach (Form child in MdiChildren)
            {
                if (child is T)
                {
                    child.WindowState = FormWindowState.Normal;
                    child.Activate();
                    return;
                }
            }

            T form = new T { MdiParent = this };
            FormStudent student = form as FormStudent;
            if (student != null)
            {
                student.StatusChanged += ChildStatusChanged;
            }
            FormProduct product = form as FormProduct;
            if (product != null)
            {
                product.StatusChanged += ChildStatusChanged;
            }
            form.Show();
            SetStatus("Đã mở " + form.Text + ".");
        }

        private void ChildStatusChanged(string message)
        {
            SetStatus(message);
        }

        private void SetStatus(string message)
        {
            messageStatusLabel.Text = message;
        }

        private void LogoutClick(object sender, EventArgs e)
        {
            SetStatus("Đã đăng xuất người dùng.");
        }

        private void CloseActiveChildClick(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
                SetStatus("Đã đóng cửa sổ hiện tại.");
            }
        }

        private void ExitClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
