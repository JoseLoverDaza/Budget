namespace Domain.Context.Configurations
{

    #region Librerias

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: UserBudgetConfiguration   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public partial class UserBudgetConfiguration : IEntityTypeConfiguration<UserBudget>
    {

        #region Métodos y Funciones

        public void Configure(EntityTypeBuilder<UserBudget> entity)
        {
            /// Tabla [UserBudget].[SecurityBudget]

            entity.ToTable("UserBudget", "SecurityBudget");

            entity.HasKey(e => e.IdUserBudget);

            entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(e => e.Phone)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(e => e.Username)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.EncryptedPassword)
                  .IsRequired()
                  .HasMaxLength(255);

            entity.Property(e => e.IdRoleBudget).IsRequired();

            entity.Property(e => e.IdStatusBudget).IsRequired();

        }
        
        #endregion

    }
}