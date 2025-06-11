namespace CORE.Dto
{

    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BillingExtendDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BillingExtendDto : BillingDto
    {

        #region Atributos y Propiedades

        public string EmailUserBudget { get; set; } = null!;
        public string UsernameUserBudget { get; set; } = null!;

        public string NameStatusBudget { get; set; } = null!;
        public string? DescriptionStatusBudget { get; set; }

        #endregion

    }
}