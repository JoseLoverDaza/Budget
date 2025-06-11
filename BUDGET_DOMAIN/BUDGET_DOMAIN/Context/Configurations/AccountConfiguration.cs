namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AccountConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class AccountConfiguration : IEntityTypeConfiguration<Account>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<Account> entity)
        {
            /// Tabla [Account].[Budget]

            entity.ToTable("Account", "Budget");

            entity.HasKey(e => e.IdAccount);

            entity.Property(e => e.NameAccount)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.DescriptionAccount)
                  .HasMaxLength(255);

            entity.Property(e => e.IdFinancialInstitution)
                  .IsRequired();

            entity.Property(e => e.IdTypeAccount)
                  .IsRequired();

            entity.Property(e => e.IdUserBudget)
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