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
            entity.ToTable("TypeExpense", "Budget");

            entity.HasKey(e => e.IdTypeExpense);

            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.Description)
                  .HasMaxLength(255);

            entity.Property(e => e.IdStatus)
                  .IsRequired();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<TypeExpense> entity);

        #endregion

    }
}