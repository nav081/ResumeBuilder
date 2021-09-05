using Microsoft.Extensions.Configuration;
using ResumeBuilder.Data.Models.Common;
using ResumeBuilder.Data.Models.User;
using ResumeBuilder.Data.Services;
using ResumeBuilder.Data.Services.Manager;
using ResumeBuilder.Data.Services.TokenService;
using ResumeBuilder.DTO.Account;
using ResumeBuilder.Utilities;
using System;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Factories
{
    public class AccountFactory : IAccountFactory
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly ICommonService _commonService;
        private readonly ITokenService _tokenService;
        private readonly IRepositoryService<Token> _tokenRepository;
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructor
        public AccountFactory(IUserService userService, ICommonService commonService, ITokenService tokenService, IRepositoryService<Token> tokenRepository, IConfiguration configuration)
        {
            _userService = userService;
            _tokenRepository = tokenRepository;
            _commonService = commonService;
            _tokenService = tokenService;
            Configuration = configuration;
        }
        #endregion

        #region Methods
        public async Task<UserStatusResponseModel> GetUserStatusBy(string Username, string Password)
        {
            var user = await _userService.Get(Username);
            if (user is null)
                return new UserStatusResponseModel { Status = UserAccountStatus.IncorrectUserName };
            if (EncryptionHelper.Decrypt(user.Password) == Password)
                return new UserStatusResponseModel { Status = UserAccountStatus.Success,Data=user };
            else
                return new UserStatusResponseModel { Status = UserAccountStatus.IncorrectPassword };
        }

        public async Task<LoginResponseModel> Login(string username, string password, string ipaddress)
        {
            var response = new LoginResponseModel();

            var user =await GetUserStatusBy(username, password);
            response.Status = user.Status;
            response.Message = Enum.GetName(typeof(UserAccountStatus), user.Status);
            if (response.Status == UserAccountStatus.Success)
                response.Token = await _commonService.GenerateToken(user.Data.Id, ipaddress);

            return response;

        }

        public async Task<User> GetByToken(string token, string ipaddress)
        {
            return await _commonService.GetUserByToken(token,ipaddress);
        }

        public async Task Logout(string token)
        {
            await _tokenService.DeleteAsync(token);
        }

        public async Task RemoveInactive()
        {
            var duration = Configuration.GetValue<int>("UserManagement:LogoutInactiveUsers");
            var allinactivetoken =await _commonService.AllInActive(DateTime.Now.AddDays(-duration));
            await _tokenRepository.DeleteMultipleAsync(allinactivetoken);
        }

        #endregion

    }
}
