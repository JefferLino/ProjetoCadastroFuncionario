using JL.Business.Models.Funcionarios;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JL.Data.Context
{
    public class CadastroFuncionarioContext : DbContext
    {
        public CadastroFuncionarioContext(DbContextOptions<CadastroFuncionarioContext> options) : base(options) { }


        public DbSet<Funcionario> Funcionarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastroFuncionarioContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
