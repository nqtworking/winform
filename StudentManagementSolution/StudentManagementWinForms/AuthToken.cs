using System;
using System.Runtime.Serialization;

namespace StudentManagementWinForms.StudentManagementServiceReference
{
    [DataContract]
    public class AuthToken
    {
        [DataMember]
        public string TokenValue { get; set; }
        
        [DataMember]
        public string Username { get; set; }
        
        [DataMember]
        public DateTime ExpirationTime { get; set; }
        
        [DataMember]
        public bool IsValid => DateTime.Now < ExpirationTime;
    }
}