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
            entity.ToTable("Budget", "Budget");

            entity.HasKey(e => e.IdBudget);

            entity.Property(e => e.Year)
                  .IsRequired();

            entity.Property(e => e.Month)
                  .IsRequired();

            entity.Property(e => e.CreationDate)
                 .IsRequired();

            entity.Property(e => e.Description)
                   .HasMaxLength(255);

            entity.Property(e => e.Observation)
                  .HasMaxLength(255);

            entity.Property(e => e.IdUser)
                  .IsRequired();

            entity.Property(e => e.IdStatus)
                  .IsRequired();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Budget> entity);

        #endregion

    }
}