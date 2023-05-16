
using Microsoft.OpenApi.Models;

namespace WebApp
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
            //configure logging
            /*
            var nlogConfig = new LoggingConfiguration();

            nlogConfig.AddRule(minLevel: NLog.LogLevel.Trace, maxLevel: NLog.LogLevel.Fatal,
                target: new ConsoleTarget("consoleTarget")
                {
                    Layout = "${level} [${longdate}]: \n message=${message}"
                });
            LogManager.Configuration = nlogConfig;

            services.AddSingleton<ILoggerService, LoggerService>();*/


            //configure Logic layer and data access layer
            LogicLayer.Extension.Extension.ConfigureApplication(services, Configuration);


            services.AddControllers();
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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*, ILoggerService logger*/)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cars API V1");
            });

            // app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
