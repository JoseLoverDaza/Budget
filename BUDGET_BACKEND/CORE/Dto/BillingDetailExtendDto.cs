namespace CORE.Dto
{
    #region Librerias

    using Domain.Dto;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BillingDetailExtendDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BillingDetailExtendDto : BillingDetailsDto
    {

        #region Atributos y Propiedades

        public short YearBilling { get; set; }
        public byte MonthBilling { get; set; }
        public string NameExpense { get; set; } = null!;
        public string? DescriptionExpense { get; set; }
        public string NameStatus { get; set; } = null!;
        public string? DescriptionStatus { get; set; }

        #endregion

    }
}