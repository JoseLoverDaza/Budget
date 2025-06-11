namespace Domain.Entities
{

    /// <summary>
    /// Fecha: 01 de enero de 2026
    /// Nombre: BudgetDetails   
    /// Autor: Jose Lover Daza Rojas
    /// </summary>

    public class BudgetDetails : BaseEntity
    {

        #region Atributos y Propiedades

        public int IdBudgetDetails { get; set; }
        public int IdBudget { get; set; }       
        public decimal Amount { get; set; }

        public int IdExpense { get; set; }       

        public int IdStatusBudget { get; set; }
        
        #endregion

    }
}