namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: TokenApiConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class TokenApiConfiguration : IEntityTypeConfiguration<TokenApi>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<TokenApi> entity)
        {
            /// Tabla [TokenApi].[Security]

            entity.ToTable("TokenApi", "Security");

            entity.HasKey(e => e.IdTokenApi);

            entity.Property(e => e.Token)
                  .IsRequired()
                  .HasColumnType("nvarchar(max)");

            entity.Property(e => e.CreationDate)
                  .IsRequired();

            entity.Property(e => e.ExpirationDate)
                  .IsRequired();

            entity.Property(e => e.IdUser)
                  .IsRequired();

            entity.Property(e => e.IdStatus)
                  .IsRequired();
        }

        #endregion

    }
}