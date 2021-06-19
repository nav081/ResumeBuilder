using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Data.Models.Common;
using ResumeBuilder.Data.Models.CV;
using ResumeBuilder.Data.Models.User;

namespace ResumeBuilder.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public DbSet<Body> Bodies { get; set; }
        public DbSet<Footer> Footer { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<Salutation> Salutations { get; set; }
        public DbSet<Template> Templates { get; set; }

    }
}
