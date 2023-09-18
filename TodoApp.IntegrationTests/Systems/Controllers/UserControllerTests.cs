namespace TodoApp.IntegrationTests.Systems.Controllers
{
    public class UserControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public UserControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetUser_WhenCalled_ReturnSuccessStatus()
        {
            // Act
            var response = await _client.GetAsync(ApiRoutes.UserApi);

           // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CreateUserAsync_WhenCalled_ReturnBadRequest()
        {
            // Arrange
            var fixture = new Fixture();
            var data = fixture.Build<User>()
                .OmitAutoProperties()
                .Create();
            var inputData =new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync(ApiRoutes.UserApi, inputData);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);            
        }

        [Fact]
        public async Task CreateUserAsync_WhenCalled_ReturnSuccessCode201()
        {
            // Arrange
            var fixture = new Fixture();
            var data = fixture.Build<User>().Without(p => p.Id).Create();
            var inputData = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync(ApiRoutes.UserApi, inputData);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task CreateUserAsync_WhenCalled_ReturnInternalServerError500()
        {
            // Arrange
            var fixture = new Fixture();
            var data = fixture.Create<User>();
            var inputData = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync(ApiRoutes.UserApi, inputData);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
        }


    }
}
