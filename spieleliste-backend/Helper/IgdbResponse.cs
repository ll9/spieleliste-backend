using System;

namespace spieleliste_backend.Helper
{
    public class IgdbResponse
    {
        public IgdbResponse(string accessToken, long expiresIn, string tokenType)
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
            TokenType = tokenType;
            ExpirationDate = DateTime.Now.Add(TimeSpan.FromSeconds(expiresIn));
        }

        public string AccessToken { get; set; }
        public long ExpiresIn { get; set; }
        public string TokenType { get; set; }
        public DateTime ExpirationDate { get; set; }

        public bool IsExpired()
        {
            return ExpirationDate < DateTime.Now;
        }
    }
}