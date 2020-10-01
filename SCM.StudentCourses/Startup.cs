using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SCM.StudentCourses.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using SCM.StudentCourses.Mapper;
using SCM.StudentCourses.Repositories.Interfaces;
using SCM.StudentCourses.Repositories.Implementations;
using SCM.StudentCourses.Services.Interfaces;
using SCM.StudentCourses.Services.Implementations;
using SCM.StudentCourses.Services.ExternalResources;
namespace SCM.StudentCourses
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<StudentCoursesDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("StudentCourseDbCS")));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new StudentCourseMapper());
                mc.AddProfile(new CourseMapper());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IStudentCourseRepository, StudentCourseRepository>();
            services.AddTransient<IStudentService,StudentService>();  
            services.AddTransient<IStudentCourseService, StudentCourseService>();  
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseService, CourseService>();
            // Register the Swagger services
            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UpdateDatabase(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseHttpsRedirection();
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()); 
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<StudentCoursesDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
