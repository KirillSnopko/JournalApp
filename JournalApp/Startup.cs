using JournalApp.DAO.Context;
using JournalApp.DAO.Repository;
using JournalApp.Logic.Mapper;
using JournalApp.Logic.Service;
using Microsoft.EntityFrameworkCore;

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

            //configure context 
            services.AddDbContext<ApplicationContext>(options =>
     options.UseMySql(Configuration.GetConnectionString("MySQLWork"), new MySqlServerVersion(new Version(8, 0, 30))));

            //configure repository
            services.AddScoped<SubjectRepository>();

            //configure service
            services.AddScoped<SubjectService>();


            //configure mapper
            services.AddAutoMapper(typeof(SubjectMapper));




            services.AddControllers();
            services.AddEndpointsApiExplorer();
            // services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, /*ILoggerService logger*/)
        {
            /*
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cars API V1");
            });

            app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();
            */
            app.UseRouting();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
