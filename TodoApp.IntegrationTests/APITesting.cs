namespace TodoApp.IntegrationTests
{
    public class APITesting : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;
        public APITesting(WebApplicationFactory<Program> factory)
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetHealthy_WhenCalled_Returns_Healthy()
        {
            var response = await _client.GetAsync(ApiRoutes.Healthy);
            var stringResult = await response.Content.ReadAsStringAsync();
            Assert.Equal(ApiRoutes.HealthyString, stringResult);
        }
    }
}