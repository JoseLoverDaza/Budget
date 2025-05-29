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
            entity.ToTable("Billing", "Budget");

            entity.HasKey(e => e.IdBilling);

            entity.Property(e => e.Year)
                  .IsRequired();

            entity.Property(e => e.Month)
                  .IsRequired();

            entity.Property(e => e.Observations)
                  .HasMaxLength(255);

            entity.Property(e => e.IdUser)
                  .IsRequired();

            entity.Property(e => e.IdStatus)
                  .IsRequired();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Billing> entity);

        #endregion

    }
}