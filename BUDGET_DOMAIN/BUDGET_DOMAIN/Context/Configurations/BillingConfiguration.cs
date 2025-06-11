namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BillingConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class BillingConfiguration : IEntityTypeConfiguration<Billing>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<Billing> entity)
        {
            /// Tabla [Billing].[Budget]

            entity.ToTable("Billing", "Budget");

            entity.HasKey(e => e.IdBilling);

            entity.Property(e => e.YearBilling)
                  .IsRequired();

            entity.Property(e => e.MonthBilling)
                  .IsRequired();

            entity.Property(e => e.DescriptionBilling)
                  .HasMaxLength(255);

            entity.Property(e => e.ObservationBilling)
                  .HasMaxLength(255);

            entity.Property(e => e.IdUserBudget)
                  .IsRequired();

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