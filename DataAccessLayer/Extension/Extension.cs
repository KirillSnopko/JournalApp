using DataAccessLayer.Context;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using DataAccessLayer.Repository.iFace;
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
            services.AddScoped<RepositoryBase<Subject>, SubjectRepository>();
            services.AddScoped<RepositoryBase<GradeLevel>, GradeLevelRepository>();
            services.AddScoped<RepositoryBase<Topic>, TopicRepository>();

            services.AddScoped<RepositoryBase<Student>, StudentRepository>();
            services.AddScoped<RepositoryBase<StudentProfile>, StudentProfileRepository>();
            services.AddScoped<RepositoryBase<Course>, CourseRepository>();
            services.AddScoped<RepositoryBase<Lesson>, LessonRepository>();
        }
    }
}
