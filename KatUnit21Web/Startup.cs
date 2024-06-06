using KatUnit21Web.Controllers;
using KatUnit21Web.Services; 
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KatUnit21Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services) //gets called by runtime
        {
            //register HttpClient
            services.AddHttpClient();

            //rgister controllers
            services.AddControllers();

            //add MPsController as a service
            services.AddScoped<MPsController>();

            //add TheyWorkForYouApiService as a service
            services.AddScoped<TheyWorkForYouApiService>();
        }

     
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)   // gets called by runtime
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // map controllers for routing
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
