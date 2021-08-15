using Microsoft.Extensions.DependencyInjection;
using ResumeBuilder.Data.Services;
using ResumeBuilder.Data.Services.Manager;
using ResumeBuilder.Data.Services.TokenService;

namespace ResumeBuilderAPI.Infrastructure
{
    public static class ServiceRegistrar
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped(typeof(IRepositoryService<>), typeof(RepositoryService<>));
        }
    }
}
