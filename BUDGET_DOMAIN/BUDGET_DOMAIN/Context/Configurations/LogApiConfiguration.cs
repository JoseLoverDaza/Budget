namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: LogConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class LogApiConfiguration : IEntityTypeConfiguration<LogApi>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<LogApi> entity)
        {
            /// Tabla [LogApi].[Security]

            entity.ToTable("LogApi", "Security");

            entity.HasKey(e => e.IdLogApi);

            entity.Property(e => e.IdLogApi)
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.Entity)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.PreviousValues)
                  .HasColumnType("nvarchar(max)");

            entity.Property(e => e.NewValues)
                  .HasColumnType("nvarchar(max)");

            entity.Property(e => e.EntityAction)
                  .HasMaxLength(20);

            entity.Property(e => e.CreationDate)
                  .IsRequired()
                  .HasColumnType("date");

            entity.Property(e => e.IdStatus)
                  .IsRequired();
        }

        #endregion

    }
}