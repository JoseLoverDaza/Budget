namespace CORE.Dto
{

    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: FinancialInstitutionExtendDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class FinancialInstitutionExtendDto : FinancialInstitutionDto
    {

        #region Atributos y Propiedades

        public string NameStatus { get; set; } = null!;
        public string? DescriptionStatus { get; set; }

        #endregion

    }
}