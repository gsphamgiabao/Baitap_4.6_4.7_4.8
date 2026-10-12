using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Async_ProgressBar_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            EnableFilters(false);
        }
        private const int StudentCount = 30;
        private List<Student> allStudents = new List<Student>();

        private async void btnLoadData_Click(object sender, EventArgs e)
        {
            if (!btnLoadData.Enabled)
            {
                return;
            }

            btnLoadData.Enabled = false;
            progressBar.Value = 0;
            lblProgress.Text = "0%";
            lblStatus.Text = "Đang kết nối nguồn dữ liệu...";
            statusLabel.Text = "Đang tải dữ liệu sinh viên...";
            Cursor = Cursors.WaitCursor;

            var progress = new Progress<int>(percent =>
            {
                progressBar.Value = Math.Max(0, Math.Min(100, percent));
                lblProgress.Text = percent + "%";
                lblStatus.Text = "Đang nạp dữ liệu • " + percent + "%";
                statusLabel.Text = "Đang tải dữ liệu sinh viên • " + percent + "%";
            });

            try
            {
                List<Student> students = await LoadStudentsAsync(progress);
                allStudents = students;
                EnableFilters(true);
                RefreshStudentGrid();
                lblTotal.Text = students.Count.ToString("00");
                lblStatus.Text = "Đã nạp thành công " + students.Count + " sinh viên.";
                statusLabel.Text = "Hoàn tất • Dữ liệu đã sẵn sàng";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Không thể nạp dữ liệu.";
                statusLabel.Text = "Đã xảy ra lỗi khi tải dữ liệu";
                MessageBox.Show("Không thể nạp dữ liệu sinh viên.\n\n" + ex.Message,
                    "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLoadData.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void EnableFilters(bool enabled)
        {
            txtSearch.Enabled = enabled;
            cboStatus.Enabled = enabled;
            btnClearFilter.Enabled = enabled;
        }

        private void RefreshStudentGrid()
        {
            string search = txtSearch.Text.Trim();
            string selectedStatus = cboStatus.SelectedItem == null ? "Tất cả trạng thái" : cboStatus.SelectedItem.ToString();

            var filteredStudents = allStudents.FindAll(student =>
                (search.Length == 0
                    || student.Id.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) >= 0
                    || student.FullName.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) >= 0
                    || student.Major.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) >= 0)
                && (selectedStatus == "Tất cả trạng thái" || student.Status == selectedStatus));

            studentGrid.DataSource = null;
            studentGrid.DataSource = filteredStudents;
            lblFiltered.Text = filteredStudents.Count + " kết quả";
            statusLabel.Text = filteredStudents.Count == allStudents.Count
                ? "Hoàn tất • Đang hiển thị toàn bộ dữ liệu"
                : "Đang lọc • Hiển thị " + filteredStudents.Count + "/" + allStudents.Count + " sinh viên";
        }

        private void filterControl_Changed(object sender, EventArgs e)
        {
            if (allStudents.Count > 0)
            {
                RefreshStudentGrid();
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cboStatus.SelectedIndex = 0;
            RefreshStudentGrid();
        }

        private Task<List<Student>> LoadStudentsAsync(IProgress<int> progress)
        {
            return Task.Run(() =>
            {
                var students = new List<Student>(StudentCount);

                for (int i = 1; i <= StudentCount; i++)
                {
                    Thread.Sleep(100);
                    students.Add(new Student
                    {
                        Id = "SV" + i.ToString("000"),
                        FullName = GetStudentName(i),
                        Major = i % 3 == 0 ? "Công nghệ phần mềm" : (i % 3 == 1 ? "Hệ thống thông tin" : "Khoa học máy tính"),
                        Score = Math.Round(7.0 + ((i * 17) % 30) / 10.0, 1),
                        Status = i % 7 == 0 ? "Cần cải thiện" : "Đang học"
                    });

                    progress.Report(i * 100 / StudentCount);
                }

                return students;
            });
        }

        private static string GetStudentName(int index)
        {
            string[] names = { "Nguyễn Minh Anh", "Trần Quốc Bảo", "Lê Hoàng Nam", "Phạm Khánh Linh", "Võ Gia Huy", "Đỗ Ngọc Mai" };
            return names[(index - 1) % names.Length];
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private sealed class Student
        {
            public string Id { get; set; }
            public string FullName { get; set; }
            public string Major { get; set; }
            public double Score { get; set; }
            public string Status { get; set; }
        }
    }
}
