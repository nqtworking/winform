using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StudentManagementService
{
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        List<Student> GetAllStudents();

        [OperationContract]
        Student GetStudentById(int id);

        [OperationContract]
        void AddStudent(Student student);

        [OperationContract]
        void UpdateStudent(Student student);

        [OperationContract]
        void DeleteStudent(int id);
    }
}
