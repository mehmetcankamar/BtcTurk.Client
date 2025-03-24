using System;
using System.Security.Cryptography;
using System.Text;
using BtcTurk.Client.Models.Authentication;

namespace BtcTurk.Client.Authentication
{
    internal class AuthenticationHandler
    {
        private readonly ApiCredentials _credentials;

        public AuthenticationHandler(ApiCredentials credentials)
        {
            _credentials = credentials;
        }

        public string GenerateSignature(string message)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_credentials.ApiSecret));
            byte[] signatureBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
            return Convert.ToBase64String(signatureBytes);
        }

        public string GenerateNonce()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
        }

        public (string Signature, string Nonce) CreateAuthenticationSignature(string httpMethod, string endpoint, string? requestBody = null)
        {
            string nonce = GenerateNonce();
            string message = $"{_credentials.ApiKey}{nonce}{httpMethod.ToUpper()}/api/v1{endpoint}";
            
            if (!string.IsNullOrEmpty(requestBody))
            {
                message += requestBody;
            }

            string signature = GenerateSignature(message);
            return (signature, nonce);
        }
    }
}
