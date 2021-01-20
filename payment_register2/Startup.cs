using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using MySqlConnector;
using payment_register2.Models;

namespace payment_register2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddJsonOptions(
                options => {
                    var resolver = options.JsonSerializerOptions.PropertyNamingPolicy = null;
                }
            );
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddTransient<IPaymentDetailRepo, PaymentDetailRepo>();
            // services.AddSwaggerGen();
            // services.AddSingleton<IDbExecutor, MySqlExecutor>(x => new MySqlExecutor(Configuration.GetConnectionString("DevConnection")));
            // services.AddDbContextPool<PaymentDetailContext>(
            // dbContextOptions => dbContextOptions
            //     .UseMySql(
            //         // Replace with your connection string.
            //         Configuration.GetConnectionString("DevConnection"),
            //         // Replace with your server version and type.
            //         // For common usages, see pull request #1233.
            //         new MySqlServerVersion(new Version(10, 3, 22)), // use MariaDbServerVersion for MariaDB
            //         mySqlOptions => mySqlOptions
            //             .CharSetBehavior(CharSetBehavior.NeverAppend))
            //     // Everything from this point on is optional but helps with debugging.
            //     .EnableSensitiveDataLogging()
            //     .EnableDetailedErrors()
            // );
            services.AddCors(options => options.AddPolicy("PaymentDetail", builder =>
            {
                builder.WithOrigins("http://localhost:5001").AllowAnyMethod().AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseCors(options => options.WithOrigins("http://localhost:5001")
                .AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
