using ITI.Application.Interfaces.Repositories;
using ITI.Application.Interfaces.Services;
using ITI.Application.Services;
using ITI.Infrastructure.Persistence.Context;
using ITI.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ITI.WinForms
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            MainMenuForm form;
            try
            {
                form = ServiceProvider.GetRequiredService<MainMenuForm>();
            }
            catch (Exception ex)
            {
                // If DI resolution fails, fall back to constructing the MainMenuForm directly
                System.Diagnostics.Debug.WriteLine($"DI failed to resolve MainMenuForm: {ex.Message}");
                form = new MainMenuForm();
            }

            System.Windows.Forms.Application.Run(form);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Form1>();
            services.AddTransient<MainMenuForm>();
            services.AddTransient<DepartmentForm>();
            services.AddTransient<InstractorForm>();
            services.AddTransient<CourseForm>();
            services.AddTransient<StudentCourseForm>();
            services.AddTransient<CourseSessionForm>();
            services.AddTransient<CourseSessionAttendanceForm>();

            services.AddDbContext<AppDbContext>();
            services.AddScoped<IStudentService,StudentService>();
            services.AddScoped<IStudentRepository,StudentRepository>();
            services.AddScoped<IDepartmentService,DepartmentService>();
            services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            services.AddScoped<IInstractorService,InstractorService>();
            services.AddScoped<IInstractorRepository,InstractorRepository>();
            services.AddScoped<IStudentCourseService,StudentCourseService>();
            services.AddScoped<IStudentCourseRepository,StudentCourseRepository>();
            services.AddScoped<ICourseService,CourseService>();
            services.AddScoped<ICourseRepository,CourseRepository>();
            services.AddScoped<ICourseSessionService,CourseSessionService>();
            services.AddScoped<ICourseSessionRepository,CourseSessionRepository>();
            services.AddScoped<ICourseSessionAttendanceService,CourseSessionAttendanceService>();
            services.AddScoped<ICourseSessionAttendanceRepository,CourseSessionAttendanceRepository>();


        }
    }
}