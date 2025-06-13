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
            /// Tabla [LogApi].[SecurityBudget]

            entity.ToTable("LogApi", "SecurityBudget");

            entity.HasKey(e => e.IdLogApi);

            entity.Property(e => e.Entity)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.EntityAction)
                 .HasMaxLength(20);

            entity.Property(e => e.PreviousValues)
                  .HasColumnType("nvarchar(max)");

            entity.Property(e => e.NewValues)
                  .HasColumnType("nvarchar(max)");

            entity.Property(e => e.FilterValues)
                  .HasColumnType("nvarchar(max)");

            entity.Property(e => e.IdStatusBudget)
                  .IsRequired();

            entity.Property(e => e.CreationUser)
                   .IsRequired();

            entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .IsRequired();

            entity.Property(e => e.ModificationUser)
                    .IsRequired();

            entity.Property(e => e.ModificationDate)
                    .HasColumnType("datetime")
                    .IsRequired();

        }

        #endregion

    }
}