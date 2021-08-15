using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ResumeBuilderAPI.Factories;
using ResumeBuilderAPI.Filters;

namespace ResumeBuilderAPI.Infrastructure
{
    public static class APIConfigurations
    {
        public static void RegisterAPIConfigurations(this IServiceCollection services, IConfiguration configurations) 
        {
            services.AddHangfire(x => x.UseSqlServerStorage(configurations.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ResumeBuilderAPI", Version = "v1" });
                c.OperationFilter<CustomHeaderSwaggerAttribute>();
            });
        }

        public static void MultilingualConfigurations(this IServiceCollection services)
        {
            services.AddLocalization(options=> {
                options.ResourcesPath = "Resources";
            });
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
        }

        public static void SwaggerConfigurations(this IApplicationBuilder app, IWebHostEnvironment env) 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ResumeBuilderAPI v1"));
            }
        }
        public static void HangFireConfigurations(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new MyAuthorizationFilter() }
            });
        }

        public static void MultilingualConfigurations(this IApplicationBuilder app)
        {
            var supportedCultures = new[] { "en-US", "fr" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                ApplyCurrentCultureToResponseHeaders = true
            });
        }
        public static void RecurringJobs(IAccountFactory _account)
        {
            RecurringJob.RemoveIfExists("SendInactiveAlert");
            RecurringJob.AddOrUpdate("SendInactiveAlert", () => new Controllers.RecurringJobController(_account).RemoveInactiveToken(), Cron.Daily);
        }
    }
}
