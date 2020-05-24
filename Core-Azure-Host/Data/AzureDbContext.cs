using Core_Azure_Host.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_Azure_Host.Data
{
    public class AzureDbContext : DbContext
    {
        public AzureDbContext(DbContextOptions<AzureDbContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeDetail> EmployeeDetail { get; set; }
    }
}
