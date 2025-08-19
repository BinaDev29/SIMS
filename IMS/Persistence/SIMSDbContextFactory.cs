using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Persistence
{
    public class SIMSDbContextFactory : IDesignTimeDbContextFactory<SIMSDbContext>
    {
        public SIMSDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<SIMSDbContext>();
            var connectionString = configuration.GetConnectionString("InventoryConnectionString");
            builder.UseSqlServer(connectionString);

            return new SIMSDbContext(builder.Options);
        }
    }
}