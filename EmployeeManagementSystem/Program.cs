
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Data.Context;
using EmployeeManagementSystem.Domain.Helpers;
using EmployeeManagementSystem.Data.Repository;
using EmployeeManagementSystem.Domain.Interfaces;
using EmployeeManagementSystem.Data.Services;

namespace EmployeeManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Database connection string configuration
            builder.Services.AddDbContextPool<EmployeeDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeManagementSystem"));
            });

            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

            // Registering scoped services for repository interfaces.
            // This allows for the use of dependency injection to provide instances of these repositories
            // to various parts of the application, ensuring data access is scoped to the current request.
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}