namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: StatusConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class StatusConfiguration : IEntityTypeConfiguration<Status>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<Status> entity) 
        {
            /// Tabla [Status].[Parameterization]

            entity.ToTable("Status", "Parameterization");

            entity.HasKey(e => e.IdStatus);

            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.Description)
                  .HasMaxLength(255);
        }

        #endregion

    }
}