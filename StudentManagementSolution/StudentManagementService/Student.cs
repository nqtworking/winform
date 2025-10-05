using System;
using System.Runtime.Serialization;

namespace StudentManagementService
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public int Age { get; set; }
    }
}
