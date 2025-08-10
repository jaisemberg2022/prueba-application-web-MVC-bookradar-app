using BookRadarApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRadarApp.Infraestructure.Config
{
    public class HistorialBusquedasConfiguration : IEntityTypeConfiguration<HistorialBusquedas>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<HistorialBusquedas> builder)
        {
            builder.ToTable("HistorialBusquedas");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Id)
                .ValueGeneratedOnAdd(); 

            builder.Property(h => h.Autor)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(h => h.Titulo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(h => h.AnioPublicacion)
                .IsRequired(); 

            builder.Property(h => h.Editorial)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(h => h.FechaConsulta)
                .IsRequired();

        }
    }
}
