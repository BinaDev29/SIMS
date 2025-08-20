using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SIMSDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("InventoryConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IInwardTransactionRepository, InwardTransactionRepository>();
            services.AddScoped<IOutwardTransactionRepository, OutwardTransactionRepository>();
            services.AddScoped<IReturnTransactionRepository, ReturnTransactionRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IGodownRepository, GodownRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>(); // << This is the missing line
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            return services;
        }
    }
}