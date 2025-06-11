namespace CORE.Dto
{

    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: DepositExtendDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class DepositExtendDto : DepositDto
    {

        #region Atributos y Propiedades

        public string EmailUserBudget { get; set; } = null!;
        public string UsernameUserBudget { get; set; } = null!;

        public string NameAccount { get; set; } = null!;
        public string? DescriptionAccount { get; set; }

        public string NameStatusBudget { get; set; } = null!;
        public string? DescriptionStatusBudget { get; set; }

        #endregion

    }
}