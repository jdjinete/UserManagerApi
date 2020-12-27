using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserManagerApi.Models;

namespace UserManagerApi
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
            var server = Configuration["DBServer"] ?? "localhost";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "ArandaApp";
            var password = Configuration["DBPassword"] ?? "1234";
            var database = Configuration["Database"] ?? "ARANDADB";


            services.AddDbContext<ArandaContext>(options =>
            options.UseSqlServer($"Server=DESKTOP-PDTEPRF;Initial Catalog={database};User Id={user};Password={password}"));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Authentication}/{data?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Filter}/{userName?}/{idRol?}");
            });


            


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //    name: "Authentication",
            //    pattern: "api/{controller}/{action}/{id}",
            //    defaults: new { action = "Index" });
            //});

        }
    }
}
