namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: StatusBudgetConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class StatusBudgetConfiguration : IEntityTypeConfiguration<StatusBudget>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<StatusBudget> entity) 
        {
            /// Tabla [StatusBudget].[ParameterizationBudget]

            entity.ToTable("StatusBudget", "ParameterizationBudget");

            entity.HasKey(e => e.IdStatusBudget);

            entity.Property(e => e.NameStatus)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.DescriptionStatus)
                  .HasMaxLength(255);

        }

        #endregion

    }
}