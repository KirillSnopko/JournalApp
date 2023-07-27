using DataAccessLayer.Context;
using DataAccessLayer.Entity;
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
                                                  options.UseLazyLoadingProxies()
                                                         .UseMySql(configuration.GetConnectionString("Develop"), new MySqlServerVersion(new Version(8, 0, 30)))
                                                         .EnableSensitiveDataLogging());

            //configure repository
            services.AddTransient<RepositoryBase<Subject>, SubjectRepository>();
            services.AddTransient<RepositoryBase<GradeLevel>, GradeLevelRepository>();
            services.AddTransient<RepositoryBase<Topic>, TopicRepository>();

            services.AddTransient<RepositoryBase<Student>, StudentRepository>();
            services.AddTransient<RepositoryBase<StudentProfile>, StudentProfileRepository>();
            services.AddTransient<RepositoryBase<Course>, CourseRepository>();
            services.AddTransient<RepositoryBase<Lesson>, LessonRepository>();
        }
    }
}
