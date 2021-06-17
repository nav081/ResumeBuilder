using ResumeBuilder.Utilities;

namespace ResumeBuilder.DTO.Account
{
    public class LoginResponseModel
    {
        public UserAccountStatus Status { get; set; }
        public string  Message { get; set; }
        public string Token { get; set; }
    }
}
