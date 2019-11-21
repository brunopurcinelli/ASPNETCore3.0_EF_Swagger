using APIClientes.Models;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;

namespace APIClientes.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>(e=>
            {
                e.ToTable("Customer");
                e.HasKey(p => p.Id);
                e.Property(p => p.Name).HasMaxLength(150).IsRequired();
                e.Property(p => p.Email).HasMaxLength(250).IsRequired();
                e.Property(p => p.Address).HasMaxLength(1000);
                e.Property(p => p.Birthday);
                e.Property(p => p.CreatedDateTime).HasDefaultValue(DateTime.UtcNow.ToLocalTime());
            });
        }
    }
}
