using JL.Business.Models.Funcionarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JL.Data.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasIndex(e => e.NumeroChapa).IsUnique();

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Sobrenome)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.NumeroChapa)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Funcionarios");
        }
    }
}
