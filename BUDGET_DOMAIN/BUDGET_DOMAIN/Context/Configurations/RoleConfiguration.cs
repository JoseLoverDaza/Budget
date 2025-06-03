namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: RoleConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class RoleConfiguration : IEntityTypeConfiguration<Role>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<Role> entity)
        {
            /// Tabla [Role].[Security]

            entity.ToTable("Role", "Security");

            entity.HasKey(e => e.IdRole);

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