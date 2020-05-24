using Core_Azure_Host.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Azure_Host.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AzureDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AzureDbContext>>()))
            {
                if (context.EmployeeDetail.Any())
                {
                    return;
                }
                context.EmployeeDetail.AddRange(
                    new EmployeeDetail
                    {
                        Name = "Sorav Thakur",
                        EmailAddress = "singhsunny126@gmail.com"
                    },
                    new EmployeeDetail
                    {
                        Name = "Demo",
                        EmailAddress = "demo@gmail.com"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
