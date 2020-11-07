using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using spieleliste_backend.Helper;
using spieleliste_backend.Services;
using System.Net.Http;
using System.Threading.Tasks;

namespace spielelistebackendtests.Services
{
    public class IGDBTokenServiceTests
    {
        private IGDBTokenService _sut;

        [SetUp]
        public void Setup()
        {
            var igdbSettingsOptions = Options.Create(ReadIgdbSettings());
            _sut = new IGDBTokenService(new HttpClient(), igdbSettingsOptions);
        }

        [Test]
        public async Task Test_GetNewAccessToken()
        {
            var result = await _sut.GetNewAccessToken();
            Assert.True(result.IsSuccess);
        }

        private static IgdbSettings ReadIgdbSettings()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var igdbSettings = config.GetSection(nameof(IgdbSettings)).Get<IgdbSettings>();
            return igdbSettings;
        }
    }
}