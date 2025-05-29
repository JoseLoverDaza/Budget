namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: ExpenseConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<Expense> entity)
        {
            entity.ToTable("Expense", "Budget");

            entity.HasKey(e => e.IdExpense);

            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.Description)
                  .HasMaxLength(255);

            entity.Property(e => e.IdTypeExpense).IsRequired();
            entity.Property(e => e.IdStatus).IsRequired();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Expense> entity);

        #endregion

    }
}