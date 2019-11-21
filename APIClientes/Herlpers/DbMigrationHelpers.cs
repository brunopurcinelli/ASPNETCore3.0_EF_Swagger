using APIClientes.Context;
using APIClientes.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIClientes.Helpers
{
    public static class DbMigrationHelpers
    {
        /// <summary>
        /// Generate migrations before running this method, you can use command bellow:
        /// Nuget package manager: Add-Migration DbInit -context AdminDbContext -output Data/Migrations
        /// Dotnet CLI: dotnet ef migrations add DbInit -c AdminDbContext -o Data/Migrations
        /// </summary>
        /// <param name="host"></param>
        public static async Task EnsureSeedData(IWebHost host)
        {
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                await EnsureSeedData(services);
            }
        }
        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                context.Database.Migrate();
                await EnsureSeedServerData(context);
            }
        }
        private static async Task EnsureSeedServerData(ApplicationDbContext context)
        {
            try
            {
                var customers = new List<Customer>()
            {
                new Customer(new Guid(), "Antonio", "antinio@ecommerce.com", "Rua 1, 10, 14001-001, Ribeirão Preto, SP", new DateTime(1962, 5, 2),DateTime.UtcNow.ToLocalTime()),
                new Customer(new Guid(), "Carlos", "carlos@ecommerce.com", "Rua 14, 48, 14002-001, Ribeirão Preto, SP", new DateTime(1964, 6, 7),DateTime.UtcNow.ToLocalTime()),
                new Customer(new Guid(), "Luisa", "luisa@ecommerce.com", "Rua 10, 1, 14003-001, Ribeirão Preto, SP", new DateTime(2014, 3, 14),DateTime.UtcNow.ToLocalTime()),
                new Customer(new Guid(), "Bruno", "bruno@ecommerce.com", "Rua 10, 1, 14001-006, Ribeirão Preto, SP", new DateTime(1989, 11, 6),DateTime.UtcNow.ToLocalTime()),
                new Customer(new Guid(), "Willian", "wilian@ecommerce.com", "Rua 68, 70, 14007-001, Ribeirão Preto, SP", new DateTime(1981, 6, 30),DateTime.UtcNow.ToLocalTime()),
                new Customer(new Guid(), "Alice", "alice@ecommerce.com", "Rua 54, 110, 14008-001, Ribeirão Preto, SP", new DateTime(2006, 4, 21),DateTime.UtcNow.ToLocalTime()),
            };
                if (!context.Customer.Any())
                {
                    customers.ForEach(e => context.Customer.AddAsync(e));
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }
    }
}
