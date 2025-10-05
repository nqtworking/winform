using System.Collections.Generic;
using System.Data.SqlClient;

namespace StudentManagementService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StudentService : IStudentService
    {
        private string connectionString = "Data Source=.;Initial Catalog=StudentManagementDB;Integrated Security=True";
        public List<Student> GetAllStudents() {
            var students = new List<Student>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Id, Name, Age FROM Students", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Age = (int)reader["Age"]
                    });
                }
            }

            return students;
        }

        public Student GetStudentById(int id)
        {
            Student student = null;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Id, Name, Age FROM Students WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    student = new Student
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Age = (int)reader["Age"]
                    };
                }
            }
            return student;
        }

        public void AddStudent(Student student)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Students (Name, Age) VALUES (@Name, @Age)", conn);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Students SET Name = @Name, Age = @Age WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Id", student.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Students WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
