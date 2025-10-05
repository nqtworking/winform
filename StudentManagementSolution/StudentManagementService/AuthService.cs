using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;

namespace StudentManagementService
{
    public class AuthService : IAuthService
    {
        // This would typically come from a database
        private Dictionary<string, string> _users = new Dictionary<string, string>
        {
            { "admin", "password123" }
        };

        // In production, use a more secure storage
        private static Dictionary<string, DateTime> _validTokens = new Dictionary<string, DateTime>();

        public AuthenticationToken Login(string username, string password)
        {
            if (!_users.ContainsKey(username) || _users[username] != password)
            {
                throw new FaultException("Invalid credentials");
            }

            // Generate token
            var tokenString = GenerateToken();
            var expiration = DateTime.Now.AddHours(1);
            
            // Store token
            _validTokens[tokenString] = expiration;

            return new AuthenticationToken
            {
                Token = tokenString,
                ExpiresAt = expiration
            };
        }

        private string GenerateToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());
            return token;
        }

        public static bool ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                return false;

            return _validTokens.ContainsKey(token) && _validTokens[token] > DateTime.Now;
        }
    }
}