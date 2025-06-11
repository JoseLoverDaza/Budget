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

            entity.Property(e => e.YearDeposit)
                  .IsRequired();

            entity.Property(e => e.MonthDeposit)
                  .IsRequired();

            entity.Property(e => e.Amount)
                  .HasColumnType("decimal(18,2)")
                  .HasDefaultValue(0)
                  .IsRequired();

            entity.Property(e => e.IdUserBudget)
                  .IsRequired();

            entity.Property(e => e.IdAccount)
                  .IsRequired();

            entity.Property(e => e.IdStatusBudget)
                  .IsRequired();

            entity.Property(e => e.CreationUser)
                  .IsRequired();

            entity.Property(e => e.CreationDate)
                  .HasColumnType("datetime")
                  .IsRequired();

            entity.Property(e => e.ModificationUser)
                  .IsRequired();

            entity.Property(e => e.ModificationDate)
                  .HasColumnType("datetime")
                  .IsRequired();

        }

        #endregion

    }
}