using System.ComponentModel.DataAnnotations;

namespace ResumeBuilder.Utilities
{
    public enum UserRoles
    {
        Admin = 1,
        EndUser = 2,
        DeveloperUser = 3
    }
    public enum Gender
    {
        Male = 1,
        Female = 2,
        NotDisclosed = 3
    }

    public enum AccountStatus
    {
        Blocked = 1,
        Banned = 2
    }

    public enum UserAccountStatus
    {
        [Display(Name = "Success")]
        Success = 1,
        [Display(Name = "Incorrect Password")]
        IncorrectPassword = 2,
        [Display(Name = "Incorrect UserName/Email")]
        IncorrectUserName = 3,
    }

    public enum TemplateType
    {
        [Display(Name = "Single Page")]
        SinglePage = 1,
        [Display(Name = "Multi Page")]
        MultiPage = 2
    }
}
