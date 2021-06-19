using ResumeBuilder.Data.Models.User;
using ResumeBuilder.Data.Services;
using ResumeBuilder.Data.Services.Manager;
using ResumeBuilder.Data.Services.TokenService;
using ResumeBuilder.DTO.Account;
using ResumeBuilder.Utilities;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ResumeBuilderAPI.Factories
{
    public class AccountFactory : IAccountFactory
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly ICommonService _commonService;
        private readonly ITokenService _tokenService;
        #endregion

        #region Constructor
        public AccountFactory(IUserService userService, ICommonService commonService, ITokenService tokenService)
        {
            _userService = userService;
            _commonService = commonService;
            _tokenService = tokenService;
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

        public void Logout(string token)
        {
            _tokenService.Delete(token);
        }

        #endregion

    }
}
