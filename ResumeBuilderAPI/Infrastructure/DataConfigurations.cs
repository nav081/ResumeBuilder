using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResumeBuilder.Data;

namespace ResumeBuilderAPI.Infrastructure
{
    public static class DataConfigurations
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configurations) 
        {
            services.AddDbContext<DatabaseContext>(options =>
                    options.UseSqlServer(configurations.GetConnectionString("DefaultConnection")));
            services.AddControllers();
        }
        public static void ConfigureCaching(this IServiceCollection services , IConfiguration configurations)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configurations.GetConnectionString("RedisConnection");
                options.InstanceName = "ResumeBuilder";
            });
        }
    }
}
