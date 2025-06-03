namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TypeAccountConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class TypeAccountConfiguration : IEntityTypeConfiguration<TypeAccount>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<TypeAccount> entity)
        {
            /// Tabla [TypeAccount].[Budget]

            entity.ToTable("TypeAccount", "Budget");

            entity.HasKey(e => e.IdTypeAccount);

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