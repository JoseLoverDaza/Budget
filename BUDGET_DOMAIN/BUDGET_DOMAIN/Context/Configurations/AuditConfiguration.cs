namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AuditConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class AuditConfiguration : IEntityTypeConfiguration<Audit>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<Audit> entity)
        {
            /// Tabla [Audit].[Security]

            entity.ToTable("Audit", "Security");

            entity.HasKey(e => e.IdAudit);

            entity.Property(e => e.Host)
                     .HasMaxLength(255);

            entity.Property(e => e.Endpoint)
                     .HasMaxLength(255);

            entity.Property(e => e.Agent)
                    .HasMaxLength(255);

            entity.Property(e => e.Method)
                    .HasMaxLength(255);

            entity.Property(e => e.CreationDate)
                  .IsRequired();

            entity.Property(e => e.IdStatus)
                  .IsRequired();
        }

        #endregion

    }
}