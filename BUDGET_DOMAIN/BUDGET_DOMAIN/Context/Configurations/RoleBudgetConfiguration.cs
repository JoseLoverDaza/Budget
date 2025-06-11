namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: RoleBudgetConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class RoleBudgetConfiguration : IEntityTypeConfiguration<RoleBudget>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<RoleBudget> entity)
        {
            /// Tabla [RoleBudget].[SecurityBudget]

            entity.ToTable("RoleBudget", "SecurityBudget");

            entity.HasKey(e => e.IdRoleBudget);

            entity.Property(e => e.NameRole)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.DescriptionRole)
                  .HasMaxLength(255);

            entity.Property(e => e.IdStatusBudget)
                  .IsRequired();

            entity.Property(e => e.CreationUser)
                 .IsRequired();

            entity.Property(e => e.CreationDate)
                  .HasColumnType("datetime")
                  .IsRequired();

            entity.Property(e => e.ModificationUser)
                  .IsRequired(false);

            entity.Property(e => e.ModificationDate)
                  .HasColumnType("datetime")
                  .IsRequired(false);

        }

        #endregion

    }
}