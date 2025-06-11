namespace CORE.Dto
{

    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: UserExtendDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class UserBudgetExtendDto : UserBudgetDto
    {

        #region Atributos y Propiedades

        public string NameRoleBudget { get; set; } = null!;
        public string? DescriptionRoleBudget { get; set; }

        public string NameStatusBudget { get; set; } = null!;
        public string? DescriptionStatusBudget { get; set; }

        #endregion

    }
}