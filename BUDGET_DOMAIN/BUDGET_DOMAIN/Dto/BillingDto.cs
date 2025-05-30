namespace Domain.Dto
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BillingDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BillingDto
    {

        #region Atributos y Propiedades

        public int IdBilling { get; set; }
        public short Year { get; set; }
        public byte Month { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Description { get; set; }
        public string? Observation { get; set; }

        public int IdUser { get; set; }

        public int IdStatus { get; set; }

        #endregion

    }
}