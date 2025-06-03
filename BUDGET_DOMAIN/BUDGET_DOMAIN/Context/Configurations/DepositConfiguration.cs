namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: DepositConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class DepositConfiguration : IEntityTypeConfiguration<Deposit>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<Deposit> entity)
        {
            /// Tabla [Deposit].[Budget]
            
            entity.ToTable("Deposit", "Budget");

            entity.HasKey(e => e.IdDeposit);

            entity.Property(e => e.Year)
                  .IsRequired();

            entity.Property(e => e.Month)
                  .IsRequired();

            entity.Property(e => e.Amount)
                  .HasColumnType("decimal(18,2)")
                  .HasDefaultValue(0)
                  .IsRequired();

            entity.Property(e => e.IdUser).IsRequired();
            entity.Property(e => e.IdAccount).IsRequired();
            entity.Property(e => e.IdStatus).IsRequired();
        }

        #endregion

    }
}