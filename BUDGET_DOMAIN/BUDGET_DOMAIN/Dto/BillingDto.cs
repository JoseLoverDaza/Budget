namespace Domain.Dto
{

    #region Librerias

    using Domain.Dto.Common;

    #endregion

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BillingDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BillingDto : BaseDto
    {

        #region Atributos y Propiedades

        public int IdBilling { get; set; }
        public short YearBilling { get; set; }
        public byte MonthBilling { get; set; }       
        public string? DescriptionBilling { get; set; }
        public string? ObservationBilling { get; set; }

        public int IdUserBudget { get; set; }

        public int IdStatusBudget { get; set; }

        #endregion

    }
}