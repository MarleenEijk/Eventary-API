using Microsoft.EntityFrameworkCore;
using DAL;
using CORE.Interfaces;
using CORE.Repositories;
using CORE.Services;
using DAL.Repositories;

namespace Eventary_API
{
    public partial class Program
    {
        protected Program() { }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("conn");
            builder.Services.AddDbContext<AppDbContext>(options =>
                 options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<EmployeeService>();
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<ItemService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<OrderService>();
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<CompanyService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", policy =>
                {
                    policy.WithOrigins(
                        "https://eventary-frontend.victoriousrock-cc8323fc.northeurope.azurecontainerapps.io",
                        "http://localhost:4200",
                        "http://localhost:4201",
                        "http://localhost:8080",
                        "http://52.158.32.127:4200"
                    )
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                });
            }

            app.UseCors("MyCors");

            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();
            app.MapGet("/", () => "Welcome to Eventary API");

            app.Run();
        }
    }
}
