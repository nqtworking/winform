using System;
using System.ServiceModel;
using StudentManagementService;

namespace StudentManagementWinForms
{
    public static class TokenManager
    {
        private static string _token;
        private static DateTime _expiration = DateTime.MinValue;

        public static string Token 
        { 
            get { return _token; }
            private set { _token = value; }
        }

        public static bool IsAuthenticated
        {
            get { return !string.IsNullOrEmpty(_token) && _expiration > DateTime.Now; }
        }

        public static void Login(string username, string password)
        {
            var authClient = new AuthServiceClient();
            try
            {
                var result = authClient.Login(username, password);
                _token = result.Token;
                _expiration = result.ExpiresAt;
            }
            finally
            {
                if (authClient.State == CommunicationState.Opened)
                    authClient.Close();
                else
                    authClient.Abort();
            }
        }

        public static void AddTokenToHeader(ClientBase<IStudentService> client)
        {
            if (IsAuthenticated)
            {
                using (var scope = new OperationContextScope(client.InnerChannel))
                {
                    var header = MessageHeader.CreateHeader("AuthToken", "http://tempuri.org", _token);
                    OperationContext.Current.OutgoingMessageHeaders.Add(header);
                }
            }
            else
                throw new InvalidOperationException("Not authenticated");
        }
    }

    // Temporary interface definition to make the code compile
    public interface IStudentServices
    {
    }

    // Temporary class to make the code compile
    public class StudentServiceClient : ClientBase<IStudentService>, IStudentService
    {
    }
}