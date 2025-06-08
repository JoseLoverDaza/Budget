namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: UserConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class UserConfiguration : IEntityTypeConfiguration<User>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<User> entity)
        {
            /// Tabla [User].[Security]

            entity.ToTable("User", "Security");

            entity.HasKey(e => e.IdUser);

            entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(e => e.Phone)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(e => e.Username)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.Password)
                  .IsRequired()
                  .HasMaxLength(255);

            entity.Property(e => e.IdRole).IsRequired();
            entity.Property(e => e.IdStatus).IsRequired();
        }
        
        #endregion

    }
}