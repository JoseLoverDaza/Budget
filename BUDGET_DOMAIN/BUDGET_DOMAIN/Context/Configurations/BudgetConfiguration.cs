namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BudgetConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class BudgetConfiguration : IEntityTypeConfiguration<Budget>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<Budget> entity)
        {
            /// Tabla [Budget].[Budget]

            entity.ToTable("Budget", "Budget");

            entity.HasKey(e => e.IdBudget);

            entity.Property(e => e.YearBudget)
                  .IsRequired();

            entity.Property(e => e.MonthBudget)
                  .IsRequired();

            entity.Property(e => e.DescriptionBudget)
                   .HasMaxLength(255);

            entity.Property(e => e.ObservationBudget)
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