namespace TodoApp.UnitTests.Systems.Repository
{
    public class UserRepositoryTests
    {
        private readonly Mock<IMongoDbContext> _userDbServiceMock;
        private readonly Fixture _fixture;
        private readonly IUserRepository _sut;

        public UserRepositoryTests()
        {
            _fixture = new Fixture();
            _userDbServiceMock = new Mock<IMongoDbContext>();
            _sut = new UserRepository(_userDbServiceMock.Object);
        }
        [Fact]
        public async Task GetUserAsync_WhenCalled_ReturnUserList()
        {
            // Arrange

            var data = _fixture.Create<List<User>>();
            _userDbServiceMock
                .Setup(service => service.GetUsersAsync())
                .ReturnsAsync(data);

            // Act

            var result = await _sut.GetUsersAsync();

            // Assert

            Assert.Equal(data, result);
            Assert.IsType<List<User>>(result);
            _userDbServiceMock
                .Verify(service => service.GetUsersAsync(), Times.Once());
        }

        [Fact]
        public async Task CreateUserAsync_WhenCalled_ReturnIdString()
        {
            // Arrange

            var returnData = _fixture.Create<string>();
            var inputData = _fixture.Create<User>();
            _userDbServiceMock
                .Setup(service => service.CreteUserAsync(inputData))
                .ReturnsAsync(returnData);

            // Act

            var result = await _sut.CreteUserAsync(inputData);

            // Assert

            Assert.IsType<string>(result);
            Assert.Equal(returnData, result);
            _userDbServiceMock
                .Verify(service => service.CreteUserAsync(inputData), Times.Once());
        }
    }
}
