using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Data.Models.User;

namespace ResumeBuilder.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
