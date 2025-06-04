namespace CORE.Dto
{

    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: AccountExtendDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class AccountExtendDto : AccountDto
    {

        #region Atributos y Propiedades

        public string NameFinancialInstitution { get; set; } = null!;
        public string? DescriptionFinancialInstitution { get; set; }
        public string NameTypeAccount { get; set; } = null!;
        public string? DescriptionTypeAccount { get; set; }
        public string EmailUser { get; set; } = null!;
        public string LoginUser { get; set; } = null!;

        public string NameStatus { get; set; } = null!;
        public string? DescriptionStatus { get; set; }

        #endregion

    }
}