using Confitec.Core.Data;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Veiculo.Data
{
    public class VeiculoContext : DbContext, IUnitOfWork
    {
        public VeiculoContext(DbContextOptions<VeiculoContext> options)
            : base(options) { }

        public DbSet<Domain.Veiculo> Veiculos { get; set; }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            var sucesso = await base.SaveChangesAsync() > 0;

            return sucesso;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Ignore<ValidationResult>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VeiculoContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
