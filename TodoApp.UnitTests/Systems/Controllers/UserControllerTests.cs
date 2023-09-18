namespace TodoApp.UnitTests.Systems.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Fixture _fixture;
        private readonly UserController _sut;
        public UserControllerTests() 
        {
            _fixture = new Fixture();
            _userServiceMock = new Mock<IUserService>();
            _sut = new UserController(_userServiceMock.Object);
        }

        [Fact]
        public async Task GetUser_WhenCalled_Return200StatusCode()
        {
            //Arrange
            
            var data = _fixture.Create<List<User>>();
            _userServiceMock
                .Setup(service => service.GetUserListAsync())
                .ReturnsAsync(data);

            // Act

            var result = (OkObjectResult)await _sut.GetUsersAsync();

            // Assert

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(data, result.Value);
            _userServiceMock.Verify(s => s.GetUserListAsync(), Times.Once);

        }

        [Fact]
        public async Task GetUser_WhenCalled_ReturnNoContent()
        {
            var data = _fixture.CreateMany<User>(0).ToList();
            _userServiceMock
                .Setup (service => service.GetUserListAsync())
                .ReturnsAsync(data);

            // Act

            var result = (NoContentResult) await _sut.GetUsersAsync();

            // Assert

            Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, result.StatusCode);

        }
    }
}
