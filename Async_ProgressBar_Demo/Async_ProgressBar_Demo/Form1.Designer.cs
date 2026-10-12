namespace Async_ProgressBar_Demo
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel overviewPanel;
        private System.Windows.Forms.Label overviewTitleLabel;
        private System.Windows.Forms.Label overviewTextLabel;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label totalCaptionLabel;
        private System.Windows.Forms.Panel progressPanel;
        private System.Windows.Forms.Label progressTitleLabel;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.Label gridTitleLabel;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label statusFilterLabel;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Label lblFiltered;
        private System.Windows.Forms.DataGridView studentGrid;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.overviewPanel = new System.Windows.Forms.Panel();
            this.overviewTitleLabel = new System.Windows.Forms.Label();
            this.overviewTextLabel = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.totalCaptionLabel = new System.Windows.Forms.Label();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.progressTitleLabel = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.gridTitleLabel = new System.Windows.Forms.Label();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.searchLabel = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.statusFilterLabel = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.lblFiltered = new System.Windows.Forms.Label();
            this.studentGrid = new System.Windows.Forms.DataGridView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.overviewPanel.SuspendLayout();
            this.progressPanel.SuspendLayout();
            this.gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentGrid)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // menuStrip
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.menuStrip.ForeColor = System.Drawing.Color.White;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.fileMenuItem });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1100, 24);
            // fileMenuItem
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.exitMenuItem });
            this.fileMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Text = "Tệp";
            // exitMenuItem
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Text = "Thoát";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // headerPanel
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.headerPanel.Controls.Add(this.subtitleLabel);
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 24);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1100, 116);
            // titleLabel
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(34, 24);
            this.titleLabel.Text = "Student Data Hub";
            // subtitleLabel
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.subtitleLabel.Location = new System.Drawing.Point(38, 67);
            this.subtitleLabel.Text = "Nạp dữ liệu bất đồng bộ • Giao diện luôn mượt mà và sẵn sàng";
            // contentPanel
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.contentPanel.Controls.Add(this.gridPanel);
            this.contentPanel.Controls.Add(this.progressPanel);
            this.contentPanel.Controls.Add(this.overviewPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Padding = new System.Windows.Forms.Padding(32, 24, 32, 24);
            // overviewPanel
            this.overviewPanel.BackColor = System.Drawing.Color.White;
            this.overviewPanel.Controls.Add(this.totalCaptionLabel);
            this.overviewPanel.Controls.Add(this.lblTotal);
            this.overviewPanel.Controls.Add(this.overviewTextLabel);
            this.overviewPanel.Controls.Add(this.overviewTitleLabel);
            this.overviewPanel.Location = new System.Drawing.Point(32, 24);
            this.overviewPanel.Size = new System.Drawing.Size(1036, 91);
            // overviewTitleLabel
            this.overviewTitleLabel.AutoSize = true;
            this.overviewTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.overviewTitleLabel.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.overviewTitleLabel.Location = new System.Drawing.Point(20, 14);
            this.overviewTitleLabel.Text = "Tổng quan dữ liệu";
            // overviewTextLabel
            this.overviewTextLabel.AutoSize = true;
            this.overviewTextLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.overviewTextLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.overviewTextLabel.Location = new System.Drawing.Point(22, 45);
            this.overviewTextLabel.Text = "Danh sách sinh viên được mô phỏng từ nguồn dữ liệu lớn";
            // lblTotal
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 25F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblTotal.Location = new System.Drawing.Point(878, 11);
            this.lblTotal.Size = new System.Drawing.Size(138, 45);
            this.lblTotal.Text = "00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // totalCaptionLabel
            this.totalCaptionLabel.AutoSize = true;
            this.totalCaptionLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.totalCaptionLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.totalCaptionLabel.Location = new System.Drawing.Point(927, 61);
            this.totalCaptionLabel.Text = "SINH VIÊN";
            // progressPanel
            this.progressPanel.BackColor = System.Drawing.Color.White;
            this.progressPanel.Controls.Add(this.btnLoadData);
            this.progressPanel.Controls.Add(this.progressBar);
            this.progressPanel.Controls.Add(this.lblStatus);
            this.progressPanel.Controls.Add(this.lblProgress);
            this.progressPanel.Controls.Add(this.progressTitleLabel);
            this.progressPanel.Location = new System.Drawing.Point(32, 131);
            this.progressPanel.Size = new System.Drawing.Size(1036, 121);
            // progressTitleLabel
            this.progressTitleLabel.AutoSize = true;
            this.progressTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.progressTitleLabel.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.progressTitleLabel.Location = new System.Drawing.Point(20, 15);
            this.progressTitleLabel.Text = "Tiến trình nạp dữ liệu";
            // lblProgress
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblProgress.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblProgress.Location = new System.Drawing.Point(920, 13);
            this.lblProgress.Size = new System.Drawing.Size(93, 25);
            this.lblProgress.Text = "0%";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblStatus.Location = new System.Drawing.Point(22, 82);
            this.lblStatus.Text = "Sẵn sàng nạp dữ liệu";
            // progressBar
            this.progressBar.Location = new System.Drawing.Point(23, 52);
            this.progressBar.Maximum = 100;
            this.progressBar.Size = new System.Drawing.Size(764, 12);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // btnLoadData
            this.btnLoadData.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnLoadData.FlatAppearance.BorderSize = 0;
            this.btnLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadData.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoadData.ForeColor = System.Drawing.Color.White;
            this.btnLoadData.Location = new System.Drawing.Point(807, 43);
            this.btnLoadData.Size = new System.Drawing.Size(202, 32);
            this.btnLoadData.Text = "▶  NẠP DỮ LIỆU";
            this.btnLoadData.UseVisualStyleBackColor = false;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // gridPanel
            this.gridPanel.BackColor = System.Drawing.Color.White;
            this.gridPanel.Controls.Add(this.studentGrid);
            this.gridPanel.Controls.Add(this.filterPanel);
            this.gridPanel.Controls.Add(this.gridTitleLabel);
            this.gridPanel.Location = new System.Drawing.Point(32, 268);
            this.gridPanel.Size = new System.Drawing.Size(1036, 319);
            // gridTitleLabel
            this.gridTitleLabel.AutoSize = true;
            this.gridTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.gridTitleLabel.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.gridTitleLabel.Location = new System.Drawing.Point(20, 14);
            this.gridTitleLabel.Text = "Danh sách sinh viên";
            // filterPanel
            this.filterPanel.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.filterPanel.Controls.Add(this.lblFiltered);
            this.filterPanel.Controls.Add(this.btnClearFilter);
            this.filterPanel.Controls.Add(this.cboStatus);
            this.filterPanel.Controls.Add(this.statusFilterLabel);
            this.filterPanel.Controls.Add(this.txtSearch);
            this.filterPanel.Controls.Add(this.searchLabel);
            this.filterPanel.Location = new System.Drawing.Point(20, 43);
            this.filterPanel.Size = new System.Drawing.Size(996, 42);
            // searchLabel
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.searchLabel.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.searchLabel.Location = new System.Drawing.Point(12, 13);
            this.searchLabel.Text = "Tìm kiếm";
            // txtSearch
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(75, 9);
            this.txtSearch.Size = new System.Drawing.Size(280, 23);
            this.txtSearch.TextChanged += new System.EventHandler(this.filterControl_Changed);
            // statusFilterLabel
            this.statusFilterLabel.AutoSize = true;
            this.statusFilterLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.statusFilterLabel.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.statusFilterLabel.Location = new System.Drawing.Point(383, 13);
            this.statusFilterLabel.Text = "Trạng thái";
            // cboStatus
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] { "Tất cả trạng thái", "Đang học", "Cần cải thiện" });
            this.cboStatus.Location = new System.Drawing.Point(457, 8);
            this.cboStatus.Size = new System.Drawing.Size(170, 23);
            this.cboStatus.SelectedIndex = 0;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.filterControl_Changed);
            // btnClearFilter
            this.btnClearFilter.BackColor = System.Drawing.Color.White;
            this.btnClearFilter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilter.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnClearFilter.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnClearFilter.Location = new System.Drawing.Point(647, 8);
            this.btnClearFilter.Size = new System.Drawing.Size(88, 25);
            this.btnClearFilter.Text = "Xóa lọc";
            this.btnClearFilter.UseVisualStyleBackColor = false;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // lblFiltered
            this.lblFiltered.AutoSize = true;
            this.lblFiltered.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFiltered.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblFiltered.Location = new System.Drawing.Point(850, 13);
            this.lblFiltered.Text = "0 kết quả";
            // studentGrid
            this.studentGrid.AllowUserToAddRows = false;
            this.studentGrid.AllowUserToDeleteRows = false;
            this.studentGrid.AutoGenerateColumns = false;
            this.studentGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.studentGrid.BackgroundColor = System.Drawing.Color.White;
            this.studentGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.studentGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.studentGrid.ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle { BackColor = System.Drawing.Color.FromArgb(248, 250, 252), Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(71, 85, 105), SelectionBackColor = System.Drawing.Color.FromArgb(248, 250, 252), SelectionForeColor = System.Drawing.Color.FromArgb(71, 85, 105) };
            this.studentGrid.EnableHeadersVisualStyles = false;
            this.studentGrid.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.studentGrid.Location = new System.Drawing.Point(20, 91);
            this.studentGrid.ReadOnly = true;
            this.studentGrid.RowHeadersVisible = false;
            this.studentGrid.RowTemplate.Height = 30;
            this.studentGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.studentGrid.Size = new System.Drawing.Size(996, 209);
            this.studentGrid.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Mã SV", FillWeight = 17 });
            this.studentGrid.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Họ và tên", FillWeight = 30 });
            this.studentGrid.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "Major", HeaderText = "Chuyên ngành", FillWeight = 30 });
            this.studentGrid.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "Score", HeaderText = "Điểm", FillWeight = 10 });
            this.studentGrid.Columns.Add(new System.Windows.Forms.DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Trạng thái", FillWeight = 22 });
            // statusStrip
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.statusLabel });
            this.statusStrip.Location = new System.Drawing.Point(0, 613);
            this.statusStrip.Size = new System.Drawing.Size(1100, 22);
            // statusLabel
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Text = "Sẵn sàng • Nhấn NẠP DỮ LIỆU để bắt đầu";
            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 635);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Data Hub • Async Progress Demo";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.overviewPanel.ResumeLayout(false);
            this.overviewPanel.PerformLayout();
            this.progressPanel.ResumeLayout(false);
            this.progressPanel.PerformLayout();
            this.gridPanel.ResumeLayout(false);
            this.gridPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentGrid)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}