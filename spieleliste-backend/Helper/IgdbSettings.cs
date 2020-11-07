using System;

namespace spieleliste_backend.Helper
{
    public class IgdbSettings
    {
        public IgdbSettings(string clientSecret, string clientId, string grantType)
        {
            ClientSecret = clientSecret;
            ClientId = clientId;
            GrantType = grantType;
        }

        [Obsolete("Framework only")]
        public IgdbSettings() { }

        public string ClientSecret { get; set; }
        public string ClientId { get; set; }
        public string GrantType { get; set; }
    }
}