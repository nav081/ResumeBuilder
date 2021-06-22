using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ResumeBuilder.Data;
using ResumeBuilder.Data.Services;
using ResumeBuilder.Data.Services.Manager;
using ResumeBuilder.Data.Services.TokenService;
using ResumeBuilderAPI.Factories;
using ResumeBuilderAPI.Filters;

namespace ResumeBuilderAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region Dependancy

            


            //Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped(typeof(IRepositoryService<>), typeof(RepositoryService<>));

            //Factories
            services.AddScoped<IUserFactory, UserFactory>();
            services.AddScoped<IAccountFactory, AccountFactory>();
            services.AddScoped<IResumeBuilderFactory, ResumeBuilderFactory>();
            #endregion

            #region Filters
            services.AddScoped<AuthenticationFilter>();
            #endregion


            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer();
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000")
                                                          .AllowAnyHeader()
                                                          .AllowAnyMethod();
                                  });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ResumeBuilderAPI", Version = "v1" });
                c.OperationFilter<CustomHeaderSwaggerAttribute>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IAccountFactory _account)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ResumeBuilderAPI v1"));
            }
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new MyAuthorizationFilter() }
            });
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            RecurringJob.RemoveIfExists("SendInactiveAlert");
            RecurringJob.AddOrUpdate("SendInactiveAlert", () => new Controllers.RecurringJobController(_account).RemoveInactiveToken(), Cron.Daily);
        }
    }
}
