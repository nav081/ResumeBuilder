using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using ResumeBuilder.Data.Models.Common;
using ResumeBuilder.Data.Models.User;
using ResumeBuilder.Data.Services;
using ResumeBuilder.Data.Services.Manager;
using ResumeBuilder.Data.Services.TokenService;
using ResumeBuilder.Utilities;
using ResumeBuilderAPI.Factories;
using System.Threading.Tasks;

namespace ResumeBuilder.Test.API.Factories
{
    class AccountFactoryTests
    {
        private AccountFactory _systemUnderTest;
        private Mock<IUserService> _userServiceMock;
        private Mock<ICommonService> _commonServiceMock;
        private Mock<ITokenService> _tokenServiceMock;
        private Mock<IRepositoryService<Token>> _tokenRepositoryMock;
        private Mock<IConfiguration> _configMock;

        [SetUp]
        public void Setup()
        {
            _userServiceMock = new Mock<IUserService>();
            _commonServiceMock = new Mock<ICommonService>();
            _tokenRepositoryMock = new Mock<IRepositoryService<Token>>();
            _tokenServiceMock = new Mock<ITokenService>();
            _configMock = new Mock<IConfiguration>();
            _systemUnderTest = new AccountFactory(_userServiceMock.Object,
                _commonServiceMock.Object,
                _tokenServiceMock.Object,
                _tokenRepositoryMock.Object,
                _configMock.Object);
        }

        [Test]
        public async Task GetUserStatusBy_BlankInfo_()
        {
            _userServiceMock.Setup(a => a.Get("Test")).Returns(Task.FromResult(default(User)));
            var response = await _systemUnderTest.GetUserStatusBy("Test", "123");            
            Assert.AreEqual(response.Status, UserAccountStatus.IncorrectUserName);
        }

        [Test]
        public async Task GetUserStatusBy_IncorrectPassword()
        {
            _userServiceMock.Setup(a => a.Get("Test")).Returns(Task.FromResult(new User { UserName = "Test", Password = "TLHjuTFxUHxvymkOYn8vPA==" }));
            var response = await _systemUnderTest.GetUserStatusBy("Test", "1234");            
            Assert.AreEqual(response.Status, UserAccountStatus.IncorrectPassword);
        }

        [Test]
        public async Task GetUserStatusBy_CorrectInfo()
        {
            _userServiceMock.Setup(a => a.Get("Test")).Returns(Task.FromResult(new User { UserName = "Test", Password = "TLHjuTFxUHxvymkOYn8vPA==" }));
            var response = await _systemUnderTest.GetUserStatusBy("Test", "123");            
            Assert.AreEqual(response.Status, UserAccountStatus.Success);
        }


    }
}
