using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Veiculo.Data.Mappings
{
    public class VeiculoMapping : IEntityTypeConfiguration<Domain.Veiculo>
    {
        public void Configure(EntityTypeBuilder<Domain.Veiculo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.IdCondutor)
               .IsRequired()
               .HasColumnName("IdCondutor")
               .HasColumnType("varchar(50)");

            builder.Property(c => c.CPFCondutor)
               .IsRequired()
               .HasColumnName("CPFCondutor")
               .HasColumnType("varchar(20)");

            builder.Property(c => c.Placa)
               .IsRequired()
               .HasColumnName("Placa")
               .HasColumnType("varchar(20)");

            builder.Property(c => c.Modelo)
               .IsRequired()
               .HasColumnName("Modelo")
               .HasColumnType("varchar(50)");

            builder.Property(c => c.Marca)
               .IsRequired()
               .HasColumnName("Marca")
               .HasColumnType("varchar(50)");

            builder.Property(c => c.Cor)
               .IsRequired()
               .HasColumnName("Cor")
               .HasColumnType("varchar(50)");

            builder.Property(c => c.AnoFabricacao)
               .IsRequired()
               .HasColumnName("AnoFabricacao")
               .HasColumnType("int");

            builder.ToTable("Veiculo");
        }
    }
}
