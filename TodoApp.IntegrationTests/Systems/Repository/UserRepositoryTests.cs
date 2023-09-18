namespace TodoApp.IntegrationTests.Systems.Repository
{
    public class UserRepositoryTests : IClassFixture<DBFixtures>
    {
        private readonly DBFixtures _fixture;
        public UserRepositoryTests(DBFixtures fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetUsersAsync_WhenCalled_ReturnsUserLists()
        {
            // Arrange

            var sut = new UserRepository(_fixture.DbContext);

            // Act

            var user = await sut.GetUsersAsync();

            // Assert

            user.Should().NotBeNull();
            Assert.IsType<List<User>>(user);

        }

        [Fact]
        public async Task GetUsersAsync_WhenCalled_ReturnsZeroUsers()
        {
            // Arrange
            var sut = new UserRepository(_fixture.DbContext);


            // Act
            var user = await sut.GetUsersAsync();


            // Assert
            Assert.Equal(0, user.Count);
        }

        [Fact]
        public async Task CreateUserAsync_WhenCalled_ReturnsId()
        {
            // Arrange

            var fixture = new Fixture();
            var inputData = fixture.Build<User>()
                .Without(p => p.Id)
                .Create();
            var sut = new UserRepository(_fixture.DbContext);

            // Act

            var result = await sut.CreteUserAsync(inputData);

            // Assert

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }
    }
}
