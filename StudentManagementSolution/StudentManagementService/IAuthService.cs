using System.Runtime.Serialization;
using System.ServiceModel;

namespace StudentManagementService
{
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        AuthenticationToken Login(string username, string password);
    }

    [DataContract]
    public class AuthenticationToken
    {
        [DataMember]
        public string Token { get; set; }

        [DataMember]
        public System.DateTime ExpiresAt { get; set; }
    }
}