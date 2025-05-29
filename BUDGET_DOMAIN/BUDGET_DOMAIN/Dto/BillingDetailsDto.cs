namespace Domain.Dto
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BillingDetailsDto   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BillingDetailsDto
    {

        #region Atributos y Propiedades

        public int IdBillingDetails { get; set; }
        public int IdBilling { get; set; }
       
        public decimal Amount { get; set; }

        public int IdExpense { get; set; }
       
        public int IdStatus { get; set; }
        
        #endregion

    }
}