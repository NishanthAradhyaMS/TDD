namespace TodoApp.UnitTests.Systems.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userDbServiceMock;
        private readonly Fixture _fixture;
        private readonly IUserService _sut;
        public UserServiceTests()
        {
            _fixture = new Fixture();
            _userDbServiceMock = new Mock<IUserRepository>();
            _sut = new UserService(_userDbServiceMock.Object);
        }

        [Fact]
        public async Task GetUsersDB_WhenCalled_Returns_UsersList()
        {
            // Arrange

            var data = _fixture.Create<List<User>>();
            _userDbServiceMock
                .Setup(service => service.GetUsersAsync())
                .ReturnsAsync(data);

            // Act

            var result = await _sut.GetUserListAsync();

            // Assert

            Assert.Equal(data, result);
            Assert.IsType<List<User>>(result);
            _userDbServiceMock
                .Verify(service => service.GetUsersAsync(), Times.Once());
        }

        [Fact]
        public async Task CreateUserAsync_WhenCalled_ReturnId()
        {
            // Arrange

            var returnData= _fixture.Create<string>();
            var inputData= _fixture.Create<User>();
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
