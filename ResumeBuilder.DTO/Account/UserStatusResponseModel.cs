using ResumeBuilder.Data.Models.User;
using ResumeBuilder.Utilities;

namespace ResumeBuilder.DTO.Account
{
    public class UserStatusResponseModel
    {
        public UserAccountStatus Status { get; set; }
        public User Data { get; set; }
    }
}
