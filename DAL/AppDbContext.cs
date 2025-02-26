using Microsoft.EntityFrameworkCore;
using CORE.Dto;
namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<EmployeeDto> employee { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
