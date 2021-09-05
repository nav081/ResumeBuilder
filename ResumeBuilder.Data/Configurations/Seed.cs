using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Data.Models.User;
using ResumeBuilder.Utilities;

namespace ResumeBuilder.Data.Configurations
{
    public static class Seed
    {
        public static void CreateAdminUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id=1,
                    UserName = "Admin",
                    Password = EncryptionHelper.Encrypt("123"),
                    FirstName = "Navneet",
                    MiddleName = "k",
                    LastName = "Yadav",
                    Email = "nicenavneet99@gmail.com",
                    ContactNumber = "+919911227565",
                    Gender = Gender.Male
                }
            );
        }
    }
}
