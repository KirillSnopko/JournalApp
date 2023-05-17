using DataAccessLayer.Context;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DataAccessLayer.Extension
{
    public static class Extension
    {
        public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            //configure context 
            services.AddDbContext<JournalContext>(options =>
    options.UseMySql(configuration.GetConnectionString("Develop"), new MySqlServerVersion(new Version(8, 0, 30))));

            //configure repository
            services.AddScoped<SubjectRepository>();
            services.AddScoped<StudentRepository>();
        }
    }
}
