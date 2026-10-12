using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson4_6_StudentManagement
{
    public partial class Form1 : Form
    {
        private BindingSource bindingSource;
        private BindingList<Student> studentList;

        public Form1()
        {
            InitializeComponent();
            InitializeData();
            SetupDataBinding();
        }

        private void InitializeData()
        {
            // Khởi tạo danh sách sinh viên
            studentList = new BindingList<Student>
            {
                new Student("SV001", "Nguyễn Văn A", 20, "Nam", ""),
                new Student("SV002", "Trần Thị B", 19, "Nữ", ""),
                new Student("SV003", "Lê Văn C", 21, "Nam", ""),
                new Student("SV004", "Hoàng Thị D", 20, "Nữ", "")
            };

            bindingSource = new BindingSource(studentList, null);
        }

        private void SetupDataBinding()
        {
            // Liên kết DataGridView với BindingSource
            dataGridViewStudents.DataSource = bindingSource;

            // Cấu hình các cột
            dataGridViewStudents.Columns["StudentId"].HeaderText = "Mã SV";
            dataGridViewStudents.Columns["FullName"].HeaderText = "Họ Tên";
            dataGridViewStudents.Columns["Age"].HeaderText = "Tuổi";
            dataGridViewStudents.Columns["Gender"].HeaderText = "Giới Tính";
            dataGridViewStudents.Columns["AvatarPath"].Visible = false;

            // Liên kết TextBox với BindingSource
            txtStudentId.DataBindings.Add("Text", bindingSource, "StudentId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtFullName.DataBindings.Add("Text", bindingSource, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAge.DataBindings.Add("Text", bindingSource, "Age", true, DataSourceUpdateMode.OnPropertyChanged);
            cmbGender.DataBindings.Add("Text", bindingSource, "Gender", true, DataSourceUpdateMode.OnPropertyChanged);

            // Sự kiện chọn dòng trên DataGridView
            dataGridViewStudents.SelectionChanged += DataGridViewStudents_SelectionChanged;

            // Tự động chọn dòng đầu tiên
            if (dataGridViewStudents.Rows.Count > 0)
            {
                dataGridViewStudents.Rows[0].Selected = true;
                LoadAvatar();
            }
        }

        private void DataGridViewStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                LoadAvatar();
            }
        }

        private void LoadAvatar()
        {
            try
            {
                if (bindingSource.Current is Student student && !string.IsNullOrEmpty(student.AvatarPath) && File.Exists(student.AvatarPath))
                {
                    pictureBoxAvatar.Image = Image.FromFile(student.AvatarPath);
                }
                else
                {
                    pictureBoxAvatar.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSelectAvatar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bindingSource.Current is Student student)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        Filter = "Tệp hình ảnh|*.jpg;*.jpeg;*.png;*.bmp|JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|BMP files (*.bmp)|*.bmp|All files (*.*)|*.*",
                        Title = "Chọn ảnh đại diện"
                    };

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        student.AvatarPath = openFileDialog.FileName;
                        LoadAvatar();
                        bindingSource.ResetBindings(false);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sinh viên trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    Student newStudent = new Student(
                        txtStudentId.Text.Trim(),
                        txtFullName.Text.Trim(),
                        int.Parse(txtAge.Text.Trim()),
                        cmbGender.Text
                    );

                    // Kiểm tra trùng mã sinh viên
                    if (studentList.Any(s => s.StudentId == newStudent.StudentId))
                    {
                        MessageBox.Show("Mã sinh viên này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    studentList.Add(newStudent);
                    MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (bindingSource.Current is Student student)
                {
                    if (ValidateInput())
                    {
                        student.StudentId = txtStudentId.Text.Trim();
                        student.FullName = txtFullName.Text.Trim();
                        student.Age = int.Parse(txtAge.Text.Trim());
                        student.Gender = cmbGender.Text;

                        bindingSource.ResetBindings(false);
                        MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sinh viên để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (bindingSource.Current is Student student)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        studentList.Remove(student);
                        MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInput();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sinh viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                    Title = "Xuất danh sách sinh viên",
                    DefaultExt = "csv",
                    FileName = "StudentList.csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToCSV(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCSV(string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    // Ghi header
                    sw.WriteLine("Mã Sinh Viên,Họ Tên,Tuổi,Giới Tính,Đường Dẫn Ảnh");

                    // Ghi dữ liệu
                    foreach (Student student in studentList)
                    {
                        string line = $"\"{student.StudentId}\",\"{student.FullName}\",{student.Age},\"{student.Gender}\",\"{student.AvatarPath}\"";
                        sw.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xuất file CSV: " + ex.Message);
            }
        }

        private void ClearInput()
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            txtAge.Clear();
            cmbGender.SelectedIndex = -1;
            pictureBoxAvatar.Image = null;
            txtStudentId.Focus();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã SV!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            if (!int.TryParse(txtAge.Text, out int age) || age < 1 || age > 100)
            {
                MessageBox.Show("Vui lòng nhập Tuổi hợp lệ (1-100)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAge.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbGender.Text))
            {
                MessageBox.Show("Vui lòng chọn Giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGender.Focus();
                return false;
            }

            return true;
        }
    }
}
