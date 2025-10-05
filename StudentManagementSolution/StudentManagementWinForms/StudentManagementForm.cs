using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using StudentManagementWinForms.StudentManagementServiceReference;

namespace StudentManagementWinForms
{
    public partial class StudentManagementForm : Form
    {
        private StudentServiceClient serviceClient;

        public StudentManagementForm()
        {
            InitializeComponent();
            
            this.Load += StudentManagementForm_Load;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
            dataGridViewStudents.SelectionChanged += dataGridViewStudents_SelectionChanged;
        }

        private void StudentManagementForm_Load(object sender, EventArgs e)
        {
            try
            {
                serviceClient = new StudentServiceClient();
                LoadStudents();
                
                // Ban đầu vô hiệu hóa nút Update và Delete
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStudents()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                List<Student> students = serviceClient.GetAllStudents().ToList();
                dataGridViewStudents.DataSource = null;
                dataGridViewStudents.DataSource = students;
                
                // Format cột nếu cần
                if (dataGridViewStudents.Columns.Count > 0)
                {
                    dataGridViewStudents.Columns["Id"].HeaderText = "ID";
                    dataGridViewStudents.Columns["Name"].HeaderText = "Student Name";
                    dataGridViewStudents.Columns["Age"].HeaderText = "Age";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Please enter a valid age", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAge.Focus();
                return;
            }

            try
            {
                var student = new Student
                {
                    Name = txtName.Text.Trim(),
                    Age = age
                };

                serviceClient.AddStudent(student);
                LoadStudents();
                ClearInputs();
                MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to update", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Please enter a valid age", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAge.Focus();
                return;
            }

            try
            {
                var student = dataGridViewStudents.SelectedRows[0].DataBoundItem as Student;
                student.Name = txtName.Text.Trim();
                student.Age = age;

                serviceClient.UpdateStudent(student);
                LoadStudents();
                ClearInputs();
                MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to delete", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var student = dataGridViewStudents.SelectedRows[0].DataBoundItem as Student;
                var result = MessageBox.Show($"Are you sure you want to delete student {student.Name}?", 
                                          "Confirm Delete", 
                                          MessageBoxButtons.YesNo, 
                                          MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    serviceClient.DeleteStudent(student.Id);
                    LoadStudents();
                    ClearInputs();
                    MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadStudents();
        }

        private void dataGridViewStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                var student = dataGridViewStudents.SelectedRows[0].DataBoundItem as Student;
                if (student != null)
                {
                    txtName.Text = student.Name;
                    txtAge.Text = student.Age.ToString();
                    
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            else
            {
                ClearInputs();
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void ClearInputs()
        {
            txtName.Text = string.Empty;
            txtAge.Text = string.Empty;
            
            if (dataGridViewStudents.Rows.Count > 0)
            {
                dataGridViewStudents.ClearSelection();
            }
            
            txtName.Focus();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            
            if (serviceClient != null)
            {
                try
                {
                    // Đóng client đúng cách
                    if (serviceClient.State != System.ServiceModel.CommunicationState.Faulted)
                    {
                        serviceClient.Close();
                    }
                    else
                    {
                        serviceClient.Abort();
                    }
                }
                catch
                {
                    // Nếu không thể đóng, abort client
                    serviceClient.Abort();
                }
            }
        }
    }
}