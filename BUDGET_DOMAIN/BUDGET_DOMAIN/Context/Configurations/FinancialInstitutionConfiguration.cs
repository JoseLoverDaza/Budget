namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: FinancialInstitutionConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class FinancialInstitutionConfiguration : IEntityTypeConfiguration<FinancialInstitution>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<FinancialInstitution> entity)
        {
            /// Tabla [FinancialInstitution].[Budget]

            entity.ToTable("FinancialInstitution", "Budget");

            entity.HasKey(e => e.IdFinancialInstitution);

            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.Description)
                  .HasMaxLength(255);

            entity.Property(e => e.IdStatus)
                  .IsRequired();
        }

        #endregion

    }
}