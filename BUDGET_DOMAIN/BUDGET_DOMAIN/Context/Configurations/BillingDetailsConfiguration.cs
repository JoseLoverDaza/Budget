namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BillingDetailsConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class BillingDetailsConfiguration : IEntityTypeConfiguration<BillingDetails>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<BillingDetails> entity)
        {
            /// Tabla [BillingDetails].[Budget]

            entity.ToTable("BillingDetails", "Budget");

            entity.HasKey(e => e.IdBillingDetails);

            entity.Property(e => e.IdBilling)
                 .IsRequired();

            entity.Property(e => e.Amount)
                  .HasColumnType("decimal(18,2)")
                  .IsRequired();

            entity.Property(e => e.IdExpense)
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