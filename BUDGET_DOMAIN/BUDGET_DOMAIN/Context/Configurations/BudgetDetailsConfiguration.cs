namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BudgetDetailsConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class BudgetDetailsConfiguration : IEntityTypeConfiguration<BudgetDetails>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<BudgetDetails> entity)
        {
            /// Tabla [BudgetDetails].[Budget]

            entity.ToTable("BudgetDetails", "Budget");

            entity.HasKey(e => e.IdBudgetDetails);

            entity.Property(e => e.IdBudget)
                  .IsRequired();

            entity.Property(e => e.Amount)
                  .HasColumnType("decimal(18,2)")
                  .HasDefaultValue(0)
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