using LogicLayer.Mapper;
using LogicLayer.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace LogicLayer.Extension
{
    public static class Extension
    {
        public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            //configure data access layer
            DataAccessLayer.Extension.Extension.ConfigureApplication(services, configuration);
           
            //configure service
            services.AddScoped<SubjectService>();

            //configure mapper
            services.AddAutoMapper(typeof(SubjectMapper));
        }
    }
}
