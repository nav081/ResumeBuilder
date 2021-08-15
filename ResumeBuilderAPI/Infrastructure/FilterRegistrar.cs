using Microsoft.Extensions.DependencyInjection;
using ResumeBuilderAPI.Filters;

namespace ResumeBuilderAPI.Infrastructure
{
    public static class FilterRegistrar
    {
        public static void RegisterFilters(this IServiceCollection services) 
        {
            services.AddScoped<AuthenticationFilter>();
        }
    }
}
