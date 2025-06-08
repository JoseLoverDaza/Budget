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

        public string EmailUser { get; set; } = null!;
        public string UsernameUser { get; set; } = null!;
        public string NameStatus { get; set; } = null!;
        public string? DescriptionStatus { get; set; }

        #endregion

    }
}