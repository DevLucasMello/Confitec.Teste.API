using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Condutor.Data.Mappings
{
    public class CondutorMapping : IEntityTypeConfiguration<Domain.Condutor>
    {
        public void Configure(EntityTypeBuilder<Domain.Condutor> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Placa)
               .IsRequired()
               .HasColumnName("Placa")
               .HasColumnType("varchar(20)");

            builder.OwnsOne(c => c.Nome, n =>
            {
                n.Property(c => c.PrimeiroNome)
                .IsRequired()
                .HasColumnName("PrimeiroNome")
                .HasColumnType("varchar(50)");

                n.Property(c => c.UltimoNome)
                .IsRequired()
                .HasColumnName("UltimoNome")
                .HasColumnType("varchar(50)");
            });

            builder.Property(c => c.CPF)
                .IsRequired()
                .HasColumnName("CPF")
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasColumnName("Telefone")
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.CNH)
                .IsRequired()
                .HasColumnName("CNH")
                .HasColumnType("varchar(20)");

            builder.Property(c => c.DataNascimento)
                .IsRequired()
                .HasColumnName("DataNascimento")
                .HasColumnType("datetime");

            builder.ToTable("Condutor");
        }
    }
}
