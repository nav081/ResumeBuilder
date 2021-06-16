using ResumeBuilder.Data.Models.Common;
using ResumeBuilder.Utilities;

namespace ResumeBuilder.Data.Models.User
{
    public class User: BaseEntitites
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public UserRoles Roles { get; set; }
        public string Token { get; set; }
        public string EmailVerificationCode { get; set; }
        public string MobileVerificationCode { get; set; }
        public Gender Gender { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public string Zipcode { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string ReferalCode { get; set; }
        public bool IsTwoFactorEnabled { get; set; }
        public string IpAdress { get; set; }
        public AccountStatus Status { get; set; }
        public bool NewsletterSubcription { get; set; }

    }
}
