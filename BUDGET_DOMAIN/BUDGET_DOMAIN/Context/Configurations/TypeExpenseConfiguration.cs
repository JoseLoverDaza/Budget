namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TypeExpenseConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class TypeExpenseConfiguration : IEntityTypeConfiguration<TypeExpense>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<TypeExpense> entity)
        {
            /// Tabla [TypeExpense].[Budget]

            entity.ToTable("TypeExpense", "Budget");

            entity.HasKey(e => e.IdTypeExpense);

            entity.Property(e => e.NameTypeExpense)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.DescriptionTypeExpense)
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