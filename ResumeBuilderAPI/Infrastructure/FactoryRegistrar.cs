using Microsoft.Extensions.DependencyInjection;
using ResumeBuilderAPI.Factories;
using ResumeBuilderAPI.Factories.Templates;

namespace ResumeBuilderAPI.Infrastructure
{
    public static class FactoryRegistrar
    {
        public static void RegisterFactories(this IServiceCollection services)
        {
            services.AddScoped<IUserFactory, UserFactory>();
            services.AddScoped<IAccountFactory, AccountFactory>();
            services.AddScoped<IResumeBuilderFactory, ResumeBuilderFactory>();
            services.AddScoped<ITemplatesFactory, TemplatesFactory>();
        }
    }
}
