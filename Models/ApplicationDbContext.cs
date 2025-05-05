using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace guvenport.Models
{
    // Renamed the class to avoid conflict with the existing 'ApplicationDbContext' definition  
    public class CustomApplicationDbContext : DbContext
    {
        public CustomApplicationDbContext(DbContextOptions<CustomApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
