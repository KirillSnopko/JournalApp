
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Config;
using NLog.Targets;
using JournalApp.Middleware;

namespace JournalApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //configure Logic layer and data access layer
            LogicLayer.Extension.Extension.ConfigureApplication(services, Configuration);


            services.AddControllersWithViews();
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Journal API",
                    Version = "v1",
                    Description = "An API to perform journal operations",
                    Contact = new OpenApiContact
                    {
                        Name = "Snopko Kirill",
                        Email = "kirillsnopko@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/snopko-kirill/"),
                    },
                });
            });
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
                  .AllowAnyHeader());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*, ILoggerService logger*/)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cars API V1");
            });

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
