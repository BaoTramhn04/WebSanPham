using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebProductManagement.Data
{
    // EF CLI sẽ dùng class này để khởi tạo DbContext ở thời gian thiết kế
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            // Dùng cùng connection string như appsettings (hoặc trực tiếp đặt ở đây)
            optionsBuilder.UseSqlServer("Server=DESKTOP-3VJI60G;Database=ProductDB;Trusted_Connection=True;TrustServerCertificate=True;");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
