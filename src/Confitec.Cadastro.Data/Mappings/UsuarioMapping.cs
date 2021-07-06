using Confitec.Cadastro.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Cadastro.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.OwnsOne(u => u.Nome, n =>
            {
                n.Property(u => u.PrimeiroNome)
                .IsRequired()
                .HasColumnName("PrimeiroNome")
                .HasColumnType("varchar(50)");

                n.Property(u => u.UltimoNome)
                .IsRequired()
                .HasColumnName("UltimoNome")
                .HasColumnType("varchar(50)");
            });

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(100)");

            builder.Property(u => u.Senha)
                .IsRequired()
                .HasColumnName("Senha")
                .HasColumnType("varchar(30)");

            builder.ToTable("Usuario");
        }
    }
}
