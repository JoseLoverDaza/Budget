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
            /// Tabla [Expense].[Budget]

            entity.ToTable("Expense", "Budget");

            entity.HasKey(e => e.IdExpense);

            entity.Property(e => e.NameExpense)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.DescriptionExpense)
                  .HasMaxLength(255);

            entity.Property(e => e.IdTypeExpense)
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