using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using spieleliste_backend.Helper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace spieleliste_backend.Services
{
    public interface IIGDBTokenService
    {
        Task<Result<IgdbResponse>> GetNewAccessToken();
    }

    public class IGDBTokenService : IIGDBTokenService
    {
        private const string _baseUrl = "https://id.twitch.tv/oauth2/token";
        private readonly HttpClient _client;
        private readonly IgdbSettings _settings;

        public IGDBTokenService(HttpClient client, IOptions<IgdbSettings> igdbSettingsOptions)
        {
            _client = client;
            _settings = igdbSettingsOptions.Value;
        }

        public async Task<Result<IgdbResponse>> GetNewAccessToken()
        {
            var response = await _client.PostAsync(GetUrl(), null);
            var body = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return Result.Failure<IgdbResponse>(body);
            }

            var igdbResponse = DeserializeRespone(body);
            return Result.Success(igdbResponse);
        }

        private IgdbResponse DeserializeRespone(string body)
        {
            return JsonConvert.DeserializeObject<IgdbResponse>(body, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            });
        }

        private Uri GetUrl()
        {
            var param = new Dictionary<string, string>()
            {
                ["client_secret"] = _settings.ClientSecret,
                ["client_id"] = _settings.ClientId,
                ["grant_type"] = _settings.GrantType
            };

            var url = new Uri(QueryHelpers.AddQueryString(_baseUrl, param));
            return url;
        }
    }
}