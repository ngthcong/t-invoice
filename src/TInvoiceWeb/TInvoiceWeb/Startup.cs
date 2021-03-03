using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using TInvoiceWeb.Data;
using TInvoiceWeb.Helpers;
using TInvoiceWeb.Interfaces;
using TInvoiceWeb.Interfaces.Repository;
using TInvoiceWeb.Interfaces.Service;
using TInvoiceWeb.Repositories;
using TInvoiceWeb.Services;


namespace TInvoiceWeb
{
    public class Startup
    {
        private const string SPA_ROOT_PATH = "reactjs";
        private const bool BUILD_WITH_SPA = true;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddDbContext<TInvoiceDBContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITMABankService, TMABankService>();
            services.AddScoped<IProjectService, ProjectService>();


            if (BUILD_WITH_SPA)
                services.AddSpaStaticFiles((cfg) =>
                {
                    cfg.RootPath = $"{SPA_ROOT_PATH}/build";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseMiddleware<JwtMiddleware>();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller}/{action=Index}/{id?}");
            });
            // Use single application host
            if (BUILD_WITH_SPA)
                app.UseSpa((cfg) =>
                {
                    cfg.Options.SourcePath = SPA_ROOT_PATH;
                    if (env.IsDevelopment())
                    {
                        cfg.UseReactDevelopmentServer("start");
                    }
                });
        }
    }
}
