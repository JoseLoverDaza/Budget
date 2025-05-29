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
            entity.ToTable("Account", "Budget");

            entity.HasKey(e => e.IdAccount);

            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.Description)
                  .HasMaxLength(255);

            entity.Property(e => e.IdFinancialInstitution).IsRequired();
            entity.Property(e => e.IdTypeAccount).IsRequired();
            entity.Property(e => e.IdUser).IsRequired();
            entity.Property(e => e.IdStatus).IsRequired();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Account> entity);

        #endregion

    }
}