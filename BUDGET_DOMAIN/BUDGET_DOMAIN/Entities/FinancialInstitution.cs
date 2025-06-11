namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: FinancialInstitution   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class FinancialInstitution : BaseEntity
    {

        #region Atributos y Propiedades

        public int IdFinancialInstitution { get; set; }
        public string NameFinancialInstitution { get; set; } = null!;
        public string? DescriptionFinancialInstitution { get; set; }

        public int IdStatusBudget { get; set; }
        
        #endregion

    }
}