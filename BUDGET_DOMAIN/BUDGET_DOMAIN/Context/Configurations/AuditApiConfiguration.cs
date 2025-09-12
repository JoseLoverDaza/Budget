namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AuditApiConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class AuditApiConfiguration : IEntityTypeConfiguration<AuditApi>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<AuditApi> entity)
        {
            /// Tabla [AuditApi].[SecurityBudget]

            entity.ToTable("AuditApi", "SecurityBudget");

            entity.HasKey(e => e.IdAuditApi);

            entity.Property(e => e.Host)
                    .HasMaxLength(255);

            entity.Property(e => e.EndpointUrl)
                    .HasMaxLength(255);

            entity.Property(e => e.Agent)
                    .HasMaxLength(255);

            entity.Property(e => e.Method)
                    .HasMaxLength(255);

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