using LogicLayer.Mapper;
using LogicLayer.Service;
using LogicLayer.Service.iFaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace LogicLayer.Extension
{
    public static class Extension
    {
        public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            //configure logging

            var nlogConfig = new LoggingConfiguration();

            nlogConfig.AddRule(minLevel: NLog.LogLevel.Trace, maxLevel: NLog.LogLevel.Fatal,
                target: new ConsoleTarget("consoleTarget")
                {
                    Layout = "${level} [${longdate}]: \n message=${message}"
                });
            LogManager.Configuration = nlogConfig;

            services.AddSingleton<ILoggerService, LoggerService>();

            //configure data access layer
            DataAccessLayer.Extension.Extension.ConfigureApplication(services, configuration);


            //configure service
            services.AddTransient<SubjectService>();
            services.AddTransient<GradeLevelService>();
            services.AddTransient<TopicService>();
            services.AddTransient<StudentService>();
            services.AddTransient<StudentProfileService>();
            services.AddTransient<CourseService>();
            services.AddTransient<LessonService>();


            //configure mapper
            services.AddAutoMapper(typeof(MapperDto));
          
        }
    }
}
